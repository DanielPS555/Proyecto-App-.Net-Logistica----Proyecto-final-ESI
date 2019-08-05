Imports Operario

Public Interface IActualizaMessage
    Sub Actualizar()
End Interface

Public Class panelInfoVehiculo
    Implements IActualizaMessage


    Private vin As String
    Private lugar As DataRow
    Public Sub New(VIN As String, aqui As Boolean)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        If Not aqui Then
            Button1.Visible = False
            Button2.Visible = False
            Button3.Visible = False
            Button4.Visible = False
        Else
            LoteCombo.Enabled = True
        End If
        Me.vin = VIN
        TipoCombo.Items.Clear()
        TipoCombo.Items.AddRange([Enum].GetNames(GetType(Logica.TipoVehiculo)))
        RegularTamañoColumnas()
        TomarValores()
    End Sub

    Private Sub TomarValores()
        VINBox.Text = vin
        Dim vehiculo = Controladores.Fachada.getInstancia.InfoVehiculos(vin).SingleOrDefault
        If vehiculo Is Nothing Then
            MsgBox("No se encontró el vehículo con VIN " + vin + ", reporte este error")
            Close()
        End If
        MarcaBox.Text = vehiculo.Marca
        ModeloBox.Text = vehiculo.Modelo
        ClienteBox.Text = vehiculo.Cliente.Nombre
        AñoBox.Text = vehiculo.Año
        TipoCombo.SelectedItem = vehiculo.Tipo
        Panel1.BackColor = vehiculo.Color
        Dim ultpos = Controladores.Fachada.getInstancia.UltimaPosicionVehiculoEnLugar(vin, Controladores.Persistencia.getInstancia.TrabajaEn.Lugar.Nombre)
        SubzonaLabel.Text = ultpos.Item(1)
        Dim zona = Controladores.Persistencia.getInstancia.PadreDeLugar(ultpos.Item(0))
        ZonaLabel.Text = zona.Item(0)
        PosicionLabel.Text = ultpos.Item(2) & " desde " & CType(ultpos.Item(3), Date?).DarFormato
        lugar = Controladores.Persistencia.getInstancia.PadreDeLugar(zona.Item(1))
        lugarLabel.Text = lugar.Item(0)
        Dim lotes = Controladores.Fachada.getInstancia.LotesDisponiblesPorLugarActual.Select(Function(x) x.Nombre).ToArray
        LoteCombo.Items.AddRange(lotes)
        Dim loteVehiculo As String = Controladores.Fachada.getInstancia.LoteVehiculo(vin, lugar.Item(0)).Nombre
        For i = 0 To lotes.Count - 1
            If lotes(i) = loteVehiculo Then
                LoteCombo.SelectedIndex = i
            End If
        Next
        'informes.Columns.Clear()
        'informes.DataSource = Controladores.
        traslados.Columns.Clear()
        traslados.DataSource = Controladores.Persistencia.getInstancia.PosicionesDeVehiculoEnLugar(lugar.Item(0), vin)
        'dtlugares = New DataTable
        'dtlugares.Columns.Add("Nombre de Lugar", GetType(String))
        'dtlugares.Columns.Add("Fecha de llegada", GetType(String))
        'dtlugares.Columns.Add("Transportado por", GetType(String))
        'dtlugares.Columns.Add("Fecha de partida", GetType(String))
        'VRepo.Lugares(dtlugares, vin)
        'lugares.Columns.Clear()
        'lugares.DataSource = dtlugares
    End Sub

    Private dtlugares As DataTable
    Public Sub RegularTamañoColumnas()
        informes.Columns(0).Width = 60
        informes.Columns(1).Width = 200
        informes.Columns(2).Width = 200
        informes.Columns(3).Width = 150
        informes.Columns(4).Width = 150
        informes.Columns(5).Width = 60
        Me.Height = 3000

        traslados.Columns(0).Width = 200
        traslados.Columns(1).Width = 200
        traslados.Columns(2).Width = 175
        traslados.Columns(3).Width = 175
        traslados.Columns(4).Width = 175
        traslados.Columns(5).Width = 225

        lugares.Columns(0).Width = 170
        lugares.Columns(1).Width = 170
        lugares.Columns(2).Width = 170
        lugares.Columns(3).Width = 170
        lugares.Columns(4).Width = 170
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim permitido = False
        If permitido Then
            ModeloBox.Enabled = Not ModeloBox.Enabled
            MarcaBox.Enabled = Not MarcaBox.Enabled
            AñoBox.Enabled = Not AñoBox.Enabled
            TipoCombo.Enabled = Not TipoCombo.Enabled
            LoteCombo.Enabled = Not LoteCombo.Enabled
            Button3.Visible = Not Button3.Visible
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim tInterno = New trasladoInterno(vin, Me)
        tInterno.ShowDialog()
    End Sub

    Private Sub informes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles informes.CellDoubleClick
        'Marco.getInstancia.cargarPanel(Of crearInformaDeDaños)(New crearInformaDeDaños(DirectCast(informes.Rows()(e.RowIndex).Cells()(0).Value, Integer)))
    End Sub

    Private _changedTB2 As Boolean = False
    Private _changedTB3 As Boolean = False
    Private _changedTB4 As Boolean = False
    Private _changedTB5 As Boolean = False
    Private _changedCB1 As Boolean = False



    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles MarcaBox.TextChanged
        _changedTB2 = True
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles ModeloBox.TextChanged
        _changedTB3 = True
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles ClienteBox.TextChanged
        _changedTB4 = True
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles AñoBox.TextChanged
        If AñoBox.Text.Where(Function(x) x >= "0" And x <= "9").Count <> AñoBox.Text.Count Then
            AñoBox.ForeColor = Color.Red
        Else
            AñoBox.ForeColor = Color.Black
            _changedTB5 = True
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TipoCombo.SelectedIndexChanged
        _changedCB1 = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Marco.getInstancia.cargarPanel(New crearInformaDeDaños(vin))
    End Sub

    Private Sub LoteCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LoteCombo.SelectedIndexChanged
        If Controladores.Fachada.getInstancia.InfoLote(Nombre:=LoteCombo.SelectedItem).Estado = Controladores.Lote.TIPO_ESTADO_ABIERTO Then
            If Not Controladores.Fachada.getInstancia.AsignarLote(vin, LoteCombo.SelectedItem) Then ' FALTA IMPLEMENTACIÓN
                MsgBox("No se pudo asignar el lote por alguna razón. ACTUALMENTE SIN IMPLEMENTAR")
            End If
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        'Dim nl = New NuevoLote(Me)
        'Marco.getInstancia.cargarPanel(nl)
    End Sub

    Public Sub Actualizar() Implements IActualizaMessage.Actualizar
        traslados.Columns.Clear()
        traslados.DataSource = Controladores.Persistencia.getInstancia.PosicionesDeVehiculoEnLugar(lugar.Item(0), vin)
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Marco.getInstancia.cargarPanel(New PanelInfoLote(LoteCombo.Text))
    End Sub
End Class
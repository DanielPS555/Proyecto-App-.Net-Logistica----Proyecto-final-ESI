Imports Operario



Public Class panelInfoVehiculo


    Private informesElementos As New List(Of Controladores.InformeDeDaños)
    Private vin As String
    Private lugar As DataRow
    Private actualInfore As Integer = 0
    Private actualRegistro As Integer = 0
    Private actualImagen As Integer = 0
    Public Sub New(VIN As String, aqui As Boolean)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        If Not aqui Then
            Button2.Visible = False
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

        traslados.Columns.Clear()
        traslados.DataSource = Controladores.Persistencia.getInstancia.PosicionesDeVehiculoEnLugar(lugar.Item(0), vin)
        informesElementos = Controladores.Fachada.getInstancia.devolverTodosLosInformesYregistrosCompletos(vehiculo)
        cargarInformesYRegistros()
    End Sub

    Public Sub cargarInformesYRegistros()
        Dim info As Controladores.InformeDeDaños = informesElementos(actualInfore)

        numeroInforme.Text = info.ID
        NomCreador.Text = info.Creador.Nombre
        fechaCreacionInforme.Text = info.Fecha
        descrip_Informe.Text = info.Descripcion
        If info.Registros.Count > 0 Then
            visualizarElementosRegistro(True)
            Dim reg As Controladores.RegistroDaños = informesElementos(actualInfore).Registros(actualRegistro)
            numRegistro.Text = reg.ID
            descrip_registro.Text = reg.Descripcion
        Else
            visualizarElementosRegistro(False)
        End If



    End Sub

    Private Sub visualizarElementosRegistro(j As Boolean)
        sinregistros.Visible = Not j
        Label17.Visible = j
        numRegistro.Visible = j
        Label19.Visible = j
        idregistropadre.Visible = j
        idinformepadre.Visible = j
        Label20.Visible = j
        Label18.Visible = j
        tipoRegistro.Visible = j
        verReferencia.Visible = j
        anteriorRegistro.Visible = j
        AnteriorImagen.Visible = j
        SigienteRegistro.Visible = j
        SigienteImagen.Visible = j
        Label21.Visible = j
        descrip_registro.Visible = j
        imagen.Visible = j
        modificar.Visible = j
    End Sub

    Private dtlugares As DataTable
    Public Sub RegularTamañoColumnas()

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

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim permitido = False
        If permitido Then
            ModeloBox.Enabled = Not ModeloBox.Enabled
            MarcaBox.Enabled = Not MarcaBox.Enabled
            AñoBox.Enabled = Not AñoBox.Enabled
            TipoCombo.Enabled = Not TipoCombo.Enabled
            LoteCombo.Enabled = Not LoteCombo.Enabled
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Dim tInterno = New trasladoInterno(vin, Me)
        'tInterno.ShowDialog()
    End Sub

    Private Sub informes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
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

    Private Sub Button3_Click(sender As Object, e As EventArgs)
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

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Marco.getInstancia.cargarPanel(New PanelInfoLote(LoteCombo.Text))
    End Sub


End Class
Imports Operario

Public Interface IActualizaMessage
    Sub Actualizar()
End Interface

Public Class panelInfoVehiculo
    Implements IActualizaMessage
    Private vin As String
    Public Sub New(VIN As String, aqui As Boolean)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        If Not aqui Then
            Button1.Visible = False
            'Button2.Visible = False
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
        MarcaBox.Text = VRepo.Marca(vin)
        ModeloBox.Text = VRepo.Modelo(vin)
        ClienteBox.Text = VRepo.Cliente(vin)
        AñoBox.Text = VRepo.Año(vin)
        TipoCombo.SelectedItem = VRepo.Tipo(vin)
        Panel1.BackColor = VRepo.Color(vin)
        ZonaLabel.Text = VRepo.Zona(vin)
        SubzonaLabel.Text = VRepo.Subzona(vin)
        Dim pos = VRepo.Posicion(vin).GetValueOrDefault
        PosicionLabel.Text = pos
        lugar.Text = VRepo.Lugar(vin)
        LoteCombo.Items.AddRange(LRepo.LotesEnLugar(VRepo.Lugar(vin)).ToArray)
        LoteCombo.SelectedItem = VRepo.Lote(vin)
        informes.Columns.Clear()
        informes.DataSource = VRepo.Inspecciones(vin)
        traslados.Columns.Clear()
        traslados.DataSource = VRepo.PosicionesEn(vin, URepo.ConectadoEn)
        dtlugares = New DataTable
        dtlugares.Columns.Add("Nombre de Lugar", GetType(String))
        dtlugares.Columns.Add("Fecha de llegada", GetType(String))
        dtlugares.Columns.Add("Transportado por", GetType(String))
        dtlugares.Columns.Add("Fecha de partida", GetType(String))
        VRepo.Lugares(dtlugares, vin)
        lugares.Columns.Clear()
        lugares.DataSource = dtlugares
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
        Dim permitido = (URepo.RolDeUsuario() = "Administrador")
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

    Private Sub informes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        Marco.getInstancia.cargarPanel(Of crearInformaDeDaños)(New crearInformaDeDaños(DirectCast(informes.Rows()(e.RowIndex).Cells()(0).Value, Integer)))
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
        If _changedTB2 Then
            _changedTB2 = False
            VRepo.Marca(vin, MarcaBox.Text)
        End If
        If _changedTB3 Then
            _changedTB3 = False
            VRepo.Modelo(vin, ModeloBox.Text)
        End If
        If _changedTB5 And AñoBox.ForeColor = Color.Black Then
            _changedTB5 = False
            VRepo.Año(vin, AñoBox.Text)
        End If
        If _changedTB4 Then
            _changedTB4 = False
            VRepo.Cliente(vin, ClienteBox.Text)
        End If
        If _changedCB1 Then
            _changedCB1 = False
            VRepo.Tipo(vin, TipoCombo.SelectedItem)
        End If
        Button1_Click(sender, e)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Marco.getInstancia.cargarPanel(New crearInformaDeDaños(vin))
    End Sub

    Private Sub LoteCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LoteCombo.SelectedIndexChanged
        If LRepo.LoteAbierto(LoteCombo.SelectedItem) Then
            VRepo.Lote(vin, LoteCombo.SelectedItem)
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim nl = New NuevoLote(Me)
        Marco.getInstancia.cargarPanel(nl)
    End Sub

    Public Sub Actualizar() Implements IActualizaMessage.Actualizar
        traslados.Columns.Clear()
        traslados.DataSource = VRepo.PosicionesEn(vin, URepo.ConectadoEn)
    End Sub
End Class
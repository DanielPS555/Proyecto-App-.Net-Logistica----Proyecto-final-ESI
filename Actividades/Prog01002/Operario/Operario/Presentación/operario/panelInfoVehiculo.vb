Public Class panelInfoVehiculo
    Private vin As String
    Public Sub New(VIN As String)
        ' Esta llamada es exigida por el diseñador.
        Me.vin = VIN
        InitializeComponent()
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
        PosicionLabel.Text = VRepo.Posicion(vin)
        LoteCombo.Items.AddRange(LRepo.LotesEnLugar(VRepo.Lugar(vin)).ToArray)
        LoteCombo.SelectedItem = VRepo.Lote(vin)
        informes.Columns.Clear()
        informes.DataSource = VRepo.Inspecciones(vin)
        traslados.Columns.Clear()
        traslados.DataSource = VRepo.PosicionesEn(vin, URepo.ConectadoEn)
    End Sub

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

    Private Sub panelInfoVehiculo_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint, TabPage1.Paint
        Dim g As Graphics = e.Graphics
        g.DrawRectangle(New Pen(Color.FromArgb(15, 139, 196), 2), New Rectangle(informes.Location, informes.Size))
        For Each textCo In Me.Controls
            If TypeOf (textCo) Is TextBox Then
                Dim text As TextBox = DirectCast(textCo, TextBox)
                g.DrawLine(New Pen(Color.FromArgb(35, 35, 35)), text.Location.X, text.Location.Y + text.Height, text.Location.X + text.Size.Width, text.Location.Y + text.Height)
            End If
        Next
    End Sub

    Private Sub ingresar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim permitido = (URepo.RolDeUsuario() = "Administrador")
        If permitido Then
            ModeloBox.Enabled = Not ModeloBox.Enabled
            MarcaBox.Enabled = Not MarcaBox.Enabled
        End If
        permitido = permitido OrElse URepo.CreadorDe(vin)
        If permitido Then
            AñoBox.Enabled = Not AñoBox.Enabled
            TipoCombo.Enabled = Not TipoCombo.Enabled
        End If
        LoteCombo.Enabled = Not LoteCombo.Enabled
        Button3.Visible = Not Button3.Visible
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MarcoPuerto.getInstancia.cargarPanel(Of trasladoInterno)(New trasladoInterno(""))
    End Sub

    Private Sub informes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles informes.CellDoubleClick
        MarcoPuerto.getInstancia.cargarPanel(Of crearInformaDeDaños)(New crearInformaDeDaños(informes.Rows()(e.RowIndex).Cells()(0).Value))
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
End Class
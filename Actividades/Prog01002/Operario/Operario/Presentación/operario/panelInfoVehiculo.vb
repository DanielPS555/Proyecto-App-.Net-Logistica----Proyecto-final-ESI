Public Class panelInfoVehiculo
    Private vin As String
    Public Sub New(VIN As String)
        ' Esta llamada es exigida por el diseñador.
        Me.vin = VIN
        InitializeComponent()
        ComboBox1.Items.Clear()
        ComboBox1.Items.AddRange([Enum].GetNames(GetType(Logica.TipoVehiculo)))
        RegularTamañoColumnas()
        TomarValores()
    End Sub

    Private Sub TomarValores()
        TextBox1.Text = vin
        TextBox2.Text = VRepo.Marca(vin)
        TextBox3.Text = VRepo.Modelo(vin)
        TextBox4.Text = VRepo.Cliente(vin)
        TextBox5.Text = VRepo.Año(vin)
        ComboBox1.SelectedItem = VRepo.Tipo(vin)
        Panel1.BackColor = VRepo.Color(vin)
        Label20.Text = VRepo.Zona(vin)
        Label21.Text = VRepo.Subzona(vin)
        Label22.Text = VRepo.Posicion(vin)
        Label23.Text = VRepo.Lote(vin)
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

        lugares.Columns(0).Width = 225
        lugares.Columns(1).Width = 225
        lugares.Columns(2).Width = 225
        lugares.Columns(3).Width = 225
        lugares.Columns(4).Width = 225
        lugares.Columns(5).Width = 225

    End Sub

    Private Sub panelInfoVehiculo_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics
        g.DrawRectangle(New Pen(Color.FromArgb(15, 139, 196), 2), New Rectangle(informes.Location, informes.Size))
    End Sub

    Private Sub ingresar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox2.Enabled = Not TextBox2.Enabled
        TextBox3.Enabled = Not TextBox3.Enabled
        TextBox4.Enabled = Not TextBox4.Enabled
        TextBox5.Enabled = Not TextBox5.Enabled
        ComboBox1.Enabled = Not ComboBox1.Enabled
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

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        _changedTB2 = True
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        _changedTB3 = True
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        _changedTB4 = True
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        If TextBox5.Text.Where(Function(x) x >= "0" And x <= "9").Count <> TextBox5.Text.Count Then
            TextBox5.ForeColor = Color.Red
        Else
            TextBox5.ForeColor = Color.Black
            _changedTB5 = True
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        _changedCB1 = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If _changedTB2 Then
            _changedTB2 = False
            VRepo.Marca(vin, TextBox2.Text)
        End If
        If _changedTB3 Then
            _changedTB3 = False
            VRepo.Modelo(vin, TextBox3.Text)
        End If
        If _changedTB5 And TextBox5.ForeColor = Color.Black Then
            _changedTB5 = False
            VRepo.Año(vin, TextBox5.Text)
        End If
        If _changedTB4 Then
            _changedTB4 = False
            VRepo.Cliente(vin, TextBox4.Text)
        End If
        If _changedCB1 Then
            _changedCB1 = False
            VRepo.Tipo(vin, ComboBox1.SelectedItem)
        End If
        Button1_Click(sender, e)
    End Sub
End Class
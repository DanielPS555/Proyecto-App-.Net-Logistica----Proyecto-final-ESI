Public Class panelInfoVehiculo
    Private vin As String
    Public Sub New(VIN As String)
        ' Esta llamada es exigida por el diseñador.
        Me.vin = VIN
        InitializeComponent()
        regularTamañoColumnas()
        tomarValores()
    End Sub

    Private Sub tomarValores()
        Label14.Text = vin
        Label15.Text = VRepo.Marca(vin)
        Label16.Text = VRepo.Modelo(vin)
        Label17.Text = VRepo.Cliente(vin)
        Label18.Text = VRepo.Año(vin)
        Label19.Text = VRepo.Tipo(vin)
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

    Public Sub regularTamañoColumnas()
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
        ' nos lleva a la ventana nuevovehiculo pero ya con la infocargada 
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MarcoPuerto.getInstancia.cargarPanel(Of trasladoInterno)(New trasladoInterno)
    End Sub

    Private Sub informes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles informes.CellDoubleClick
        MarcoPuerto.getInstancia.cargarPanel(Of crearInformaDeDaños)(New crearInformaDeDaños(informes.Rows()(e.RowIndex).Cells()(0).Value))
    End Sub
End Class
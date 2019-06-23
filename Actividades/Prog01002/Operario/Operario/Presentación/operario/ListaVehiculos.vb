Public Class ListaVehiculos

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        CargarDatos(DataGridView1.Columns)
        DataGridView1.MultiSelect = False

    End Sub

    Dim t As DataTable

    Public Sub CargarDatos(columns As DataGridViewColumnCollection)
        Dim dt As New DataTable("Vehiculos")
        For Each col As DataGridViewColumn In columns
            dt.Columns.Add(col.Name, GetType(String))
        Next
        dt = URepo.ListaVehiculos(dt,
                                  Function(x) If(buscador.Text.Trim.Count = 0,
                                  True,
                                  DirectCast(x(criterios.Text), String).StartsWith(buscador.Text)))
        DataGridView1.Columns.Clear()
        DataGridView1.DataSource = dt
        DataGridView1.Columns()("VehiculoTipo").HeaderText = "Tipo"
        DataGridView1.Update()
    End Sub

    Private Sub ListaVehiculos_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim g As Graphics = e.Graphics
        g.DrawRectangle(New Pen(Color.FromArgb(35, 35, 35), 2), New Rectangle(criterios.Location, criterios.Size)) 'para dibujarle un rectangulo al combobox
    End Sub

    Private Sub nuevo_Click(sender As Object, e As EventArgs)
        Marco.getInstancia.cargarPanel(Of nuevoVehiculo)(New nuevoVehiculo)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim row = DataGridView1.Rows()(e.RowIndex)
        Marco.getInstancia.cargarPanel(New panelInfoVehiculo(row.Cells(1).Value, "Fuera del lugar" <> row.Cells(0).Value)).Show()
    End Sub

    Private Sub buscar_Click(sender As Object, e As EventArgs)
        CargarDatos(DataGridView1.Columns)
    End Sub
End Class


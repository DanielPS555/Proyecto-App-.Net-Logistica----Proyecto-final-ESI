Public Class ListaVehiculos

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        CargarDatos()
        DataGridView1.MultiSelect = False

    End Sub

    Public Sub CargarDatos()
        Dim dt As New DataTable("Vehiculos")
        Dim List = DirectCast(DataGridView1.Columns, IList)
        For i1 = 0 To list.Count - 1
            Dim i As DataGridViewColumn = DirectCast(list(i1), DataGridViewColumn)
            dt.Columns.Add(i.Name)
        Next
        dt = URepo.ListaVehiculos(dt)
        DataGridView1.Columns.Clear()
        DataGridView1.DataSource = dt
        DataGridView1.Columns()("VehiculoTipo").HeaderText = "Tipo"
    End Sub


    Private Sub ListaVehiculos_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim g As Graphics = e.Graphics
        g.DrawRectangle(New Pen(Color.FromArgb(35, 35, 35), 2), New Rectangle(criterios.Location, criterios.Size)) 'para dibujarle un rectangulo al combobox
    End Sub

    Private Sub nuevo_Click(sender As Object, e As EventArgs)
        MarcoPuerto.getInstancia.cargarPanel(Of nuevoVehiculo)(New nuevoVehiculo)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        For Each i As DataGridViewRow In DataGridView1.SelectedRows
            MarcoPuerto.getInstancia.cargarPanel(Of panelInfoVehiculo)(New panelInfoVehiculo(i.Cells(1).Value))
        Next
    End Sub
End Class


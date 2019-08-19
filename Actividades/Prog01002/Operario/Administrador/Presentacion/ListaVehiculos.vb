Imports Controladores.Fachada
Public Class ListaVehiculos
    Private tipolista As Boolean = True
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        asignados()
        DataGridView1.MultiSelect = False
        criterios.SelectedIndex = 0
        tiposListas.SelectedIndex = 0
    End Sub

    Dim t As DataTable

    Public Sub asignados()
        DataGridView1.DataSource = Controladores.Fachada.getInstancia.ListaVehiculos()
    End Sub

    Public Sub Noasignados()
        DataGridView1.DataSource = Controladores.Fachada.getInstancia.listaDeVehiculosSinLoteNiPosicion(Controladores.Fachada.getInstancia.TrabajaEnAcutual.Lugar.IDLugar)
    End Sub

    Private Sub ListaVehiculos_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim g As Graphics = e.Graphics
        g.DrawRectangle(New Pen(Color.FromArgb(35, 35, 35), 2), New Rectangle(criterios.Location, criterios.Size)) 'para dibujarle un rectangulo al combobox
    End Sub

    Private Sub nuevo_Click(sender As Object, e As EventArgs)
        Marco.getInstancia.cargarPanel(Of nuevoVehiculo)(New nuevoVehiculo)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If tipolista Then
            Dim row = DataGridView1.Rows()(e.RowIndex)
            Marco.getInstancia.cargarPanel(New panelInfoVehiculo(row.Cells(1).Value, "Fuera del lugar" <> row.Cells(6).Value)).Show()
        Else
            Dim eleme As New Asignacion(DataGridView1.Rows(e.RowIndex).Cells(1).Value)
            eleme.ShowDialog()
        End If

    End Sub

    Private Sub buscar_Click(sender As Object, e As EventArgs)
        'CargarDatos(DataGridView1.Columns)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Noasignados()
        tipolista = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        asignados()
        tipolista = True
    End Sub

    Private Sub tiposListas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tiposListas.SelectedIndexChanged

    End Sub
End Class


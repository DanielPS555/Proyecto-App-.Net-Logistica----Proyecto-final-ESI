Public Class ListarLugares
    Private lugaresTabla As DataTable
    Public Sub New()


        InitializeComponent()
        cargarDatos()

    End Sub

    Private Sub cargarDatos()
        lugaresTabla = Controladores.Fachada.getInstancia.listarTodosLosLugares
        lugares.DataSource = lugaresTabla
    End Sub

    Private Sub Lugares_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles lugares.CellDoubleClick
        Marco.getInstancia.cargarPanel(Of PanelLugar)(New PanelLugar(lugaresTabla.Rows(e.RowIndex).Item(0)))

    End Sub


End Class
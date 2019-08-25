Public Class ListarUsuario

    Private Usuariostabla As DataTable
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        carardatos()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub carardatos()
        Usuariostabla = Controladores.Fachada.getInstancia.todosLosUsuarios
        usuarios.DataSource = Usuariostabla
    End Sub

    Private Sub Usuarios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles usuarios.CellDoubleClick
        Marco.getInstancia.cargarPanel(Of PanelInfoUsuario)(New PanelInfoUsuario(Usuariostabla.Rows(e.RowIndex).Item(0)))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Marco.getInstancia.cargarPanel(Of NuevoUsuario)(New NuevoUsuario)
    End Sub
End Class
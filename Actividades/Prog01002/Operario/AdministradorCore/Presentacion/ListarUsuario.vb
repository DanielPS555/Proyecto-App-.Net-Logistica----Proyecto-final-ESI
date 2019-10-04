Imports System.Windows.Forms
Public Class ListarUsuario
    Dim alfa As Controladores.Alfa
    Private Usuariostabla As DataTable
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        alfa = New Controladores.Alfa(GetType(Controladores.Usuario), GetType(Controladores.SUB_Usuario)) With {
            .Location = New Drawing.Point(13, 86),
            .Size = New Drawing.Size(853, 548)
        }
        Me.Controls.Add(alfa)
        Me.Update()
        carardatos()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub carardatos()
        Usuariostabla = Controladores.Fachada.getInstancia.TodosLosUsuariosTabla
        For Each user As DataRow In Usuariostabla.Rows
            Dim elemento As New Controladores.Usuario With {.ID_usuario = user.Item(0), .NombreDeUsuario = user.Item(1), .Rol = user.Item(4)}
            alfa.Nuevo(elemento, False)
        Next
        alfa.render()
        'usuarios.DataSource = Usuariostabla
    End Sub

    Private Sub Usuarios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) 
        Controladores.Marco.getInstancia.CargarPanel(Of PanelInfoUsuario)(New PanelInfoUsuario(Usuariostabla.Rows(e.RowIndex).Item(0)))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Controladores.Marco.getInstancia.CargarPanel(Of NuevoUsuario)(New NuevoUsuario)
    End Sub
End Class
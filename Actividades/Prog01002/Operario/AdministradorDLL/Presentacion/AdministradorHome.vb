Imports Controladores
Public Class AdministradorHome
    Public Sub New() 'me tiene que pasar un objeto de tipo usuario


        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Fachada.getInstancia.CargarDataBaseDelUsuario()
        Dim data As Usuario = Fachada.getInstancia.DevolverUsuarioActual
        NombreCompleto.Text = data.Nombre + " " + data.Apellido
        nombreUsuario.Text = data.NombreDeUsuario
        rolUsuario.Text = data.Rol
        'Dim numA As Integer = Fachada.getInstancia.TrabajaEnAcutual.Conexiones.Count
        'nAccesos.Text = numA
        'If numA = 0 Then
        '    anteriorIngreso.Text = "Nunca"
        'Else
        '    anteriorIngreso.Text = Funciones_comunes.DarFormato(Fachada.getInstancia.TrabajaEnAcutual.ultimaConexcion.Item1)
        'End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox("¡Sin implementar!")
    End Sub
End Class
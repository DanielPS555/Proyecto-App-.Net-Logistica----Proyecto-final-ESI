Public Class SUB_Usuario
    Private user As Usuario
    Private padre As Alfa

    Public Sub New(usuario As Usuario, padre As Alfa)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        nom.Text = usuario.NombreDeUsuario
        Select Case usuario.Rol
            Case Usuario.TIPO_ROL_ADMINISTRADOR
                rol.Text = "Administrativo"
            Case Usuario.TIPO_ROL_OPERARIO
                rol.Text = "Operario"
            Case Usuario.TIPO_ROL_TRANSPORTISTA
                rol.Text = "Transportista"
        End Select
        user = usuario
        ancho = padre.tamaño.Width
        Me.padre = padre
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Property ancho() As Integer
        Get
            Return Me.Width
        End Get
        Set(ByVal value As Integer)
            Me.Width = value
        End Set
    End Property

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        padre.devolver(user)
    End Sub

    Public Function tostring() As String
        Return user.NombreDeUsuario
    End Function

End Class
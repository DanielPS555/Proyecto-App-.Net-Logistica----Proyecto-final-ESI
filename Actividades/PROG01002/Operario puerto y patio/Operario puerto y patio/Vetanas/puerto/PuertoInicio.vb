Imports Operario_puerto_y_patio.Data

Public Class PuertoInicio
    Implements IHandlesUsers
    Private _usuario As User
    Public Lugar As String
    Public Property Usuario As User Implements IHandlesUsers.Usuario
        Get
            Return _usuario
        End Get
        Set(value As User)
            _usuario = value
            Label7.Text = _usuario.Nombre
            Label6.Text = User.StringFromRol(_usuario.Rol)
            Label2.Text = $"{_usuario.primernombre} {_usuario.primerapellido}"
        End Set
    End Property
    Private Sub PuertoInicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
End Class
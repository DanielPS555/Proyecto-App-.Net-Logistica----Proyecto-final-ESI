Public Interface UsuarioRepositorio
    Function UsuarioPorID(id As Integer) As Boolean
    Function UsuarioPorNombre(nombre As String) As Boolean
    Function Sincronizar() As Boolean

    Function Login(username As String, password As String) As Boolean
    Function Restablecer(respuesta As String, newpass As String) As Boolean
    Function Registrar(username As String, password As String, primer_nombre As String, segundo_nombre As String, primer_apellido As String, segundo_apellido As String)

End Interface
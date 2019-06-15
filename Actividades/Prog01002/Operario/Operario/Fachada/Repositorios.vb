Public Interface UsuarioRepositorio
    Function UsuarioPorID(id As Integer) As Logica.Usuario
    Function UsuarioPorNombre(nombre As String) As Logica.Usuario
    Function Sincronizar() As Task(Of Boolean)
End Interface
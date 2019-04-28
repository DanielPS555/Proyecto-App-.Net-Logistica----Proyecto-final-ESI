Public Interface ILogin
    Function UserLogin(uname As String, pwd As String) As User
End Interface

Public Class User
    Public Sub New(Name As String, Password As String, Role As Type)
        Nombre = Name
        Contra = Password
        Rol = Role
    End Sub
    Public Enum Type
        OperadorPuerto = 0
        OperadorPlaza = 1
    End Enum
    Public Nombre As String
    Public Contra As String
    Public Rol As Type
End Class
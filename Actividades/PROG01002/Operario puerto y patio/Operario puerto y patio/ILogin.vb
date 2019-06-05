Imports Operario_puerto_y_patio

Public Interface ILogin
    Function UserLogin(uname As String, pwd As String) As User
    Function UserRegister(user As User, pregunta As String, respuesta As String) As Boolean
End Interface

Public Class User
    Public Enum Type
        OperadorPuerto = 0
        OperadorPlaza
        Transportista
        Administrador
    End Enum
    Public Shared Function StringFromRol(rol As Type) As String
        Dim strings As String = {"OpTrans", "OpPatio", "OpPuerto", "Admin"}.Where(Function(x) rol.Equals(RolFromString(x)))(0)
        Return strings
    End Function
    Public Shared Function RolFromString(rol As String) As Type
        Select Case rol
            Case "OpTrans"
                Return Type.Transportista
            Case "OpPatio"
                Return Type.OperadorPlaza
            Case "OpPuerto"
                Return Type.OperadorPuerto
            Case "Admin"
                Return Type.Administrador
            Case Else
                Return Nothing
        End Select
    End Function
    Public Nombre As String
    Public Contra As String
    Public Rol As Type
    Public email As String
    Public fechanac As Date
    Public telefono As String
    Public primernombre As String
    Public segundonombre As String
    Public primerapellido As String
    Public segundoapellido As String
    Public sexo As Char

    Public Sub New(nombre As String, contra As String, rol As Type, email As String, fechanac As Date, telefono As String, primernombre As String, segundonombre As String, primerapellido As String, segundoapellido As String, sexo As Char)
        Me.Nombre = nombre
        Me.Contra = contra
        Me.Rol = rol
        Me.email = email
        Me.fechanac = fechanac
        Me.telefono = telefono
        Me.primernombre = primernombre
        Me.segundonombre = segundonombre
        Me.primerapellido = primerapellido
        Me.segundoapellido = segundoapellido
        Me.sexo = sexo
    End Sub
End Class
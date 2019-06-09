Imports Operario_puerto_y_patio

Public Class Data

    Public Shared Sub HandleAlphaNum(sender As Object, e As KeyPressEventArgs)
        If (e.KeyChar >= "0" AndAlso e.KeyChar <= "9") OrElse Char.IsControl(e.KeyChar) OrElse (Char.ToLower(e.KeyChar) >= "a" AndAlso Char.ToLower(e.KeyChar) <= "z") Then ' los VIN utilizan números y letras mayúsculas
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Public Shared Sub HandleNum(sender As Object, e As KeyPressEventArgs)
        If (e.KeyChar >= "0" AndAlso e.KeyChar <= "9") OrElse Char.IsControl(e.KeyChar) Then ' el año sólo pueden ser números
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Shared _login As ILogin = Nothing
    Public Shared Property Login As ILogin
        Get
            If IsNothing(_login) Then
                _login = New ODBCLogin
                Principal.getInstancia.lobutton.Enabled = True
            End If
            Return _login
        End Get
        Set(value As ILogin)
            _login = value
        End Set
    End Property

    Public Class Vehiculo
        Public VIN As String
        Public marca As String
        Public modelo As String
        Public comprador As String
        Public color As Color
        Public año As Integer
        Public tipo As String
        Public fuerasistema As Boolean
        Public usuarioIngresa As User
        Public lugar As Integer




        Public Sub New(vIN As String, marca As String, modelo As String, comprador As String, color As Color, año As Integer, tipo As String, fuerasistema As Boolean, usuarioIngresa As User, lugar As Integer)
            Me.VIN = vIN
            Me.marca = marca
            Me.modelo = modelo
            Me.comprador = comprador
            Me.color = color
            Me.año = año
            Me.tipo = tipo
            Me.fuerasistema = fuerasistema
            Me.usuarioIngresa = usuarioIngresa
            Me.lugar = lugar
        End Sub
    End Class

    Public Class User
        Public lugaractual As Integer = -1
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
End Class

Namespace Logica
    Public Class Usuario
        Private _username As String
        Public ReadOnly Property UserName As String
            Get
                Return _username
            End Get
        End Property

        Private _password_hash As String
        Public Function VerificarContraseña(password As String) As Boolean

        End Function

        Private _primer_nombre As String
        Public ReadOnly Property PrimerNombre As String
            Get
                Return _primer_nombre
            End Get
        End Property

        Private _segundo_nombre As String
        Public ReadOnly Property SegundoNombre As String
            Get
                Return _segundo_nombre
            End Get
        End Property

        Private _primer_apellido As String
        Public ReadOnly Property PrimerApellido As String
            Get
                Return _primer_apellido
            End Get
        End Property

        Private _segundo_apellido As String
        Public ReadOnly Property SegundoApellido As String
            Get
                Return _segundo_apellido
            End Get
        End Property

        Private _pregunta_secreta As String
        Private _respuesta_secreta As String

        Public ReadOnly Property PreguntaSecreta As String
            Get
                Return _pregunta_secreta
            End Get
        End Property

        Public Function VerificarPregunta(pregunta As String) As Boolean

        End Function

        Private _fecha_nacimiento As Date
        Public ReadOnly Property FechaNacimiento As Date
            Get
                Return _fecha_nacimiento
            End Get
        End Property

        Private _sexo As Char
        Public ReadOnly Property Sexo As Char
            Get
                Return _sexo
            End Get
        End Property

        Private _email As String
        Public ReadOnly Property Email As String
            Get
                Return _email
            End Get
        End Property

        Private _telefono As String
        Public ReadOnly Property Telefono As String
            Get
                Return _telefono
            End Get
        End Property

        Private _rol As Role
        Public ReadOnly Property Rol As Role
            Get
                Return _rol
            End Get
        End Property
    End Class
    Public Class Role
        Public ReadOnly Nombre As String
    End Class
End Namespace
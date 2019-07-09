Imports Controladores

Public Class Usuario

    Enum Roles
        Administrador
        Operario
        Transportista
    End Enum

    Private _ID_usuario As Integer
    Public Property ID_usuario() As Integer
        Get
            Return _ID_usuario
        End Get
        Set(ByVal value As Integer)
            If value >= 0 Then
                ID_usuario = value
            Else
                Throw New Exception("El id no puede ser negativo")
            End If
        End Set
    End Property

    Private _rol As String
    Public Property Rol() As String
        Get
            Return _rol
        End Get
        Set(ByVal value As String)
            If value = Roles.Administrador Or value = Roles.Transportista Or value = Roles.Operario Then
                _rol = value
            Else
                Throw New Exception("Rol incorrecto, mire los posibles en el enum 'Roles'")
            End If

        End Set
    End Property

    Private _sexo As Char
    Public Property sexo() As Char
        Get
            Return _sexo
        End Get
        Set(ByVal value As Char)
            _sexo = value
        End Set
    End Property

    Private _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _email As String
    Public Property Email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property

    Private _fechaNac As DateTime
    Public Property FechaNacimiento() As DateTime
        Get
            Return _fechaNac
        End Get
        Set(ByVal value As DateTime)
            _fechaNac = value
        End Set
    End Property

    Private _preguntaSecreta As String
    Public Property PreguntaSecreta() As String
        Get
            Return _preguntaSecreta
        End Get
        Set(ByVal value As String)
            _preguntaSecreta = value
        End Set
    End Property

    Private _respuestaSecreeta As String
    Public Property RespuestaSecreta() As String
        Get
            Return _respuestaSecreeta
        End Get
        Set(ByVal value As String)
            _respuestaSecreeta = value
        End Set
    End Property

    Private _linkRastreador As String
    Public Property LinkRastreador() As String
        Get
            Return _linkRastreador
        End Get
        Set(ByVal value As String)
            _linkRastreador = value
        End Set
    End Property

    Private _camiones As List(Of Tuple(Of Tuple(Of DateTime?, DateTime?), Camion))
    Public Property Camiones() As List(Of Tuple(Of Tuple(Of DateTime?, DateTime?), Camion))
        Get
            Return _camiones
        End Get
        Set(ByVal value As List(Of Tuple(Of Tuple(Of DateTime?, DateTime?), Camion)))
            _camiones = value
        End Set
    End Property

    Public Overrides Function Equals(obj As Object) As Boolean
        Dim usuario = TryCast(obj, Usuario)
        Return usuario IsNot Nothing AndAlso
               ID_usuario = usuario.ID_usuario
    End Function


End Class

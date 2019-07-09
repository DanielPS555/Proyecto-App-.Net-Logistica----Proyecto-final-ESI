Public Class Usuario
    Private _ID_usuario As Integer
    Public Property ID_usuario() As Integer
        Get
            Return _ID_usuario
        End Get
        Set(ByVal value As Integer)
            _ID_usuario = value
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


End Class

Public Class Lugar
    Private _IDlugar As Integer
    Public Property IDLugar() As Integer
        Get
            Return _IDlugar
        End Get
        Set(ByVal value As Integer)
            _IDlugar = value
        End Set
    End Property

    Private _capasidad As Integer
    Public Property Capasidad() As Integer
        Get
            Return _capasidad
        End Get
        Set(ByVal value As Integer)
            _capasidad = value
        End Set
    End Property

    Private _posicionX As Double
    Public Property PosicionX() As Double
        Get
            Return _posicionX
        End Get
        Set(ByVal value As Double)
            _posicionX = value
        End Set
    End Property

    Private _posicionY As Double
    Public Property PosicionY() As Double
        Get
            Return _posicionY
        End Get
        Set(ByVal value As Double)
            _posicionY = value
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

    Private _tipo As String
    Public Property Tipo() As String
        Get
            Return _tipo
        End Get
        Set(ByVal value As String)
            _tipo = value
        End Set
    End Property

    Private _zonas As List(Of Zona)
    Public Property Zonas() As List(Of Zona)
        Get
            Return _zonas
        End Get
        Set(ByVal value As List(Of Zona))
            _zonas = value
        End Set
    End Property

    Private _creador As Usuario
    Public Property Creador() As Usuario
        Get
            Return _creador
        End Get
        Set(ByVal value As Usuario)
            _creador = value
        End Set
    End Property
End Class

Imports Controladores

Public Class Lugar

    Public Shared ReadOnly TIPO_LUGAR_PATIO As String = "Patio"
    Public Shared ReadOnly TIPO_LUGAR_PUERTO As String = "Puerto"
    Public Shared ReadOnly TIPO_LUGAR_ESTABLECIMIENTO As String = "Establecimiento"
    Public Shared ReadOnly TIPO_LUGAR_ESTACION As String = "Estacion"

    Public Shared ReadOnly Property TIPOS_LUGARES() As String()
        Get
            Return {TIPO_LUGAR_PATIO, TIPO_LUGAR_PUERTO, TIPO_LUGAR_ESTABLECIMIENTO, TIPO_LUGAR_ESTACION}
        End Get
    End Property

    Public Function Distancia(x As Lugar) As Double
        Dim d_x = Math.Abs(x.PosicionX - Me.PosicionX)
        Dim d_y = Math.Abs(x.PosicionY - Me.PosicionY)
        Return Math.Sqrt((d_x * d_x) + (d_y * d_y))
    End Function

    Public ReadOnly Property Posicion As PointF
        Get
            Return New PointF(PosicionX, PosicionY)
        End Get
    End Property

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
            If TIPOS_LUGARES.Contains(value) Then

            End If
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

    Private _Dueño As Cliente
    Public Property Dueño() As Cliente
        Get
            Return _Dueño
        End Get
        Set(ByVal value As Cliente)
            _Dueño = value
        End Set
    End Property

    Private _ListaAutorizada As List(Of TipoMedioTransporte)
    Public Property TiposDeMediosDeTrasporteHabilitados() As List(Of TipoMedioTransporte)
        Get
            Return _ListaAutorizada
        End Get
        Set(ByVal value As List(Of TipoMedioTransporte))
            _ListaAutorizada = value
        End Set
    End Property

    Public Sub New(iDLugar As Integer, capasidad As Integer, posicionX As Double, posicionY As Double, nombre As String, tipo As String, creador As Usuario)
        Me.IDLugar = iDLugar
        Me.Capasidad = capasidad
        Me.PosicionX = posicionX
        Me.PosicionY = posicionY
        Me.Nombre = nombre
        Me.Tipo = tipo
        Me.Creador = creador
        Me.Zonas = New List(Of Zona)
    End Sub

    Public Sub New()
        Me.Zonas = New List(Of Zona)
    End Sub
End Class

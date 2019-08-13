Imports Controladores

Public Class MedioDeTransporte

    Private _id As String
    Public Property ID() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property

    Private _Nombre As String
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property

    Private _Tipo As TipoMedioTransporte
    Public Property Tipo() As TipoMedioTransporte
        Get
            Return _Tipo
        End Get
        Set(ByVal value As TipoMedioTransporte)
            _Tipo = value
        End Set
    End Property

    Private _Creadpr As Usuario
    Public Property Creador() As Usuario
        Get
            Return _Creadpr
        End Get
        Set(ByVal value As Usuario)
            _Creadpr = value
        End Set
    End Property

    Private _cantAutos As Integer
    Public Property CantAutos() As Integer
        Get
            Return _cantAutos
        End Get
        Set(ByVal value As Integer)
            _cantAutos = value
        End Set
    End Property

    Private _cantVAN As Integer
    Public Property CantVAN() As Integer
        Get
            Return _cantVAN
        End Get
        Set(ByVal value As Integer)
            _cantVAN = value
        End Set
    End Property

    Private _cantMiniVan As Integer
    Public Property CantMiniVan() As Integer
        Get
            Return _cantMiniVan
        End Get
        Set(ByVal value As Integer)
            _cantMiniVan = value
        End Set
    End Property

    Private _cantSUV As Integer
    Public Property CantSUV() As Integer
        Get
            Return _cantSUV
        End Get
        Set(ByVal value As Integer)
            _cantSUV = value
        End Set
    End Property

    Private _cantCamiones As Integer
    Public Property CantCamiones() As Integer
        Get
            Return _cantCamiones
        End Get
        Set(ByVal value As Integer)
            _cantCamiones = value
        End Set
    End Property

    Private _conductores As List(Of Usuario)
    Public Property Conductores() As List(Of Usuario)
        Get
            Return _conductores
        End Get
        Set(ByVal value As List(Of Usuario))
            _conductores = value
        End Set
    End Property

    Private _fecha As DateTime
    Public Property FechaCreacion() As DateTime
        Get
            Return _fecha
        End Get
        Set(ByVal value As DateTime)
            _fecha = value
        End Set
    End Property

    Public Sub New()
        _conductores = New List(Of Usuario)
    End Sub

    Public Sub New(iD As String, nombre As String, tipo As TipoMedioTransporte, creador As Usuario, cantAutos As Integer, cantVAN As Integer, cantMiniVan As Integer, cantSUV As Integer, cantCamiones As Integer)
        Me.ID = iD
        Me.Nombre = nombre
        Me.Tipo = tipo
        Me.Creador = creador
        Me.CantAutos = cantAutos
        Me.CantVAN = cantVAN
        Me.CantMiniVan = cantMiniVan
        Me.CantSUV = cantSUV
        Me.CantCamiones = cantCamiones
    End Sub
End Class

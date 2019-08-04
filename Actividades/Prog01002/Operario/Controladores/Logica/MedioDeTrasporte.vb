Imports Controladores

Public Class MedioDeTrasporte

    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
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

    Private _Tipo As TipoMedioTrasporte
    Public Property Tipo() As TipoMedioTrasporte
        Get
            Return _Tipo
        End Get
        Set(ByVal value As TipoMedioTrasporte)
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

    Public Sub New()

    End Sub

    Public Sub New(iD As Integer, nombre As String, tipo As TipoMedioTrasporte, creador As Usuario, cantAutos As Integer, cantVAN As Integer, cantMiniVan As Integer, cantSUV As Integer, cantCamiones As Integer)
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

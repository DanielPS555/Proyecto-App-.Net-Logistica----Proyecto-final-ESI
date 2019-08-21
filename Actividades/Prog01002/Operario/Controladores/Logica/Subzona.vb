Imports Controladores

Public Class Subzona


    Private _idSubzona As Integer
    Public Property IDSubzona() As Integer
        Get
            Return _idSubzona
        End Get
        Set(ByVal value As Integer)
            _idSubzona = value
        End Set
    End Property

    Private _capacidad As Integer
    Public Property Capasidad() As Integer
        Get
            Return _capacidad
        End Get
        Set(ByVal value As Integer)
            _capacidad = value
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

    Private _zonaPadre As Zona
    Public Property ZonaPadre() As Zona
        Get
            Return _zonaPadre
        End Get
        Set(ByVal value As Zona)
            _zonaPadre = value
        End Set
    End Property

    Public Sub New(iDSubzona As Integer, capasidad As Integer, nombre As String, zonaPadre As Zona)
        Me.IDSubzona = iDSubzona
        Me.Capasidad = capasidad
        Me.Nombre = nombre
        Me.ZonaPadre = zonaPadre
    End Sub
    Public Sub New()

    End Sub

    Public Overrides Function ToString() As String
        Return Nombre
    End Function

    Public Sub New(zonaPadre As Zona)
        Me.ZonaPadre = zonaPadre
    End Sub
End Class

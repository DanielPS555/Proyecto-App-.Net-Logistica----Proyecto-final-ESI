Public Class Subzona
    Public Sub New(padre As Zona)
        Me.ZonaPadre = padre
    End Sub

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
End Class

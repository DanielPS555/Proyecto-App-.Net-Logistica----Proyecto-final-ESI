Imports Controladores

Public Class Zona

    Public Sub New(Padre As Lugar)
        Me.LugarPadre = Padre
    End Sub

    Public Sub New(iDZona As Integer, nombre As String, capacidad As Integer, lugarPadre As Lugar)
        Me.IDZona = iDZona
        Me.Nombre = nombre
        Me.Capacidad = capacidad
        Me.LugarPadre = lugarPadre
        Me.Subzonas = New List(Of Subzona)
    End Sub

    Public Sub New()
        Me.Subzonas = New List(Of Subzona)
    End Sub



    Private _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _capasidad As Integer
    Public Property Capacidad() As Integer
        Get
            Return _capasidad
        End Get
        Set(ByVal value As Integer)
            _capasidad = value
        End Set
    End Property

    Private _idZona As Integer
    Public Property IDZona() As Integer
        Get
            Return _idZona
        End Get
        Set(ByVal value As Integer)
            _idZona = value
        End Set
    End Property

    Private _subzona As List(Of Subzona)
    Public Property Subzonas() As List(Of Subzona)
        Get
            Return _subzona
        End Get
        Set(ByVal value As List(Of Subzona))
            _subzona = value
        End Set
    End Property

    Private _lugarPadre As Lugar

    Public Property LugarPadre() As Lugar
        Get
            Return _lugarPadre
        End Get
        Set(ByVal value As Lugar)
            _lugarPadre = value
        End Set
    End Property

End Class

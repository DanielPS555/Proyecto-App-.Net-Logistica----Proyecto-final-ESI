Imports Controladores

Public Class TrabajaEn

    Private _usuario As Usuario
    Public Property Usuario() As Usuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As Usuario)
            _usuario = value
        End Set
    End Property

    Private _lugar As Lugar
    Public Property Lugar() As Lugar
        Get
            Return _lugar
        End Get
        Set(ByVal value As Lugar)
            _lugar = value
        End Set
    End Property

    Private _fechaI As DateTime
    Public Property FechaInicio() As DateTime
        Get
            Return _fechaI
        End Get
        Set(ByVal value As DateTime)
            _fechaI = value
        End Set
    End Property

    Private _fechaF As DateTime
    Public Property FechaFinalizacion() As DateTime
        Get
            Return _fechaF
        End Get
        Set(ByVal value As DateTime)
            _fechaF = value
        End Set
    End Property

    Private _conex As List(Of Tuple(Of DateTime, DateTime?))

    Public Sub New(usuario As Usuario, lugar As Lugar, fechaInicio As Date, fechaFinalizacion As Date)
        Me.Usuario = usuario
        Me.Lugar = lugar
        Me.FechaInicio = fechaInicio
        Me.FechaFinalizacion = fechaFinalizacion
        Me.Conexiones = New List(Of Tuple(Of Date, Date?))
    End Sub

    Public Property Conexiones() As List(Of Tuple(Of DateTime, DateTime?))
        Get
            Return _conex
        End Get
        Set(ByVal value As List(Of Tuple(Of DateTime, DateTime?)))
            _conex = value
        End Set
    End Property

End Class

Imports System.Net.Mime.MediaTypeNames

Public Class RegistroDaños
    Public Sub New()

    End Sub

    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _descripcion As String
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Private _Actualiza As RegistroDaños
    Public Property Actualiza() As RegistroDaños
        Get
            Return _Actualiza
        End Get
        Set(ByVal value As RegistroDaños)
            _Actualiza = value
        End Set
    End Property

    Private _TipoActualizacion As String
    Public Property TipoActualizacion() As String
        Get
            Return _TipoActualizacion
        End Get
        Set(ByVal value As String)
            _TipoActualizacion = value
        End Set
    End Property

    Private _inforPadre As InformeDeDaños
    Public Property InformePadre() As InformeDeDaños
        Get
            Return _inforPadre
            Dim i As Drawing.Image
        End Get
        Set(ByVal value As InformeDeDaños)
            _inforPadre = value
        End Set
    End Property

    Private _imagenes As List(Of )
    Public Property NewProperty() As List(Of Image)
        Get
            Return _imagenes
        End Get
        Set(ByVal value As List(Of Image))
            _imagenes = value
        End Set
    End Property
End Class

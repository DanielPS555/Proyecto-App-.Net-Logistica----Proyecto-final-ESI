Public Class InformeDeDaños
    Public Sub New()

    End Sub

    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            If value >= 0 Then
                _id = value
            Else
                Throw New Exception("El id no puede ser negativo")
            End If

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

    Private _fecha As DateTime
    Public Property Fecha() As DateTime
        Get
            Return _fecha
        End Get
        Set(ByVal value As DateTime)
            _fecha = value
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

    Private _registros As List(Of RegistroDaños)
    Public Property NewProperty() As List(Of RegistroDaños)
        Get
            Return _registros
        End Get
        Set(ByVal value As List(Of RegistroDaños))
            _registros = value
        End Set
    End Property
End Class

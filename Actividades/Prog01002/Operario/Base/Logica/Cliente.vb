Public Class Cliente
    Private _IDCliente As Integer
    Public Property IDCliente() As Integer
        Get
            Return _IDCliente
        End Get
        Set(ByVal value As Integer)
            _IDCliente = value
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

    Private _Capacidad As Integer
    Public Property Capacidad() As Integer
        Get
            Return _Capacidad
        End Get
        Set(ByVal value As Integer)
            _Capacidad = value
        End Set
    End Property

    Private _fechaRegistro As DateTime
    Public Property FechaRegistro() As DateTime
        Get
            Return _fechaRegistro
        End Get
        Set(ByVal value As DateTime)
            _fechaRegistro = value
        End Set
    End Property

    Private _lugares As List(Of Lugar)
    Public Property Lugares() As List(Of Lugar)
        Get
            Return _lugares
        End Get
        Set(ByVal value As List(Of Lugar))
            _lugares = value
        End Set
    End Property
End Class

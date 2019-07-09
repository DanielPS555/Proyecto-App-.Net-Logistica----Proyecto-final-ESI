Public Class Vehiculo

    Public Sub New()

    End Sub

    Public Sub New(VIN As String, marca As String, modelo As String, año As Integer, tipo As String, color As Drawing.Color, Cliente As Cliente)
        Me.VIN = VIN
        Me.Marca = marca
        Me.Modelo = modelo
        Me.Año = año
        Me.Tipo = tipo
        Me.Color = color
        Me.Cliente = Cliente
    End Sub

    Public Sub New(VIN As String, marca As String, modelo As String, año As Integer, tipo As String, color As Drawing.Color, Cliente As Cliente, arribaEn As Lugar)
        Me.VIN = VIN
        Me.Marca = marca
        Me.Modelo = modelo
        Me.Año = año
        Me.Tipo = tipo
        Me.Color = color
        Me.Cliente = Cliente
        Me.ArribaEn = arribaEn
    End Sub

    Public Sub New(VIN As String, marca As String, modelo As String, año As Integer, tipo As String, color As Drawing.Color, Cliente As Cliente, arribaEn As Lugar, info As List(Of InformeDeDaños))
        Me.VIN = VIN
        Me.Marca = marca
        Me.Modelo = modelo
        Me.Año = año
        Me.Tipo = tipo
        Me.Color = color
        Me.Cliente = Cliente
        Me.ArribaEn = arribaEn
        Me.Informes = info
    End Sub

    Private _año As Integer
    Public Property Año() As Integer
        Get
            Return _año
        End Get
        Set(ByVal value As Integer)
            _año = value
        End Set
    End Property

    Private _marca As String
    Public Property Marca() As String
        Get
            Return _marca
        End Get
        Set(ByVal value As String)
            _marca = value
        End Set
    End Property

    Private _color As Drawing.Color
    Public Property Color() As Drawing.Color
        Get
            Return _color
        End Get
        Set(ByVal value As Drawing.Color)
            _color = value
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

    Private _modelo As String
    Public Property Modelo() As String
        Get
            Return _modelo
        End Get
        Set(ByVal value As String)
            _modelo = value
        End Set
    End Property

    Private _VIN As String
    Public Property VIN() As String
        Get
            Return _VIN
        End Get
        Set(ByVal value As String)
            _VIN = value
        End Set
    End Property

    Private _Cliente As Cliente
    Public Property Cliente() As Cliente
        Get
            Return _Cliente
        End Get
        Set(ByVal value As Cliente)
            _Cliente = value
        End Set
    End Property

    Private _Informes As List(Of InformeDeDaños)
    Public Property Informes() As List(Of InformeDeDaños)
        Get
            Return _Informes
        End Get
        Set(ByVal value As List(Of InformeDeDaños))
            _Informes = value
        End Set
    End Property

    Private _arribaEn As Lugar
    Public Property ArribaEn() As Lugar
        Get
            Return _arribaEn
        End Get
        Set(ByVal value As Lugar)
            _arribaEn = value
        End Set
    End Property
End Class

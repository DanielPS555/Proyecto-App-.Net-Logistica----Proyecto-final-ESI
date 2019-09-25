Public Class Vehiculo

    Public Shared ReadOnly TIPO_VEHICULO_AUTO As String = "Auto"
    Public Shared ReadOnly TIPO_VEHICULO_MINIVAN As String = "MiniVan"
    Public Shared ReadOnly TIPO_VEHICULO_SUV As String = "SUV"
    Public Shared ReadOnly TIPO_VEHICULO_CAMION As String = "Camion"
    Public Shared ReadOnly TIPO_VEHICULO_VAN As String = "Van"

    Public Shared ReadOnly Property TIPOS_VEHICULOS() As String()
        Get
            Return {TIPO_VEHICULO_AUTO, TIPO_VEHICULO_MINIVAN, TIPO_VEHICULO_SUV, TIPO_VEHICULO_CAMION, TIPO_VEHICULO_VAN}
        End Get
    End Property

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
        Me.Informes = New List(Of InformeDeDaños)
    End Sub

    Public Overrides Function ToString() As String
        Return VIN.ToString
    End Function

    Public Sub New(VIN As String, marca As String, modelo As String, año As Integer, tipo As String, color As Drawing.Color, Cliente As Cliente, info As List(Of InformeDeDaños))
        Me.VIN = VIN
        Me.Marca = marca
        Me.Modelo = modelo
        Me.Año = año
        Me.Tipo = tipo
        Me.Color = color
        Me.Cliente = Cliente
        Me.Informes = info
    End Sub

    Private _año As Integer? = Nothing
    Public Property Año() As Integer
        Get
            Return If(_año, 0)
        End Get
        Set(ByVal value As Integer)
            If value >= 1900 AndAlso value <= 10000 Then
                _año = value
            ElseIf value = 0 Then
                _año = Nothing
            Else
                Throw New Exception("Valor del año invalido")
            End If
        End Set
    End Property



    Private _idVehiculo As Integer
    Public Property IdVehiculo() As Integer
        Get
            Return _idVehiculo
        End Get
        Set(ByVal value As Integer)
            _idVehiculo = value
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
            If TIPOS_VEHICULOS.Contains(value) Then
                _tipo = value
            End If
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

    Private _Cliente As Cliente = Nothing
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

    Public ReadOnly Property AñoNullable As Integer?
        Get
            Return _año
        End Get
    End Property
End Class

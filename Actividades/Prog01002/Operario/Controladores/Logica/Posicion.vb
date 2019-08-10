Imports Controladores

Public Class Posicion

    Private _posicion As Integer
    Public Property Posicion() As Integer
        Get
            Return _posicion
        End Get
        Set(ByVal value As Integer)
            _posicion = value
        End Set
    End Property

    Private _subzona As Subzona
    Public Property Subzona() As Subzona
        Get
            Return _subzona
        End Get
        Set(ByVal value As Subzona)
            _subzona = value
        End Set
    End Property

    Private _ingresadoPor As Usuario
    Public Property IngresadoPor() As Usuario
        Get
            Return _ingresadoPor
        End Get
        Set(ByVal value As Usuario)

            _ingresadoPor = value


        End Set
    End Property

    Private _desde As DateTime
    Public Property Desde() As DateTime
        Get
            Return _desde
        End Get
        Set(ByVal value As DateTime)
            _desde = value
        End Set
    End Property

    Private _hasta As DateTime

    Public Sub New(posicion As Integer, subzona As Subzona, ingresadoPor As Usuario, desde As Date, hasta As Date)
        Me.Posicion = posicion
        Me.Subzona = subzona
        Me.IngresadoPor = ingresadoPor
        Me.Desde = desde
        Me.Hasta = hasta
    End Sub

    Public Sub New()

    End Sub

    Public Property Hasta() As DateTime
        Get
            Return _hasta
        End Get
        Set(ByVal value As DateTime)

            _hasta = value


        End Set
    End Property

    Private _vehiculo As Vehiculo
    Public Property Vehiculo() As Vehiculo
        Get
            Return _vehiculo
        End Get
        Set(ByVal value As Vehiculo)
            _vehiculo = value
        End Set
    End Property


End Class

Imports Controladores

Public Class Ingreso

    Enum TiposIngresos
        Precarga
        Alta
        Baja
    End Enum

    Public Sub New(tipoIngreso As String, fecha As Date, vehiculo As Vehiculo, usuario As Usuario)
        Me.TipoIngreso = tipoIngreso
        Me.Fecha = fecha
        Me.Vehiculo = vehiculo
        Me.Usuario = usuario
    End Sub

    Private _tipoIngreso As String
    Public Property TipoIngreso() As String
        Get
            Return _tipoIngreso
        End Get
        Set(ByVal value As String)
            If DirectCast([Enum].GetValues(GetType(TiposIngresos)), String()).Contains(value) Then
                _tipoIngreso = value
            Else
                Throw New Exception("El tipo de ingreso no es correcto, verifique los valores del enum TiposIngresos")
            End If
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

    Private _vehiculo As Vehiculo
    Public Property Vehiculo() As Vehiculo
        Get
            Return _vehiculo
        End Get
        Set(ByVal value As Vehiculo)
            _vehiculo = value
        End Set
    End Property

    Private _usuario As Usuario
    Public Property Usuario() As Usuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As Usuario)
            If value.Rol <> value.roles.Transportista Then
                _usuario = value
            End If
        End Set
    End Property
End Class

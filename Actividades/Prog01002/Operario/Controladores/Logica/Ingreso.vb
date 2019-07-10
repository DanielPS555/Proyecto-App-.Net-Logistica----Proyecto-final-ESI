Imports Controladores

Public Class Ingreso

    Public Shared ReadOnly TIPO_INGRESO_PRECARGA As String = "Precarga"
    Public Shared ReadOnly TIPO_INGRESO_ALTA As String = "Alta"
    Public Shared ReadOnly TIPO_INGRESO_BAJA As String = "Baja"

    Public Shared ReadOnly Property TIPOS_INGRESOS() As String()
        Get
            Return {TIPO_INGRESO_PRECARGA, TIPO_INGRESO_ALTA, TIPO_INGRESO_BAJA}
        End Get
    End Property

    Public Sub New(tipoIngreso As String, fecha As Date, vehiculo As Vehiculo, usuario As Usuario)
        Me.TipoIngreso = tipoIngreso
        Me.Fecha = fecha
        Me.Vehiculo = vehiculo
        Me.Usuario = usuario
    End Sub

    Public Sub New()

    End Sub

    Private _tipoIngreso As String
    Public Property TipoIngreso() As String
        Get
            Return _tipoIngreso
        End Get
        Set(ByVal value As String)
            If TIPOS_INGRESOS.Contains(value) Then
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
            If value.Rol <> Usuario.TIPO_ROL_TRANSPORTISTA Then
                _usuario = value
            End If
        End Set
    End Property
End Class

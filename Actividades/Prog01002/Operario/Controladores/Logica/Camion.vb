Public Class Camion
    Private _VIN As String
    Public Property VIN() As String
        Get
            Return _VIN
        End Get
        Set(ByVal value As String)
            _VIN = value
        End Set
    End Property

    Private _color As Drawing.Color
    Public Property color() As Drawing.Color
        Get
            Return _color
        End Get
        Set(ByVal value As Drawing.Color)
            _color = value
        End Set
    End Property

    Private _matricula As String
    Public Property Matricula() As String
        Get
            Return _matricula
        End Get
        Set(ByVal value As String)
            _matricula = value
        End Set
    End Property

    Private _conductores As List(Of Usuario)
    Public Property Conductores() As List(Of Usuario)
        Get
            Return _conductores
        End Get
        Set(ByVal value As List(Of Usuario))
            _conductores = value
        End Set
    End Property

    Private _cantCamion As List(Of Integer)
    Public Property CantCamiones() As List(Of Integer)
        Get
            Return _cantCamion
        End Get
        Set(ByVal value As List(Of Integer))
            _cantCamion = value
        End Set
    End Property

    Private _cantAuto As List(Of Integer)
    Public Property CantAutos() As List(Of Integer)
        Get
            Return _cantAuto
        End Get
        Set(ByVal value As List(Of Integer))
            _cantAuto = value
        End Set
    End Property

    Private _cantVAN As List(Of Integer)
    Public Property CantVAN() As List(Of Integer)
        Get
            Return _cantVAN
        End Get
        Set(ByVal value As List(Of Integer))
            _cantVAN = value
        End Set
    End Property

    Private _cantSUV As List(Of Integer)
    Public Property CantSUV() As List(Of Integer)
        Get
            Return _cantSUV
        End Get
        Set(ByVal value As List(Of Integer))
            _cantSUV = value
        End Set
    End Property

    Private _cantminivan As List(Of Integer)
    Public Property CantMiniVan() As List(Of Integer)
        Get
            Return _cantminivan
        End Get
        Set(ByVal value As List(Of Integer))
            _cantminivan = value
        End Set
    End Property

    Private _creador As Usuario

    Public Sub New(vIN As String, color As Color, matricula As String)
        Me.VIN = vIN
        Me.color = color
        Me.Matricula = matricula
        Me.Conductores = New List(Of Usuario)
        Me.CantCamiones = New List(Of Integer)
        Me.CantAutos = New List(Of Integer)
        Me.CantSUV = New List(Of Integer)
        Me.CantVAN = New List(Of Integer)
        Me.CantMiniVan = New List(Of Integer)
    End Sub

    Public Sub New()
        Me.Conductores = New List(Of Usuario)
        Me.CantCamiones = New List(Of Integer)
        Me.CantAutos = New List(Of Integer)
        Me.CantSUV = New List(Of Integer)
        Me.CantVAN = New List(Of Integer)
        Me.CantMiniVan = New List(Of Integer)
    End Sub
    Public Property Creador() As Usuario
        Get
            Return _creador
        End Get
        Set(ByVal value As Usuario)
            If value.Rol = Usuario.TIPO_ROL_ADMINISTRADOR Then
                _creador = value
            End If
        End Set
    End Property
End Class

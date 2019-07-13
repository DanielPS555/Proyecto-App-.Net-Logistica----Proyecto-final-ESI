Imports Controladores

Public Class Lote
    Public Shared ReadOnly TIPO_PRIORIDAD_ALTA As String = "Alta"
    Public Shared ReadOnly TIPO_PRIORIDAD_NORMAL As String = "Normal"

    Public Shared ReadOnly Property TIPOS_PRIORIDADES() As String()
        Get
            Return {TIPO_PRIORIDAD_ALTA, TIPO_PRIORIDAD_NORMAL}
        End Get
    End Property

    Public Shared ReadOnly TIPO_ESTADO_ABIERTO As String = "Abierto"
    Public Shared ReadOnly TIPO_ESTADO_CERRADO As String = "Cerrado"

    Public Shared ReadOnly Property TIPOS_ESTADOS() As String()
        Get
            Return {TIPO_ESTADO_ABIERTO, TIPO_ESTADO_CERRADO}
        End Get
    End Property

    Public Sub New(id As Integer, nom As String, prio As String, ori As Lugar, des As Lugar, es As String, fechaCreacion As Date)
        Me.IDLote = id
        Me.Prioridad = prio
        Me.Origen = ori
        Me.Destino = des
        Me.Estado = es
        Me.Nombre = nom
        Me.Vehiculos = New List(Of Tuple(Of Tuple(Of Date, Usuario), Vehiculo))
        Me.FechaCreacion = fechaCreacion
    End Sub

    Public Sub New()
        Me.Vehiculos = New List(Of Tuple(Of Tuple(Of Date, Usuario), Vehiculo))
    End Sub

    Private _nombre As String
    Public Property Nombre() As String ' ¿Por qué hay tantas propiedades con getter/setter por defecto?
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Public FechaCreacion As Date

    Private _estado As String
    Public Property Estado() As String
        Get
            Return _estado
        End Get
        Set(ByVal value As String)
            If TIPOS_ESTADOS.Contains(value) Then
                _estado = value
            Else
                Throw New Exception("Estado invalido")
            End If

        End Set
    End Property

    Public Overrides Function Equals(obj As Object) As Boolean
        Dim lote = TryCast(obj, Lote)
        Return lote IsNot Nothing AndAlso
               IDLote = lote.IDLote
    End Function

    Private _idLote As Integer
    Public Property IDLote() As Integer
        Get
            Return _idLote
        End Get
        Set(ByVal value As Integer)
            If value >= 0 Then
                _idLote = value
            Else
                Throw New Exception("LA ID NO PUEDE SER NEGATIVA")
            End If

        End Set
    End Property

    Private _proridad As String
    Public Property Prioridad() As String
        Get
            Return _proridad
        End Get
        Set(ByVal value As String)
            If TIPOS_PRIORIDADES.Contains(value) Then
                _proridad = value
            Else
                Throw New Exception("Las proridades son Alta o Normal, use las constantes estaticas ")
            End If

        End Set
    End Property

    Private _vehiculo As List(Of Tuple(Of Tuple(Of DateTime, Usuario), Vehiculo))
    Public Property Vehiculos() As List(Of Tuple(Of Tuple(Of DateTime, Usuario), Vehiculo))
        Get
            Return _vehiculo
        End Get
        Set(ByVal value As List(Of Tuple(Of Tuple(Of DateTime, Usuario), Vehiculo)))
            _vehiculo = value
        End Set
    End Property

    Private _origen As Lugar
    Public Property Origen() As Lugar
        Get
            Return _origen
        End Get
        Set(ByVal value As Lugar)
            _origen = value
        End Set
    End Property

    Private _destino As Lugar
    Public Property Destino() As Lugar
        Get
            Return _destino
        End Get
        Set(ByVal value As Lugar)
            _destino = value
        End Set
    End Property

End Class

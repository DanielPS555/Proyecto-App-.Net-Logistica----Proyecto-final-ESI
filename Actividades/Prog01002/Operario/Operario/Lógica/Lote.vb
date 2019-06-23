Namespace Logica
    Public Enum EstadoLote
        Abierto
        Cerrado
        Transportado
    End Enum
    Public Enum PrioridadLote
        Normal
        Alta
    End Enum
    Public Class Lote
        Public Shared prioridadMap As Dictionary(Of String, PrioridadLote) = Nothing
        Public Shared estadoMap As Dictionary(Of String, EstadoLote) = Nothing
        Public Shared Function PrioridadFromString(prioridad As String) As PrioridadLote
            If Lote.prioridadMap Is Nothing Then
                Dim x = [Enum].GetValues(GetType(PrioridadLote))
                Dim map As New Dictionary(Of String, PrioridadLote)
                For Each i As PrioridadLote In x
                    map([Enum].GetName(GetType(PrioridadLote), i)) = i
                Next
                Lote.prioridadMap = map
            End If
            Return Lote.prioridadMap(prioridad)
        End Function
        Public Shared Function EstadoFromString(estado As String) As EstadoLote
            If Lote.estadoMap Is Nothing Then
                Dim x = [Enum].GetValues(GetType(EstadoLote))
                Dim map As New Dictionary(Of String, EstadoLote)
                For Each i As PrioridadLote In x
                    map([Enum].GetName(GetType(EstadoLote), i)) = i
                Next
                Lote.estadoMap = map
            End If
            Return Lote.estadoMap(estado)
        End Function
        Public ReadOnly ID As UInteger
        Public ReadOnly Nombre As String
        Public ReadOnly FechaPartida As Date?
        Public ReadOnly _desde As Integer
        Public ReadOnly _hacia As Integer
        Public ReadOnly Property Desde As Lugar
            Get
                Return LRepo.LugarPorID(_desde)
            End Get
        End Property
        Public ReadOnly Property Hacia As Lugar
            Get
                Return LRepo.LugarPorID(_hacia)
            End Get
        End Property
        Public ReadOnly Creador As Usuario
        Public ReadOnly Integrantes As New List(Of Vehiculo)
        Private _prioridad As PrioridadLote
        Public Property Prioridad As PrioridadLote
            Get
                Return _prioridad
            End Get
            Set(value As PrioridadLote)
                _prioridad = value
                _dirty = True
            End Set
        End Property
        Private _estado As EstadoLote
        Public ReadOnly Property Estado As EstadoLote
            Get
                Return _estado
            End Get
        End Property

        Public _dirty As Boolean

        Public Sub CambiarEstado(NuevoEstado As EstadoLote)
            If _estado = EstadoLote.Transportado Then
                Throw New InvalidOperationException("No puedes bajar el estado de un lote transportado")
            End If
            _estado = NuevoEstado
            _dirty = True
        End Sub

        Public Sub New(dr As DataRow, lugar As Integer, transportado As Boolean)
            Me.New(dr("IDLote"), dr("nombre"), lugar, dr("Hacia"), URepo.UsuarioIncompletoPorID(dr("CreadorID")), DirectCast(dr("Prioridad"), String), If(Not transportado, DirectCast(dr("Estado"), String), "Transportado"))
        End Sub

        Public Sub New(iD As UInteger, nombre As String, desde As Integer, hacia As Integer, creador As Usuario, prioridad As PrioridadLote, estado As EstadoLote)
            Me.ID = iD
            Me.Nombre = nombre
            Me.FechaPartida = FechaPartida
            Me._desde = desde
            Me._hacia = hacia
            Me.Creador = creador
            Me.Prioridad = (prioridad)
            _estado = (estado)
        End Sub

        Public Sub New(iD As UInteger, nombre As String, desde As Integer, hacia As Integer, creador As Usuario, prioridad As String, estado As String)
            Me.New(iD, nombre, desde, hacia, creador, PrioridadFromString(prioridad), EstadoFromString(estado))
        End Sub
    End Class
End Namespace
Namespace Logica
    Public Enum EstadoLote
        Abierto
        Cerrado
        Transportado
    End Enum
    Public Enum PrioridadLote
        Normal
        Alto
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
        Public ReadOnly Nombre As UInteger
        Public ReadOnly FechaPartida As Date?
        Public ReadOnly Desde As Lugar
        Public ReadOnly Hacia As Lugar
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

        Public Sub New(dr As DataRow, lugar As Lugar, fecha As Date?)
            Me.New(dr("IDLote"), fecha, lugar, LRepo.LugarPorID(dr("Hacia")), URepo.UsuarioIncompletoPorID(dr("CreadorID")), dr("Prioridad"), dr("Estado"))
        End Sub

        Public Sub New(iD As UInteger, fechaPartida As Date?, desde As Lugar, hacia As Lugar, creador As Usuario, prioridad As String, estado As String)
            Me.ID = iD
            Me.FechaPartida = fechaPartida
            Me.Desde = desde
            Me.Hacia = hacia
            Me.Creador = creador
            Me.Prioridad = PrioridadFromString(prioridad)
            _estado = EstadoFromString(estado)
            desde.LotesCreados.Add(Me)
        End Sub
    End Class
End Namespace
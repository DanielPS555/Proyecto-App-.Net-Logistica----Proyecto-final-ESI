Public Class Evento
    Public Enum TipoEvento
        Mensaje
        Comentario
        Notificacion
    End Enum

    Public Tipo As TipoEvento
    Public ID As Integer
    Public FechaAgregado As Date
    Public Datos As Dictionary(Of String, Object)
End Class

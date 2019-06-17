Namespace Logica
    Public Class Conexion
        Public ReadOnly FechaInicio As DateTime
        Public FechaFin As DateTime?

        Public Sub New(fechaInicio As Date, fechaFin As Date?)
            Me.FechaInicio = fechaInicio
            Me.FechaFin = fechaFin
        End Sub
    End Class
End Namespace
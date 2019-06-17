Namespace Logica
    Public Class InformeDaños
        Private _dirty As Boolean
        Public ReadOnly id As Integer
        Private _descripcion As String
        Public Property Descripcion As String
            Get
                Return _descripcion
            End Get
            Set(value As String)
                Dim TimeDif As TimeSpan = (Date.Now - Fecha).Duration
                If TimeDif.TotalHours > 4 Then
                    Throw New InvalidOperationException($"Sólo puede modificar un informe 4 horas o menos antes de ser creado. Han pasado: {TimeDif.TotalHours:00}h:{TimeDif.Minutes:00}:{TimeDif.Seconds:00}")
                End If
                _descripcion = value
            End Set
        End Property
        Public ReadOnly Property Fecha As DateTime
        Public ReadOnly Tipo As String
        Private _registros As List(Of RegistroDaños)
        Private ReadOnly Property Registros As List(Of RegistroDaños)
            Get
                Return _registros
            End Get
        End Property
    End Class
End Namespace
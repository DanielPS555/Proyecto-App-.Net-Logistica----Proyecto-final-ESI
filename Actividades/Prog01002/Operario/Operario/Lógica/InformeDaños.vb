Namespace Logica
    Public Class InformeDaños
        Private _dirty As Boolean
        Public ReadOnly id As Integer
        Private _descripcion As String
        Private ReadOnly _creador As Integer
        Public ReadOnly Property Creador As Usuario
            Get
                Return URepo.UsuarioPorID(_creador)
            End Get
        End Property
        Private ReadOnly _lugar As Integer
        Public ReadOnly Property Lugar As Lugar
            Get
                Return LRepo.LugarPorID(_lugar)
            End Get
        End Property
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
        Private _registros As New List(Of RegistroDaños)
        Public ReadOnly Property Registros As List(Of RegistroDaños)
            Get
                Return _registros
            End Get
        End Property

        Public Sub New(id As Integer, creador As Integer, fecha As Date, tipo As String, lugar As Integer, desc As String)
            Me.id = id
            _creador = creador
            Me.Fecha = fecha
            Me.Tipo = tipo
            _lugar = lugar
            _descripcion = desc
        End Sub
    End Class
End Namespace
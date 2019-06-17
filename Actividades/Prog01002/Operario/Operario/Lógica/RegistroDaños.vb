Namespace Logica
    Public Class RegistroDaños
        Private _dirty As Boolean
        Private _descripcion As String
        Public ReadOnly EnInforme As InformeDaños
        Public Property Descripcion As String
            Get
                Return _descripcion
            End Get
            Set(value As String)
                Dim TimeDif As TimeSpan = (Date.Now - EnInforme.Fecha).Duration
                If TimeDif.TotalHours > 4 Then
                    Throw New InvalidOperationException($"Sólo puede modificar un registro de informe 4 horas o menos antes de ser creado. Han pasado: {TimeDif.TotalHours:00}h:{TimeDif.Minutes:00}:{TimeDif.Seconds:00}")
                End If
                _descripcion = value
                _dirty = _descripcion
            End Set
        End Property
        Private _numeroenlista As UInteger
        Public ReadOnly Property NumeroEnLista As UInteger
            Get
                Return _numeroenlista
            End Get
        End Property

        Public ReadOnly Property Actualiza As RegistroDaños
            Get
                Return _actualiza
            End Get
        End Property

        Private _actualiza As RegistroDaños
        Private _imagenes As List(Of System.Drawing.Bitmap)
        Public Sub AgregarImagen(imagen As System.Drawing.Bitmap)
            Dim TimeDif As TimeSpan = (Date.Now - EnInforme.Fecha).Duration

            If TimeDif.CompareTo(New TimeSpan(4, 0, 0)) < 0 Then
                _imagenes.Add(imagen)
            Else
                Throw New InvalidOperationException($"Solo puede añadir imagenes si han pasado menos de 4 horas. Han pasado: {TimeDif.TotalHours}h:{TimeDif.Minutes:03}:{TimeDif.Seconds}")
            End If
        End Sub
    End Class
End Namespace
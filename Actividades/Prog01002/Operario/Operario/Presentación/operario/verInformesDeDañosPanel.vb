Public Class verInformesDeDañosPanel
    Private _informe As New List(Of Logica.InformeDaños)
    Public Property NewProperty() As List(Of Logica.InformeDaños)
        Get
            Return _informe
        End Get
        Set(ByVal value As List(Of Logica.InformeDaños))
            _informe = value
        End Set
    End Property

    Private Sub verInformesDeDañosPanel_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics
        If _informe.Count = 0 Then
            Dim posx As Integer = (Me.Width - g.MeasureString("Ingrese infomes de daños a mostrar", New Font(New FontFamily("Century Gothic"), 9)).Width) / 2
            Dim posy As Integer = (Me.Height - g.MeasureString("Ingrese infomes de daños a mostrar", New Font(New FontFamily("Century Gothic"), 9)).Height) / 2
            e.Graphics.DrawString("Ingrese infomes de daños a mostrar", New Font(New FontFamily("Century Gothic"), 9), New SolidBrush(Color.Black), New PointF(posx, posy))
        End If
    End Sub
End Class

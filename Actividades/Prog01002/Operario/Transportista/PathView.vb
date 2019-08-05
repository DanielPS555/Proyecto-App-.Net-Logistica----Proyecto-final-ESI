Imports Controladores
Public Class PathView
    Public Function normalizepoint(point As PointF) As Point
        Dim ny = (point.X + 33.165067)
        ny /= (-33.165067 + 33.751149)
        Dim nx = (point.Y + 54.951876)
        nx /= (-57.067129 + 54.951876)
        Return New Point(nx * 1000, ny * 1099)
    End Function
    Public Camino As New List(Of Lugar)
    Public Origen As Lugar
    Public Medio As TipoMedioTransporte

    Public Class DistanceCompare
        Inherits Comparer(Of Lugar)
        Public origen As Lugar
        Public Sub New(origen As Lugar)
            Me.origen = origen
        End Sub

        Public Overrides Function Compare(x As Lugar, y As Lugar) As Integer
            Dim dist1 As Double = origen.Distancia(x)
            Dim dist2 As Double = origen.Distancia(y)
            Return dist1.CompareTo(dist2)
        End Function
    End Class
    Public Function SortPath(Origen As Lugar, Camino As List(Of Lugar)) As List(Of Lugar)
        Dim l As New List(Of Lugar)
        l.Add(Origen)
        Dim r As New List(Of Lugar)(Camino)
        While r.Count > 0
            r.Sort(New DistanceCompare(l.Last))
            l.Add(r.First)
            r.RemoveAt(0)
        End While
        Return l
    End Function
    Public Sub UpdateView(destGraph As Graphics)
        Dim bmp As New Bitmap(My.Resources.uy)
        Dim path = SortPath(Origen, Camino)
        Dim prev = path.First
        path.RemoveAt(0)
        Using g = Graphics.FromImage(bmp)
            While path.Count > 0
                g.DrawLine(New Pen(Brushes.Yellow), normalizepoint(prev.Posicion), normalizepoint(path.First.Posicion))
                prev = path.First
                path.RemoveAt(0)
            End While
            g.Flush()
        End Using
        destGraph.DrawImage(bmp, New Rectangle(0, 0, Width, Height))
    End Sub

    Private Sub PathView_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        UpdateView(e.Graphics)
    End Sub
End Class

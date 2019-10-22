Imports System.Drawing.Imaging

Public Class AcercaDe
    Private MapHeight As Integer = 128
    Dim map(MapHeight - 1)() As Byte
    Private pointCount As UInteger = 12
    Private Sub RenderVoronoiMap()
        ReDim map(MapHeight - 1)
        For i = 0 To MapHeight - 1
            ReDim map(i)(MapHeight - 1)
        Next
        Dim points(pointCount, 1) As Integer
        Dim rd As New Random
        For c = 0L To pointCount
            For r = 0 To 1
                points(c, r) = rd.Next() Mod MapHeight
            Next
        Next
        For x = 0 To MapHeight - 1
            For y = 0 To MapHeight - 1
                Dim minDist As Integer = (Math.Pow(points(0, 0) - x, 2) + Math.Pow(points(0, 1) - y, 2))
                Dim minIdx As Integer = 0
                For i = 1L To pointCount
                    Dim curDist As Integer = (Math.Pow(points(i, 0) - x, 2) + Math.Pow(points(i, 1) - y, 2))
                    If minDist > curDist Then
                        minDist = curDist
                        minIdx = i
                    End If
                Next
                map(x)(y) = minIdx
            Next
        Next
        Dim bmp As New Bitmap(MapHeight, MapHeight)
        Dim cols(pointCount) As Color
        Dim knowncolors = [Enum].GetValues(GetType(KnownColor)).Cast(Of KnownColor).ToList
        For i = 0L To pointCount
            cols(i) = Color.FromKnownColor(knowncolors.Item(rd.Next Mod knowncolors.Count))
        Next
        For i = 0 To MapHeight - 1
            For ii = 0 To MapHeight - 1
                bmp.SetPixel(i, ii, cols(map(i)(ii)))
            Next
        Next
        PictureBox2.Image = bmp
        PictureBox2.Size = New Size(MapHeight, MapHeight)
    End Sub

    Private Sub AcercaDe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RenderVoronoiMap()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        MapHeight = NumericUpDown1.Value
        RenderVoronoiMap()
    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged
        pointCount = NumericUpDown2.Value
        RenderVoronoiMap()
    End Sub
End Class
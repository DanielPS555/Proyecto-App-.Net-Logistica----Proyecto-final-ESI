Imports Operario_puerto_y_patio

Public Class AnimationPlayer

    Public Class ATuple
        Public p As List(Of Point)
        Public b As List(Of Bitmap)
        Public a As List(Of Integer)

        Public Sub New(p As List(Of Point), b As List(Of Bitmap), a As List(Of Integer))
            Me.p = p
            Me.b = b
            Me.a = a
        End Sub
    End Class

    Public Class STuple
        Public p As Point
        Public b As Bitmap
        Public scale As Single
        Public zOrder As Integer

        Public Sub New(p As Point, b As Bitmap, zOrder As Integer)
            Me.p = p
            Me.b = b
            Me.zOrder = zOrder
            scale = 1
        End Sub

        Public Class Comparer
            Implements IComparer(Of STuple)
            Public Function Compare(x As STuple, y As STuple) As Integer Implements IComparer(Of STuple).Compare
                Return x.zOrder.CompareTo(y.zOrder)
            End Function
        End Class
    End Class

    Public animTuples As New List(Of ATuple)
    Public statics As New List(Of STuple)
    Public frame As Integer = 0
    Public Sub PaintMethod(s As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.Clear(Color.White)
        statics.Sort(New STuple.Comparer)
        For Each i In statics
            If i.scale <> 1.0! Then
                e.Graphics.DrawImage(i.b, New RectangleF(i.p, New Size(i.b.Size.Width * i.scale, i.b.Size.Height * i.scale)))
            Else
                e.Graphics.DrawImage(i.b, i.p)
            End If
        Next
        For Each i In animTuples
            e.Graphics.DrawImage(i.b(i.a(frame)), i.p(frame))
        Next
        e.Graphics.Flush()
    End Sub
End Class

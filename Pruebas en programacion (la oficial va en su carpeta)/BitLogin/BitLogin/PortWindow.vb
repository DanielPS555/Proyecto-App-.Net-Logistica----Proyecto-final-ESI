Public Class PortWindow
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f As ColorDialog = New ColorDialog()
        f.ShowDialog()
        ChromaPicture1.ChromaColor = f.Color
        ChromaPicture1.Invalidate()
    End Sub

    Private Sub PortWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChromaPicture1.Image = Bitmap.FromFile("suv.png")
    End Sub
End Class
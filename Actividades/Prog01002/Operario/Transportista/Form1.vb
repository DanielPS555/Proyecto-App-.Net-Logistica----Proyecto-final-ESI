Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PathView1.Origen = New Controladores.Lugar(0, 0, -34.861142, -56.165493, "", "", Nothing)
        PathView1.Camino.Add(New Controladores.Lugar(0, 0, -34.474548, -54.33587, "", "", Nothing))
        PathView1.Refresh()
    End Sub
End Class

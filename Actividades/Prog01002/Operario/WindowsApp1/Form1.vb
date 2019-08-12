Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Controladores.Persistencia.getInstancia.RealizarConexcion("192.168.1.100", "9088", "ol_esi", "root", "root", "bit2", False)
    End Sub
End Class

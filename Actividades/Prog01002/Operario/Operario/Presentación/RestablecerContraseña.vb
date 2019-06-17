Public Class RestablecerContraseña

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Constantes.URepo.Restablecer(username.Text, secretanswer.Text, newpwd.Text) Then
            Button1.Enabled = False
            Dim tboxes() As TextBox = {username, secretanswer, newpwd}
            tboxes.ForEach(Sub(x) x.Enabled = False)
        Else
            MsgBox("Respuesta incorrecta")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class
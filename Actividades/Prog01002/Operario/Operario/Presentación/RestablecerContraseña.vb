Public Class RestablecerContraseña

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If URepo.Restablecer(username.Text, secretanswer.Text, newpwd.Text) Then
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim usuarioPregunta = URepo.Pregunta(username.Text)
        Pregunta.Text = usuarioPregunta
        Pregunta.Visible = True
        secretanswer.Visible = True
        Label4.Visible = True
        newpwd.Visible = True
        Label5.Visible = True
        Button1.Visible = True
    End Sub
End Class
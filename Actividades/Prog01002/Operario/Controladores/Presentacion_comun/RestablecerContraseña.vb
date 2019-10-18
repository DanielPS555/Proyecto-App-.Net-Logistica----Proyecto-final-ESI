Imports Controladores.Fachada
Imports Controladores.Extenciones.Extensiones
Public Class RestablecerContraseña

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Controladores.Fachada.getInstancia.ModificarContrasñeaConRecuperacion(username.Text, secretanswer.Text, newpwd.Text) Then
            Button1.Enabled = False
            Dim tboxes() As TextBox = {username, secretanswer, newpwd}
            tboxes.ForEach(Sub(x) x.Enabled = False)
            MsgBox("Modificado con exito")
        Else
            MsgBox("Respuesta incorrecta")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim l As New Login
        l.NotificarDeConexion(True)
        Principal.getInstancia.cargarPanel(Of Login)(l)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Controladores.Fachada.getInstancia.ComprobacionSoloNombreUsuario(username.Text) Then
            If Not Controladores.Fachada.getInstancia.Existenciadatosderecuperacion(username.Text) Then
                MsgBox("Este usuario no tiene datos de recuperacion, por favor ingrese con su contraseña asignada y ingrese unos", MsgBoxStyle.Critical)
                Return
            End If
            Dim usuarioPregunta = Controladores.Fachada.getInstancia.PreguntaSecretaUsuario(username.Text)
                Pregunta.Text = usuarioPregunta
                Pregunta.Visible = True
                secretanswer.Visible = True
                Label4.Visible = True
                newpwd.Visible = True
                Label5.Visible = True
                Button1.Visible = True
                preg.Visible = True
            Else
                MsgBox("Nombre de usuario incorrecto", MsgBoxStyle.Critical)
        End If

    End Sub
End Class
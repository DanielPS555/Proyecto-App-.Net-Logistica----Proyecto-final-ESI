Public Class Registrar
    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        Dim nombres() As String = If(nombresBox.Text.Contains(" "), nombresBox.Text.Split(" "), {nombresBox.Text, Nothing})
        Dim apellidos() As String = If(apellidosBox.Text.Contains(" "), apellidosBox.Text.Split(" "), {apellidosBox.Text, Nothing})
        Dim usuario As New User(userBox.Text, pwdBox.Text, User.RolFromString(roleList.SelectedItem), emailBox.Text, datePicker.Value, telefonoBox.Text, nombres(0), nombres(1), apellidos(0), apellidos(1), CType(sexCombo.SelectedItem, String)(0))
        If Data.Login.UserRegister(usuario, preguntaBox.Text, respuestaBox.Text) Then
            Principal.getInstancia.cargarPanel(Of Login)()
        Else
            MsgBox("No se pudo registrar el usuario XDDDDDDDDDDDDD")
        End If
    End Sub
End Class
Public Class Registrar
    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        Dim nombres() As String = If(nombresBox.Text.Contains(" "), nombresBox.Text.Split(" "), {nombresBox.Text, Nothing})
        Dim apellidos() As String = If(apellidosBox.Text.Contains(" "), apellidosBox.Text.Split(" "), {apellidosBox.Text, Nothing})
        Dim lugares As New List(Of Integer)
        For Each i As DataRowView In CheckedListBox1.CheckedItems
            lugares.Add(i(0))
        Next
        '        If Data.Login.UserRegister(usuario, preguntaBox.Text, respuestaBox.Text, lugares) Then
        Principal.getInstancia.cargarPanel(Of Login)()
        'Else
        MsgBox("No se pudo registrar el usuario XDDDDDDDDDDDDD")
        'End If
    End Sub

    Private Sub Registrar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
End Class
Public Class LispPanel
    Private lispBox As New LispBox
    Private Sub insertButton_Click(sender As Object, e As EventArgs) Handles insertButton.Click
        Dim st = outputBox.TextLength
        outputBox.AppendText(inputLine.Text + vbNewLine)
        outputBox.SelectionStart = st
        outputBox.SelectionLength = inputLine.Text.Length
        outputBox.SelectionColor = Drawing.Color.Green
        lispBox.ExecuteLine(inputLine.Text, outputBox)
        insertButton.Text = Controladores.Funciones_comunes.I18N("Evaluar", Controladores.Marco.getInstancia.Language)
    End Sub
End Class
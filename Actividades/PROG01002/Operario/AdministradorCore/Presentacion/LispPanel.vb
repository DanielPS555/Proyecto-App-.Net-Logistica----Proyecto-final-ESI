Public Class LispPanel
    Private lispBox As New LispBox
    Private Sub insertButton_Click(sender As Object, e As EventArgs) Handles insertButton.Click
        outputBox.AppendText(inputLine.Text + vbNewLine)
        Dim r = lispBox.ExecuteLine(inputLine.Text)
        outputBox.AppendText(r + vbNewLine)
    End Sub
End Class
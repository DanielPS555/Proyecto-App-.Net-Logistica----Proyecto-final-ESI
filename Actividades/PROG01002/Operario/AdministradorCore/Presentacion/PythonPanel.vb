Public Class PythonPanel
    Private pythonBox As PythonBox = PythonBox.GetInstancia
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        insertButton.Text = Controladores.Funciones_comunes.I18N("Evaluar", Controladores.Marco.Language)

    End Sub

    Private Sub insertButton_Click(sender As Object, e As EventArgs) Handles insertButton.Click
        Dim st = outputBox.TextLength
        outputBox.AppendText(inputLine.Text + vbNewLine)
        outputBox.SelectionStart = st
        outputBox.SelectionLength = inputLine.Text.Length
        outputBox.SelectionColor = Drawing.Color.Green
        Dim retval = pythonBox.Execute(inputLine.Text)
        If retval IsNot Nothing Then
            outputBox.AppendText(pythonBox.MarshalString(retval) + vbNewLine)
        End If
    End Sub

    Private Sub inputLine_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles inputLine.KeyPress
    End Sub

    Private Sub inputLine_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles inputLine.KeyDown
        If e.Shift And e.KeyCode = Windows.Forms.Keys.Enter Then
            e.Handled = True
            insertButton_Click(sender, e)
        End If
    End Sub
End Class
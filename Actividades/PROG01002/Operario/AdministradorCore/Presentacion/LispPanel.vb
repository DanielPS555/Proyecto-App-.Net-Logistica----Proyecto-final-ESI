Public Class LispPanel
    Private lispBox As New LispBox
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        insertButton.Text = Controladores.Funciones_comunes.I18N("Evaluar", Controladores.Marco.getInstancia.Language)

    End Sub

    Private Sub insertButton_Click(sender As Object, e As EventArgs) Handles insertButton.Click
        Dim st = outputBox.TextLength
        outputBox.AppendText(inputLine.Text + vbNewLine)
        outputBox.SelectionStart = st
        outputBox.SelectionLength = inputLine.Text.Length
        outputBox.SelectionColor = Drawing.Color.Green
        lispBox.ExecuteLine(inputLine.Text, outputBox)
    End Sub
End Class
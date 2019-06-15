Public Class PuertosVeiculos

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub ColorButton_Click(sender As Object, e As EventArgs) Handles ColorButton.Click
        Dim cd As New ColorDialog()
        cd.ShowDialog()
    End Sub

    Private Sub type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles typeComBox.SelectedIndexChanged
        Select Case typeComBox.Text
            Case "SUV"
            Case "Auto"
            Case Else
        End Select
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim resultado As Integer
        Dim tryParse As Boolean = Integer.TryParse(añoTextBox.Text, resultado)
        If Not tryParse Then
            MsgBox("El año debe ser numérico")
            Return
        End If

    End Sub
    Public padre As MarcoPuerto

    Public lugar As Integer

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    End Sub

    Public zone As Integer = -1
    Public pos As Integer = -1

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    End Sub
End Class
Public Class PuertosVeiculos
    Private Sub VINTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles VINTextBox.KeyPress
        If (e.KeyChar >= "0" AndAlso e.KeyChar <= "9") OrElse (e.KeyChar >= "A" AndAlso e.KeyChar <= "Z") Then ' los VIN utilizan números y letras mayúsculas
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub añoTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles añoTextBox.KeyPress
        If (e.KeyChar >= "0" AndAlso e.KeyChar <= "9") Then ' el año sólo pueden ser números
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub ColorButton_Click(sender As Object, e As EventArgs) Handles ColorButton.Click
        Dim cd As New ColorDialog()
        cd.ShowDialog()
        ChromaPicture1.ChromaColor = cd.Color
        ColorButton.BackColor = cd.Color
        ChromaPicture1.Invalidate()
    End Sub

    Private Sub type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles typeComBox.SelectedIndexChanged
        Select Case typeComBox.Text
            Case "SUV"
                Me.ChromaPicture1.Image = My.Resources.SUV
            Case "Auto"
                Me.ChromaPicture1.Image = My.Resources.car
            Case Else
                Me.ChromaPicture1.Image = Nothing
        End Select
        Me.ChromaPicture1.Invalidate()
    End Sub

End Class
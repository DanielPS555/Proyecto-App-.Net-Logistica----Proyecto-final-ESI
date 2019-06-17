Public Class NuevoLote
    Private Sub NuevoLote_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics
        g.DrawRectangle(New Pen(Color.FromArgb(35, 35, 35), 2), New Rectangle(descipt.Location, descipt.Size))
    End Sub

    Private Sub ingresar_Click(sender As Object, e As EventArgs)
        Dim verif As Integer = 0


        ' verifican los datos
        ' se crea el lote
        ' se lo envia al formulario padre 
        Me.Close()

    End Sub

    Private Sub descipt_TextChanged(sender As Object, e As EventArgs) Handles descipt.TextChanged
        cp.Text = 255 - descipt.Text.Length
    End Sub
End Class
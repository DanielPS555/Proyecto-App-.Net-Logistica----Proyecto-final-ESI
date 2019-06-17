Public Class crearInformaDeDaños
    ' hay que crear una lista de registros
    Public Sub New()
        InitializeComponent()
        tipo.SelectedIndex = 0

    End Sub

    Private Sub descipt_TextChanged(sender As Object, e As EventArgs) Handles descipt.TextChanged
        cp.Text = 255 - descipt.Text.Length
        If 255 - descipt.Text.Length < 0 Then
            cp.ForeColor = Color.FromArgb(180, 20, 20)
        Else
            cp.ForeColor = Color.FromArgb(35, 35, 35)
        End If
    End Sub

    Private Sub nuevo_Click(sender As Object, e As EventArgs)
        MarcoPuerto.getInstancia.cargarPanel(Of RegistroDeDañoPanel)(New RegistroDeDañoPanel)
    End Sub

    Private Sub eliminar_Click(sender As Object, e As EventArgs)
        If Registros.SelectedIndex > 0 Then
            'Se debe eliminar el elemento de la lista
            Registros.Items.Remove(Registros.SelectedIndex)

        End If


    End Sub
End Class
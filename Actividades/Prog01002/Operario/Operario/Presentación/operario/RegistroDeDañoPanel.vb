Public Class RegistroDeDañoPanel
    Public Sub New(EnInforme As Integer)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        infoDaños.Text = EnInforme
        regisDaños.Text = VRepo.NewReg(EnInforme)
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub
End Class
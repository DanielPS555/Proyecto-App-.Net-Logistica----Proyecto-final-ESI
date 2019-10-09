Public Class NuevoMedio

    Private TipoMedioLocal As Controladores.TipoMedioTransporte
    Private mediosDeTransporte As List(Of Controladores.TipoMedioTransporte)

    Public Sub New()
        InitializeComponent()
        mediosDeTransporte = Controladores.Fachada.getInstancia.TodosLosTiposDeMediosDisponibles()
        tipo.Items.AddRange(mediosDeTransporte.Select(Function(x) x.Nombre).ToArray)

        If tipo.Items.Count <> 0 Then
            tipo.SelectedIndex = 0
        End If



    End Sub

    Private Sub CrearButton_Click(sender As Object, e As EventArgs) Handles CrearButton.Click
        If nombreBox.Text.Length = 0 Then
            MsgBox("El nombre o identificador no puede ser vacio", MsgBoxStyle.Critical)
            Return
        End If

        If nombreBox.Text.Length <> nombreBox.Text.Trim.Length Then

        End If

        If tipo.SelectedIndex = -1 Then

        End If

        If TipoMedioLocal Is Nothing Then
            If Controladores.Fachada.getInstancia.ExistenciaDeMedioConIdTipoYIdLegak(mediosDeTransporte(tipo.SelectedIndex).ID, nombreBox.Text) Then

            End If
        Else

            End If
    End Sub
End Class
Imports Operario

Public Class PanelInfoUsuario

    Public usuario As Integer

    Public Sub New(idusuario As Integer)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        usuario = idusuario

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'If URepo.CambiarPregunta(NPregunta.Text, NRespuesta.Text, Contraseña.Text) Then
        '    MsgBox("Pregunta cambiada con éxito.")
        'Else
        '    MsgBox("Hubo un error cambiando la pregunta. Por favor verifique su contraseña.")
        'End If
    End Sub

    Private editados As New Dictionary(Of String, String)

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        editados.Add(DataGridView1.Rows(e.RowIndex).Cells(0).Value, DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
    End Sub

    Private Sub DataGridView1_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridView1.CellBeginEdit
        If e.ColumnIndex = 0 OrElse DataGridView1.Rows(e.RowIndex).Cells(0).Value = "nombredeusuario" Then
            e.Cancel = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        'For Each i In editados
        '    SRepo.ConsultarSinRetorno($"update usuario set {i.Key}='{i.Value}' where idusuario={usuario};")
        'Next
        'editados.Clear()
    End Sub
End Class
Public Class EditarHabilitaciones
    Private lugar As Controladores.Lugar
    Private habi As List(Of Controladores.TipoMedioTransporte)

    Public Sub New(lug As Controladores.Lugar)
        InitializeComponent()
        lugar = lug
        Me.habi = Controladores.Fachada.getInstancia.TodosLosTiposDeMediosDisponibles()
        For Each h As Controladores.TipoMedioTransporte In habi
            lista.Items.Add(h.Nombre, False)
        Next
        Marcarvalidos()
    End Sub

    Private Sub Marcarvalidos()
        For i As Integer = 0 To habi.Count - 1
            lista.SetItemChecked(i, Controladores.Fachada.getInstancia.ExistenciaDelHabilitado(habi(i), lugar))
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim elementos As New List(Of Controladores.TipoMedioTransporte)
        For Each i As Integer In lista.CheckedIndices
            elementos.Add(habi(i))
        Next

        Controladores.Fachada.getInstancia.ActualizarTipos(lugar, elementos)

        MsgBox("Cambios realizados con exito", MsgBoxStyle.Information)
        Me.Close()

    End Sub
End Class
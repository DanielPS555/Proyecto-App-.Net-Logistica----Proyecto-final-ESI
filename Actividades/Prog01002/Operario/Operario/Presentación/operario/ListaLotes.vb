Imports Controladores
Public Class ListaLotes
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        cargar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub cargar()
        'QUEDA REGISTRAR EL LUGAR DE CONEXCION 
        Dim r = Fachada.getInstancia.LotesEnLugar()
        lote.Rows.Clear()
        For Each t In r
            lote.Rows.Add(t.Item1.IDLote, t.Item1.Nombre, t.Item1.Estado, t.Item2, t.Item3)
        Next

    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles lote.CellClick
        'LLAMA AL PANEL DE INFORMACION
        If e.RowIndex < 0 Then
            Return
        End If
        Marco.getInstancia.cargarPanel(Of PanelInfoLote)(New PanelInfoLote(lote.Rows(e.RowIndex).Cells(0).Value))
    End Sub

End Class
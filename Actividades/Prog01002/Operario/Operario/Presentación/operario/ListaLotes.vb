Public Class ListaLotes
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        cargar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub cargar()

        Dim r As DataTable = Constantes.SRepo.Consultar("select lote.nombre,min(integra.fecha) fecha_creacion, lugar.nombre,
                                                        count(integra.VIN) from lote,integra,lugar,vehiculoIngresa
                                                        where IDLote=integra.lote and lote.hacia=lugar.idlugar  and
                                                        vehiculoIngresa.VIN = integra.VIN and  vehiculoingresa.tipoingreso='Alta'
                                                        group by lote.nombre, lugar.nombre
                                                           ")
        lote.Rows.Clear()
        lote.DataSource = r
    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles lote.CellClick
        'LLAMA AL PANEL DE INFORMACION
        If e.RowIndex < 0 Then
            Return
        End If
        Marco.getInstancia.cargarPanel(Of PanelInfoLote)(New PanelInfoLote(lote.Rows(e.RowIndex).Cells(0).Value))
    End Sub

End Class
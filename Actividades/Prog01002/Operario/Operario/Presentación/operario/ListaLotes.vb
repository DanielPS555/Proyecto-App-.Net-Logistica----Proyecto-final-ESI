Public Class ListaLotes
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        cargar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub cargar()
        'QUEDA REGISTRAR EL LUGAR DE CONEXCION 
        Dim r As DataTable = Constantes.SRepo.Consultar("select lote.nombre,min(integra.fecha) fecha_creacion, lugar.nombre,
                                                        count(integra.VIN) from lote,integra,lugar,vehiculoIngresa
                                                        where IDLote=integra.lote and lote.desde=lugar.idlugar  and
                                                        vehiculoIngresa.VIN = integra.VIN and  vehiculoingresa.tipoingreso='Alta'
                                                        and lugar.nombre='" & URepo.ConectadoEn & "'
                                                        group by lote.nombre, lugar.nombre")
        lote.Rows.Clear()
        r.Columns.Add("Estado", GetType(String))
        lote.DataSource = r
        For i As Integer = 0 To r.Rows.Count - 1
            Try
                Dim elemento As Integer = SRepo.ConsultarSingle("Select count(transporte.estado)

                                    from lote , transporte,transporta,lugar

                                    where lote.idlote = transporta.idlote and transporte.transporteid= transporta.transporteid

                                    and lote.nombre='" & lote.Rows(i).Cells(0).Value & "' and transporte.estado='Exitoso' and

                                    lugar.idlugar=lote.Desde and lugar.nombre='" & URepo.ConectadoEn & "'

                                    group by transporte.estado")

                If elemento > 0 Then
                    lote.Rows(i).Cells(4).Value = "Fuera del lugar"
                Else
                    lote.Rows(i).Cells(4).Value = "En el lugar"
                End If

            Catch ex As Exception
                lote.Rows(i).Cells(4).Value = "En el lugar"
            End Try

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
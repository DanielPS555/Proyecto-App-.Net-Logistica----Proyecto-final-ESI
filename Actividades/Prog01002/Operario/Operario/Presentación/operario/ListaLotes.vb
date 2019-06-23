Public Class ListaLotes
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim dt As New DataTable("Lotes")
        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Nombre", GetType(String))
        dt.Columns.Add("Hacia", GetType(String))
        dt.Columns.Add("Prioridad", GetType(String))
        dt.Columns.Add("Estado", GetType(String))
        LRepo.LugarPorNombre(URepo.ConectadoEn).LotesCreados.Select(
            Function(x) New Tuple(Of Integer, String, String, String, String)(x.ID, x.Nombre, x.Hacia.Nombre, [Enum].GetName(GetType(Logica.PrioridadLote), x.Prioridad), [Enum].GetName(GetType(Logica.EstadoLote), x.Estado))
            ).ForEach(Sub(x)
                          Dim t = dt.NewRow
                          dt.Rows.Add(t)
                          t("ID") = x.Item1
                          t("Nombre") = x.Item2
                          t("Hacia") = x.Item3
                          t("Prioridad") = x.Item4
                          t("Estado") = x.Item5
                      End Sub)
        DataGridView1.DataSource = dt
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim dt As DataTable = LRepo.VehiculosEnLote(DataGridView1.Rows(e.RowIndex).Cells(0).Value)
        DataGridView2.DataSource = dt
    End Sub

End Class
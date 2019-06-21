Public Class ListaLotes
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim dt As New DataTable("Lotes")
        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Hacia", GetType(String))
        dt.Columns.Add("Prioridad", GetType(String))
        dt.Columns.Add("Estado", GetType(String))
        LRepo.LugarPorNombre(URepo.ConectadoEn).LotesPorPartir.Select(
            Function(x) New Tuple(Of Integer, String, String, String)(x.ID, x.Hacia.Nombre, [Enum].GetName(GetType(Logica.PrioridadLote), x.Prioridad), [Enum].GetName(GetType(Logica.EstadoLote), x.Estado))
            ).ForEach(Sub(x)
                          Dim t = dt.NewRow
                          dt.Rows.Add(t)
                          t("ID") = x.Item1
                          t("Hacia") = x.Item2
                          t("Prioridad") = x.Item3
                          t("Estado") = x.Item4
                      End Sub)
        DataGridView1.DataSource = dt
    End Sub
End Class
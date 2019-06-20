Public Class ListaLotes
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim dt As New DataTable("Lotes")
        LRepo.LugarPorNombre(URepo.ConectadoEn).LotesPorPartir.Select(Function(x) New Tuple(Of Integer, String, String, String)(x.ID, x.Hacia.Nombre, [Enum].GetName(GetType(Logica.PrioridadLote), x.Prioridad), [Enum].GetName(GetType(Logica.EstadoLote), x.Estado)))
        DataGridView1.DataSource = dt
    End Sub
End Class
Public Class ListaDeTrasportes
    Dim lista As DataTable
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        lista = Controladores.Fachada.getInstancia.ListaDeTrasportesPorIdUsuario(Controladores.Fachada.getInstancia.DevolverUsuarioActual.ID_usuario)
        trasportes.DataSource = lista
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
End Class
Imports Operario.Logica

Public Class PanelInfoLote
    Public Sub New(l As Logica.Lote)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Label1.Text = l.Nombre
        Label2.Text = l.Hacia.Nombre
        Label3.Text = [Enum].GetName(GetType(EstadoLote), l.Estado)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        DataGridView1.DataSource = LRepo.VehiculosEnLote(l.ID)
    End Sub
End Class
Public Class ListaZonas
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        CargarData()
    End Sub

    Private conectadoEn As String
    Private Sub CargarData()
        TreeView1.Nodes.Clear()
        conectadoEn = URepo.ConectadoEn
        Dim zonas = LRepo.ZonasEnLugar(URepo.ConectadoEn)
        zonas.ForEach(Sub(x)
                          Dim subzonas = LRepo.SubzonasEnLugar(x, conectadoEn)
                          Dim n = TreeView1.Nodes.Add(x)
                          For Each y In subzonas
                              n.Nodes.Add(y)
                          Next
                      End Sub)
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        If e.Node.Level < 1 Then
            Return
        End If
        Dim capacidad = LRepo.CapacidadSubzona(e.Node.Text, e.Node.Parent.Text, conectadoEn)
        Dim ocupacion = LRepo.OcupacionSubzona(e.Node.Text, e.Node.Parent.Text, conectadoEn)
        Label1.Text = $"Capacidad: ({ocupacion}/{capacidad})"
        ProgressBar1.Maximum = capacidad
        ProgressBar1.Value = ocupacion
    End Sub
End Class
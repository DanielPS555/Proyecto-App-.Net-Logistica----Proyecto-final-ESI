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
                              Dim vehiculos As List(Of String) = LRepo.VehiculosEnSubzona(y, x, conectadoEn)
                              Dim t = n.Nodes.Add(y)
                              For Each v In vehiculos
                                  t.Nodes.Add(v)
                              Next
                          Next
                      End Sub)
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        If pInfo IsNot Nothing Then
            pInfo.Close()
            Marco.getInstancia.cerrarPanel(Of panelInfoVehiculo)()
        End If
        If e.Node.Level = 0 Then
            Label1.Visible = True
            ProgressBar1.Visible = True
            Label2.Visible = True
            Dim capacidad As Integer = LRepo.CapacidadZona(e.Node.Text, conectadoEn)
            Dim ocupacion As Integer = LRepo.OcupacionZona(e.Node.Text, conectadoEn)
            Label1.Text = $"Capacidad: ({ocupacion}/{capacidad})"
            Label2.Text = $"Nro de Subzonas: {LRepo.SubzonasEnLugar(e.Node.Text, conectadoEn).Count}"
            ProgressBar1.Maximum = capacidad
            ProgressBar1.Value = ocupacion
        ElseIf e.Node.Level = 1 Then
            Label1.Visible = True
            ProgressBar1.Visible = True
            Dim capacidad As Integer = LRepo.CapacidadSubzona(e.Node.Text, e.Node.Parent.Text, conectadoEn)
            Dim ocupacion As Integer = LRepo.OcupacionSubzona(e.Node.Text, e.Node.Parent.Text, conectadoEn)
            Label1.Text = $"Capacidad: ({ocupacion}/{capacidad})"
            Label2.Visible = False
            ProgressBar1.Maximum = capacidad
            ProgressBar1.Value = ocupacion
        Else
            Label1.Visible = False
            ProgressBar1.Visible = False
            Label2.Visible = False
            pInfo = New panelInfoVehiculo(e.Node.Text, True)
            Marco.getInstancia.cargarPanel(pInfo)
            pInfo.Location = Label1.Location
        End If
    End Sub
    Private pInfo As panelInfoVehiculo

    Private Sub ListaZonas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If pInfo IsNot Nothing Then
            pInfo.Close()
            Marco.getInstancia.cerrarPanel(Of panelInfoVehiculo)()
        End If
    End Sub
End Class
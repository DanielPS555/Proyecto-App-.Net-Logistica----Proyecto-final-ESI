Imports Operario.Logica

Public Class PanelInfoLote
    Private idlote As Integer
    Public Sub New(nombre As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Dim dt = SRepo.Consultar($"select lote.nombre, lugar.nombre, lote.estado, lote.prioridad, lote.idlote from lote inner join lugar on lote.hacia=lugar.idlugar where lote.nombre = '{nombre}';")
        If dt.Rows.Count <> 1 Then
            Me.Close()
        End If
        Dim dr = dt.Rows(0)
        Label1.Text = $"Nombre: {dr(0)}"
        Label2.Text = $"Destino: {dr(1)}"
        Label3.Text = $"Estado: {dr(2)}"
        If dr(2) <> "Abierto" Then
            Button1.Visible = False
        End If
        Label4.Text = $"Prioridad: {dr(3)}"
        idlote = dr(4)
        Dim vehiculos = LRepo.VehiculosEnLote(dr(4))
        DataGridView1.DataSource = vehiculos
        Dim fechaCreacion = vehiculos.ToList.Select(Function(x) CType(x(3), DateTime)).ToList
        Dim Fecha As String
        If fechaCreacion.Count = 0 Then
            Fecha = "Desconocido"
        Else
            fechaCreacion.Sort()
            Fecha = fechaCreacion.First.ToShortDateString
        End If
        Label5.Text = $"Fecha de creación: {Fecha}"
    End Sub

    Private vehiculo As panelInfoVehiculo

    Private Sub dgv(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex < 0 Then
            Return
        End If

        Dim vehiculo = New panelInfoVehiculo(DataGridView1.Rows(e.RowIndex).Cells(0).Value, False) With {
            .Location = DataGridView1.Location + New Point(0, DataGridView1.Height + 25),
            .TopLevel = False
        }
        Marco.getInstancia.cargarPanel(Of panelInfoVehiculo)(vehiculo)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CType(sender, Button).Visible = (SRepo.ConsultarSinRetorno($"update lote set estado='Cerrado' where idlote={idlote};") = 0)
    End Sub
End Class
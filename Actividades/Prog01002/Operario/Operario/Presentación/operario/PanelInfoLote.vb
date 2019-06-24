Imports Operario.Logica

Public Class PanelInfoLote
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
        Me.Size = New Size(880, 650)
    End Sub

    Private vehiculo As panelInfoVehiculo

    Private Sub dgv(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If vehiculo IsNot Nothing Then
            vehiculo.Close()
            Me.Controls.Remove(vehiculo)
            vehiculo = Nothing
            Me.Size = New Size(880, 650)
        End If
        If e.RowIndex < 0 Then
            Return
        End If

        vehiculo = New panelInfoVehiculo(DataGridView1.Rows(e.RowIndex).Cells(0).Value, False) With {
            .Location = DataGridView1.Location + New Point(0, DataGridView1.Height + 25),
            .TopLevel = False
        }
        Me.Size = New Size(880, vehiculo.Location.Y + vehiculo.Height)
        Me.Controls.Add(vehiculo)
        vehiculo.Show()
    End Sub
End Class
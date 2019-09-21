Imports Controladores

Public Class PanelInfoLote
    Private idlote As Integer
    Public Sub New(nombrelote As String)
        Me.New(Fachada.getInstancia.InfoLote(Nombre:=nombrelote))
    End Sub

    Public Sub New(lote As Lote)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Label1.Text = $"Nombre: {lote.Nombre}"
        If lote.Destino Is Nothing Then
            lote = Fachada.getInstancia.InfoLote(ID:=lote.IDLote)
        End If
        Label2.Text = $"Destino: {lote.Destino.Nombre}"
        Label3.Text = $"Estado: {lote.Estado}"
        If lote.Estado <> "Abierto" Then
            Button1.Visible = False
        End If
        Label4.Text = $"Prioridad: {lote.Prioridad}"
        Label5.Text = $"Fecha de creación: {lote.FechaCreacion}"
        idlote = lote.IDLote
        Dim vehiculos = Fachada.getInstancia.VehiculosEnLote(idlote)
        For Each i In vehiculos
            Dim colorColumn = New Bitmap(50, 50)
            For x = 0 To 49
                For y = 0 To 49
                    colorColumn.SetPixel(x, y, i.Color)
                Next
            Next
            DataGridView1.Rows.Add(i.VIN, i.Marca, i.Modelo, i.Tipo, colorColumn, i.Cliente.Nombre)
        Next
    End Sub

    Private vehiculo As panelInfoVehiculo

    Private Sub dgv(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex < 0 Then
            Return
        End If

        Dim vehiculo = New panelInfoVehiculo(DataGridView1.Rows(e.RowIndex).Cells(0).Value, False)
        Marco.getInstancia.cargarPanel(Of panelInfoVehiculo)(vehiculo)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CType(sender, Button).Visible = Not (Fachada.getInstancia.CerrarLote(idlote))
        If CType(sender, Button).Visible Then
            MsgBox("El lote no fue cerrado porque uno o más vehículos no han sido inspeccionados")
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub PanelInfoLote_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
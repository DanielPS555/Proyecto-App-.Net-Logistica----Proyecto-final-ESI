Imports Controladores.Extenciones
Imports GMap.NET

Public Class TrayectoVehicular
    Private conn As Odbc.OdbcConnection

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Controladores.Fachada.getInstancia.IniciarConexcion(ConexionLib.FachadaRegistro.LeerConfiguracion)
        conn = Controladores.Persistencia.getInstancia.Conexcion
        Dim selcmd As New Odbc.OdbcCommand("select VIN from vehiculo;", conn)
        Dim rdr = selcmd.ExecuteReader
        Dim dt As New DataTable
        dt.Load(rdr)
        For Each i As DataRow In dt.Rows
            ListBox1.Items.Add(i.Item(0))
        Next
    End Sub

    Dim transportes As DataTable

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        transportes = Controladores.Persistencia.getInstancia.TransportesDeVehiculo(ListBox1.SelectedItem)
        ListBox2.Items.Clear()
        For Each i As DataRow In transportes.Rows
            ListBox2.Items.Add(i.Item(0) & " -> " & i.Item(1) & "(" & i.Item(2) & ") a través de " & i.Item(3) & " el " & i.Item(4))
        Next
        GMapControl1.MapProvider = MapProviders.GoogleMapProvider.Instance
        GMapControl1.ShowCenter = False
        If transportes.Rows.Count > 0 Then
            Dim olay = New WindowsForms.GMapOverlay("route")
            Dim route As New List(Of PointLatLng)
            route.Add(New PointLatLng(transportes.Rows(0).Item(5), transportes.Rows(0).Item(6)))
            route.Add(New PointLatLng(transportes.Rows(0).Item(7), transportes.Rows(0).Item(8)))
            Dim pointlatl As PointLatLng
            For i = 1 To transportes.Rows.Count - 1
                pointlatl = New PointLatLng(transportes.Rows(i).Item(7), transportes.Rows(i).Item(8))
                route.Add(pointlatl)
            Next
            Dim mk = New WindowsForms.Markers.GMarkerGoogle(pointlatl, WindowsForms.Markers.GMarkerGoogleType.blue)
            Dim rt = New GMap.NET.WindowsForms.GMapRoute(route, "Route")
            rt.Stroke = New Pen(Color.Red, 3)
            olay.Routes.Add(rt)
            olay.Markers.Add(mk)
            GMapControl1.Overlays.Add(olay)
            GMapControl1.ZoomAndCenterMarkers("route")
        End If
    End Sub

    Private ListBox3 As ListBox = Nothing

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        If ListBox2.SelectedIndex < 0 Then
            If ListBox3 IsNot Nothing Then
                If Me.Controls.Contains(ListBox3) Then
                    Me.Controls.Remove(ListBox3)
                End If
            End If
        Else
            If ListBox3 Is Nothing Then
                ListBox3 = New ListBox With {
                    .Location = ListBox1.Location + New Point(0, ListBox1.Height + 5),
                    .Size = New Size(ListBox2.Width, 200)
                }
            End If
            Me.Height = ListBox1.Height + 255
            Me.Controls.Add(ListBox3)
            Dim orig = transportes.Rows.Item(ListBox2.SelectedIndex).Item(0)
            Dim dest = transportes.Rows.Item(ListBox2.SelectedIndex).Item(1)
            Dim pos_orig = Controladores.Persistencia.getInstancia.PosicionesDeVehiculoEnLugar(orig, ListBox1.SelectedItem)
            Dim pos_dest = Controladores.Persistencia.getInstancia.PosicionesDeVehiculoEnLugar(dest, ListBox1.SelectedItem)
            ListBox3.Items.Clear()
            For Each i As DataRow In pos_orig.Rows
                ListBox3.Items.Add("En " & orig & ": " & i.Item(0) & "(" & i.Item(1) & ") desde " & CType(i.Item(2), Date?).DarFormato & " hasta " & CType(i.Item(3), Date?).DarFormato)
            Next
            For Each i As DataRow In pos_dest.Rows
                ListBox3.Items.Add("En " & dest & ": " & i.Item(0) & "(" & i.Item(1) & ") desde " & CType(i.Item(2), Date?).DarFormato & " hasta " & CType(i.Item(3), Date?).DarFormato)
            Next
            ListBox3.Show()
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim qt As New QueryTool
        qt.ShowDialog()
    End Sub
End Class

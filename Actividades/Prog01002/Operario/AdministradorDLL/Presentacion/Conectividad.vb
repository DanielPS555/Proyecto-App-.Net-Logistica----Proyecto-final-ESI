Imports Controladores
Imports GMap.NET

Public Class Conectividad
    Private pos As New Dictionary(Of String, Lugar)
    Private Sub tiposTransporte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tiposTransporte.SelectedIndexChanged
        GMapControl1.Overlays.Clear()
        GMapControl1.Overlays.Add(New GMap.NET.WindowsForms.GMapOverlay("Routes"))
        GMapControl1.Overlays.Single.Markers.Clear()
        GMapControl1.Overlays.Single.Routes.Clear()
        Dim cam As New HashSet(Of String)
        Dim cons = con.Where(Function(x) x.Item3 = tiposTransporte.SelectedIndex + 1)
        If cons.Count > 0 Then
            For Each c In cons
                cam.Add(c.Item1)
                cam.Add(c.Item2)
                If Not pos.ContainsKey(c.Item1) Then
                    pos(c.Item1) = Fachada.getInstancia.informacionBaseDelLugarPorNombre(c.Item1)
                End If
                Dim pos1 = New PointLatLng(pos(c.Item1).PosicionX, pos(c.Item1).PosicionY)
                GMapControl1.Overlays.Single.Markers.Add(New WindowsForms.Markers.GMarkerGoogle(pos1, WindowsForms.Markers.GMarkerGoogleType.red_pushpin))
                If Not pos.ContainsKey(c.Item2) Then
                    pos(c.Item2) = Fachada.getInstancia.informacionBaseDelLugarPorNombre(c.Item2)
                End If
                Dim pos2 = New PointLatLng(pos(c.Item2).PosicionX, pos(c.Item2).PosicionY)
                GMapControl1.Overlays.Single.Markers.Add(New WindowsForms.Markers.GMarkerGoogle(pos2, WindowsForms.Markers.GMarkerGoogleType.red_pushpin))
            Next
            Dim cpoint = New PointF(-34.888116, -56.154605)
            Dim points = cam.Select(Function(x) pos(x)).Select(Function(x) x.Posicion).OrderBy(Function(x) Math.Sqrt(Math.Pow(cpoint.X - x.X, 2) + Math.Pow(cpoint.Y - x.Y, 2))).Select(Function(x) New PointLatLng(x.X, x.Y)).ToList
            Dim route = New GMap.NET.WindowsForms.GMapRoute(points, tiposTransporte.SelectedItem)
            GMapControl1.Overlays.Single.Routes.Add(route)
        End If
        GMapControl1.ZoomAndCenterRoutes("Routes")
    End Sub

    Private medios = {"Camion", "Trenvia", "Maritimo"}
    Private con As List(Of Tuple(Of String, String, Integer)) = Controladores.Fachada.getInstancia.ConexionesLugares

    Private Sub Conectividad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GMapControl1.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance
        GMapControl1.Position = New GMap.NET.PointLatLng(Controladores.Fachada.URUGUAYTOP, Controladores.Fachada.URUGUAYEAST)
        GMapControl1.Zoom = 3
        tiposTransporte.Items.AddRange(medios)
        Dim cg = ConnectionGraph.CreateGraph
        cg.Size = New Size(400, 400)
        cg.Location = New Point(450, 150)
        Me.Controls.Add(cg)
    End Sub
End Class
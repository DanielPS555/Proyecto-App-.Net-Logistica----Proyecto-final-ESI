Imports GMap.NET
Imports GMap.NET.MapProviders
Public Class MapaPanelGrande
    Public Sub New(point As PointLatLng)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        mapa.MapProvider = GMapProviders.GoogleMap
        mapa.Position = point
        mapa.MarkersEnabled = True
        mapa.MinZoom = 0
        mapa.MaxZoom = 24
        mapa.Zoom = 11
        mapa.AutoScroll = True
        Dim overlay = New GMap.NET.WindowsForms.GMapOverlay("markers")
        overlay.Markers.Add(New GMap.NET.WindowsForms.Markers.GMarkerGoogle(point, WindowsForms.Markers.GMarkerGoogleType.red))
        mapa.Overlays.Add(overlay)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Public Sub New(route As Boolean, ParamArray points() As PointLatLng)
        InitializeComponent()
        mapa.MapProvider = GMapProviders.GoogleMap
        mapa.Position = points.First
        mapa.MarkersEnabled = True
        mapa.MinZoom = 0
        mapa.MaxZoom = 24
        mapa.Zoom = 18
        mapa.AutoScroll = True
        Dim overlay = New GMap.NET.WindowsForms.GMapOverlay("markers")
        mapa.Overlays.Add(overlay)
        If Not route Then
            Dim myroute = New WindowsForms.GMapRoute("Ruta del transportista")
            myroute.Points.AddRange(points)
            overlay.Routes.Add(myroute)
        Else
            For i = 0 To points.Count - 2
                overlay.Routes.Add(GMap.NET.MapProviders.GoogleMapProvider.Instance.GetRoute(points(i), points(i + 1), True, False, 1))
            Next
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class
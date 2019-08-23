Imports GMap.NET

Public Class PanelLugar


    Private Sub VerUbicacion_Click_1(sender As Object, e As EventArgs) Handles verUbicacion.Click
        Dim m As New Controladores.MapaPanelGrande(New PointLatLng(lugar.PosicionX, lugar.PosicionY))
        m.ShowDialog()
    End Sub
End Class
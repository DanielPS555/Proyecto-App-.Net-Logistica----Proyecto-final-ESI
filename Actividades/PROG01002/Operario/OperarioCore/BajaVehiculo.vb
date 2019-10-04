Imports Controladores.Vehiculo

Public Class BajaVehiculo
    Public Sub New(Vehicle As Controladores.Vehiculo)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Vehiculo = Vehicle

    End Sub
    Private Vehiculo As Controladores.Vehiculo
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Controladores.Fachada.getInstancia.BajaVehiculo(Vehiculo, TipoBajaVehiculo.Recogido, MensajeBaja.Text)
        Me.Close()
    End Sub
End Class
Public Class BajaVehiculo
    Public Sub New(Vehicle As Controladores.Vehiculo)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Vehiculo = Vehicle

        TipoBaja.Items.Clear()
        TipoBaja.Items.AddRange([Enum].GetValues(GetType(Controladores.Vehiculo.TipoBajaVehiculo)).Cast(Of Object).ToArray)

    End Sub
    Private Vehiculo As Controladores.Vehiculo
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Controladores.Fachada.getInstancia.BajaVehiculo(Vehiculo, TipoBaja.SelectedItem, MensajeBaja.Text)
        Me.Close()
    End Sub
End Class
Public Class EventMessenger
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub EventMessenger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim k = Controladores.Fachada.getInstancia.VehiculosConMensajes()
        vehicleList.Items.AddRange(k.ToArray)
    End Sub

    Private Sub vehicleList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles vehicleList.SelectedIndexChanged
        Dim v = CType(vehicleList.SelectedItem, Controladores.Vehiculo)
        Dim msgs As List(Of String) = Controladores.Fachada.getInstancia.MensajesVehiculo(v)
        RichTextBox1.Text = String.Join(",", msgs.ToArray().Cast(Of Object).ToArray)
    End Sub
End Class
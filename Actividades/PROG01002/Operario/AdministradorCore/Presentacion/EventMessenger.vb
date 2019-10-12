Public Class EventMessenger
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        enviarBtn.Text = Controladores.Funciones_comunes.I18N("Enviar", Controladores.Marco.getInstancia.Language)
    End Sub

    Private Sub EventMessenger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim k = Controladores.Fachada.getInstancia.VehiculosConMensajes()
        Dim t = Controladores.Fachada.getInstancia.InfoVehiculos(k.Select(Function(x) x.Item1.VIN).ToArray).Zip(k, Function(x, y) New Tuple(Of Controladores.Vehiculo, Boolean)(x, y.Item2)).ToList
        vehicleList.Items.AddRange(t.ToArray)
    End Sub

    Private Sub vehicleList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles vehicleList.SelectedIndexChanged
        ActualizarMensajes()
    End Sub

    Private Sub ActualizarMensajes()
        Dim v = CType(vehicleList.SelectedItem, Tuple(Of Controladores.Vehiculo, Boolean))
        Dim msgs As List(Of String) = Controladores.Fachada.getInstancia.MensajesVehiculo(v.Item1)
        RichTextBox1.Text = String.Join(vbNewLine, msgs.ToArray().Cast(Of Object).ToArray)
    End Sub

    Private Sub enviarBtn_Click(sender As Object, e As EventArgs) Handles enviarBtn.Click
        Controladores.Fachada.getInstancia.CargarDataBaseDelUsuario()
        Controladores.Fachada.getInstancia.EnviarMensaje(Controladores.Fachada.getInstancia.DevolverUsuarioActual, CType(vehicleList.SelectedItem, Tuple(Of Controladores.Vehiculo, Boolean)).Item1, messageLine.Text)
        ActualizarMensajes()
    End Sub
End Class
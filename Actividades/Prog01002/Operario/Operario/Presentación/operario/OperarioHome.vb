Public Class OperarioHome
    Public Sub New() 'me tiene que pasar un objeto de tipo usuario


        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub PuertoInicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NombreCompleto.Text = URepo.NombreCompleto
        nombreUsuario.Text = URepo.NombreDeUsuario
        rolUsuario.Text = URepo.RolDeUsuario
        nAccesos.Text = URepo.AccesosAlSistema.ToString
        anteriorIngreso.Text = URepo.UltimoAcceso.DarFormato
    End Sub
End Class
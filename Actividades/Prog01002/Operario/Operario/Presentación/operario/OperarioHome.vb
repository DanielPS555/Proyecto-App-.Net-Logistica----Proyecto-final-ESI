Public Class OperarioHome
    Public Sub New() 'me tiene que pasar un objeto de tipo usuario


        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        NombreCompleto.Text = URepo.NombreCompleto
        nombreUsuario.Text = URepo.NombreDeUsuario
        rolUsuario.Text = URepo.RolDeUsuario
        nAccesos.Text = URepo.AccesosAlSistema.ToString
        anteriorIngreso.Text = URepo.UltimoAcceso.DarFormato
        origenLote.Text = SRepo.ConsultarSingle("select count(*) from lote left join transporta on transporta.idlote=lote.idlote where transporta.transporteid is null;").ToString
        autosAlteados.Text = SRepo.ConsultarSingle($"select count(*) from vehiculoIngresa where Usuario={URepo.UsuarioID} and TipoIngreso='Alta';")
        lotesCreados.Text = SRepo.ConsultarSingle($"select count(*) from lote where creadorID={URepo.UsuarioID};")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Marco.getInstancia.cargarPanel(New PanelInfoUsuario(URepo.UsuarioID))
    End Sub
End Class
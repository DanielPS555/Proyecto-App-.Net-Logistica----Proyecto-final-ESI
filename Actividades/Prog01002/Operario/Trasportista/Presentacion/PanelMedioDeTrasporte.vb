Public Class PanelMedioDeTrasporte
    Public Sub New(idlegal As String)
        InitializeComponent()

        Dim data As Controladores.MedioDeTransporte = Controladores.Fachada.getInstancia.devolverInformacionCompletaDelMedioDeTrasporte(idlegal)
        nombre.Text = data.Nombre
        idpublico.Text = data.ID
        estado.Text = Controladores.Fachada.getInstancia.estadoDeUnMedioDeTrasporte(idlegal)
        tipodeMedio.Text = data.Tipo.Nombre
        fechadeagreacion.Text = data.FechaCreacion
        creadoPor.Text = data.Creador.NombreDeUsuario
        N_autos.Text = data.CantAutos
        n_camiones.Text = data.CantCamiones
        n_suv.Text = data.CantSUV
        n_van.Text = data.CantVAN
        n_minivan.Text = data.CantMiniVan
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("Id usuario"))
        dt.Columns.Add(New DataColumn("Nombre de usuario"))
        For Each u As Controladores.Usuario In data.Conductores
            Dim r As DataRow = dt.NewRow
            r.Item(0) = u.ID_usuario
            r.Item(1) = u.NombreDeUsuario
            dt.Rows.Add(r)
        Next
        userA.DataSource = dt
    End Sub
End Class
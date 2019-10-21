Imports Controladores.Extenciones.Extensiones
Public Class PanelMedioDeTrasporte
    Public Sub New(idlegal As String)
        InitializeComponent()
        Label3.Traducir
        Label2.Traducir
        Label4.Traducir
        Label5.Traducir
        Label6.Traducir
        Label7.Traducir
        Label8.Traducir
        Label9.Traducir
        Label10.Traducir
        Label11.Traducir
        Label12.Traducir
        Label13.Traducir
        Label1.Traducir
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
        dt.Columns.Add(New DataColumn(Controladores.Funciones_comunes.I18N("Id usuario", Controladores.Marco.Language)))
        dt.Columns.Add(New DataColumn(Controladores.Funciones_comunes.I18N("Nombre de usuario", Controladores.Marco.Language)))
        For Each u As Controladores.Usuario In data.Conductores
            Dim r As DataRow = dt.NewRow
            r.Item(0) = u.ID_usuario
            r.Item(1) = u.NombreDeUsuario
            dt.Rows.Add(r)
        Next
        userA.DataSource = dt
    End Sub
End Class
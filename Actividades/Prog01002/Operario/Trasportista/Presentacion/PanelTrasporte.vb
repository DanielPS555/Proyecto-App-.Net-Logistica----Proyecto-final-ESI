Public Class PanelTrasporte
    Public Sub New(idtransporte)
        InitializeComponent()

        Dim t As Controladores.Trasporte = Controladores.Fachada.getInstancia.InformacionCompletaDelTrasporteSIN_LOTES(idtransporte)
        id.Text = t.ID
        conductor.Text = t.Trasportista.NombreDeUsuario
        nombreMedio.Text = t.MedioDeTrasporte.Nombre
        tipoMedio.Text = t.MedioDeTrasporte.Tipo.Nombre
        HoraDeCreacion.Text = t.FechaCreacion
        FechaDeInico.Text = t.FechaSalida
        FechaDeFinalizacionEstimada.Text = t.FechaLLegadaEstimada
        FechaDeFinalizacionReal.Text = t.FechaLLegadaReal
        estado.Text = t.Estado
        lote.DataSource = Controladores.Fachada.getInstancia.listaDeLotesPorTransporte(idtransporte)

    End Sub
End Class
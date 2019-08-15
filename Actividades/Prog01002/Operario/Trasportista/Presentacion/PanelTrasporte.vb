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
        estado.Text = t.Estado
        Dim lotes As DataTable = Controladores.Fachada.getInstancia.listaDeLotesPorTransporte(idtransporte)
        lote.DataSource = lotes

        Dim real As DateTime = lotes.Rows(0).Item(6)
        Dim estimada As DateTime = lotes.Rows(0).Item(5)

        For Each l As DataRow In lotes.Rows
            If l.Item(6) > real Then
                real = l.Item(6)
            End If

            If l.Item(5) > estimada Then
                estimada = l.Item(5)
            End If
        Next


        FechaDeFinalizacionEstimada.Text = estimada
        FechaDeFinalizacionReal.Text = real

    End Sub
End Class
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

        Dim real As DateTime? = Controladores.Funciones_comunes.AutoNull(Of Object)(lotes.Rows(0).Item(6))
        Dim estimada As DateTime? = Controladores.Funciones_comunes.AutoNull(Of Object)(lotes.Rows(0).Item(5))

        For Each l As DataRow In lotes.Rows
            If real IsNot Nothing AndAlso l.Item(6) > real Then
                real = l.Item(6)
            End If

            If estimada IsNot Nothing AndAlso l.Item(5) > estimada Then
                estimada = l.Item(5)
            End If
        Next


        FechaDeFinalizacionEstimada.Text = If(estimada Is Nothing, "SIN INFORMACION", estimada)
        FechaDeFinalizacionReal.Text = If(real Is Nothing, "SIN INFORMACION", real)

    End Sub
End Class
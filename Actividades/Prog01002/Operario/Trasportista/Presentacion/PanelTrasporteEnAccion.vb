Public Class PanelTrasporteEnAccion
    Dim listaDeSUBLote As List(Of SUB_lote)
    Dim listaDeLotes As List(Of Controladores.Lote)
    Dim medioUtilizado As Controladores.MedioDeTransporte
    Public Sub New(listaLotes As List(Of Controladores.Lote), medio As Controladores.MedioDeTransporte)
        InitializeComponent()
        Me.listaDeLotes = listaLotes
        medioUtilizado = medio
        listaDeSUBLote = New List(Of SUB_lote)
        CargarPanales()

    End Sub

    Private Sub CargarPanales()

        Dim destinos As New List(Of Tuple(Of Controladores.Lugar, List(Of Controladores.Lote)))
        For Each l As Controladores.Lote In listaDeLotes
            If Not destinos.Select(Function(x) x.Item1).ToList.Contains(l.Destino) Then
                destinos.Add(New Tuple(Of Controladores.Lugar, List(Of Controladores.Lote))(l.Destino, New List(Of Controladores.Lote)))
            End If
            destinos.Where(Function(x) x.Item1.Nombre.Equals(l.Destino.Nombre)).Single.Item2.Add(l)
        Next

        For Each d As Tuple(Of Controladores.Lugar, List(Of Controladores.Lote)) In destinos
            listaDeSUBLote.Add(New SUB_lote(d.Item2) With {.Width = 400, .Height = 130})
        Next

        des.Controls.Clear()
        If listaDeSUBLote.Count * listaDeSUBLote(0).Height > 540 Then
            des.Height = listaDeSUBLote.Count * listaDeSUBLote(0).Height
        Else
            des.Height = 540
        End If

        For Each p As SUB_lote In listaDeSUBLote
            p.TopLevel = False
            p.Dock = DockStyle.Top
            des.Controls.Add(p)
            p.Show()
        Next
    End Sub

End Class
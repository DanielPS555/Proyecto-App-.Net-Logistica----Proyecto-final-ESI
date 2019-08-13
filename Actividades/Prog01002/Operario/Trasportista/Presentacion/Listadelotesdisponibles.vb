Imports Controladores.Fachada
Public Class Lista_de_trasportes
    Private lotes As New List(Of Controladores.Lote)
    Private paneles As New List(Of SUB_informeLote)
    Private actual As Integer = 0
    Private sub_paneles() As Panel

    Public Sub New()
        InitializeComponent()
        lotes = Controladores.Fachada.getInstancia.DevolverLotesDisponblesCompletos()
        crearPanelesPorLote()
        cargarLosPaneles()
    End Sub

    Public Sub crearPanelesPorLote()
        For Each l As Controladores.Lote In lotes
            paneles.Add(New SUB_informeLote(l))
        Next
    End Sub

    Public Sub cargarLosPaneles()
        ele1.Controls.Clear()
        If paneles.Count > 6 Then
            ele1.Height = paneles.Count * 80
        Else
            ele1.Height = 480
        End If

        For Each p As SUB_informeLote In paneles
            p.TopLevel = False
            p.Dock = DockStyle.Top
            ele1.Controls.Add(p)
            p.Show()
        Next



    End Sub




End Class
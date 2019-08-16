Public Class PanelTrasporteEnAccion
    Dim listaDeSUBLote As List(Of ContenedorLote)
    Dim listaDeLotes As List(Of Controladores.Lote)
    Dim medioUtilizado As Controladores.MedioDeTransporte
    Dim elementosSelecionados As List(Of Integer)
    Public Sub New(listaLotes As List(Of Controladores.Lote), medio As Controladores.MedioDeTransporte)
        InitializeComponent()
        Me.listaDeLotes = listaLotes
        medioUtilizado = medio
        listaDeSUBLote = New List(Of ContenedorLote)
        CargarPanales()
        elementosSelecionados = New List(Of Integer)
    End Sub

    Private Sub CargarPanales()

        Dim destinos As New List(Of Tuple(Of Controladores.Lugar, List(Of Controladores.Lote)))
        For Each l As Controladores.Lote In listaDeLotes
            If Not destinos.Select(Function(x) x.Item1.Nombre).ToList.Contains(l.Destino.Nombre) Then
                destinos.Add(New Tuple(Of Controladores.Lugar, List(Of Controladores.Lote))(l.Destino, New List(Of Controladores.Lote)))
            End If
            destinos.Where(Function(x) x.Item1.Nombre.Equals(l.Destino.Nombre)).Single.Item2.Add(l)
        Next

        For Each d As Tuple(Of Controladores.Lugar, List(Of Controladores.Lote)) In destinos
            listaDeSUBLote.Add(New ContenedorLote() With {.Lotes = d.Item2})
            ListaDestinos.Items.Add(d.Item1.Nombre)
        Next



    End Sub

    Private Sub ListaDestinos_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles ListaDestinos.ItemCheck
        If e.CurrentValue = CheckState.Checked Then
            e.NewValue = CheckState.Checked
            MsgBox("Los lotes de dicho destino ya fueron entregados", MsgBoxStyle.Critical)
            Return
        End If

        If e.CurrentValue = CheckState.Unchecked Then
            If MsgBox("¿Esta seguro que desea confirmar la entrega del lote?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                e.NewValue = CheckState.Checked
            Else
                e.NewValue = CheckState.Unchecked
            End If
        End If


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'CAMBIAR EL TEXTO A TERMINADO
    End Sub
End Class

Public Class ContenedorLote
    Private _selecionado As Boolean
    Public Property Selecionado() As Boolean
        Get
            Return _selecionado
        End Get
        Set(ByVal value As Boolean)
            _selecionado = value
        End Set
    End Property

    Private _lotes As List(Of Controladores.Lote)
    Public Property Lotes() As List(Of Controladores.Lote)
        Get
            Return _lotes
        End Get
        Set(ByVal value As List(Of Controladores.Lote))
            _lotes = value
        End Set
    End Property

    Public Sub New()
        _selecionado = False
    End Sub

End Class
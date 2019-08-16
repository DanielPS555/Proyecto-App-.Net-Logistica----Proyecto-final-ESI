Public Class SUB_lote

    Private _listaLotes As List(Of Controladores.Lote)
    Public Property ListaLostes() As List(Of Controladores.Lote)
        Get
            Return _listaLotes
        End Get
        Set(ByVal value As List(Of Controladores.Lote))
            _listaLotes = value
        End Set
    End Property

    Private _Listo As Boolean
    Public ReadOnly Property Listo() As Boolean
        Get
            Return selecionado.Checked
        End Get
    End Property

    Public Sub New(lista As List(Of Controladores.Lote))
        InitializeComponent()
        _listaLotes = lista
        comprobacion()

        nom.Text = lista(0).Destino.Nombre
        Me.lista.Items.AddRange(lista.Select(Function(x) x.Nombre).ToArray)
    End Sub

    Private Sub comprobacion()

        Dim lug As String = ListaLostes(0).Destino.Nombre
        For Each l As String In ListaLostes.Select(Function(x) x.Destino.Nombre).ToList
            If Not l.Equals(lug) Then
                Throw New Exception("Los destinos deben los lotes deben ser el mismo")
            End If
        Next

    End Sub


End Class
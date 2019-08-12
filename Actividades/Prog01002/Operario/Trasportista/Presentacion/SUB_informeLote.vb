Public Class SUB_informeLote
    Public Sub New(lote As Controladores.Lote)
        InitializeComponent()

        nombre.Text = lote.Nombre
        origen.Text = lote.Origen.Nombre
        destino.Text = lote.Destino.Nombre
        numeroDeVehiculos.Text = lote.Vehiculos.Count

    End Sub

    Private _selecionado As Boolean
    Public ReadOnly Property Selecionado() As Boolean
        Get
            Return selecionar.Checked
        End Get
    End Property
End Class
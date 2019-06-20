Public Class VerInforme
    Private dt As DataTable
    Private infdesc As String
    Public Sub New(dt As Tuple(Of DataTable, String, Integer, Date, String, Integer))
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Me.dt = dt.Item1
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Tipo.Text = dt.Item2
        IDInforme.Text = dt.Item3.ToString
        Fecha.Text = dt.Item4.ToShortDateString
        Descripcion.Text = dt.Item5
        infdesc = dt.Item5
        ComboBox1.Items.Clear()
        For Each i As DataRow In Me.dt.Rows
            ComboBox1.Items.Add(i(0))
        Next
        ComboBox1.Items.Add("Descripcion del Informe")
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem.Equals("Descripcion del Informe") Then
            Descripcion.Text = infdesc
        Else
            Descripcion.Text = dt.ToList.Where(Function(x) x(0).ToString = ComboBox1.SelectedItem).Select(Function(x) x(1)).Single
        End If
    End Sub
End Class
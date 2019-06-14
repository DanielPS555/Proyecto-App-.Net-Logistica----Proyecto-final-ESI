Public Class DoubleDict(Of T1, T2)
    Inherits Dictionary(Of T1, List(Of Dictionary(Of T1, Predicate(Of T2))))
End Class

Public Class FilterGridView
    Public DT As DataTable
    Public Filters As DoubleDict(Of String, DataRow)
    Public Filter As New List(Of Predicate(Of DataRow))
    Public Sub New(DT As DataTable, Filters As DoubleDict(Of String, DataRow))
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FilterName.Items.Clear()
        FilterName.Items.AddRange(Filters.Keys.ToArray)
    End Sub
    Public Sub FilterSelect() Handles FilterName.SelectedValueChanged
        FilterValue.Items.Clear()
        FilterValue.Items.AddRange(Filters(FilterName.SelectedItem))
    End Sub
End Class

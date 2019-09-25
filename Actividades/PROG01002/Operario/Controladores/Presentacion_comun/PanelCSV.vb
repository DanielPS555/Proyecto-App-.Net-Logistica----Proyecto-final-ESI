Public Class PanelCSV
    Private csvreader As PICSVReader
    Private cols() As String
    Public ColumnCount As Integer? = Nothing
    Private Sub New(ParamArray columns() As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cols = columns

    End Sub

    Public Shared Function ReadCSV(ParamArray columns() As String) As DataTable
        Dim pcsv As New PanelCSV(columns)
        Dim dt As DataTable = Nothing
        If pcsv.ShowDialog = DialogResult.OK Then
            dt = pcsv.csvreader.ToDataTable
        End If
        If pcsv.csvreader IsNot Nothing Then
            pcsv.csvreader.Close()
        End If
        Return dt
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles OpenBtn.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "Archivos CSV|*.csv"
        }
        If ofd.ShowDialog = DialogResult.OK Then
            csvreader = New PICSVReader(ofd.OpenFile, cols)
            ColumnCount = csvreader.ColumnCount
            Dim dt As New DataTable("Columnas")
            dt.Columns.Add("Columna")
            dt.Columns.Add("Posición", GetType(Integer))
            For Each p In csvreader.Positions
                dt.Rows.Add(p.Key, p.Value)
            Next
            ColTable.DataSource = dt
            ColTable.Columns.Item(0).ReadOnly = True
            If csvreader.Positions.Where(Function(x) x.Value Is Nothing).Count = 0 Then
                GenDataTable()
                okbtn.Enabled = True
            Else
                okbtn.Enabled = False
            End If
        End If
    End Sub

    Private Sub GenDataTable()
        DataTable.DataSource = csvreader.ToDataTable
        DataTable.ReadOnly = True
    End Sub

    Private Sub ColTable_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles ColTable.CellEndEdit
        Dim dgvc As DataGridViewCell = ColTable.Rows.Item(e.RowIndex).Cells.Item(e.ColumnIndex)

        If dgvc.Value IsNot Nothing And Integer.Parse(dgvc.Value.ToString) > csvreader.ColumnCount - 1 Then
            dgvc.Value = 0
            Return
        End If
        For Each r In ColTable.Rows.Cast(Of DataGridViewRow)
            csvreader.Positions(r.Cells(0).Value) = If(r.Cells(1).Value.ToString.Length < 1, Nothing, r.Cells(1).Value)
        Next
        If csvreader.Positions.Where(Function(x) x.Value Is Nothing).Count = 0 Then
            GenDataTable()
            okbtn.Enabled = True
        Else
            okbtn.Enabled = False
        End If
    End Sub
End Class
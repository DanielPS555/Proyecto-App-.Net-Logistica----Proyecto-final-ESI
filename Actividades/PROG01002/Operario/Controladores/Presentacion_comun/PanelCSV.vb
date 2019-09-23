Public Class PanelCSV
    Private csvreader As PICSVReader
    Private cols() As String
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
        pcsv.csvreader.Close()
        Return dt
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles OpenBtn.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "Archivos CSV|*.csv"
        }
        If ofd.ShowDialog = DialogResult.OK Then
            csvreader = New PICSVReader(ofd.OpenFile, cols)
        End If
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
    End Sub

    Private Sub GenDataTable()
        DataTable.DataSource = csvreader.ToDataTable
        DataTable.ReadOnly = True
    End Sub

    Private Sub ColTable_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles ColTable.CellEndEdit
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
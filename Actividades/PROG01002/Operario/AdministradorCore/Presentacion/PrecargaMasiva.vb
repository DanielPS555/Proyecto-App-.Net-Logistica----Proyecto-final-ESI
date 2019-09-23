Imports System.Windows.Forms
Imports Controladores

Public Class PrecargaMasiva
    Private Sub openCSV_Click(sender As Object, e As EventArgs) Handles openCSV.Click
        Dim cols(OptionalColumns.CheckedItems.Count) As String
        OptionalColumns.CheckedItems.CopyTo(cols, 1)
        cols(0) = "VIN"
        Dim k = PanelCSV.ReadCSV(cols)
        If k Is Nothing Then
            Return
        End If
        If Not k.Columns.Contains("Marca") Then
            k.Columns.Add("Marca")
        End If
        If Not k.Columns.Contains("Modelo") Then
            k.Columns.Add("Modelo")
        End If
        For Each r In k.Rows.Cast(Of DataRow)
            Dim nr = dt.NewRow()
            For i = 0 To r.ItemArray.Length - 1
                nr(i) = r(i)
            Next
            dt.Rows.Add(nr)
        Next
    End Sub

    Private dt As DataTable

    Private Sub PrecargaMasiva_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dt = New DataTable("Precargas")
        For Each c In preloadGrid.Columns.Cast(Of DataGridViewColumn)
            dt.Columns.Add(c.Name, GetType(String))
        Next
        preloadGrid.Columns.Clear()
        preloadGrid.DataSource = dt
    End Sub
End Class
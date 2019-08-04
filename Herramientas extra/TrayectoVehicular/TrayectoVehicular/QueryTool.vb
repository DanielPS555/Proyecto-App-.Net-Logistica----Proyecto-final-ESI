Imports System.Text.RegularExpressions

Public Class QueryTool
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim variables As New List(Of Object)
        For Each i As DataGridViewRow In DataGridView1.Rows
            Dim cbb As DataGridViewComboBoxCell = i.Cells.Item(0)
            Select Case cbb.Value
                Case "Int"
                    variables.Add(Integer.Parse(i.Cells.Item(1).Value))
                Case "String"
                    variables.Add(i.Cells.Item(1).Value)
            End Select
        Next
        If variables.Count < Regex.Matches(TextBox1.Text, "\?").Count Then
            MsgBox("Faltan variables, por favor agreguelas")
            Return
        End If
        Dim dt = Controladores.Persistencia.getInstancia.Consultar(TextBox1.Text, variables.ToArray)
        DataGridView2.DataSource = dt
    End Sub
End Class
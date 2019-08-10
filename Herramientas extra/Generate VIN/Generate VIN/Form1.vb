Public Class Form1
    Private VINChars As String = Nothing
    Private rd As New Random
    Private Function GenVin() As String
        If VINChars Is Nothing Then
            VINChars = ""
            For i = 0 To 9
                VINChars += ChrW(AscW("0") + i)
            Next
            For c = AscW("A") To AscW("Z")
                VINChars += ChrW(c)
            Next
        End If
        Dim vin(16) As Char

        For i = 0 To 16
            vin(i) = VINChars(rd.Next(VINChars.Length))
        Next
        Return vin
    End Function
    Private Function GenInsert() As String
        Dim clientes() = {"Sevel", "Chevrolet UY"}
        Dim str = "insert into vehiculo(vin,cliente,tipo) values('" + GenVin() + "', (select IDCliente from cliente where nombre='" + clientes(rd.Next(2)) + "'), 'Auto');"
        Return str
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListBox1.Items.Add(GenInsert)
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim strs As New List(Of String)
        For Each i As String In ListBox1.SelectedItems
            strs.Add(i)
        Next
        TextBox1.Lines = strs.ToArray
    End Sub
End Class

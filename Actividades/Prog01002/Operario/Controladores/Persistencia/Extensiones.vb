Imports System.Data.Odbc
Namespace Extenciones
    Public Module Extensiones
        <Runtime.CompilerServices.Extension>
        Public Function DarFormato(fecha As Date?) As String
            Return If(fecha IsNot Nothing, fecha?.ToString("yyyy/MM/dd a la\s HH:mm:ss"), "Nunca")
        End Function
        <Runtime.CompilerServices.Extension>
        Public Function UnionListas(Of T1)(Listas As IEnumerable(Of IEnumerable(Of T1))) As IEnumerable(Of T1)
            Dim lista As New List(Of T1)
            For Each l In Listas
                lista.AddRange(l)
            Next
            Return lista
        End Function

        <Runtime.CompilerServices.Extension>
        Public Function Transpose(table As DataTable) As DataTable
            Dim dt As New DataTable(table.TableName + " transposed")
            dt.Columns.Add("Columna")
            For i = 1 To table.Rows.Count
                dt.Columns.Add($"{i}")
            Next
            For Each c As DataColumn In table.Columns
                Dim dr = dt.NewRow
                dr(0) = c.ColumnName
                For i = 1 To table.Rows.Count
                    dr(i) = table.Rows(i - 1)(c)
                Next
                dt.Rows.Add(dr)
            Next
            Return dt
        End Function

        Delegate Sub T2Delegate(Of T1, T2)(arg1 As T1, arg2 As T2)

        Delegate Sub T1Delegate(Of T1)(arg As T1)
        <Runtime.CompilerServices.Extension>
        Public Sub ForEach(Of T1)(Enumerable As IEnumerable(Of T1), fn As T1Delegate(Of T1))
            For Each i In Enumerable
                fn(i)
            Next
        End Sub

        <Runtime.CompilerServices.Extension>
        Public Function SubArray(Of T1)(Array As IEnumerable(Of T1), start As UInteger, length As UInteger) As T1()
            Dim retArray(length - 1) As T1
            For i = start To start + length - 1
                retArray(i - start) = Array(i)
            Next
            Return retArray
        End Function

        <Runtime.CompilerServices.Extension>
        Public Function CrearParametro([this] As OdbcCommand, type As DbType, value As Object) As OdbcParameter
            Dim par = this.CreateParameter
            par.DbType = type
            par.Value = value
            this.Parameters.Add(par)
            Return par
        End Function

        <Runtime.CompilerServices.Extension>
        Public Function Multiply(Of T)([this] As T, times As Integer) As IEnumerable(Of T)
            Dim r As New List(Of T)
            For i = 1 To times
                r.Add(this)
            Next
            Return r
        End Function

        <Runtime.CompilerServices.Extension>
        Public Function Repeat([this] As String, times As Integer) As String
            Dim r = ""
            For i = 1 To times
                r += this
            Next
            Return r
        End Function
    End Module
End Namespace

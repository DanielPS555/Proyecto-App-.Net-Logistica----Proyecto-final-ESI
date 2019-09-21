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

        Public Sub MsgBoxI18N(originalString As String, Optional msgStyle As MsgBoxStyle = MsgBoxStyle.Information)
            MsgBox(Funciones_comunes.I18N(originalString, Marco.Language), msgStyle)
        End Sub

        Public Function MsgBoxI18NFormat(originalString As String, msgStyle As MsgBoxStyle, ParamArray values() As Object) As MsgBoxResult
            Return MsgBox(String.Format(Funciones_comunes.I18N(originalString, Marco.Language), values), msgStyle)
        End Function

        Public Sub MsgBoxI18NFormat(originalString As String, ParamArray values() As Object)
            MsgBox(String.Format(Funciones_comunes.I18N(originalString, Marco.Language), values))
        End Sub

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
        Delegate Sub LambdaDelegate()

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
        Public Function CrearParametro([this] As OdbcCommand, nombre As String, type As DbType, value As Object) As OdbcParameter ' Nombrado
            Dim par = this.Parameters.Add(nombre, type)
            par.Value = value
            Return par
        End Function

        <Runtime.CompilerServices.Extension>
        Public Function CrearParametro([this] As OdbcCommand, type As DbType, value As Object) As OdbcParameter ' Posicional
            Dim par = this.Parameters.Add(New OdbcParameter())
            par.DbType = type
            par.IsNullable = True
            par.Value = value
            Return par
        End Function
        <Runtime.CompilerServices.Extension>
        Public Function CrearParametro([this] As OdbcCommand, value As Object) As OdbcParameter ' Posicional autotipado
            Dim dbtype As DbType
            Select Case (value.GetType)
                Case GetType(String)
                    dbtype = DbType.String
                Case GetType(Integer)
                    dbtype = DbType.Int32
                Case GetType(Long)
                    dbtype = DbType.Int64
                Case GetType(Char)
                    dbtype = DbType.Byte
                Case GetType(Date())
                    dbtype = DbType.DateTime
                Case GetType(Single)
                    dbtype = DbType.Single
                Case GetType(Double)
                    dbtype = DbType.Double
                Case Else
                    dbtype = DbType.Binary
            End Select
            Return this.CrearParametro(dbtype, value)
        End Function


        <Runtime.CompilerServices.Extension>
        Public Function ToList(dt As DataTable) As List(Of DataRow)
            Dim newlist As New List(Of DataRow)
            For Each i In dt.Rows
                newlist.Add(i)
            Next
            Return newlist
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

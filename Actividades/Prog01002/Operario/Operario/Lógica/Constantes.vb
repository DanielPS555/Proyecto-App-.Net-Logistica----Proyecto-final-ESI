Namespace Logica
    Public Module Constantes
        Public Roles() As Role = {New Role("Operario"), New Role("Transportista"), New Role("Administrador")}
        Public Function AutoNull(Of T)(data As Object) As T
            If data Is DBNull.Value Then
                Return Nothing
            End If
            Return data
        End Function
        Public Function TipoFromString(tipo As String) As TipoLugar
            Select Case tipo.ToLower
                Case "puerto"
                    Return TipoLugar.Puerto
                Case "patio"
                    Return TipoLugar.Patio
                Case Else
                    Return Nothing
            End Select
        End Function
        Public Function SexoFromString(sexo As String) As Sexo
            Select Case sexo
                Case "m"
                    Return Logica.Sexo.Masculino
                Case "f"
                    Return Logica.Sexo.Femenino
                Case "o"
                    Return Logica.Sexo.Otro
                Case Else
                    Return Nothing
            End Select
        End Function
        Public Function RoleFromID(ID As Integer) As Role
            Return Roles(ID - 1)
        End Function
    End Module
End Namespace
Module Extensiones
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
End Module
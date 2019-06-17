Namespace Logica
    Public Module Constantes
        Public Roles() As Role = {New Role("Operario"), New Role("Admin")}
        Public Function UnionListas(Of T1)(A As IEnumerable(Of T1), B As IEnumerable(Of T1)) As IList(Of T1)
            Dim list As New List(Of T1)
            list.AddRange(A)
            list.AddRange(B)
            Return list
        End Function
        Public Function UnionListas(Of T1)(Listas As IEnumerable(Of IEnumerable(Of T1))) As List(Of T1)
            Dim lista As New List(Of T1)
            For Each l In Listas
                lista.AddRange(l)
            Next
            Return lista
        End Function


    End Module
End Namespace
Module Extensiones
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
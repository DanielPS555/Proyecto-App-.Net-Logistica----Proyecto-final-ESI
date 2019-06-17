Namespace Logica
    Public Module Constantes
        Public Roles() As Role = {New Role("Operario")}
        Public URepo As IUsuarioRepositorio = Nothing
        Public LRepo As ILugarRepositorio = Nothing
        Public VRepo As VehiculoRepo = Nothing
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
Namespace Logica
    Public Module Constantes
        Public Roles() As Role = {New Role("Operario"), New Role("Transportista"), New Role("Administrador")}
        Public Function UnionListas(Of T1)(A As IEnumerable(Of T1), B As IEnumerable(Of T1)) As IList(Of T1)
            Dim list As New List(Of T1)
            list.AddRange(A)
            list.AddRange(B)
            Return list
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
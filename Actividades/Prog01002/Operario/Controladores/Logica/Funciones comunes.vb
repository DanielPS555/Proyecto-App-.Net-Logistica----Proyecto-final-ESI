Imports Controladores.Extenciones.Extensiones
Public Class Funciones_comunes
    Public Shared Function ContraseñaHash(password As String) As String
        Dim mysha = System.Security.Cryptography.SHA1Managed.Create
        Dim barray = System.Text.UTF8Encoding.UTF8.GetBytes(password)
        Dim result As New System.Text.StringBuilder
        mysha.ComputeHash(barray).Select(Function(x) x.ToString("X2")).ForEach(Sub(x)
                                                                                   result.Append(x)
                                                                               End Sub)
        Return result.ToString
    End Function

    Public Shared Function AutoNull(Of T)(data As Object) As T
        If data Is DBNull.Value Then
            Return Nothing
        End If
        Return data
    End Function

    Public Shared Function DarFormato(fecha As Date?) As String
        Return If(fecha IsNot Nothing, fecha?.ToString("yyyy/MM/dd a la\s HH:mm:ss"), "Nunca")
    End Function
End Class

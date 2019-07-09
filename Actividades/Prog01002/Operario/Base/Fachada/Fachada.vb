Public Class Fachada
    Private Shared initi As Fachada

    Private Sub New()

    End Sub

    Public Function getInstancia() As Fachada
        If initi Is Nothing Then
            initi = New Fachada()
        End If
        Return initi
    End Function
End Class

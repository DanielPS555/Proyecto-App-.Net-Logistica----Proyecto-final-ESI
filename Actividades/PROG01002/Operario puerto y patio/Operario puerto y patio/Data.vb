Public Class Data
    Private Shared _login As ILogin = Nothing
    Public Shared ReadOnly Property Login As ILogin
        Get
            If IsNothing(_login) Then
                _login = New ODBCLogin
            End If
            Return _login
        End Get
    End Property
End Class

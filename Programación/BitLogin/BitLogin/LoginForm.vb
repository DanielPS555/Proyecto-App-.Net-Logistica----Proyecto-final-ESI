Imports System.ComponentModel

Public Class LoginForm
    Private lang As String
    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lang = System.Threading.Thread.CurrentThread.CurrentCulture.Name.Split("-")(0)
    End Sub
    Private Sub AsignarLenguaje(lang As String)
        For Each i As Control In Me.Controls
            Dim rsrc As ComponentResourceManager = New ComponentResourceManager(GetType(LoginForm))
            rsrc.ApplyResources(i, i.Name, New Globalization.CultureInfo(lang))
        Next
    End Sub
    Private Sub LanguageButton_Click(sender As Object, e As EventArgs) Handles LanguageButton.Click
        Select Case lang
            Case "en"
                lang = "es"
            Case "es"
                lang = "en"
        End Select
        AsignarLenguaje(lang)
    End Sub

    Private Sub LoginButton_Click(sender As Object, e As EventArgs) Handles LoginButton.Click
        Dim user As BitLogic.User = BitLogic.Data.Login.UserLogin(UsuarioTextBox.Text, ContraTextBox.Text)
        If Not (IsNothing(user)) Then
            Select Case user.Rol
                Case user.Type.OperadorPlaza
                    Dim pw As New PortWindow
                    pw.Show()
                    Me.Close()
                Case user.Type.OperadorPuerto
                    Select Case lang
                        Case "es"
                            MsgBox("Puerto")
                        Case "en"
                            MsgBox("Port")
                    End Select
            End Select
        Else
            Select Case lang
                Case "es"
                    MsgBox("Wrong username or password")
                Case "en"
                    MsgBox("Usuario o contraseña incorrecto")
            End Select
        End If
    End Sub
End Class

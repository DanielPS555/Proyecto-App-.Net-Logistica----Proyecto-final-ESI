Public Class RestablecerContraseña
    Private timer As New Timer
    Private sprites As New List(Of Bitmap)
    Private ctr As Integer
    Private idle As Boolean
    Private frames As Integer
    Private tried As Boolean
    Public Function limit(min As Integer, max As Integer, x As Integer) As Integer
        If x < min Then
            Return max
        ElseIf x > max Then
            Return min
        Else
            Return x
        End If
    End Function
    Public Function ceil(x As Integer, max As Integer) As Integer
        If x > max Then
            Return max
        Else Return x
        End If
    End Function
    Private _tried As Boolean = False

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tried = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class
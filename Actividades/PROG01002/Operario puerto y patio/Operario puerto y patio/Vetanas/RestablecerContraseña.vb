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
    Private Sub RestablecerContraseña_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim _r = ODBCLogin.Connection.State
        Dim pos() As Point
        pos = {0, 15, 30, 45, 60, 75, 90, 105, 110, 125, 125, 125, 125, 130, 145, 165, 190, 210, 240}.Select(Of Point)(Function(x) New Point(x, 400)).ToArray
        ReDim Preserve pos(25)
        For i = 19 To 25
            pos(i) = New Point(240, 400)
        Next
        Dim tls(25) As Integer
        For i = 0 To 9
            tls(i) = i Mod 4
        Next
        For i = 10 To 12
            tls(i) = (i Mod 10) + 4
        Next
        For i = 13 To 18
            tls(i) = i Mod 4
        Next
        For i = 19 To 25
            tls(i) = (i Mod 5) + 7
        Next
        Dim fsprites = IO.Directory.GetFiles("C:\Users\darkfm\Downloads\parallax backgound pack").Where(Function(x) x.EndsWith("png"))
        For i = 0 To fsprites.Count
            Console.WriteLine($"{i}: {fsprites(i)}")
        Next
        sprites = fsprites.Select(Function(x) New Bitmap(IO.File.OpenRead(x))).ToList
        Dim sprs() As Bitmap = {57, 58, 59, 60, 45, 46, 47, 0, 1, 2, 3, 4}.Select(Of Bitmap)(Function(x) sprites(x)).ToArray
        Dim obj As New AnimationPlayer.ATuple(pos.ToList, sprs.ToList, tls.ToList)
        AnimationPlayer1.animTuples.Add(obj)
        AnimationPlayer1.statics.Add(New AnimationPlayer.STuple(New Point(0, 25), sprites(78), 0))
        AnimationPlayer1.statics.Add(New AnimationPlayer.STuple(New Point(0, 25), sprites(79), 1))
        AnimationPlayer1.statics.Add(New AnimationPlayer.STuple(New Point(250, 350), sprites(72), 2))
        AnimationPlayer1.statics.Last.scale = 0.5F
        timer.Interval = 1000 / 30
        AddHandler timer.Tick, Sub()
                                   If AnimationPlayer1.frame < 10 AndAlso Not idle Then
                                       AnimationPlayer1.frame += 1
                                       If AnimationPlayer1.frame > 9 Then
                                           idle = True
                                       End If
                                   ElseIf idle AndAlso Not tried Then
                                       AnimationPlayer1.frame = limit(10, 12, AnimationPlayer1.frame + 1)
                                   Else
                                       AnimationPlayer1.frame = ceil(AnimationPlayer1.frame + 1, 25)
                                       If (AnimationPlayer1.frame = 25 AndAlso Not _tried) Then
                                           Dim pwd = BCrypt.Net.BCrypt.HashPassword(TextBox3.Text)
                                           Dim updPwd = Data.Login.PConnection.CreateCommand()
                                           If Not _tried Then
                                               updPwd.CommandText = "update usuario set hash_contra=? where preguntasecreta=? and respuestasecreta=? and nombredeusuario=?;"
                                               updPwd.CrearParametro(Odbc.OdbcType.Char, "hash", pwd, False)
                                               updPwd.CrearParametro(Odbc.OdbcType.VarChar, "ps", TextBox1.Text, False)
                                               updPwd.CrearParametro(Odbc.OdbcType.VarChar, "rs", TextBox2.Text, False)
                                               updPwd.CrearParametro(Odbc.OdbcType.VarChar, "usr", TextBox4.Text, False)
                                           End If
                                           If updPwd.ExecuteNonQuery <> 1 Then
                                               AnimationPlayer1.frame = 0
                                               tried = False
                                               MsgBox("Error! respuesta o pregunta incorrecta")
                                           Else
                                               If Not _tried Then
                                                   AnimationPlayer1.statics.Last.b = sprites(74)
                                                   _tried = True
                                                   MsgBox("Restaurada con éxito!")
                                               End If
                                           End If
                                       End If
                                   End If
                                   AnimationPlayer1.Invalidate()
                               End Sub
        timer.Start()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tried = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class
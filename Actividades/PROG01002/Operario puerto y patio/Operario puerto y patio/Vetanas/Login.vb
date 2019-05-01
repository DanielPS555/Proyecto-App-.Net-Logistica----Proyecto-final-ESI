Public Class Login
    Private contraseñaVisible As Boolean = False
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Tiempo.Tick, user.TextChanged 'se ejecuta un reloj cada 0.5 segundos
        fecha.Text = DateTime.Now.Day & "/" & DateTime.Now.Month & "/" & DateTime.Now.Year 'Ingresa la fecha
        If DateTime.Now.Second < 10 Then
            hora.Text = DateTime.Now.Hour & ":" & DateTime.Now.Minute & ":0" & DateTime.Now.Second 'Ingresa la hora
        Else
            hora.Text = DateTime.Now.Hour & ":" & DateTime.Now.Minute & ":" & DateTime.Now.Second 'Ingresa la hora
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        tiempo.Start()
    End Sub

    Private Sub user_Enter(sender As Object, e As EventArgs) Handles user.Enter
        If user.Text = "Nombre de usuario" Then
            user.Text = ""
            user.ForeColor = Color.FromArgb(28, 28, 28)

        End If
        e1.BackColor = Color.FromArgb(18, 115, 201)
    End Sub

    Private Sub user_Leave(sender As Object, e As EventArgs) Handles user.Leave
        Dim espaciosEnBlancoPrevios As Integer = 0
        For i As Integer = 0 To user.Text.Length - 1
            If user.Text.Chars(i) = " " Then
                espaciosEnBlancoPrevios += 1
            Else
                Exit For
            End If
        Next
        If espaciosEnBlancoPrevios = user.Text.Length Then
            user.Text = "Nombre de usuario"
            user.ForeColor = Color.FromArgb(100, 100, 100)

        End If
        e1.BackColor = Color.FromArgb(23, 23, 23)
    End Sub


    Private Sub pass_Leave(sender As Object, e As EventArgs) Handles pass.Leave
        If 0 = pass.Text.Length Then
            pass.Text = "Contraseña"
            pass.PasswordChar = ""
            ver.Image = Global.Operario_puerto_y_patio.My.Resources.ojo
            ver.Enabled = False
            pass.ForeColor = Color.FromArgb(100, 100, 100)

        End If
        e2.BackColor = Color.FromArgb(23, 23, 23)
    End Sub

    Private Sub pass_Enter(sender As Object, e As EventArgs) Handles pass.Enter
        If pass.Text = "Contraseña" Then
            pass.Text = ""
            pass.PasswordChar = "*"
            ver.Image = Global.Operario_puerto_y_patio.My.Resources.ojo
            ver.Enabled = True
            pass.ForeColor = Color.FromArgb(28, 28, 28)

        End If
        e2.BackColor = Color.FromArgb(18, 115, 201)
    End Sub

    Private Sub ver_Click(sender As Object, e As EventArgs) Handles ver.Click
        If Not contraseñaVisible Then
            contraseñaVisible = True
            pass.PasswordChar = ""
            ver.Image = Global.Operario_puerto_y_patio.My.Resources.ojo_no
        Else
            contraseñaVisible = False
            pass.PasswordChar = "*"
            ver.Image = Global.Operario_puerto_y_patio.My.Resources.ojo
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        login()
    End Sub

    Private Sub login()
        'AQUI SE REALIZA EL LOGIN, VERIFICAMOS SI EL USUARIO EXSISTE EN LA BBDD, SI ES ASI BUSCAMOS A QUE ROL PERTENECE Y ABRIMOS SU VENTANA

        'POR EL MOMENTO, HASTA QUE NO SEPAMOS DONDE ESTARA LA BBDD ENTREMOS DOS USUARIOS, UNO PARA PATIO Y OTRO PARA PUERTO, si quieen lo podemos hacer con un CSV, los demas datos capas los
        ' guardamos en la fachada hasta no tener un BBDD 
        'USUARIO DEL PUERTO 
        If user.Text.ToUpper = "PUERTO" And pass.Text = "123" Then 'esto luego se motifica por la verficacion real 
            Principal.getInstancia.cargarPanel(Of MarcoPuerto)()
        ElseIf user.Text.ToUpper = "PATIO" And pass.Text = "123" Then
            Principal.getInstancia.cargarPanel(Of MarcoPatio)()
        Else
            estado.ForeColor = Color.FromArgb(178, 8, 20)
        End If


    End Sub


    Private Sub user_KeyDown(sender As Object, e As KeyEventArgs) Handles user.KeyDown, pass.KeyDown, Button1.KeyDown
        If e.KeyData = Keys.Enter Then
            login()
        End If
    End Sub

    Private Sub panelLogin_Paint(sender As Object, e As PaintEventArgs) Handles panelLogin.Paint

    End Sub
End Class
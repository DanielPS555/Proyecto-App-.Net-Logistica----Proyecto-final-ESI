Imports System.Data.Odbc
Imports System.IO
Imports System.Text
Imports Microsoft.Win32

Public Class Login
    Private contraseñaVisible As Boolean = False

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Button1.Visible = True 'SACA LA PARTE QUE LOS HACE NO INVISIBLES DONDE SEA QUE ESTE 
        Button3.Visible = True
        Button1.Enabled = True
        Button3.Enabled = True
        conectar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Tiempo.Tick 'se ejecuta un reloj cada 0.5 segundos
        Dim Tiempo As DateTime = DateTime.Now
        fecha.Text = Tiempo.ToString("dd MMMM yyyy") ' dd -> día en formato 01, 02, ..., 31. MMMM -> nombre completo del mes (enero, febrero, ..., diciembre). yyyy -> año en formato 1900, 1901, ..., 2019.
        hora.Text = Tiempo.ToString("HH:mm:ss") ' HH -> hora en formato 24hs. mm -> minutos del 00 al 59. ss -> segundos del 00 al 59
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Tiempo.Start()
        Me.AcceptButton = Button1 ' al asignar Button1 a la propiedad AcceptButton, el evento Click de Button1 será ejecutado al presionar enter

    End Sub

    Private Sub user_Enter(sender As Object, e As EventArgs) Handles user.Enter
        If user.Text = "Nombre de usuario" Then
            user.Text = ""
            user.ForeColor = Color.FromArgb(28, 28, 28)
        End If
        e1.BackColor = Color.FromArgb(18, 115, 201)
    End Sub

    Private Sub user_Leave(sender As Object, e As EventArgs) Handles user.Leave
        If String.IsNullOrEmpty(user.Text.TrimStart()) Then
            user.Text = "Nombre de usuario"
            user.ForeColor = Color.FromArgb(100, 100, 100)
        End If
        e1.BackColor = Color.FromArgb(23, 23, 23)
    End Sub


    Private Sub pass_Leave(sender As Object, e As EventArgs) Handles pass.Leave
        If 0 = pass.Text.Length Then
            pass.Text = "Contraseña"
            pass.PasswordChar = ""
            ver.Enabled = False
            pass.ForeColor = Color.FromArgb(100, 100, 100)
        End If
        e2.BackColor = Color.FromArgb(23, 23, 23)
    End Sub

    Private Sub pass_Enter(sender As Object, e As EventArgs) Handles pass.Enter
        If pass.Text = "Contraseña" Then
            pass.Text = ""
            If contraseñaVisible Then ' asignar diseño de acuerdo al estado de contraseñaVisible
                ver.Image = Global.Operario.My.Resources.ojo_no
                pass.PasswordChar = ""
            Else
                ver.Image = Global.Operario.My.Resources.ojo
                pass.PasswordChar = "*"
            End If
            ver.Enabled = True
            pass.ForeColor = Color.FromArgb(28, 28, 28)
        End If
        e2.BackColor = Color.FromArgb(18, 115, 201)
    End Sub

    Private Sub ver_Click(sender As Object, e As EventArgs) Handles ver.Click
        If Not contraseñaVisible Then
            contraseñaVisible = True
            pass.PasswordChar = ""
            ver.Image = Global.Operario.My.Resources.ojo_no
        Else
            contraseñaVisible = False
            pass.PasswordChar = "*"
            ver.Image = Global.Operario.My.Resources.ojo
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        login()
    End Sub

    Private Sub login()
        Dim usuario = Constantes.URepo.Login(user.Text, pass.Text)
        If usuario Is Nothing Then
            MsgBox("Credenciales incorrectas. Intente nuevamente")
        Else
            Principal.getInstancia.cargarPanel(Of LugarDeTrabajo)(New LugarDeTrabajo)
        End If
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Principal.getInstancia.cargarPanel(Of RestablecerContraseña)(New RestablecerContraseña)
    End Sub

    Private con As New Odbc.OdbcConnection

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim config As New ConfiguracionRed(Me)
        config.ShowDialog()

    End Sub

    Public Function conectar(ip As String, port As String, servername As String, uid As String, pwd As String, db As String) As Integer
        Try
            Dim creacion As String = "Driver=IBM INFORMIX ODBC DRIVER (64-bit);Database=" & db & ";Host=" & ip & ";Server=" & servername & ";Service=" &
            port & ";Uid=" & uid & "; Pwd=" & pwd & ";"
            MsgBox(creacion)
            Dim con As New OdbcConnection(creacion)
            con.Open()
            URepo = New SQLRepo(con)
            LRepo = URepo
            VRepo = URepo
            SRepo = URepo
            estadoConex.Text = "Conectado"
            estadoConex.ForeColor = Color.FromArgb(14, 160, 36)
            Button1.Enabled = True
            Button3.Enabled = True
            Return 1
        Catch ee As Exception
            estadoConex.Text = "Desconectado"
            estadoConex.ForeColor = Color.FromArgb(180, 20, 20)
            Button1.Enabled = False
            Button3.Enabled = False
            Return 0

        End Try
    End Function

    Private Function conectar() As Integer
        Try

            Dim ip = "192.168.1.12" 'MIRA QUE ANDA AUNQUE LE CAMBIE LA IP!!!!
            Dim port = "9088"
            Dim servername = "ol_esi"
            Dim uid = "root" 'CAMBIAR LUEGO
            Dim pwd = "daniel2001" 'CAMBIAR LUEGO
            Dim db = "bit"
            Dim creacion As String = "Driver=IBM INFORMIX ODBC DRIVER (64-bit);Database=" & db & ";Host=" & ip & ";Server=" & servername & ";Service=" &
            port & ";Uid=" & uid & "; Pwd=" & pwd & ";"
            Dim con As New OdbcConnection(creacion)
            con.Open()


            URepo = New SQLRepo(con)
            LRepo = URepo
            VRepo = URepo
            estadoConex.Text = "Conectado"
            estadoConex.ForeColor = Color.FromArgb(14, 160, 36)
            Button1.Enabled = True
            Button3.Enabled = True
            Return 1
        Catch ee As Exception
            estadoConex.Text = "Desconectado"
            estadoConex.ForeColor = Color.FromArgb(180, 20, 20)
            Button1.Enabled = False
            Button3.Enabled = False
            Return 0
        End Try
    End Function

    Public Function pruebaConect(ip As String, port As String, servername As String, uid As String, pwd As String, db As String) As Integer
        Try
            Dim creacion As String = "Driver=IBM INFORMIX ODBC DRIVER (64-bit);Database=" & db & ";Host=" & ip & ";Server=" & servername & ";Service=" &
            port & ";Uid=" & uid & "; Pwd=" & pwd & ";"
            Dim con1 As New OdbcConnection(creacion)
            con1.Open()
            Dim cmd As New OdbcCommand("select count(*) from conexion;", con1)
            cmd.ExecuteNonQuery()
            con1.Close()
            Return 1
        Catch ee As Exception
            Return 0
        End Try
    End Function
End Class
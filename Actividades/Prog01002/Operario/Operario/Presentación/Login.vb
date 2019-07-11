Imports System.Data.Odbc
Imports System.IO
Imports System.Text
Imports Microsoft.Win32
Imports Controladores.Fachada

Public Class Login
    Private contraseñaVisible As Boolean = False

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Button1.Visible = True
        Button3.Visible = True
        Button1.Enabled = True
        Button3.Enabled = True
        NotificarDeConexcion(False)
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
        If Not Controladores.Fachada.getInstancia.IngresoDeUsuarioConComprobacion(user.Text, pass.Text) Then 'YA CARGA EN EL METODO AL USUARIO QUE INGRESO 
            MsgBox("Credenciales incorrectas. Intente nuevamente", MsgBoxStyle.Critical)
        Else
            Principal.getInstancia.cargarPanel(Of LugarDeTrabajo)(New LugarDeTrabajo)
        End If
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Principal.getInstancia.cargarPanel(Of RestablecerContraseña)(New RestablecerContraseña)
    End Sub

    Public Sub NotificarDeConexcion(j As Boolean)
        If j Then
            estadoConex.Text = "Conectado"
            estadoConex.ForeColor = Color.FromArgb(13, 163, 51)
            Button1.Enabled = True
            Button3.Enabled = True
            user.Enabled = True
            pass.Enabled = True
        Else
            estadoConex.Text = "Desconectado"
            estadoConex.ForeColor = Color.FromArgb(180, 20, 20)
            Button1.Enabled = False
            Button3.Enabled = False
            user.Enabled = False
            pass.Enabled = False
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim config As New ConfiguracionRed(Me)
        config.ShowDialog()

    End Sub

End Class
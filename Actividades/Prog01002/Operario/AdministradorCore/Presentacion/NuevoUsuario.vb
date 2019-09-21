Public Class NuevoUsuario
    Public Sub New()
        InitializeComponent()
        Dim max As New DateTime(DateTime.Now.Year - 18, DateTime.Now.Month, DateTime.Now.Day)
        Dim min As New DateTime(DateTime.Now.Year - 80, DateTime.Now.Month, DateTime.Now.Day)
        fechaNac.Value = max
        fechaNac.MaxDate = max
        fechaNac.MinDate = min
        sexo.SelectedIndex = 0
        rol.SelectedIndex = 0
    End Sub

    Private Sub Ingresar_Click(sender As Object, e As EventArgs) Handles ingresar.Click
        If nombreDeUsuario.Text.Trim.Length = 0 Then
            MsgBox("El nombre de usuario no puede estar vacio", MsgBoxStyle.Critical)
            Return
        End If

        If NombreReal.Text.Trim.Length * ApellidoReal.Text.Trim.Length * Email.Text.Trim.Length * Telefono.Text.Trim.Length = 0 Then
            MsgBox("Alguno de los campos esta vacio, verifiquelos", MsgBoxStyle.Critical)
            Return
        End If

        If NombreReal.Text.Trim.Length > 50 Then
            MsgBox("El nombre de usuario es demaciado largo, no mas de 50 caracteres", MsgBoxStyle.Critical)
            Return
        End If

        If ApellidoReal.Text.Trim.Length > 50 Then
            MsgBox("El Apellido de usuario es demaciado largo, no mas de 50 caracteres", MsgBoxStyle.Critical)
            Return
        End If

        If Not Controladores.Funciones_comunes.formatoCorrectoDelEmail(Email.Text) Then
            MsgBox("El correo no tiene el formato correcto", MsgBoxStyle.Critical)
            Return
        End If

        If Telefono.Text.Length < 9 OrElse Telefono.Text.Length > 15 Then
            MsgBox("El telefono puede ser unicamente entre 9 a 15 numeros", MsgBoxStyle.Critical)
            Return
        End If

        If Not Controladores.Funciones_comunes.soloNumeros(Telefono.Text) Then
            MsgBox("El telefono debe ser puramente numerico", MsgBoxStyle.Critical)
            Return
        End If

        If sexo.SelectedIndex = -1 Then
            MsgBox("Debe selecionar un sexo", MsgBoxStyle.Critical)
            Return
        End If

        If rol.SelectedIndex = -1 Then
            MsgBox("Debe selecionar un rol", MsgBoxStyle.Critical)
            Return
        End If

        If Contraseña.Text.Length = 0 Then
            MsgBox("No puede esar la contrasela por defecto vacia", MsgBoxStyle.Critical)
            Return
        End If

        If Not Controladores.Funciones_comunes.SinEspacios(nombreDeUsuario.Text) Then
            MsgBox("El nombre de usuario no debe tener espacios", MsgBoxStyle.Critical)
            Return
        End If

        If Controladores.Fachada.getInstancia.comprobarNombreDeUsuarioExiste(nombreDeUsuario.Text) Then
            MsgBox("Ese nombre de usuario ya existe", MsgBoxStyle.Critical)
            Return
        End If

        ' AQUI YA PASO TODAS LAS PRIMERAS COMRPOBACIONES

        Dim user As New Controladores.Usuario With {.NombreDeUsuario = nombreDeUsuario.Text.Trim,
                                                    .Nombre = NombreReal.Text.Trim,
                                                    .Apellido = ApellidoReal.Text.Trim,
                                                    .Email = Email.Text.Trim,
                                                    .Telefono = Telefono.Text.Trim,
                                                    .Creador = Controladores.Fachada.getInstancia.DevolverUsuarioActual,
                                                    .FechaCreacion = DateTime.Now,
                                                    .FechaNacimiento = fechaNac.Value}
        Select Case sexo.SelectedIndex
            Case 0
                user.sexo = "M"
            Case 1
                user.sexo = "F"
            Case 2
                user.sexo = "O"
        End Select

        Select Case rol.SelectedIndex
            Case 0
                user.Rol = Controladores.Usuario.TIPO_ROL_OPERARIO
            Case 1
                user.Rol = Controladores.Usuario.TIPO_ROL_TRANSPORTISTA
            Case 2
                user.Rol = Controladores.Usuario.TIPO_ROL_ADMINISTRADOR
        End Select

        Controladores.Fachada.getInstancia.crearUsuario(user, Contraseña.Text)
        MsgBox("Usuario ingresado con exito", MsgBoxStyle.Information)
        Controladores.Marco.getInstancia.cargarPanel(Of ListarUsuario)(New ListarUsuario)

    End Sub



End Class
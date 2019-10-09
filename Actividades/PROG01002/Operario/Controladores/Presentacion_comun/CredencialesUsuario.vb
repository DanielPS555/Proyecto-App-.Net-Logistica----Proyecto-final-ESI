Public Class CredencialesUsuario

    Dim primerIngreso As Boolean
    Dim cambioDePregunta As Boolean
    Dim cambiopasswd As Boolean

    Public Sub New(j As Boolean)
        InitializeComponent()
        StartPosition = FormStartPosition.CenterScreen
        primerIngreso = j
        If j Then
            Button3.Visible = False
        End If
        cambioDePregunta = False
        cambiopasswd = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cambiopasswd Then
            If MsgBox("Ya cambio la contraseña anteriomente, ¿Desea volver a cambiarla?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Return
            End If
        End If
        If contraseña.Text.Trim.Length * contraseña2.Text.Trim.Length = 0 Then
            MsgBox("Debe ingresar contraseña y verificacion de contraseña. Ninguna puede ser vacia", MsgBoxStyle.Critical)
            Return
        End If

        If contraseña.Text.Contains(" ") Then
            MsgBox("No puede haber espacios en blanco", MsgBoxStyle.Critical)
            Return
        End If

        If Not contraseña.Text.Equals(contraseña2.Text) Then
            MsgBox("Las contraseñas deben ser de similar tamaño", MsgBoxStyle.Critical)
            Return
        End If

        Fachada.getInstancia.ModificarSimplementeContraseñaUsuarioActual(contraseña.Text)
        MsgBox("Contraseña modificada con exito", MsgBoxStyle.Information)
        cambiopasswd = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If cambioDePregunta Then
            If MsgBox("Ya cambio la Pregunta y respuesta anteriomente, ¿Desea volver a cambiarla?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Return
            End If
        End If
        If pregunta.Text.Trim.Length * respuesta.Text.Trim.Length = 0 Then
            MsgBox("Debe ingresar contraseña y verificacion de contraseña. Ninguna puede ser vacia", MsgBoxStyle.Critical)
            Return
        End If

        Fachada.getInstancia.CambiarPreguntaYRespuestaDeRecuperacionDelUsuarioActual(pregunta.Text.Trim, respuesta.Text.Trim)
        MsgBox("Actualizado con exito", MsgBoxStyle.Information)
        cambioDePregunta = True
    End Sub


    Private Sub CredencialesUsuario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = primerIngreso And Not (cambioDePregunta And cambioDePregunta)
        If e.Cancel Then
            MsgBox("Debe ingresar datos de recuperacion y contraseña por ser el primer ingreso del usuario", MsgBoxStyle.Critical)
        End If


    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If primerIngreso And Not (cambioDePregunta And cambioDePregunta) Then
            MsgBox("Debe ingresar datos de recuperacion y contraseña por ser el primer ingreso del usuario", MsgBoxStyle.Critical)
            Return
        End If
        Me.Close()
    End Sub
End Class
Public Class CredencialesUsuario

    Dim primerIngreso As Boolean
    Dim cambioDePregunta As Boolean
    Dim cambiopasswd As Boolean

    Public Sub New(j As Boolean)
        InitializeComponent()

        primerIngreso = j
        cambioDePregunta = False
        cambiopasswd = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cambiopasswd Then
            If MsgBox("Ya cambio la contraseña anteriomente, ¿Desea volver a cambiarla?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Return
            End If
        End If
        If contraseña.Text.Trim.Length * contraseña2.Text.Trim = 0 Then
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

    End Sub

    Private Function cerrar() As Boolean
        If primerIngreso And Not cambioDePregunta Then
            MsgBox("Al ser el primer ingreso debe cambiar la pregunta y respuesta de recuperacion", MsgBoxStyle.Critical)
            Return False
        End If
        Return True
    End Function

    Private Sub CredencialesUsuario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If cerrar() Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If cerrar() Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub
End Class
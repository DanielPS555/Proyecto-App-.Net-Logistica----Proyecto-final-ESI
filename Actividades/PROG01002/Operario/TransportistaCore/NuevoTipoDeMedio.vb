Public Class NuevoTipoDeMedio
    Private iter As Controladores.DevolverMedio
    Public Sub New(inter As Controladores.DevolverMedio)
        InitializeComponent()
        iter = inter
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If nombre.Text.Length = 0 Then
            MsgBox(Controladores.Funciones_comunes.I18N("No puede dejar el nombre vacio", Controladores.Marco.getInstancia.Language), MsgBoxStyle.Critical)
            Return
        End If

        If nombre.Text.Length = 50 Then
            MsgBox(Controladores.Funciones_comunes.I18N("El nombre no puede superar los 50 caracteres", Controladores.Marco.getInstancia.Language), MsgBoxStyle.Critical)
            Return
        End If

        If nombre.Text.Length <> nombre.Text.Trim.Length Then
            MsgBox(Controladores.Funciones_comunes.I18N("El nombre no puede tener espacios en el inicio ni en el final", Controladores.Marco.getInstancia.Language), MsgBoxStyle.Critical)
            Return
        End If

        If nombre.Text.Length <> nombre.Text.Trim.Length Then
            MsgBox(Controladores.Funciones_comunes.I18N("No puede dejar el nombre vacío", Controladores.Marco.getInstancia.Language), MsgBoxStyle.Critical)
            Return
        End If

        If Controladores.Fachada.getInstancia.ExistenciaDeNombreDeTipoDeMedio(nombre.Text) Then
            MsgBox(Controladores.Funciones_comunes.I18N("Ya existe ese nombre para este medio", Controladores.Marco.getInstancia.Language), MsgBoxStyle.Critical)
            Return
        End If

        iter.devolverTipoDeMedio(New Controladores.TipoMedioTransporte(nombre.Text))
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class
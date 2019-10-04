Public Class ChatInterno
    Private alfa As Alfa
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        alfa = New Alfa(GetType(Evento), GetType(SUB_Mensaje)) With {
            .Size = New Drawing.Size(574, 380),
            .Location = New Point(214, 12)
        }
        Me.Controls.Add(alfa)
        Me.Update()

        UsuariosMensajeria.Items.AddRange(Fachada.getInstancia.TodosLosUsuariosObjetos.ToArray)
    End Sub

    Private Sub UsuariosMensajeria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UsuariosMensajeria.SelectedIndexChanged
        Dim msgs = Fachada.getInstancia.MensajesEntre(Fachada.getInstancia.DevolverUsuarioActual, DirectCast(UsuariosMensajeria.SelectedItem, Usuario))
        alfa.Limpiar()
        lastMessageId = msgs.Select(Function(x) x.ID).Concat({0}).Max()
        For Each m In msgs
            alfa.Nuevo(m, False)
        Next
        alfa.render()
        If timer IsNot Nothing Then
            timer.Stop()
            timer.Dispose()
        End If
        timer = New Timer With {
            .Interval = 1000
        }
        AddHandler timer.Tick, AddressOf UpdateMessages
        timer.Start()
    End Sub

    Private timer As Timer
    Private lastMessageId As Integer = 0



    Private Sub UpdateMessages()
        Dim newMsgs As List(Of Evento) = Fachada.getInstancia.UltimosMensajes(Fachada.getInstancia.DevolverUsuarioActual, DirectCast(UsuariosMensajeria.SelectedItem, Usuario), lastMessageId)
        Dim unread = alfa.GetObjects.Cast(Of Evento).Where(Function(x) x.Datos.ContainsKey("leido") AndAlso Not x.Datos("leido")).Select(Function(x) x.ID).ToArray
        If Persistencia.getInstancia.CheckViews(unread).Rows.Cast(Of DataRow).Where(Function(x) x(1)).Count > 0 Then
            UsuariosMensajeria_SelectedIndexChanged(Nothing, Nothing)
            Return
        End If
        For Each m In newMsgs
            alfa.Nuevo(m, False)
        Next
        If newMsgs.Count > 0 Then
            alfa.render()
            Me.Update()
        End If
    End Sub

    Private Sub SendButton_Click(sender As Object, e As EventArgs) Handles SendButton.Click
        If Fachada.getInstancia.MensajePara(DirectCast(UsuariosMensajeria.SelectedItem, Usuario), InputBox.Text) Then
            UpdateMessages()
            InputBox.Text = ""
        End If
    End Sub

    Private Sub ChatInterno_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If timer IsNot Nothing Then
            timer.Stop()
            timer = Nothing
        End If
    End Sub
End Class
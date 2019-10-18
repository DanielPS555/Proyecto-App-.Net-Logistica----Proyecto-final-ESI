Public Class ChatInterno
    Private alfa As Alfa
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        alfa = New Alfa(GetType(Evento), GetType(SUB_Mensaje)) With {
            .Size = New Drawing.Size(574, 560),
            .Location = New Point(250, 12)
        }
        Me.Controls.Add(alfa)
        Me.Update()

        UsuariosMensajeria.Items.AddRange(Fachada.getInstancia.TodosLosUsuariosObjetos.ToArray) ' Agregamos la lista de usuarios

    End Sub

    Private Sub UsuariosMensajeria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UsuariosMensajeria.SelectedIndexChanged
        If timer IsNot Nothing Then
            timer.Stop()
            timer.Dispose()
        End If
        timer = New Timer With {
            .Interval = 350
        }
        alfa.Limpiar(True)
        AddHandler timer.Tick, AddressOf UpdateMessages
        lastMessageId = 0
        alfa.Refresh()
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

        Dim videoEvent As Evento = Nothing
        ' Si no asignamos = nothing se queja de que no tiene asignación, a pesar de que (teoréticamente) al ser un lenguaje GC la asignación por defecto debería ser nothing
        For Each m In newMsgs
            alfa.Nuevo(m, False)
            If m.Datos.ContainsKey("video") AndAlso m.Datos("autor") <> Fachada.getInstancia.DevolverUsuarioActual.ID_usuario Then
                videoEvent = m
            End If
        Next
        If videoEvent IsNot Nothing Then
            Dim bmp As New Bitmap(32, 32)
            Dim pixels = DirectCast(videoEvent.Datos("video"), String).ToCharArray
            For y = 0 To 31
                For x = 0 To 31
                    Dim nmbr = Asc(pixels(y * 32 + x)) - Asc("A")
                    Dim gscale = (nmbr And 63) * 4
                    bmp.SetPixel(x, y, Color.FromArgb(gscale, gscale, gscale))
                Next
            Next
            bmp = New Bitmap(bmp, New Size(160, 160))
            recvPictureBox.Image = bmp
        End If
        If newMsgs.Count > 0 Then
            alfa.Fastrender()
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

    Private webcam As WebCam.WebCam
    Private haveNewImage As Boolean
    Private lastImage As Bitmap
    Private wcTimer As Timer

    Private Sub sendPictureBox_Click(sender As Object, e As EventArgs) Handles sendPictureBox.Click
        If webcam Is Nothing Then
            webcam = New WebCam.WebCam
            AddHandler webcam.OnSnapshot, Sub(sdr, args)
                                              Dim evt = New Dictionary(Of String, Object)
                                              lastImage = New Bitmap(args.Image, New Size(32, 32))
                                              haveNewImage = True
                                          End Sub
            wcTimer = New Timer
            AddHandler wcTimer.Tick, Sub()
                                         If Not haveNewImage Then
                                             webcam.GetImage()
                                             Return
                                         End If
                                         haveNewImage = False
                                         Dim evt = New Dictionary(Of String, Object)
                                         Dim video = ""
                                         For y = 0 To 31
                                             For x = 0 To 31
                                                 Dim c = lastImage.GetPixel(x, y)
                                                 Dim r As Integer = Math.Round((c.R / 255.0!) * 32)
                                                 Dim g As Integer = Math.Round((c.G / 255.0!) * 32)
                                                 Dim b As Integer = Math.Round((c.B / 255.0!) * 32)
                                                 Dim gscale = (r + g + b) / 3
                                                 Dim ch As Char = Chr(gscale + Asc("A"))
                                                 video += ch
                                             Next
                                         Next
                                         evt("video") = video
                                         If Fachada.getInstancia.MensajePara(DirectCast(UsuariosMensajeria.SelectedItem, Usuario), "imagen", evt) Then
                                             UpdateMessages()
                                         End If
                                         webcam.GetImage()
                                     End Sub
            wcTimer.Interval = 600
            Console.WriteLine(webcam.VideoInputDevices.Count)
            For Each k As DirectX.Capture.Filter In webcam.VideoInputDevices
                If MsgBox($"Desea abrir la cámara {k.Name}?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    webcam.Open(k, sendPictureBox)
                End If
            Next
            If webcam.IsConnected Then
                wcTimer.Start()
            End If
        End If
    End Sub
End Class
Public Class RegistroDeDañoPanel

    Private padre As crearInformaDeDaños
    Private regitro As Controladores.RegistroDaños
    Private imagenes As List(Of Bitmap)
    Private piso As Integer = 0
    Private actual As Integer = 0
    Private regpadre As Controladores.RegistroDaños

    Public Sub New(informe As crearInformaDeDaños)
        InitializeComponent()
        padre = informe
        regpadre = New Controladores.RegistroDaños(informe.InformeDeDaños)
        regitro = New Controladores.RegistroDaños(informe.InformeDeDaños)
        tipo.SelectedIndex = 0

        imagenes = New List(Of Bitmap)
        p1.Image = Operario.My.Resources.sinContenidoFotografico
        p2.Image = Operario.My.Resources.sinContenidoFotografico
        p3.Image = Operario.My.Resources.sinContenidoFotografico
        If informe.NuevoVehiculo Then
            tipo.Enabled = False
            infoOrigen.Visible = False
            registroOrigen.Visible = False
            Label5.Visible = False
            Label6.Visible = False
        Else
            CargarregistrosInformes()
            If infoOrigen.Items.Count > 0 Then
                infoOrigen.SelectedIndex = 0
            End If
        End If
    End Sub

    Public Sub New(informe As crearInformaDeDaños, registroPadre As Controladores.RegistroDaños)
        InitializeComponent()
        padre = informe
        regpadre = registroPadre
        regitro = New Controladores.RegistroDaños(informe.InformeDeDaños)
        If informe.NuevoVehiculo Then
            tipo.Enabled = False
            infoOrigen.Visible = False
            registroOrigen.Visible = False
        Else
            CargarregistrosInformes()
            If infoOrigen.Items.Count > 0 Then
                If registroPadre.Actualiza IsNot Nothing Then
                    For i As Integer = 0 To infoOrigen.Items.Count - 1
                        If infoOrigen.Items(i) = registroPadre.Actualiza.ID Then
                            infoOrigen.SelectedIndex = i
                            Exit For
                        End If
                    Next
                Else
                    infoOrigen.SelectedIndex = 0
                End If

            End If

        End If
        Select Case registroPadre.TipoActualizacion
            Case Controladores.RegistroDaños.TIPO_ACTUALIZACION_ANULACION
                tipo.SelectedIndex = 1
                selecionarRegistroPrevio()
            Case Controladores.RegistroDaños.TIPO_ACTUALIZACION_REGULAR
                tipo.SelectedIndex = 0
                selecionarRegistroPrevio()
            Case Controladores.RegistroDaños.TIPO_ACTUALIZACION_CORRECION
                tipo.SelectedIndex = 2
        End Select
        imagenes = New List(Of Bitmap)
        For Each img As Image In registroPadre.Imagenes
            imagenes.Add(DirectCast(img, Bitmap))
        Next
        piso = 0
        If imagenes.Count > 0 Then
            panelFotografias.Image = imagenes(0)
            p1.Image = Operario.My.Resources.sinContenidoFotografico
            p2.Image = Operario.My.Resources.sinContenidoFotografico
            p3.Image = Operario.My.Resources.sinContenidoFotografico
            actualizarImagenes()
        End If
        descipt.Text = registroPadre.Descripcion.Trim


    End Sub

    Private Sub selecionarRegistroPrevio()
        Dim c As Integer = 0
        For Each info As Controladores.InformeDeDaños In padre.ListaDeTodosLosInformes
            If regpadre.InformePadre.Equals(info) Then
                infoOrigen.SelectedIndex = c
                Dim c2 As Integer = 0
                For Each regi As Controladores.RegistroDaños In padre.ListaDeTodosLosInformes(c).Registros
                    If regi.Equals(regpadre) Then
                        registroOrigen.SelectedIndex = c2
                        Exit For
                    End If
                Next
                c2 += 1
                Exit For
            End If
            c += 1
        Next
    End Sub

    Public Sub CargarregistrosInformes()
        infoOrigen.Items.Clear()
        infoOrigen.Visible = True
        registroOrigen.Visible = True
        If padre.ListaDeTodosLosInformes.Count = 0 Then
            infoOrigen.Enabled = False
            registroOrigen.Enabled = False
        Else
            For Each info As Controladores.InformeDeDaños In padre.ListaDeTodosLosInformes
                infoOrigen.Items.Add(info.ID)
            Next
        End If

    End Sub

    Public Sub ActualizarReg() Handles infoOrigen.SelectedIndexChanged
        registroOrigen.Items.Clear()
        For Each reg As Controladores.RegistroDaños In padre.ListaDeTodosLosInformes(infoOrigen.SelectedIndex).Registros
            If reg.TipoActualizacion <> Controladores.RegistroDaños.TIPO_ACTUALIZACION_ANULACION Then
                registroOrigen.Items.Add(reg.ID)
            End If
        Next
        If registroOrigen.Items.Count <> 0 Then
            registroOrigen.SelectedIndex = 0
        End If

        'registroOrigen.Items.AddRange(todosLosInformes(infoOrigen.SelectedIndex).Registros.Where(Function(x) x.TipoActualizacion <> Controladores.RegistroDaños.TIPO_ACTUALIZACION_ANULACION))
    End Sub



    Private Sub actualizarImagenes()
        Dim pc() As PictureBox = {p1, p2, p3}
        Dim c As Integer = 0
        For i As Integer = piso To piso + 2
            If imagenes.Count >= i + 1 Then
                pc(c).Image = imagenes(i)
            Else
                pc(c).Image = Operario.My.Resources.sinContenidoFotografico
            End If
            c += 1
        Next

        If piso = 0 Then
            subir.Enabled = False
            bajar.Enabled = True
        ElseIf piso + 3 >= imagenes.Count Then
            bajar.Enabled = False
            subir.Enabled = True
        Else
            bajar.Enabled = True
            subir.Enabled = True
        End If

    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs)
        If imagenes.Count = 0 Then
            MsgBox("Debe ingrezar al menos una imagen", MsgBoxStyle.Critical)
            Return
        End If

        If descipt.Text.Trim.Length = 0 Then
            MsgBox("Ingrese una descripcion del informe", MsgBoxStyle.Critical)
            Return
        End If

        If tipo.SelectedIndex <> 0 Then
            If infoOrigen.SelectedIndex = -1 OrElse registroOrigen.SelectedIndex = -1 Then
                MsgBox("Si es un regitro de anulacion o actualizacion usted debe elegir un regitro al que hacer referencia", MsgBoxStyle.Critical)
                Return
            End If
        End If


        Dim reg As New Controladores.RegistroDaños(padre.InformeDeDaños)
        reg.Descripcion = descipt.Text.Trim
        For Each im As Bitmap In imagenes
            reg.Imagenes.Add(im)
        Next
        Select Case tipo.SelectedIndex
            Case 1
                reg.TipoActualizacion = Controladores.RegistroDaños.TIPO_ACTUALIZACION_ANULACION
                reg.Actualiza = padre.ListaDeTodosLosInformes.Where(Function(x) x.ID = infoOrigen.SelectedItem).ToList.Single.Registros.Where(Function(x) x.ID = registroOrigen.SelectedItem).Single
            Case 2
                reg.TipoActualizacion = Controladores.RegistroDaños.TIPO_ACTUALIZACION_CORRECION
                reg.Actualiza = padre.ListaDeTodosLosInformes.Where(Function(x) x.ID = infoOrigen.SelectedItem).ToList.Single.Registros.Where(Function(x) x.ID = registroOrigen.SelectedItem).Single
            Case 0
                reg.TipoActualizacion = Controladores.RegistroDaños.TIPO_ACTUALIZACION_REGULAR
        End Select

        padre.devolverRegistro(reg)
        imagenes = Nothing
        Me.Dispose()
        Marco.getInstancia.cerrarPanel(Of RegistroDeDañoPanel)()
    End Sub

    Private Sub NuevaFotografia_Click(sender As Object, e As EventArgs)
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "Imagenes|*.jpg"
        If ofd.ShowDialog() = DialogResult.OK Then
            imagenes.Add(New Bitmap(ofd.OpenFile))
            panelFotografias.Image = New Bitmap(ofd.OpenFile)
            If imagenes.Count > 3 Then
                piso = imagenes.Count - 3
                actual = imagenes.Count - 1
                actualizarImagenes()
                'marcarImg(actual - piso)
            Else
                actual = imagenes.Count - 1
                'marcarImg(actual)
                actualizarImagenes()
            End If
            panelFotografias.Image = New Bitmap(ofd.OpenFile)
        End If
        ofd.Dispose()
    End Sub

    'Private Sub marcarImg(ins As Integer)
    '    Dim g As Graphics = Me.CreateGraphics
    '    Select Case ins
    '        Case 1
    '            g.FillRectangle(New SolidBrush(Color.FromArgb(35, 35, 35)), New RectangleF(New Point(p1.Location.X - 2, p1.Location.X - 2), New Size(p1.Size.Width + 4, p1.Size.Height + 4)))
    '            g.FillRectangle(New SolidBrush(Color.FromArgb(255, 255, 255)), New RectangleF(New Point(p2.Location.X - 2, p2.Location.X - 2), New Size(p2.Size.Width + 4, p2.Size.Height + 4)))
    '            g.FillRectangle(New SolidBrush(Color.FromArgb(255, 255, 255)), New RectangleF(New Point(p3.Location.X - 2, p3.Location.X - 2), New Size(p3.Size.Width + 4, p3.Size.Height + 4)))
    '        Case 2
    '            g.FillRectangle(New SolidBrush(Color.FromArgb(35, 35, 35)), New RectangleF(New Point(p2.Location.X - 2, p2.Location.X - 2), New Size(p2.Size.Width + 4, p2.Size.Height + 4)))
    '            g.FillRectangle(New SolidBrush(Color.FromArgb(255, 255, 255)), New RectangleF(New Point(p1.Location.X - 2, p1.Location.X - 2), New Size(p1.Size.Width + 4, p1.Size.Height + 4)))
    '            g.FillRectangle(New SolidBrush(Color.FromArgb(255, 255, 255)), New RectangleF(New Point(p3.Location.X - 2, p3.Location.X - 2), New Size(p3.Size.Width + 4, p3.Size.Height + 4)))
    '        Case 3
    '            g.FillRectangle(New SolidBrush(Color.FromArgb(35, 35, 35)), New RectangleF(New Point(p3.Location.X - 2, p3.Location.X - 2), New Size(p3.Size.Width + 4, p3.Size.Height + 4)))
    '            g.FillRectangle(New SolidBrush(Color.FromArgb(255, 255, 255)), New RectangleF(New Point(p2.Location.X - 2, p2.Location.X - 2), New Size(p2.Size.Width + 4, p2.Size.Height + 4)))
    '            g.FillRectangle(New SolidBrush(Color.FromArgb(255, 255, 255)), New RectangleF(New Point(p1.Location.X - 2, p1.Location.X - 2), New Size(p1.Size.Width + 4, p1.Size.Height + 4)))
    '        Case -1
    '            g.FillRectangle(New SolidBrush(Color.FromArgb(255, 255, 255)), New RectangleF(New Point(p1.Location.X - 2, p1.Location.X - 2), New Size(p1.Size.Width + 4, p1.Size.Height + 4)))
    '            g.FillRectangle(New SolidBrush(Color.FromArgb(255, 255, 255)), New RectangleF(New Point(p2.Location.X - 2, p2.Location.X - 2), New Size(p2.Size.Width + 4, p2.Size.Height + 4)))
    '            g.FillRectangle(New SolidBrush(Color.FromArgb(255, 255, 255)), New RectangleF(New Point(p3.Location.X - 2, p3.Location.X - 2), New Size(p3.Size.Width + 4, p3.Size.Height + 4)))
    '    End Select

    'End Sub

    Public Sub ponerImagen(sender As Object, e As EventArgs) Handles p1.Click, p2.Click, p3.Click
        Dim o As PictureBox = DirectCast(sender, PictureBox)
        If o.Equals(p1) Then
            actual = piso
            'marcarImg(1)
            panelFotografias.Image = p1.Image
        ElseIf o.Equals(p2) Then
            actual = piso + 1
            ' marcarImg(2)
            panelFotografias.Image = p2.Image
        Else
            actual = piso + 2
            'marcarImg(3)
            panelFotografias.Image = p3.Image
        End If

    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs)
        Marco.getInstancia.cerrarPanel(Of RegistroDeDañoPanel)()
    End Sub

    Private Sub sigienteFotografia_Click(sender As Object, e As EventArgs)
        'While it.Current Is Nothing AndAlso it.MoveNext
        'End While
        'panelFotografias.Image = it.Current
        'If Not it.MoveNext Then
        '    it.Reset()
        'End If
    End Sub

    Private Sub Subir_Click(sender As Object, e As EventArgs) Handles subir.Click
        If piso > 0 Then
            piso = piso - 1
            actualizarImagenes()
        End If
    End Sub

    Private Sub Bajar_Click(sender As Object, e As EventArgs) Handles bajar.Click
        If piso + 3 < imagenes.Count Then
            piso = piso + 1
            actualizarImagenes()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        If imagenes.Count = 0 Then
            MsgBox("No hay imagenes para eliminar")
        Else
            imagenes.RemoveAt(actual)
            If actual = 0 Then
                If imagenes.Count = 0 Then
                    panelFotografias.Image = Operario.My.Resources.sinContenidoFotografico
                Else
                    panelFotografias.Image = imagenes(0)
                End If

            ElseIf actual = imagenes.Count Then
                actual = actual - 1
                panelFotografias.Image = imagenes(actual)
            End If

            If piso + 2 = imagenes.Count And piso <> 0 Then
                piso = piso - 1
            End If
            actualizarImagenes()
        End If


    End Sub

    Private Sub Descipt_TextChanged(sender As Object, e As EventArgs) Handles descipt.TextChanged
        Dim num As Integer = 255 - descipt.Text.Trim.Length
        cp.Text = num
        If num < 0 Then
            cp.ForeColor = Color.FromArgb(199, 34, 34)
        Else
            cp.ForeColor = Color.FromArgb(35, 35, 35)
        End If
    End Sub

    Private Sub Tipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tipo.SelectedIndexChanged
        infoOrigen.Enabled = tipo.SelectedIndex > 0
        registroOrigen.Enabled = tipo.SelectedIndex > 0
    End Sub
End Class
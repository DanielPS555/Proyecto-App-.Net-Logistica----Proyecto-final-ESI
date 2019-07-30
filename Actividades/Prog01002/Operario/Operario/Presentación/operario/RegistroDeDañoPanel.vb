Public Class RegistroDeDañoPanel

    Private padre As crearInformaDeDaños
    Private regitro As Controladores.RegistroDaños

    Public Sub New(informe As crearInformaDeDaños, num_registro As Integer)
        InitializeComponent()
        padre = informe
        regitro = New Controladores.RegistroDaños(informe.InformeDeDaños)
        tipo.SelectedIndex = 0
        CargarregistrosInformes()
        p1.Image = Operario.My.Resources.sinContenidoFotografico
        p2.Image = Operario.My.Resources.sinContenidoFotografico
        p3.Image = Operario.My.Resources.sinContenidoFotografico
    End Sub

    Public Sub CargarregistrosInformes()
        infoOrigen.Items.Clear()
        For Each info As Controladores.InformeDeDaños In padre.ListaDeTodosLosInformes
            infoOrigen.Items.Add(info)
        Next
    End Sub

    Private Shared Function BitmapFromByteArray(v As Byte()) As Bitmap
        Dim br = New IO.MemoryStream(v)
        Dim bm = New Bitmap(br)
        br.Close()
        Return bm
    End Function

    Public Sub ActualizarReg() Handles infoOrigen.SelectedIndexChanged
        registroOrigen.Items.Clear()
        'For Each reg As Controladores.RegistroDaños In padre.ListaDeTodosLosInformes(infoOrigen.SelectedIndex).Registros
        '    If reg.TipoActualizacion <> Controladores.RegistroDaños.TIPO_ACTUALIZACION_ANULACION Then
        '        registroOrigen.Items.Add()
        '    End If
        'Next
        registroOrigen.Items.AddRange(padre.ListaDeTodosLosInformes(infoOrigen.SelectedIndex).Registros.Where(Function(x) x.TipoActualizacion <> Controladores.RegistroDaños.TIPO_ACTUALIZACION_ANULACION))
    End Sub

    Private imagenes As List(Of Bitmap)
    Private piso As Integer = 0

    Private Sub actualizarImagenes()
        Dim pc() As PictureBox = {p1, p2, p3}
        Dim c As Integer = 0
        For i As Integer = piso To piso + 2
            pc(c).Image = imagenes(i)
            c += 1
        Next
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs)
        'VRepo.UpdateInformeReg(eninforme, enregistro, descipt.Text)
        'VRepo.UpdateInformeImg(eninforme, enregistro, images)
        ''If tipo.SelectedIndex > 0 Then
        ''   VRepo.InformeActualiza(eninforme, enregistro, tipo.SelectedItem, infoOrigen.SelectedItem, registroOrigen.SelectedItem)
        ''End If
        'padre.Actualizar()
        'Marco.getInstancia.cerrarPanel(Of RegistroDeDañoPanel)()
    End Sub

    Private Sub NuevaFotografia_Click(sender As Object, e As EventArgs)
        'Dim ofd As New OpenFileDialog()
        'ofd.Filter = "Imagenes|*.jpg"
        'If ofd.ShowDialog() = DialogResult.OK Then
        '    images.Add(New Bitmap(ofd.OpenFile))
        '    it = images.GetEnumerator
        '    it.MoveNext()
        '    panelFotografias.Image = it.Current
        'End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        'If nuevo Then
        '    SRepo.ConsultarSinRetorno($"delete from imagenregistro where informe={eninforme} and nrolista={enregistro};")
        '    SRepo.ConsultarSinRetorno($"delete from registrodanios where informedanios={eninforme} and nroenlinsta={enregistro};")
        'End If
        'Marco.getInstancia.cerrarPanel(Of RegistroDeDañoPanel)()
    End Sub

    Private Sub sigienteFotografia_Click(sender As Object, e As EventArgs)
        'While it.Current Is Nothing AndAlso it.MoveNext
        'End While
        'panelFotografias.Image = it.Current
        'If Not it.MoveNext Then
        '    it.Reset()
        'End If
    End Sub


End Class
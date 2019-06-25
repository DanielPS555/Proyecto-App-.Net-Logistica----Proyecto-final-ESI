Public Class RegistroDeDañoPanel

    Private nuevo As Boolean
    Private padre As IActualizaMessage

    Public Sub New(EnInforme As Integer, registro As Integer, nuevo As Boolean, padre As IActualizaMessage)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.padre = padre
        Me.enregistro = registro
        Me.eninforme = EnInforme
        Me.nuevo = nuevo
        If Not nuevo Then
            descipt.ReadOnly = True
            Button5.Visible = False
            tipo.Enabled = False
            NuevaFotografia.Visible = False
        End If
        infoDaños.Text = EnInforme
        regisDaños.Text = registro
        images = VRepo.Imagenes(EnInforme, registro).ToList.Select(Function(x) BitmapFromByteArray(x(1))).ToList
        it = images.GetEnumerator
        descipt.Text = SRepo.ConsultarSingle($"select descripcion from registrodanios where informedanios={EnInforme} and nroenlista={registro};")
    End Sub

    Private Shared Function BitmapFromByteArray(v As Byte()) As Bitmap
        Dim br = New IO.MemoryStream(v)
        Dim bm = New Bitmap(br)
        br.Close()
        Return bm
    End Function

    Public Sub New(eninforme As Integer, padre As IActualizaMessage)
        Me.New(eninforme, VRepo.NewReg(eninforme), True, padre)
    End Sub

    Private images As List(Of Bitmap)
    Private it As IEnumerator(Of Bitmap)
    Private enregistro As Integer
    Private eninforme As Integer

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        VRepo.UpdateInformeReg(eninforme, enregistro, descipt.Text)
        VRepo.UpdateInformeImg(eninforme, enregistro, images)
        padre.Actualizar()
        Marco.getInstancia.cerrarPanel(Of RegistroDeDañoPanel)()
    End Sub

    Private Sub NuevaFotografia_Click(sender As Object, e As EventArgs)
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "Imagenes|*.jpg"
        If ofd.ShowDialog() = DialogResult.OK Then
            images.Add(New Bitmap(ofd.OpenFile))
            it = images.GetEnumerator
            it.MoveNext()
            panelFotografias.Image = it.Current
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        If nuevo Then
            SRepo.ConsultarSinRetorno($"delete from registrodanios where informedanios={eninforme} and nroenlinsta={enregistro};")
        End If
        Marco.getInstancia.cerrarPanel(Of RegistroDeDañoPanel)()
    End Sub

    Private Sub sigienteFotografia_Click(sender As Object, e As EventArgs)
        While it.Current Is Nothing AndAlso it.MoveNext
        End While
        panelFotografias.Image = it.Current
        If Not it.MoveNext Then
            it.Reset()
        End If
    End Sub
End Class
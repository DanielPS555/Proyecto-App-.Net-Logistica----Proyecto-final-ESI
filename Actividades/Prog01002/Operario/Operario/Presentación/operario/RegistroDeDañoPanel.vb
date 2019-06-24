Public Class RegistroDeDañoPanel

    Public Sub New(EnInforme As Integer, registro As Integer, nuevo As Boolean)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.enregistro = registro
        Me.eninforme = EnInforme
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

    Public Sub New(eninforme As Integer)
        Me.New(eninforme, VRepo.NewReg(eninforme), True)
    End Sub

    Private images As List(Of Bitmap)
    Private it As IEnumerator(Of Bitmap)
    Private enregistro As Integer
    Private eninforme As Integer

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        VRepo.UpdateInformeReg(eninforme, enregistro, descipt.Text)
        VRepo.UpdateInformeImg(eninforme, enregistro, images)
        Marco.getInstancia.cerrarPanel(Of RegistroDeDañoPanel)()
    End Sub

    Private Sub NuevaFotografia_Click(sender As Object, e As EventArgs)
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "Imagenes|*.jpg"
        If ofd.ShowDialog() = DialogResult.OK Then
            images.Add(New Bitmap(ofd.OpenFile))
            it = images.GetEnumerator
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        Marco.getInstancia.cerrarPanel(Of RegistroDeDañoPanel)()
    End Sub

    Private Sub sigienteFotografia_Click(sender As Object, e As EventArgs)
        panelFotografias.Image = it.Current
        If Not it.MoveNext Then
            it.Reset()
        End If
    End Sub
End Class
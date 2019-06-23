Public Class RegistroDeDañoPanel

    Public Sub New(EnInforme As Integer, registro As Integer)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.enregistro = enregistro
        Me.eninforme = EnInforme
        infoDaños.Text = EnInforme
        regisDaños.Text = registro
        images = VRepo.Imagenes(EnInforme, registro).ToList.Select(Function(x) BitmapFromByteArray(x(1))).ToList
    End Sub

    Private Shared Function BitmapFromByteArray(v As Byte()) As Bitmap
        Dim br = New IO.MemoryStream(v)
        Dim bm = New Bitmap(br)
        br.Close()
        Return bm
    End Function

    Public Sub New(eninforme As Integer)
        Me.New(eninforme, VRepo.NewReg(eninforme))
    End Sub

    Private images As List(Of Bitmap)
    Private enregistro As Integer
    Private eninforme As Integer

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        VRepo.UpdateInformeReg(eninforme, enregistro, descipt.Text)
        VRepo.UpdateInformeImg(eninforme, enregistro, images)
    End Sub

    Private Sub NuevaFotografia_Click(sender As Object, e As EventArgs)
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "Imagenes|*.jpg"
        If ofd.ShowDialog() = DialogResult.OK Then
            images.Add(New Bitmap(ofd.OpenFile))
        End If
    End Sub
End Class
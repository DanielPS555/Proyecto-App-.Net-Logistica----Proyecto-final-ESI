Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows
Imports System.Windows.Forms
Imports Controladores
Imports Controladores.Extenciones

Public Class WebcamForm
    Private bcReader As ZXing.BarcodeReader
    Private result As ZXing.Result
    Private device As WiaDotNet.WiaDevice

    Private Sub WebcamForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bcReader = New ZXing.BarcodeReader With {
            .AutoRotate = True,
            .TryInverted = True,
            .Options = New ZXing.Common.DecodingOptions With {
                .TryHarder = True
            }
        }
        bcReader.Options.PossibleFormats = New List(Of ZXing.BarcodeFormat) From {
            ZXing.BarcodeFormat.QR_CODE
        }
        OpenButton.Text = Funciones_comunes.I18N("Abrir imagen", Marco.Language)
        Dim manager = New WiaDotNet.WiaManager()
        For Each d In manager.Devices
            If MsgBoxI18NFormat("{0} {1}, utilizar?", MsgBoxStyle.OkCancel, d.Manufacturer, d.Name) = MsgBoxResult.Ok Then
                device = d
                Exit For
            End If
        Next
        If device IsNot Nothing Then
            Dim timer As New Timer With {
                .Interval = 1000 / 15
            }
            AddHandler timer.Tick, Sub()
                                       Dim res = manager.AcquireScan(device, WiaDotNet.DocumentSources.SingleSided, WiaDotNet.ScanTypes.None)
                                       Dim img = res.Frames()(0)
                                       Dim bmp = New Bitmap(img.PixelWidth, img.PixelHeight, PixelFormat.Format32bppRgb)
                                       Dim bmpdata = bmp.LockBits(New Rectangle(Drawing.Point.Empty, bmp.Size), ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb)
                                       img.CopyPixels(Int32Rect.Empty, bmpdata.Scan0, bmpdata.Height * bmpdata.Stride, bmpdata.Stride)
                                       bmp.UnlockBits(bmpdata)
                                       image.Image = bmp
                                       result = bcReader.Decode(bmp)
                                       If result IsNot Nothing Then
                                           Close()
                                       End If
                                   End Sub
        End If
    End Sub

    Public Shared Function GetQR()
        Dim wcForm = New WebcamForm
        wcForm.ShowDialog()
        Return wcForm.result?.Text
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles OpenButton.Click
        Dim ofd = New OpenFileDialog With {
            .Multiselect = False
        }
        If ofd.ShowDialog() = DialogResult.OK Then
            Dim bmap = Drawing.Image.FromFile(ofd.FileName)
            result = bcReader.Decode(bmap)
            If result IsNot Nothing Then
                Me.Close()
            Else
                MsgBoxI18N("No se encontraron codigos QR en la imagen")
            End If
        End If
    End Sub
End Class
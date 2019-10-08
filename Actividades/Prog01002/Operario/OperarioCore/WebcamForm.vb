Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows
Imports System.Windows.Forms
Imports Controladores
Imports Controladores.Extenciones

Public Class WebcamForm
    Private bcReader As ZXing.BarcodeReader
    Private result As ZXing.Result
    Private imageBmp As Bitmap

    Private manager As WebCam.WebCam

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
        manager = New WebCam.WebCam
        If manager IsNot Nothing Then
            AddHandler manager.OnSnapshot, Sub(sdr, args)
                                               imageBmp = args.Image.Clone
                                           End Sub
            timer = New Timer
            AddHandler timer.Tick, Sub()
                                       If imageBmp IsNot Nothing Then
                                           result = bcReader.Decode(imageBmp)
                                           If result IsNot Nothing Then
                                               Close()
                                           End If
                                       End If
                                       manager.GetImage()
                                   End Sub
            Console.WriteLine(manager.VideoInputDevices.Count)
            For Each k As DirectX.Capture.Filter In manager.VideoInputDevices
                If MsgBox($"Desea abrir la cámara {k.Name}?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    manager.Open(k, image)
                End If
            Next
            If manager.IsConnected Then
                timer.Start()
                Console.WriteLine(manager.ToString)
            End If
        End If
    End Sub
    Private timer As Timer

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

    Private Sub WebcamForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If manager.IsConnected Then manager.Close()
    End Sub
End Class
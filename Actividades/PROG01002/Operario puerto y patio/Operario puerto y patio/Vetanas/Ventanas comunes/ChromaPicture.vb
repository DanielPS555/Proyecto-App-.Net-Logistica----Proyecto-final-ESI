Public Class ChromaPicture
    Public Image As Bitmap = Nothing
    Public ChromaColor As Color = Nothing
    Private Sub ChromaPicture_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint ' Generación de imagen de vehículo
        If IsNothing(Image) Or IsNothing(ChromaColor) Then
            e.Graphics.FillRectangle(Brushes.White, New Rectangle(0, 0, Me.Width, Me.Height))
            Return
        End If
        Dim graph As Graphics = e.Graphics
        Dim img As Bitmap = Image.Clone
        For y = 0 To img.Size.Height - 1
            For x = 0 To img.Size.Width - 1
                Dim p = img.GetPixel(x, y)
                If p.A <> 255 Then ' En los píxeles con alfa != 255 al valor se le aplica una especie de "chroma key", haciendo el promedio de sus 3 valores y multiplicandolo por los valores de color asignados como chroma
                    Dim m_1 As Integer = (CType(p.B, Integer) + p.G + p.R) \ 3
                    Dim m As Double = CType(m_1, Double) / 255 ' \ indica división entera
                    img.SetPixel(x, y, Color.FromArgb(255, ChromaColor.R * m, ChromaColor.G * m, ChromaColor.B * m))
                End If
            Next
        Next
        Dim imageX As Single = Me.Width / 2 - img.Width / 2
        Dim imageY As Single = Me.Height / 2 - img.Height / 2
        graph.DrawImage(img, imageX, imageY, CType(img.Width, Single), CType(img.Height, Single))
    End Sub
End Class

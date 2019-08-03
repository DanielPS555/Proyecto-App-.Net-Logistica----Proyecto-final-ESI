Imports Controladores.Extenciones.Extensiones
Public Class Funciones_comunes
    Public Shared Function ContraseñaHash(password As String) As String ' NO es determinística ni idempotente;
        ' esto es, la misma contraseña retornará distintos hash ya que el hash
        ' incluye valores extra (aleatorios) para poder verificar una contraseña contra él. Por ende,
        ' para verificar no haga ContraseñaHash("passw123")=hash_contra
        ' llame a VerificarHash
        Return BCrypt.Net.BCrypt.EnhancedHashPassword(password, hashType:=BCrypt.Net.HashType.SHA256)
    End Function

    Public Shared Function AutoNull(Of T)(data As Object) As T
        If data Is DBNull.Value Then
            Return Nothing
        End If
        Return data
    End Function
    Private Shared CharToNum As List(Of Char) = New List(Of Char) From {
        " ",
        "$",
        "%",
        "*",
        "+",
        "-",
        ".",
        "/",
        ":"
    }
    Public Shared Function CharToNumber(chr As Char) As Byte
        If chr >= "0" AndAlso chr <= "9" Then
            Return AscW(chr) - AscW("0")
        ElseIf chr >= "A" AndAlso chr <= "Z" Then
            Return AscW(chr) - AscW("A") + 10
        ElseIf CharToNum.Contains(chr) Then
            Return CharToNum.IndexOf(chr) + 36
        Else
            Return Nothing
        End If

    End Function
    Public Shared Function PairToNumber(pair As String) As BitArray
        pair = pair.Substring(0, 2).ToUpper
        Dim a = CharToNumber(pair(0))
        Dim b = CharToNumber(pair(0))
        Dim r As Short = (a * 45) + b
        Dim x = BitConverter.GetBytes(r)
        Dim ba = New BitArray(x)
        Dim b_array = New BitArray(11)
        For i = 0 To 10
            b_array.Set(i, ba.Get(i))
        Next
        Return b_array
    End Function
    Public Shared Function GaloisField256(n As Byte) As Byte ' Galois Field(X): campo matemático de los numeros 0 a X, donde la suma entre (a,b) en GF(X) es (a+b) modulo x, y lo mismo con la resta.
        If n < 8 Then '                                        Según thonky.com, todos los numeros en GF(256) son representables como una potencia de 2 usando aritmética con modulo 285
            Return CType(Math.Pow(2, n), Integer)            ' No entiendo completamente los campos Galois; preguntar a Cristina
        ElseIf n = 8 Then
            Dim x As Integer = Math.Pow(2, 8)
            Return (x Xor 285)
        Else
            Dim x As Integer = GaloisField256(n - 1)
            x *= 2
            If (x >= 256) Then
                x = x Xor 285
            End If
            Return x
        End If
    End Function

    Public Shared Function QR(VIN As String) As Bitmap
        Dim QCG As New QRCoder.QRCodeGenerator
        Dim QCD = QCG.CreateQrCode(VIN, QRCoder.QRCodeGenerator.ECCLevel.M, requestedVersion:=1)
        Dim QC As New QRCoder.QRCode(QCD)
        Return QC.GetGraphic(20)
    End Function

    Public Shared Function QR_1M(VIN As String) ' https://www.thonky.com/qr-code-tutorial/data-encoding
        '                                         https://www.thonky.com/qr-code-tutorial/error-correction-coding
        '                                         https://www.thonky.com/qr-code-tutorial/character-capacities
        '                                         Probablemente sea inviable la implementación del algoritmo por nuestra parte, al menos por ahora
        If (VIN.Length And 1) > 0 Then
            VIN = VIN + " "
        End If
        Dim QRString = "0010"
        Dim pairs = VIN.Length / 2
        Dim bArray = New BitArray(9)
        For i = 0 To 8
            bArray.Set(i, VIN.Length And (1 << i))
        Next
        Dim LString = ""
        For i = 0 To 8
            If bArray(i) Then
                LString += "1"
            Else
                LString += "0"
            End If
        Next
        LString.Reverse
        QRString += LString
        For i = 0 To pairs - 1
            Dim p = PairToNumber(VIN.Substring(i * 2))
            Dim PNum = ""
            For bI = 0 To 11
                If p(bI) Then
                    PNum += "1"
                Else
                    PNum += "0"
                End If
            Next
            PNum.Reverse
            QRString += PNum
        Next
        Dim dif = QRString.Length - 16 * 8
        If dif > 0 Then
            QRString += "0".Repeat(Math.Min(dif, 4))
        End If
        If QRString Mod 8 <> 0 Then
            QRString += "0".Repeat(QRString Mod 8)
        End If
        Dim Padding() As String = New List(Of String) From {"11101100", "00010001"}.ToArray
        For i = 0 To 15 - (QRString.Length / 8)
            QRString += Padding(i Mod 2)
        Next

    End Function

    Public Shared Function DarFormato(fecha As Date?) As String
        Return If(fecha IsNot Nothing, fecha?.ToString("yyyy/MM/dd a la\s HH:mm:ss"), "Nunca")
    End Function

    Public Shared Function Hex_to_rgb(color As String) As System.Drawing.Color
        Dim R As Integer = Integer.Parse(color.Substring(0, 2), System.Globalization.NumberStyles.HexNumber)
        Dim G As Integer = Integer.Parse(color.Substring(2, 2), System.Globalization.NumberStyles.HexNumber)
        Dim B As Integer = Integer.Parse(color.Substring(4, 2), System.Globalization.NumberStyles.HexNumber)
        Dim re As Color = System.Drawing.Color.FromArgb(R, G, B)
        Return re
    End Function



End Class

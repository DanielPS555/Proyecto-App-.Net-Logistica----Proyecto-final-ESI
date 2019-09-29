Imports System.Globalization
Imports System.IO
Imports System.Resources
Imports Controladores.Extenciones.Extensiones
Public Class Funciones_comunes
    Public Shared Function ContraseñaHash(password As String) As String ' NO es determinística ni idempotente;
        ' esto es, la misma contraseña retornará distintos hash ya que el hash
        ' incluye valores extra (aleatorios) para poder verificar una contraseña contra él. Por ende,
        ' para verificar no haga ContraseñaHash("passw123")=hash_contra
        ' llame a VerificarHash
        Return BCrypt.Net.BCrypt.EnhancedHashPassword(password, hashType:=BCrypt.Net.HashType.SHA256)
    End Function

    Public Shared Function HexToColor(hex As String) As Color
        If hex Is Nothing Then
            Return Nothing
        End If
        Return Color.FromArgb(Convert.ToInt32("0x" + hex, 16))
    End Function

    Private Shared SourceDictionary As SortedList(Of Int32, String)
    Private Shared TargetDictionary As Dictionary(Of String, SortedList(Of Int32, String))
    Public Shared ReadOnly Languages() As String = {"Spanish", "English"}

    Public Shared Sub Inter_test()
        LoadI18N()
        For Each l In Languages
            For Each h In SourceDictionary.Values
                Console.WriteLine(I18N(h, l))
            Next
        Next
    End Sub

    'COMO USAR
    'LLAMAMOS A I18N(String que buscamos, lenguaje que queremos)
    'EJEMPLO: I18N('Estás mal de la cabeza o qué te pasa?', 'English') -> 'Are you insane or what's happening to you?'
    'PARA CAMBIAR O AGREGAR LINEAS: MODIFICAR Spanish.txt y English.txt
    'PARA AGREGAR LENGUAJES: CREAR UN NUEVO TXT, AGREGARLO A LOS RECURSOS *DE CONTROLADOR* Y AGREGARLO AL ARRAY LANGUAGES MÁS ARRIBA
    Public Shared Function I18N(OriginalString As String, toLang As String) As String
        If OriginalString.Length < 2 Then
            Return Nothing
        End If
        Dim iHash = KDHash(OriginalString)
        'hasheamos el string que estamos buscando

        If SourceDictionary Is Nothing Then
            LoadI18N()
        End If
        Dim dict = Array.IndexOf(Languages, toLang)
        If dict = 0 Then
            Return SourceDictionary(iHash)
        ElseIf dict > 0 Then
            Return TargetDictionary(Languages(dict))(iHash)
        Else
            Return Nothing
        End If
    End Function

    Private Shared Sub LoadI18N()

        ' cargamos los recursos de texto
        SourceDictionary = New SortedList(Of Integer, String)
        Dim fileIn = My.Resources.ResourceManager.GetString("Spanish").Split(vbNewLine)
        ' las líneas del archivo
        Dim hashes As New List(Of Int32)
        ' la lista de hashes (esperamos que cada String esté en la misma línea en todos los txt)
        For Each s In fileIn
            Dim line = s.Trim
            Dim lHash = KDHash(line)
            SourceDictionary(lHash) = line
            ' hasheamos la línea y guardamos su hash
            hashes.Add(lHash)
        Next
        TargetDictionary = New Dictionary(Of String, SortedList(Of Integer, String))
        For i = 1 To Languages.Length - 1
            TargetDictionary(Languages(i)) = New SortedList(Of Integer, String)
            Dim tdict = TargetDictionary(Languages(i))
            fileIn = My.Resources.ResourceManager.GetString(Languages(i)).Split(vbNewLine)
            For s = 0 To hashes.Count - 1
                Dim line = fileIn(s).Trim
                ' usamos el hash de esta línea en el txt original como el hash de esta línea del diccionario alternativo
                Dim lHash = hashes(s)
                TargetDictionary(Languages(i))(lHash) = line
            Next
        Next
    End Sub

    Private Shared Function KDHash(Input As String) As Int32 ' Kouta's Dirty Hash:
        ' Nota: no es una función de hasheo real, pero dentro de nuestro dominio debería ser (a la vista) un hasheo
        ' cuasi-perfecto
        ' El hasheo se calcula como el largo del string reducido a 8 bytes, seguido por
        ' el primer caracter del string (Mod 256 por si es unicode con >1 codepoint),
        ' el caracter más cercano a la mitad del string (también mod 256 por la misma razón)
        ' y el último caracter del string (idem), todo interpretado como un int32
        ' por último, se hace un xor con cada caracter del string, para intentar hacer un poco más único el hash
        ' sólo habría de colisionar en caso de tener strings que tengan el mismo largo, comiencen y terminen 
        ' con los mismos caracteres y tengan el mismo caracter en la mitad
        Dim strLen = Input.Length Mod 256
        Dim strHash(3) As Byte
        strHash(0) = strLen
        strHash(1) = AscW(Input(0)) Mod 256
        strHash(2) = AscW(Input(Input.Length \ 2)) Mod 256
        strHash(3) = AscW(Input(Input.Length - 1)) Mod 256
        For i = 0 To Input.Length - 1
            strHash(i Mod 4) = strHash(i Mod 4) Xor (AscW(Input(i)) Mod 256)
        Next
        Dim iHash = BitConverter.ToInt32(strHash, 0)
        Return iHash
    End Function

    Public Shared Function BitmapFromByteArray(v As Byte()) As Bitmap
        Dim br = New IO.MemoryStream(v)
        Dim bm = New Bitmap(br)
        br.Close()
        Return bm
    End Function

    Public Shared Function ConvertToByteArray(ByVal value As Bitmap) As Byte()
        Dim bitmapBytes As Byte()
        Using stream As New System.IO.MemoryStream
            value.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg)
            bitmapBytes = stream.ToArray
        End Using
        Return bitmapBytes
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
        Return fecha.DarFormato
    End Function

    Public Shared Function Hex_to_rgb(color As String) As System.Drawing.Color
        Dim R As Integer = Integer.Parse(color.Substring(0, 2), System.Globalization.NumberStyles.HexNumber)
        Dim G As Integer = Integer.Parse(color.Substring(2, 2), System.Globalization.NumberStyles.HexNumber)
        Dim B As Integer = Integer.Parse(color.Substring(4, 2), System.Globalization.NumberStyles.HexNumber)
        Dim re As Color = System.Drawing.Color.FromArgb(R, G, B)
        Return re
    End Function

    Public Shared Function formatoCorrectoDelEmail(email As String) As Boolean
        Dim aroba As Integer = -1
        Dim punto As Integer = -1

        For i As Integer = 0 To email.Length - 1
            If email(i) = "@" Then
                If aroba = -1 Then
                    aroba = i
                Else
                    Return False ' No puede haber dos @
                End If
            End If

            If email(i) = "." Then
                punto = i
            End If
        Next

        If punto > aroba Then 'Siempre hay un . dentras de la @
            Return True

        Else
            Return False
        End If

    End Function

    Public Shared Function SinEspacios(texto As String) As Boolean
        For Each c As Char In texto
            If c = " " Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Shared Function soloNumeros(texto As String) As Boolean
        For Each c As Char In texto
            If Not Char.IsNumber(c) Then
                Return False
            End If
        Next
        Return True
    End Function



End Class

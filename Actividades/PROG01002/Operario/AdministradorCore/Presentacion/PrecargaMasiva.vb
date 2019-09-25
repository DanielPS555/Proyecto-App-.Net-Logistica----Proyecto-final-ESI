Imports Controladores

Public Class PrecargaMasiva
    Private Verify(-1) As Boolean
    Private clientList As List(Of Cliente) = Fachada.getInstancia.ClientesDelSistema
    Private Shared ColorDictionary As New Dictionary(Of String, Drawing.Color) From {
        {"rojo", Drawing.Color.Red},
        {"azul", Drawing.Color.Blue},
        {"amarillo", Drawing.Color.Yellow},
        {"verde", Drawing.Color.Green}
        }

    Private Sub openCSV_Click(sender As Object, e As EventArgs) Handles openCSV.Click
        Dim cols(OptionalColumns.CheckedItems.Count) As String
        OptionalColumns.CheckedItems.CopyTo(cols, 1)
        cols(0) = "VIN"
        Dim k = PanelCSV.ReadCSV(cols)
        If k Is Nothing Then
            Return
        End If
        For Each optC In OptionalColumns.Items
            If Not k.Columns.Contains(optC.ToString) Then
                k.Columns.Add(optC.ToString)
            End If
        Next
        For Each r In k.Rows.Cast(Of DataRow)
            Dim VIN As String = r("VIN")
            If VIN Is Nothing OrElse VIN.Length <> 17 Then
                MsgBox("El VIN debe tener una longitud de 17, falló para " & VIN)
            End If
            Dim Marca As String = Funciones_comunes.AutoNull(Of String)(r("Marca"))
            If Marca Is Nothing OrElse Marca.Length < 1 Then
                Marca = Nothing
            End If
            Dim Modelo As String = Funciones_comunes.AutoNull(Of String)(r("Modelo"))
            If Modelo Is Nothing OrElse Modelo.Length < 1 Then
                Modelo = Nothing
            End If
            Dim colorString As String = Funciones_comunes.AutoNull(Of String)(r("Color"))
            Dim color As Drawing.Color
            If colorString Is Nothing Then
                color = Nothing
            Else
                If ColorDictionary.Keys.Contains(colorString) Then
                    color = ColorDictionary(colorString)
                Else
                    Try
                        color = Funciones_comunes.HexToColor(colorString)
                    Catch ex As Exception
                        color = Nothing
                        MsgBox("Error al interpretar el color: " & ex.ToString)
                    End Try
                End If
            End If
            Dim año As String = Funciones_comunes.AutoNull(Of String)(r("Año"))
            Dim añoInt As Integer
            If año Is Nothing Then
                añoInt = 0
            Else
                If Not Integer.TryParse(año, añoInt) Then
                    MsgBox("El valor " & año & " no es un entero")
                    añoInt = 0
                End If
            End If
            Dim tipo As String = Funciones_comunes.AutoNull(Of String)(r("Tipo"))
            If tipo IsNot Nothing AndAlso Not Vehiculo.TIPOS_VEHICULOS.Contains(tipo) Then
                MsgBox("El tipo " & tipo & " no se reconoció!")
                tipo = Nothing
            End If
            Dim NombreCliente As String = Funciones_comunes.AutoNull(Of String)(r("Cliente"))
            Dim cliente = clientList.Where(Function(x) x.Nombre.Equals(NombreCliente)).SingleOrDefault ' singleordefault: si no hay elementos en la secuencia, devuelve null
            Dim nvehiculo = New Vehiculo(VIN, Marca, Modelo, añoInt, tipo, color, cliente)
            vehicleBox.Items.Add(nvehiculo)
        Next
        Dim preLen = Verify.Length
        ReDim Preserve Me.Verify(vehicleBox.Items.Count - 1)
        For i = preLen To Verify.Length - 1
            Verify(i) = False
        Next
    End Sub

    Private Sub vehicleBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles vehicleBox.SelectedIndexChanged
        Dim v As Vehiculo = vehicleBox.SelectedItem
        If v IsNot Nothing Then
            Marco.getInstancia.CargarPanel(New NuevaPrecarga(v))
            Verify(vehicleBox.SelectedIndex) = True
        End If
    End Sub

    Private Sub uploadPreloads_Click(sender As Object, e As EventArgs) Handles uploadPreloads.Click
        If Verify.Length > 0 And Verify.Aggregate(True, Function(x, y) x And y) Then
            For Each v As Vehiculo In vehicleBox.Items
                Fachada.getInstancia.nuevaPrecarga(v, Fachada.getInstancia.DevolverUsuarioActual)
            Next
            MsgBox("Precargas subidas con éxito!")
            Marco.getInstancia.cerrarPanel(Of PrecargaMasiva)()
        Else
            MsgBox("Debe acceder a todos los vehículos para subir la precarga")
        End If
    End Sub
End Class
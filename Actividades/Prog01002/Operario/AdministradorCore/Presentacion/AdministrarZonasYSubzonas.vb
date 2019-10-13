Public Class AdministrarZonasYSubzonas
    Private lugar As Controladores.Lugar
    Private padre As Controladores.nuevoLugar
    Private lugarViejo As Controladores.Lugar
    Public Sub New(lug As Controladores.Lugar, padre As Controladores.nuevoLugar)
        If lug.Zonas Is Nothing Then
            lug.Zonas = New List(Of Controladores.Zona)
        End If
        Me.padre = padre
        lugar = lug

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        capacidad.Maximum = lug.Capasidad
        lugarnom.Text = lug.Nombre
        capasidadLugar.Text = lug.Capasidad
        cargarDatosZona(0)
        comprobar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(idlugar As Integer)
        InitializeComponent()
        lugar = Controladores.Fachada.getInstancia.LugarZonasySubzonas(idlugar)
        lugarViejo = lugar
        capacidad.Maximum = lugar.Capasidad
        lugarnom.Text = lugar.Nombre
        capasidadLugar.Text = lugar.Capasidad
        cargarDatosZona(0)
        comprobar()
    End Sub

    Private Sub cargarDatosZona(altura As Integer)
        zonas.Items.Clear()
        If lugar.Zonas.Count > 0 Then
            For Each zona As Controladores.Zona In lugar.Zonas
                zonas.Items.Add($"{zona.Nombre}({zona.Capacidad})")
            Next
            zonas.SelectedIndex = altura
        Else
            zonas.SelectedIndex = -1
        End If
    End Sub

    Private Sub Zonas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles zonas.SelectedIndexChanged
        CargarDatosSubzona()
    End Sub

    Private Sub CargarDatosSubzona()
        subzonas.Items.Clear()
        If zonas.SelectedIndex = -1 Then
            Return
        End If
        If lugar.Zonas(zonas.SelectedIndex).Subzonas.Count > 0 Then
            For Each subzona As Controladores.Subzona In lugar.Zonas(zonas.SelectedIndex).Subzonas
                subzonas.Items.Add($"{subzona.Nombre}({subzona.Capasidad})")
            Next
            subzonas.SelectedIndex = 0
        Else
            subzonas.SelectedIndex = -1
        End If
    End Sub

    Private Sub Nuevazona_Click(sender As Object, e As EventArgs) Handles nuevazona.Click

        If nombre.Text.Trim.Length = 0 Then
            MsgBox("El nombre no puede ser vacio", MsgBoxStyle.Critical)
            Return
        End If

        If lugar.Zonas.Select(Function(x) x.Nombre).Contains(nombre.Text) Then
            MsgBox("El nombre no puede repetirse", MsgBoxStyle.Critical)
            Return
        End If

        If capacidad.Value = 0 Then
            MsgBox("No puede ingresar una capasidad igual a 0", MsgBoxStyle.Critical)
            Return
        End If

        If capacidad.Value > lugar.Capasidad Then
            MsgBox("La capasidad no puede ser mayor a la del lugar", MsgBoxStyle.Critical)
            Return
        End If

        Dim suma As Integer = 0
        For Each z In lugar.Zonas
            suma += z.Capacidad
        Next

        If (suma + capacidad.Value) > lugar.Capasidad Then
            MsgBox("La capasidad sumada de las zonas supera a la del lugar", MsgBoxStyle.Critical)
            Return
        End If

        lugar.Zonas.Add(New Controladores.Zona() With {.Nombre = nombre.Text, .Capacidad = capacidad.Value, .LugarPadre = lugar})
        cargarDatosZona(zonas.SelectedIndex)
        comprobar()
    End Sub

    Private Sub Nuevasubzona_Click(sender As Object, e As EventArgs) Handles nuevasubzona.Click

        If zonas.SelectedIndex = -1 Then
            MsgBox("Debe selecionar la zona a la que pertenece", MsgBoxStyle.Critical)
            Return
        End If

        If nombre.Text.Trim.Length = 0 Then
            MsgBox("El nombre no puede ser vacio", MsgBoxStyle.Critical)
            Return
        End If

        If lugar.Zonas(zonas.SelectedIndex).Subzonas.Select(Function(x) x.Nombre).Contains(nombre.Text) Then
            MsgBox("El nombre no puede repetirse", MsgBoxStyle.Critical)
            Return
        End If

        If capacidad.Value = 0 Then
            MsgBox("No puede ingresar una capasidad igual a 0", MsgBoxStyle.Critical)
            Return
        End If

        If capacidad.Value > lugar.Zonas(zonas.SelectedIndex).Capacidad Then
            MsgBox("La capasidad no puede ser mayor a la del lugar", MsgBoxStyle.Critical)
            Return
        End If

        If lugar.Zonas.Select(Function(x) x.Nombre).Contains(nombre.Text) Then
            MsgBox("El nombre no puede ser igual al de una zona", MsgBoxStyle.Critical)
            Return
        End If

        Dim suma As Integer = 0
        For Each z In lugar.Zonas(zonas.SelectedIndex).Subzonas
            suma += z.Capasidad
        Next

        If lugar.Zonas(zonas.SelectedIndex).Capacidad < (suma + capacidad.Value) Then
            MsgBox($"La suma de las capasidad de las subzonas en la zona {lugar.Zonas(zonas.SelectedIndex).Nombre} debe no ser mayor a la misma", MsgBoxStyle.Critical)
            Return
        End If

        lugar.Zonas(zonas.SelectedIndex).Subzonas.Add(New Controladores.Subzona() With {.Nombre = nombre.Text, .Capasidad = capacidad.Value, .ZonaPadre = lugar.Zonas(zonas.SelectedIndex)})
        CargarDatosSubzona()
        comprobar()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If zonas.SelectedIndex <> -1 Then
            lugar.Zonas.RemoveAt(zonas.SelectedIndex)
            zonas.Items.RemoveAt(zonas.SelectedIndex)
        Else
            MsgBox("Primero selecione la zona que desea eliminar", MsgBoxStyle.Critical)
        End If
        comprobar()
    End Sub

    Private Sub Eliminar_Click(sender As Object, e As EventArgs) Handles eliminar.Click
        If zonas.SelectedIndex <> -1 And subzonas.SelectedIndex <> -1 Then
            lugar.Zonas(zonas.SelectedIndex).Subzonas.RemoveAt(subzonas.SelectedIndex)
            subzonas.Items.RemoveAt(subzonas.SelectedIndex)
        Else
            MsgBox("Primero selecione la zona que desea eliminar", MsgBoxStyle.Critical)
        End If
        comprobar()
    End Sub


    Private Sub comprobar()
        If lugar.Zonas Is Nothing OrElse lugar.Zonas.Count = 0 Then
            Estado.Text = "Sin elementos"
            Estado.ForeColor = System.Drawing.Color.FromArgb(180, 20, 20)
            aceptar.Enabled = False
            Return
        End If

        Dim sumaTotal As Integer = 0
        For Each zona As Controladores.Zona In lugar.Zonas
            Dim sumaMenor As Integer = 0
            For Each subzona As Controladores.Subzona In zona.Subzonas
                sumaTotal += subzona.Capasidad
                sumaMenor += subzona.Capasidad
            Next
            If sumaMenor <> zona.Capacidad Then
                Estado.Text = $"Las subzonas de la zona:{zona.Nombre} es diferente a la capasidad de la misma"
                Estado.ForeColor = System.Drawing.Color.FromArgb(180, 20, 20)
                aceptar.Enabled = False
                Return
            End If
        Next

        If sumaTotal <> lugar.Capasidad Then
            Estado.Text = "La suma de las capasidad de todas las subzonas debe ser igual a la del lugar"
            Estado.ForeColor = System.Drawing.Color.FromArgb(180, 20, 20)
            aceptar.Enabled = False
            Return
        End If

        Estado.Text = "Aceptado"
        Estado.ForeColor = System.Drawing.Color.FromArgb(35, 35, 35)
        aceptar.Enabled = True

    End Sub

    Private Sub Aceptar_Click(sender As Object, e As EventArgs) Handles aceptar.Click
        If padre IsNot Nothing Then
            padre.devolverlugar(lugar)
            Controladores.Marco.getInstancia.cerrarPanel(Of AdministrarZonasYSubzonas)()
            Me.Close()
        Else
            If Controladores.Fachada.getInstancia.PosicionesActualesPorIdlugar(lugarViejo.IDLugar).Count = 0 Then
                If MsgBox("Al no haber nigun vehiculo asignado en dicho lugar se puede realizar la modificacion directamente, ¿Desea continuar?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    'AQUI DEBEMOS REALIZAR DIRECTAMENTE EL ALTA
                End If

            Else
                    Controladores.Marco.getInstancia.CargarPanel(Of Incongrencia)(New Incongrencia(lugarViejo, lugar, Me))
            End If

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Controladores.Marco.getInstancia.cerrarPanel(Of AdministrarZonasYSubzonas)()
    End Sub
End Class
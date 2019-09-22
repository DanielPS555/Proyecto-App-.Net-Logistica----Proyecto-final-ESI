Public Class AdministrarZonasYSubzonas
    Private lugar As Controladores.Lugar
    Public Sub New(lug As Controladores.Lugar)
        lugar = lug
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        nombre.Text = lug.Nombre
        capasidadLugar.Text = lug.Capasidad
        cargarDatosZona(0)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

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
        CargarDatosSubzona(0)
    End Sub

    Private Sub CargarDatosSubzona(altura As Integer)
        subzonas.Items.Clear()
        If lugar.Zonas(zonas.SelectedIndex).Subzonas.Count > 0 Then
            For Each subzona As Controladores.Subzona In lugar.Zonas(zonas.SelectedIndex).Subzonas
                subzonas.Items.Add($"{subzona.Nombre}({subzona.Capasidad})")
            Next
            subzonas.SelectedIndex = altura
        Else
            subzonas.SelectedIndex = -1
        End If
    End Sub

    Private Sub Nuevazona_Click(sender As Object, e As EventArgs) Handles nuevazona.Click

        If nombre.Text.Trim = 0 Then
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

        If suma > lugar.Capasidad Then
            MsgBox("La capasidad sumada de las zonas supera a la del lugar", MsgBoxStyle.Critical)
            Return
        End If

        lugar.Zonas.Add(New Controladores.Zona() With {.Nombre = nombre.Text, .Capacidad = capacidad.Value, .LugarPadre = lugar})
        cargarDatosZona(zonas.SelectedIndex)
    End Sub

    Private Sub Nuevasubzona_Click(sender As Object, e As EventArgs) Handles nuevasubzona.Click

        If zonas.SelectedIndex = -1 Then

        End If

        If nombre.Text.Trim = 0 Then
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

        If suma <> lugar.Zonas(zonas.SelectedIndex).Capacidad Then
            Estado.Text = "La suma de las subzonas deber ser igual a la de la zona"
        End If

        lugar.Zonas(zonas.SelectedIndex).Subzonas.Add(New Controladores.Subzona() With {.Nombre = nombre.Text, .Capasidad = capacidad.Value, .ZonaPadre = lugar.Zonas(zonas.SelectedIndex)})
        CargarDatosSubzona(zonas.SelectedIndex)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If zonas.SelectedIndex <> -1 Then
            zonas.Items.RemoveAt(zonas.SelectedIndex)
        Else
            MsgBox("Primero selecione la zona que desea eliminar", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Eliminar_Click(sender As Object, e As EventArgs) Handles eliminar.Click

    End Sub


    Private Sub comprobar()
        Dim sumaTotal
        For Each zona As Controladores.Zona In lugar.Zonas

        Next
    End Sub
End Class
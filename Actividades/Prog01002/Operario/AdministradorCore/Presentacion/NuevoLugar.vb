Imports System.Data.Linq
Imports System.Windows.Forms
Imports Controladores
Imports Controladores.Extenciones
Public Class NuevoLugar
    Implements Controladores.nuevoLugar
    Private position As GMap.NET.WindowsForms.GMapMarker = Nothing
    Private posicionesLugar As Controladores.Lugar
    Private padreCliente As Controladores.nuevoLugar

    Private Sub GMapControl1_MouseUp(sender As Object, e As MouseEventArgs) Handles GMapControl1.MouseUp
        If e.Button <> MouseButtons.Right Then
            Return
        End If
        If GMapControl1.Overlays.Count < 1 Then
            GMapControl1.Overlays.Add(New GMap.NET.WindowsForms.GMapOverlay("mapPosition"))
        End If
        If position Is Nothing Then
            Dim pos = GMapControl1.FromLocalToLatLng(e.X, e.Y)
            position = New GMap.NET.WindowsForms.Markers.GMarkerGoogle(pos, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_pushpin)
            GMapControl1.Overlays.Single.Markers.Add(position)
        Else
            position.Position = GMapControl1.FromLocalToLatLng(e.X, e.Y)
        End If
        GMapControl1.Refresh()
    End Sub

    Private Sub NuevoLugar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GMapControl1.MapProvider = GMap.NET.MapProviders.GMapProviders.OpenStreetMap
        GMapControl1.ShowCenter = False
        GMapControl1.MaxZoom = 15
        GMapControl1.MinZoom = 3
        GMapControl1.Refresh()
        Dim tiposMedios = Controladores.Fachada.getInstancia.TodosLosTiposDeMediosDisponibles
        mediosPermitidos.Items.Clear()
        mediosPermitidos.Items.AddRange(tiposMedios.ToArray)
        TipoLugar.Items.Clear()
        TipoLugar.Items.Add(Controladores.Lugar.TIPO_LUGAR_ESTACION)
        TipoLugar.Items.Add(Controladores.Lugar.TIPO_LUGAR_PATIO)
        TipoLugar.Items.Add(Controladores.Lugar.TIPO_LUGAR_PUERTO)
    End Sub

    Private Sub CrearButton_Click(sender As Object, e As EventArgs) Handles CrearButton.Click
        If Zonas.Count < 1 Then
            MsgBox("Debe tener al menos una zona")
            Return
        End If
        Dim sum_zonas As Integer
        Try
            sum_zonas = Zonas.Select(Function(x) x.Capacidad).Sum
        Catch ex As Exception
            MsgBox("Alguna capacidad de zona no es un número!")
            Return
        End Try
        If sum_zonas <> capacidad.Value Then
            MsgBox("La suma de las capacidades de las zonas debe ser igual a la capacidad del lugar")
            Return
        End If
        For Each z In Zonas
            Dim zonaName = z.Nombre
            If z.Subzonas.Count < 1 Then
                MsgBox("Debe tener al menos una subzona por zona")
                Return
            End If
            Try
                If z.Subzonas.Select(Function(x) x.Capasidad).Sum <> z.Capacidad Then
                    MsgBox($"La suma de las capacidades de las subzonas debe ser igual a la capacidad de la zona ({zonaName})")
                    Return
                End If
            Catch ex As Exception
                MsgBox($"Alguna capacidad de subzona en {zonaName} no es un número!")
                Return
            End Try
        Next
        If position Is Nothing Then
            MsgBox("Debe establecer la posición del lugar")
            Return
        End If
        If TipoLugar.SelectedIndex < 0 Then
            MsgBox("Debe establecer el tipo del lugar")
            Return
        End If
        If mediosPermitidos.CheckedItems.Count < 1 Then
            MsgBox("Debe permitir al menos un medio de transporte")
            Return
        End If
        If nombreBox.Text.Length < 1 Then
            MsgBox("Debe ingresar un nombre para el lugar")
        End If
        Try
            Dim lugar = Controladores.Fachada.getInstancia.CrearLugar(nombreBox.Text, position.Position, CType(TipoLugar.SelectedItem, String),
                                                      mediosPermitidos.CheckedItems.Cast(Of Controladores.TipoMedioTransporte).ToArray,
                                                      capacidad.Value, Zonas)
            If lugar IsNot Nothing Then
                Controladores.Marco.getInstancia.cargarPanel(New PanelLugar(lugar.IDLugar))
                Controladores.Marco.getInstancia.cerrarPanel(Of NuevoLugar)()
            Else
                MsgBox("No se pudo crear el lugar, por favor verifique la información")
            End If
        Catch ex As Controladores.InvalidStateException(Of Integer)
            MsgBox("Excepción!")
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub VScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBar1.Scroll
        Dim pos = GMapControl1.Position
        Dim per = -((e.NewValue) / 100.0F)
        Dim newY = Controladores.Fachada.URUGUAYTOP + (Controladores.Fachada.URUGUAY_Y * per)
        pos.Lat = newY
        GMapControl1.Position = pos
    End Sub

    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar1.Scroll
        Dim pos = GMapControl1.Position
        Dim per = -((100 - e.NewValue) / 100.0F)
        Dim newX = Controladores.Fachada.URUGUAYEAST + (Controladores.Fachada.URUGUAY_X * per)
        pos.Lng = newX
        GMapControl1.Position = pos
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim newPoint As GMap.NET.PointLatLng
        Dim gcsc = GMapControl1.GetPositionByKeywords(buscarText.Text, newPoint)
        If gcsc = GMap.NET.GeoCoderStatusCode.OK Then
            GMapControl1.Position = newPoint
            Dim YScroll = -((newPoint.Lat - Controladores.Fachada.URUGUAYTOP) / Controladores.Fachada.URUGUAY_Y) * 100
            If YScroll < 0 Or YScroll > 100 Then
                Return
            End If
            Dim XScroll = -((newPoint.Lng - Controladores.Fachada.URUGUAYEAST) / Controladores.Fachada.URUGUAY_X) * 100
            XScroll = 100 - XScroll
            If XScroll < 0 Or XScroll > 100 Then
                Return
            End If
            HScrollBar1.Value = XScroll
            VScrollBar1.Value = YScroll
        Else
            MsgBox($"No se pudo encontrar el lugar: {[Enum].GetName(GetType(GMap.NET.GeoCoderStatusCode), gcsc)}")
        End If
    End Sub

    Private Zonas As New List(Of Controladores.Zona)

    Public Sub New()
        InitializeComponent()


    End Sub

    Public Sub New(papa As Controladores.nuevoLugar)
        InitializeComponent()
        TipoLugar.Enabled = False
        TipoLugar.SelectedItem = Controladores.Lugar.TIPO_LUGAR_ESTACION

    End Sub

    'Private Sub RenderTree()
    '    ZonasSubzonas.Nodes.Clear()
    '    For Each z In Zonas
    '        Dim n = ZonasSubzonas.Nodes.Add($"{z.Nombre} ({z.Capacidad})")
    '        n.Tag = z
    '        For Each sz In z.Subzonas
    '            Dim sn = n.Nodes.Add($"{sz.Nombre} ({sz.Capasidad})")
    '            sn.Tag = sz
    '        Next
    '    Next
    'End Sub

    'Private Sub Button2_Click(sender As Object, e As EventArgs)
    '    If nombreZona.Text.Length < 1 Then
    '        MsgBox("El nombre de la zona no puede estar vacío")
    '        Return
    '    ElseIf capacidadZona.Value = 0 Then
    '        MsgBox("La capacidad de la zona debe ser > 0")
    '        Return
    '    End If
    '    Dim z As New Controladores.Zona(-1, nombreZona.Text, capacidadZona.Value, Nothing)
    '    Zonas.Add(z)
    '    RenderTree()
    'End Sub

    'Private Sub ZonasSubzonas_AfterSelect(sender As Object, e As TreeViewEventArgs)
    '    Button3.Enabled = (e.Node.Level = 0)
    'End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        'If nombreZona.Text.Length < 1 Then
        '    MsgBox("El nombre de la subzona no puede estar vacío")
        '    Return
        'ElseIf capacidadZona.Value = 0 Then
        '    MsgBox("La capacidad de la subzona debe ser > 0")
        '    Return
        'End If
        'Dim n = ZonasSubzonas.SelectedNode
        'Dim z = CType(n.Tag, Controladores.Zona)
        'Dim sz = New Controladores.Subzona(-1, capacidadZona.Value, nombreZona.Text, z)
        'z.Subzonas.Add(sz)
        'RenderTree()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles zonasysubzonas.Click
        If nombreBox.Text.Trim.Length = 0 OrElse capacidad.Value = 0 Then

        End If
        Controladores.Marco.getInstancia.cargarPanel(Of AdministrarZonasYSubzonas)(New AdministrarZonasYSubzonas(New Lugar() With {
                                                                                                                .Nombre = nombreBox.Text,
                                                                                                                .Capasidad = capacidad.Value,
                                                                                                                .Zonas = New List(Of Zona)}, Me))
    End Sub

    Public Sub devolverlugar(lug As Lugar) Implements Controladores.nuevoLugar.devolverlugar
        posicionesLugar = lug
        estadozonas.Text = "Listo"
        estadozonas.ForeColor = Drawing.Color.FromArgb(35, 35, 35)
    End Sub

    Private Sub TipoLugar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TipoLugar.SelectedIndexChanged
        If TipoLugar.SelectedItem = Controladores.Lugar.TIPO_LUGAR_ESTACION Then
            zonasysubzonas.Enabled = False
            estadozonas.Text = "No requerido"
        Else
            zonasysubzonas.Enabled = True
            If posicionesLugar Is Nothing Then
                estadozonas.Text = "Sin realizar"
                estadozonas.ForeColor = Drawing.Color.FromArgb(180, 20, 20)
            Else
                estadozonas.Text = "Listo"
                estadozonas.ForeColor = Drawing.Color.FromArgb(35, 35, 35)
            End If
        End If
    End Sub
End Class
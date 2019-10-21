Imports System.Data.Linq
Imports System.Windows.Forms
Imports Controladores
Imports Controladores.Extenciones
Public Class NuevoLugar
    Implements Controladores.nuevoLugar
    Private position As GMap.NET.WindowsForms.GMapMarker = Nothing
    Private posicionesLugar As Controladores.Lugar
    Private padreCliente As Controladores.nuevoLugar
    Private tiposDeMEdio As List(Of Controladores.TipoMedioTransporte)
    Private clientes As New List(Of Controladores.Cliente)

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
        tiposDeMEdio = Controladores.Fachada.getInstancia.TodosLosTiposDeMediosDisponibles
        mediosPermitidos.Items.Clear()
        mediosPermitidos.Items.AddRange(tiposDeMEdio.Select(Function(x) x.Nombre).ToArray)


    End Sub

    Private Sub CrearButton_Click(sender As Object, e As EventArgs) Handles CrearButton.Click

        If nombreBox.Text.Trim.Length = 0 Then
            MsgBoxI18N("Debe haber un nombre para el lugar ", MsgBoxStyle.Critical)
            Return
        End If

        If Not Controladores.Funciones_comunes.sinCaracteresEspeciales(nombreBox.Text) Then
            MsgBoxI18N("el nombre del lugar tiene caracteres no permitidos", MsgBoxStyle.Critical)
            Return
        End If

        If Fachada.getInstancia.numeroDeLugarGrandeConEseNombre(nombreBox.Text.Trim) = 1 Then
            MsgBoxI18N("El nombre ya existe para ese lugar ", MsgBoxStyle.Critical)
            Return
        End If

        If position Is Nothing Then
            MsgBoxI18N("Debe establecer la posición del lugar")
            Return
        End If
        If TipoLugar.SelectedIndex < 0 Then
            MsgBoxI18N("Debe establecer el tipo del lugar")
            Return
        End If
        If mediosPermitidos.CheckedItems.Count < 1 Then
            MsgBoxI18N("Debe permitir al menos un medio de transporte")
            Return
        End If

        If Not TipoLugar.SelectedIndex = 0 Then
            If posicionesLugar Is Nothing Then
                MsgBoxI18N("Debe selecionar las zonas y subzonas a ingresar dentro del lugar", MsgBoxStyle.Critical)
                Return
            End If

            If capacidad.Value <= 0 Then
                MsgBoxI18N("La capacidad del lugar debe ser mayor a 0", MsgBoxStyle.Critical)
                Return
            End If
        End If
        Dim listTemp As New List(Of Controladores.TipoMedioTransporte)
        For Each i As Integer In mediosPermitidos.CheckedIndices
            listTemp.Add(tiposDeMEdio(i))
        Next
        If padreCliente Is Nothing Then
            Try


                Dim lugar = Controladores.Fachada.getInstancia.CrearLugar(nombreBox.Text, position.Position, CType(TipoLugar.SelectedItem, String),
                                                          listTemp.ToArray,
                                                          capacidad.Value, If(posicionesLugar IsNot Nothing, posicionesLugar.Zonas, Nothing), If(TipoLugar.SelectedIndex = 0, clientes(dueños.SelectedIndex), Nothing))
                Dim noti As New Notificacion(Notificacion.TIPO_NOTIFICACION_NUEVO_LUGAR) With {.Ref1 = lugar.IDLugar, .Ref2 = Fachada.getInstancia.DevolverUsuarioActual.ID_usuario}
                Controladores.Fachada.getInstancia.NuevaNotificacion(noti)
                If lugar IsNot Nothing Then
                    Controladores.Marco.getInstancia.CargarPanel(New PanelLugar(lugar.IDLugar))
                Else
                    MsgBoxI18N("No se pudo crear el lugar, por favor verifique la información")
                End If
            Catch ex As Controladores.InvalidStateException(Of Integer)
                MsgBoxI18N("Excepción!")
                MsgBox(ex.Message)
            End Try
        Else
            Try
                padreCliente.devolverlugar(New Lugar With {.Nombre = nombreBox.Text,
                                                       .Capasidad = capacidad.Value,
                                                       .PosicionX = position.Position.Lat,
                                                       .PosicionY = position.Position.Lng,
                                                       .Tipo = CType(TipoLugar.SelectedItem, String),
                                                       .TiposDeMediosDeTrasporteHabilitados = listTemp,
                                                       .Zonas = If(posicionesLugar Is Nothing, New List(Of Zona), posicionesLugar.Zonas)})

                Controladores.Marco.getInstancia.cerrarPanel(Of NuevoLugar)()
                Return
            Catch ex As Exception
                MsgBoxI18N("Ya hay un lugar con este nombre cargado para ese cliente", MsgBoxStyle.Critical)
                Return
            End Try


        End If
        'Try
        '    Dim lugar = Controladores.Fachada.getInstancia.CrearLugar(nombreBox.Text, position.Position, CType(TipoLugar.SelectedItem, String),
        '                                              mediosPermitidos.CheckedItems.Cast(Of Controladores.TipoMedioTransporte).ToArray,
        '                                              capacidad.Value, Zonas)
        '    If lugar IsNot Nothing Then
        '        Controladores.Marco.getInstancia.cargarPanel(New PanelLugar(lugar.IDLugar))
        '        Controladores.Marco.getInstancia.cerrarPanel(Of NuevoLugar)()
        '    Else
        '        MsgBox("No se pudo crear el lugar, por favor verifique la información")
        '    End If
        'Catch ex As Controladores.InvalidStateException(Of Integer)
        '    MsgBox("Excepción!")
        '    MsgBox(ex.Message)
        'End Try
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
            MsgBox(Controladores.Funciones_comunes.I18N("No se pudo encontrar el lugar:", Controladores.Marco.getInstancia.Language) & [Enum].GetName(GetType(GMap.NET.GeoCoderStatusCode), gcsc))
        End If
    End Sub

    Public Sub New()
        InitializeComponent()
        TipoLugar.Items.Add(Lugar.TIPO_LUGAR_ESTABLECIMIENTO)
        TipoLugar.Items.Add(Lugar.TIPO_LUGAR_PATIO)
        TipoLugar.Items.Add(Lugar.TIPO_LUGAR_PUERTO)
        TipoLugar.SelectedIndex = 0
        clientes = Controladores.Fachada.getInstancia.listaClientes()
        dueños.Items.AddRange(clientes.Select(Function(x) x.Nombre).ToArray)
        dueños.SelectedIndex = 0
        Label4.Traducir
        Label1.Traducir
        Label3.Traducir
        Label2.Traducir
        Label5.Traducir
        estadozonas.Traducir
        Button1.Traducir
        zonasysubzonas.Traducir

        CrearButton.Text = Controladores.Funciones_comunes.I18N("Aceptar", Controladores.Marco.getInstancia.Language)
        cancelar.Text = Controladores.Funciones_comunes.I18N("Cancelar", Controladores.Marco.getInstancia.Language)
    End Sub

    Public Sub New(papa As Controladores.nuevoLugar)
        InitializeComponent()
        TipoLugar.Items.Add(Lugar.TIPO_LUGAR_ESTABLECIMIENTO)
        TipoLugar.Items.Add(Lugar.TIPO_LUGAR_PATIO)
        TipoLugar.Items.Add(Lugar.TIPO_LUGAR_PUERTO)
        TipoLugar.Enabled = False
        TipoLugar.SelectedIndex = 0
        padreCliente = papa
        dueños.Items.Add(papa.DarCliente.Nombre)
        dueños.SelectedIndex = 0
        dueños.Enabled = False
        cancelar.Visible = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles zonasysubzonas.Click
        If TipoLugar.SelectedIndex = 0 Then
            MsgBoxI18N("Los establesimientos no tiene zonas y subzonas")
        End If

        If nombreBox.Text.Trim.Length = 0 OrElse capacidad.Value = 0 Then
            MsgBoxI18N("Primero debe elegir el nombre y la capacidad")
            Return
        End If
        If posicionesLugar Is Nothing Then
            Controladores.Marco.getInstancia.CargarPanel(Of AdministrarZonasYSubzonas)(New AdministrarZonasYSubzonas(New Lugar() With {
                                                                                                                .Nombre = nombreBox.Text,
                                                                                                                .Capasidad = capacidad.Value,
                                                                                                                .Zonas = New List(Of Zona)}, Me))
        Else
            Controladores.Marco.getInstancia.CargarPanel(Of AdministrarZonasYSubzonas)(New AdministrarZonasYSubzonas(posicionesLugar, Me))
        End If

    End Sub

    Public Sub devolverlugar(lug As Lugar) Implements Controladores.nuevoLugar.devolverlugar
        posicionesLugar = lug
        estadozonas.Text = Controladores.Funciones_comunes.I18N("Listo", Controladores.Marco.getInstancia.Language)
        estadozonas.ForeColor = Drawing.Color.FromArgb(35, 35, 35)
    End Sub

    Private Sub TipoLugar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TipoLugar.SelectedIndexChanged
        If TipoLugar.SelectedIndex = 0 Then
            zonasysubzonas.Enabled = False
            estadozonas.Text = Controladores.Funciones_comunes.I18N("No requerido", Controladores.Marco.getInstancia.Language)
            dueños.Enabled = True
            capacidad.Enabled = False
        Else
            zonasysubzonas.Enabled = True
            capacidad.Enabled = True
            If posicionesLugar Is Nothing Then
                estadozonas.Text = Controladores.Funciones_comunes.I18N("Sin realizar", Controladores.Marco.getInstancia.Language)
                estadozonas.ForeColor = Drawing.Color.FromArgb(180, 20, 20)
            Else
                estadozonas.Text = Controladores.Funciones_comunes.I18N("Listo", Controladores.Marco.getInstancia.Language)
                estadozonas.ForeColor = Drawing.Color.FromArgb(35, 35, 35)
            End If
            dueños.Enabled = False
        End If
    End Sub

    Public Function DarCliente() As Cliente Implements Controladores.nuevoLugar.DarCliente
        Throw New NotImplementedException()
    End Function

    Private Sub cancelar_Click(sender As Object, e As EventArgs) Handles cancelar.Click
        Controladores.Marco.getInstancia.cerrarPanel(Of NuevoLugar)()
        Me.Close()
    End Sub
End Class
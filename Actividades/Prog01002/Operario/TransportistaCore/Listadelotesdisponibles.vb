Imports System.Drawing
Imports Controladores
Imports Controladores.Fachada
Imports System.Windows.Forms
Public Class Lista_de_trasportes
    Private lotes As New List(Of Controladores.Lote)
    Private paneles As New List(Of SUB_informeLote)
    Private listaDeMedios As New List(Of Controladores.MedioDeTransporte)
    Private tiposDeMedio As New List(Of Controladores.TipoMedioTransporte)

    Public Sub New()
        InitializeComponent()
        lotes = Controladores.Fachada.getInstancia.DevolverLotesDisponblesCompletos()
        crearPanelesPorLote()
        cargarLosPaneles()
        cargarmediosDisponiblesParaElUsuario()
    End Sub


    Public Sub cargarmediosDisponiblesParaElUsuario()
        tiposDeMedio = Controladores.Fachada.getInstancia.TodosLosTiposDeMediosDisponibles()
        TiposDeMedioAutorizados.Items.Clear()
        If tiposDeMedio.Count > 0 Then
            listaDeMedios = Controladores.Fachada.getInstancia.listadeMediosPorIdUsuario(Controladores.Fachada.getInstancia.DevolverUsuarioActual.ID_usuario)
            For Each mediotipo As Controladores.TipoMedioTransporte In tiposDeMedio
                TiposDeMedioAutorizados.Items.Add(mediotipo.Nombre)
            Next
            TiposDeMedioAutorizados.SelectedIndex = 0
            cargarmediosPortipo()

        Else
            errordemedios.Visible = True
            TiposDeMedioAutorizados.Visible = False
            mediosAutorizados.Visible = False
        End If


    End Sub





    Private Sub cargarmediosPortipo()
        mediosAutorizados.Items.Clear()

        If listaDeMedios.Count > 0 Then
            For Each medio As Controladores.MedioDeTransporte In listaDeMedios
                If medio.Tipo.Nombre.Equals(tiposDeMedio(TiposDeMedioAutorizados.SelectedIndex).Nombre) Then
                    mediosAutorizados.Items.Add(medio.Nombre)
                End If
            Next
            If mediosAutorizados.Items.Count = 0 Then
                mediosAutorizados.Enabled = False
                mediosAutorizados.SelectedIndex = -1
            Else
                mediosAutorizados.Enabled = True
                mediosAutorizados.SelectedIndex = 0
            End If
        Else
            aceptar.Visible = False
            errordemedios.Visible = True
        End If
    End Sub

    Public Sub crearPanelesPorLote()
        For Each l As Controladores.Lote In lotes
            paneles.Add(New SUB_informeLote(l))
        Next
    End Sub

    Public Sub cargarLosPaneles()
        ele1.Controls.Clear()
        If paneles.Count > 6 Then
            ele1.Height = paneles.Count * 80
        Else
            ele1.Height = 480
        End If

        For Each p As SUB_informeLote In paneles
            p.TopLevel = False
            p.Dock = DockStyle.Top
            ele1.Controls.Add(p)
            p.Show()
        Next
    End Sub




    Private Sub Aceptar_Click(sender As Object, e As EventArgs) Handles aceptar.Click
        Dim lotesElegidos As New List(Of Controladores.Lote)
        For Each p As SUB_informeLote In paneles
            If p.Selecionado Then
                lotesElegidos.Add(p.Lote)
            End If
        Next

        If lotesElegidos.Count = 0 Then
            MsgBox("Debe escojer al menos 1 lote", MsgBoxStyle.Critical)
            Return
        End If

        'COMRPOBACION 1: Los lotes tiene que tener el mismo lugar de origen

        Dim lugarmuestra As Integer = lotesElegidos(0).Origen.IDLugar
        For Each origen As Controladores.Lote In lotesElegidos
            If origen.Origen.IDLugar <> lugarmuestra Then
                MsgBox("Todos los lotes deben tener como origen el mismo lugar", MsgBoxStyle.Critical)
                Return
            End If
        Next

        'COMRPOBACION 2: El origen y el destino deben tener habilitado ese tipo de medio de trasnsporte 

        If TiposDeMedioAutorizados.SelectedIndex = -1 Or mediosAutorizados.SelectedIndex = -1 Then
            MsgBox("Debe selecionar un medio de transporte a utilizar", MsgBoxStyle.Critical)
            Return
        End If

        If Not lotesElegidos(0).Origen.TiposDeMediosDeTrasporteHabilitados.Select(Function(x) x.Nombre).ToList.Contains(tiposDeMedio(TiposDeMedioAutorizados.SelectedIndex).Nombre) Then
            MsgBox("El origen debe soportar el medio de trasporte selecionado", MsgBoxStyle.Critical)
            Return
        End If

        For Each lug As Lugar In lotesElegidos.Select(Function(x) x.Destino).ToList
            If Not lug.TiposDeMediosDeTrasporteHabilitados.Select(Function(x) x.Nombre).ToList.Contains(tiposDeMedio(TiposDeMedioAutorizados.SelectedIndex).Nombre) Then
                MsgBox("Todos los destinos debe soportar el medio de trasporte selecionado", MsgBoxStyle.Critical)
                Return
            End If
        Next

        'COMPROBACION 3: El medio debe soportar la carga de vehiculos del lote

        Dim auto As Integer = 0
        Dim camion As Integer = 0
        Dim van As Integer = 0
        Dim minivan As Integer = 0
        Dim suv As Integer = 0

        For Each l As Lote In lotesElegidos
            For Each v As Vehiculo In l.Vehiculos
                Select Case v.Tipo
                    Case Vehiculo.TIPO_VEHICULO_AUTO
                        auto += 1
                    Case Vehiculo.TIPO_VEHICULO_CAMION
                        camion += 1
                    Case Vehiculo.TIPO_VEHICULO_VAN
                        van += 1
                    Case Vehiculo.TIPO_VEHICULO_MINIVAN
                        minivan += 1
                    Case Vehiculo.TIPO_VEHICULO_SUV
                        suv += 1
                End Select
            Next
        Next

        Dim medioSelecionado As Controladores.MedioDeTransporte = Nothing
        For Each m As Controladores.MedioDeTransporte In listaDeMedios
            If mediosAutorizados.SelectedItem.Equals(m.Nombre) Then
                medioSelecionado = m
                Exit For
            End If
        Next

        If medioSelecionado Is Nothing Then
            MsgBox("ERROR FATAL")
            Return
        End If

        If lotesElegidos.Any(Function(x) x.Prioridad = Lote.TIPO_PRIORIDAD_ALTA) Then
            Dim loteFallido = lotes.First(Function(x) x.Prioridad = Lote.TIPO_PRIORIDAD_ALTA)
            Extenciones.MsgBoxI18N("Uno de sus lotes era un lote fallido, por ende se mostrará la posición actual del mismo")
            Dim url = Fachada.getInstancia.TransporteFallido(loteFallido)
            If Controladores.Funciones_comunes.URLExist(url) Then
                Dim curPos = New TiempoRealGooglePlex(url)
                curPos.ShowDialog()
            Else
                MsgBox("Link del transportista invalido, comuniquese con administrador para ubicar al transportista", MsgBoxStyle.Critical)
            End If

            If auto > medioSelecionado.CantAutos OrElse camion > medioSelecionado.CantCamiones OrElse van > medioSelecionado.CantVAN OrElse minivan > medioSelecionado.CantMiniVan OrElse suv > medioSelecionado.CantSUV Then
                MsgBox("La capasidad del medio no es suficiente para el transporte de lotes selecionado", MsgBoxStyle.Critical)
                Return
            End If

        End If

        'COMPROBACION 4: COMPROBAR QUE LOS LOTES SIGAN DISPONBLES

        MsgBox("El calculo que se realiza para aprobar el transporte no es exsacto, si el medio selecionado realmente no lo soporta cancele el translado el mismo")
        Dim pepe As New PanelTrasporteEnAccion(lotesElegidos, medioSelecionado)
        pepe.Location = New Point(0, 0)
        Marco.getInstancia.CargarPanel(pepe)

    End Sub

    Private Sub TiposDeMedioAutorizados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TiposDeMedioAutorizados.SelectedIndexChanged
        cargarmediosPortipo()
    End Sub

    Private Sub Lista_de_trasportes_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        cargarLosPaneles()
        Label1.Location = New Point(20, TiposDeMedioAutorizados.Location.Y)
        TiposDeMedioAutorizados.Location = New Point(20 + Label1.Width + 10, TiposDeMedioAutorizados.Location.Y)
        TiposDeMedioAutorizados.Width = (Me.Width / 2) - 70
        Label2.Location = New Point((Me.Width / 2) + 20, TiposDeMedioAutorizados.Location.Y)
        mediosAutorizados.Location = New Point((Me.Width / 2) + 20 + Label2.Width + 10, TiposDeMedioAutorizados.Location.Y)
        mediosAutorizados.Width = (Me.Width / 2) - Label2.Width - 40
        aceptar.Location = New Point((Me.Width / 2) - 150, aceptar.Location.Y)
        aceptar.Width = 300

    End Sub
End Class
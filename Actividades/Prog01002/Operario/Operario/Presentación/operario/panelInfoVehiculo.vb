Imports Controladores
Imports Operario



Public Class panelInfoVehiculo
    Implements NotificacionDeLote

    Private informesElementos As New List(Of Controladores.InformeDeDaños)
    Private vin As String
    Private lugar As DataRow
    Private vehiculo As Controladores.Vehiculo
    Private actualInfore As Integer = 0
    Private actualRegistro As Integer = 0
    Private actualImagen As Integer = 0
    Private loteTemp As Controladores.Lote
    Public Sub New(VIN As String, aqui As Boolean)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        If Not aqui Then
            Button2.Visible = False
            Button4.Visible = False
        End If
        LoteCombo.Enabled = False
        Me.vin = VIN
        TipoCombo.Items.Clear()
        TipoCombo.Items.AddRange([Enum].GetNames(GetType(Logica.TipoVehiculo)))
        RegularTamañoColumnas()
        TomarValores()
    End Sub

    Private Sub TomarValores()
        VINBox.Text = vin
        Dim vehiculo = Controladores.Fachada.getInstancia.InfoVehiculos(vin).SingleOrDefault
        If vehiculo Is Nothing Then
            MsgBox("No se encontró el vehículo con VIN " + vin + ", reporte este error")
            Close()
        End If
        MarcaBox.Text = vehiculo.Marca
        ModeloBox.Text = vehiculo.Modelo
        ClienteBox.Text = vehiculo.Cliente.Nombre
        AñoBox.Text = vehiculo.Año
        TipoCombo.SelectedItem = vehiculo.Tipo
        Panel1.BackColor = vehiculo.Color
        Dim ultpos = Controladores.Fachada.getInstancia.UltimaPosicionVehiculoEnLugar(vin, Controladores.Persistencia.getInstancia.TrabajaEn.Lugar.Nombre)
        SubzonaLabel.Text = ultpos.Item(1)
        Dim zona = Controladores.Persistencia.getInstancia.PadreDeLugar(ultpos.Item(0))
        ZonaLabel.Text = zona.Item(0)
        PosicionLabel.Text = ultpos.Item(2) & " desde " & CType(ultpos.Item(3), Date?).DarFormato
        lugar = Controladores.Persistencia.getInstancia.PadreDeLugar(zona.Item(1))
        lugarLabel.Text = lugar.Item(0)
        Dim lotes = Controladores.Fachada.getInstancia.LotesDisponiblesPorLugarActual.Select(Function(x) x.Nombre).ToArray
        LoteCombo.Items.AddRange(lotes)
        Dim loteVehiculo As String = Controladores.Fachada.getInstancia.LoteVehiculo(vin, lugar.Item(0)).Nombre
        For i = 0 To lotes.Count - 1
            If lotes(i) = loteVehiculo Then
                LoteCombo.SelectedIndex = i
            End If
        Next

        traslados.Columns.Clear()
        traslados.DataSource = Controladores.Persistencia.getInstancia.PosicionesDeVehiculoEnLugar(lugar.Item(0), vin)
        informesElementos = Controladores.Fachada.getInstancia.devolverTodosLosInformesYregistrosCompletos(vehiculo)
        If informesElementos.Count = 0 Then

            visualizarElementosRegistro(False, False)

        Else
            If informesElementos.Count = 1 Then
                SinInformes.Enabled = False
            End If
            SinInformes.Visible = False
            cargarInformes()
        End If
        Me.vehiculo = vehiculo
    End Sub

    Public Sub cargarInformes()
        Dim info As Controladores.InformeDeDaños = informesElementos(actualInfore)

        numeroInforme.Text = info.ID
        NomCreador.Text = info.Creador.Nombre
        fechaCreacionInforme.Text = info.Fecha
        descrip_Informe.Text = info.Descripcion
        If info.Registros.Count > 0 Then
            visualizarElementosRegistro(True, True)
            If info.Registros.Count = 1 Then
                SigienteRegistro.Enabled = False
            Else
                SigienteRegistro.Enabled = True
            End If
            Cargaregistros()
        Else
            visualizarElementosRegistro(False, True)
        End If
    End Sub

    Public Sub Cargaregistros()
        Dim reg As Controladores.RegistroDaños = informesElementos(actualInfore).Registros(actualRegistro)
        numRegistro.Text = reg.ID
        descrip_registro.Text = reg.Descripcion
        tipoRegistro.Text = reg.TipoActualizacion
        If reg.TipoActualizacion.Equals(Controladores.RegistroDaños.TIPO_ACTUALIZACION_REGULAR) Then
            idinformepadre.Text = "SIN INFORMACION"
            idregistropadre.Text = "Sin INFORMACION"
        Else
            idinformepadre.Text = reg.Actualiza.InformePadre.ID
            idregistropadre.Text = reg.Actualiza.ID
        End If
        cargarImgReg()
    End Sub

    Public Sub cargarImgReg()
        Dim reg As Controladores.RegistroDaños = informesElementos(actualInfore).Registros(actualRegistro)
        If reg.Imagenes.Count = 0 Then
            imagen.Image = Operario.My.Resources.sinContenidoFotografico
            SigienteImagen.Visible = False
            AnteriorImagen.Visible = False

        Else
            If reg.Imagenes.Count = 1 Then
                SigienteImagen.Enabled = False
                AnteriorImagen.Enabled = False
            End If
            SigienteImagen.Visible = True
            AnteriorImagen.Visible = True
            imagen.Image = reg.Imagenes(actualImagen)
        End If
    End Sub

    Private Sub visualizarElementosRegistro(j As Boolean, j2 As Boolean)
        sinregistros.Visible = Not j
        Label17.Visible = j
        numRegistro.Visible = j
        Label19.Visible = j
        idregistropadre.Visible = j
        idinformepadre.Visible = j
        Label20.Visible = j
        Label18.Visible = j
        tipoRegistro.Visible = j
        verReferencia.Visible = j
        anteriorRegistro.Visible = j
        AnteriorImagen.Visible = j
        SigienteRegistro.Visible = j
        SigienteImagen.Visible = j
        Label21.Visible = j
        descrip_registro.Visible = j
        imagen.Visible = j
        modificar.Visible = j
        Label11.Visible = j2
        numeroInforme.Visible = j2
        NomCreador.Visible = j2
        Label15.Visible = j2
        Label16.Visible = j2
        Label14.Visible = j2
        fechaCreacionInforme.Visible = j2
        anteriorInforme.Visible = j2
        sigienteInforme.Visible = j2
        descrip_Informe.Visible = j2
        SinInformes.Visible = Not j2

    End Sub

    Private dtlugares As DataTable
    Public Sub RegularTamañoColumnas()

        Me.Height = 3000

        traslados.Columns(0).Width = 200
        traslados.Columns(1).Width = 200
        traslados.Columns(2).Width = 175
        traslados.Columns(3).Width = 175
        traslados.Columns(4).Width = 175
        traslados.Columns(5).Width = 225

        lugares.Columns(0).Width = 170
        lugares.Columns(1).Width = 170
        lugares.Columns(2).Width = 170
        lugares.Columns(3).Width = 170
        lugares.Columns(4).Width = 170
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim permitido = False
        If permitido Then
            ModeloBox.Enabled = Not ModeloBox.Enabled
            MarcaBox.Enabled = Not MarcaBox.Enabled
            AñoBox.Enabled = Not AñoBox.Enabled
            TipoCombo.Enabled = Not TipoCombo.Enabled
            LoteCombo.Enabled = Not LoteCombo.Enabled
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Dim tInterno = New trasladoInterno(vin, Me)
        'tInterno.ShowDialog()
    End Sub

    Private Sub informes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        'Marco.getInstancia.cargarPanel(Of crearInformaDeDaños)(New crearInformaDeDaños(DirectCast(informes.Rows()(e.RowIndex).Cells()(0).Value, Integer)))
    End Sub

    Private _changedTB2 As Boolean = False
    Private _changedTB3 As Boolean = False
    Private _changedTB4 As Boolean = False
    Private _changedTB5 As Boolean = False
    Private _changedCB1 As Boolean = False



    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles MarcaBox.TextChanged
        _changedTB2 = True
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles ModeloBox.TextChanged
        _changedTB3 = True
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles ClienteBox.TextChanged
        _changedTB4 = True
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles AñoBox.TextChanged
        If AñoBox.Text.Where(Function(x) x >= "0" And x <= "9").Count <> AñoBox.Text.Count Then
            AñoBox.ForeColor = Color.Red
        Else
            AñoBox.ForeColor = Color.Black
            _changedTB5 = True
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TipoCombo.SelectedIndexChanged
        _changedCB1 = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Marco.getInstancia.cargarPanel(Of crearInformaDeDaños)(New crearInformaDeDaños(New Controladores.InformeDeDaños(vehiculo), False) With {.ListaDeTodosLosInformes = informesElementos})
    End Sub


    Private Sub LoteCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LoteCombo.SelectedIndexChanged
        If Controladores.Fachada.getInstancia.InfoLote(Nombre:=LoteCombo.SelectedItem).Estado = Controladores.Lote.TIPO_ESTADO_ABIERTO Then
            If Not Controladores.Fachada.getInstancia.AsignarLote(vin, LoteCombo.SelectedItem) Then ' FALTA IMPLEMENTACIÓN
                MsgBox("No se pudo asignar el lote por alguna razón. ACTUALMENTE SIN IMPLEMENTAR")
            End If
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles nuevoLote.LinkClicked
        LoteCombo.Enabled = False
        Dim nl As NuevoLote
        If loteTemp Is Nothing Then
            nl = New NuevoLote(Me)
        Else
            nl = New NuevoLote(Me, loteTemp)
        End If
        nl.ShowDialog()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles vermasLote.LinkClicked
        Marco.getInstancia.cargarPanel(New PanelInfoLote(LoteCombo.Text))
    End Sub

    Private Sub SigienteInforme_Click(sender As Object, e As EventArgs) Handles sigienteInforme.Click
        If actualInfore + 1 < informesElementos.Count Then
            actualInfore += 1
            actualRegistro = 0
            actualImagen = 0
            If actualInfore + 1 = informesElementos.Count Then
                sigienteInforme.Enabled = False
            End If
            anteriorInforme.Enabled = True
        End If
        cargarInformes()
    End Sub

    Private Sub AnteriorInforme_Click(sender As Object, e As EventArgs) Handles anteriorInforme.Click
        If actualInfore > 0 Then
            actualInfore -= 1
            actualRegistro = 0
            actualImagen = 0
            If actualInfore = 0 Then
                anteriorInforme.Enabled = False
            End If
            sigienteInforme.Enabled = True
        End If
        cargarInformes()
    End Sub

    Private Sub AnteriorRegistro_Click(sender As Object, e As EventArgs) Handles anteriorRegistro.Click
        If actualRegistro > 0 Then
            actualRegistro -= 1
            actualImagen = 0
            If actualRegistro = 0 Then
                anteriorRegistro.Enabled = False
            End If
            SigienteRegistro.Enabled = True
        End If
        Cargaregistros()
    End Sub

    Private Sub SigienteRegistro_Click(sender As Object, e As EventArgs) Handles SigienteRegistro.Click
        If actualRegistro + 1 < informesElementos(actualInfore).Registros.Count Then
            actualRegistro += 1
            actualImagen = 0
            If actualRegistro + 1 = informesElementos(actualInfore).Registros.Count Then
                SigienteRegistro.Enabled = False
            End If
            anteriorRegistro.Enabled = True
        End If
        Cargaregistros()
    End Sub

    Private Sub SigienteImagen_Click(sender As Object, e As EventArgs) Handles SigienteImagen.Click
        If actualImagen + 1 < informesElementos(actualInfore).Registros(actualRegistro).Imagenes.Count Then
            actualImagen += 1
            If actualImagen + 1 = informesElementos(actualInfore).Registros(actualRegistro).Imagenes.Count Then
                SigienteImagen.Enabled = False
            End If
            AnteriorImagen.Enabled = True
        End If
        cargarImgReg()
    End Sub

    Private Sub AnteriorImagen_Click(sender As Object, e As EventArgs) Handles AnteriorImagen.Click
        If actualImagen > 0 Then
            actualImagen -= 1
            If actualImagen = 0 Then
                AnteriorImagen.Enabled = False
            End If
            SigienteImagen.Enabled = True
        End If
        cargarImgReg()
    End Sub

    Private Sub Modificar_Click(sender As Object, e As EventArgs) Handles modificar.Click
        Marco.getInstancia.cargarPanel(Of crearInformaDeDaños)(New crearInformaDeDaños(informesElementos(actualInfore), False) With {.ListaDeTodosLosInformes = informesElementos})
    End Sub

    Public Sub NotificarLote(lote As Lote) Implements NotificacionDeLote.NotificarLote
        loteTemp = lote
        Me.LoteCombo.Enabled = False
        nuevoLote.Text = "Modificar"
        EliminarLoteSelecion.Enabled = True
    End Sub

    Public Function dameVehiculoalLote() As Object Implements NotificacionDeLote.dameVehiculoalLote
        Return vehiculo
    End Function

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles EliminarLoteSelecion.LinkClicked
        loteTemp = Nothing
        EliminarLoteSelecion.Enabled = False
        nuevoLote.Text = "Nuevo lote"
    End Sub

    Private Sub CambiarGuardarLote_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles cambiarGuardarLote.LinkClicked
        If cambiarGuardarLote.Text.Equals("Cambiar lote ") Then
            cambiarGuardarLote.Text = "Guardar"
            nuevoLote.Visible = True
            EliminarLoteSelecion.Visible = True
            Cancelar.Visible = True
            EliminarLoteSelecion.Enabled = False
            LoteCombo.Enabled = True
            vermasLote.Enabled = False

        Else
            cambiarGuardarLote.Text = "Cambiar lote "
            nuevoLote.Visible = False
            EliminarLoteSelecion.Visible = False
            Cancelar.Visible = False
            vermasLote.Enabled = True
            LoteCombo.Enabled = False
            'COMUNICAR CON FACHADA PARA LA SUBIDA

            'SINCRONIZAR INFORMACION 

            loteTemp = Nothing
        End If
    End Sub

    Private Sub Cancelar_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Cancelar.LinkClicked
        cambiarGuardarLote.Text = "Cambiar lote "
        nuevoLote.Visible = False
        EliminarLoteSelecion.Visible = False
        Cancelar.Visible = False
        LoteCombo.Enabled = False
        vermasLote.Enabled = True
        loteTemp = Nothing
    End Sub
End Class
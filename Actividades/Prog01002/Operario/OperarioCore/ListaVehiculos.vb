Imports Controladores
Imports System.Drawing
Imports System.Windows.Forms
Imports Controladores.Extenciones.Extensiones
Public Class ListaVehiculos
    Private datos As DataTable
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        buscar.Text = Controladores.Funciones_comunes.I18N("Buscar", Marco.Language)
        nuevo.Text = Controladores.Funciones_comunes.I18N("Nuevo vehiculo", Marco.Language)
        Label7.Traducir

        If Fachada.getInstancia.TrabajaEnAcutual IsNot Nothing AndAlso Fachada.getInstancia.TrabajaEnAcutual.Lugar.Tipo = Lugar.TIPO_LUGAR_PUERTO Then
            nuevo.Visible = True
        Else
            nuevo.Visible = False
        End If

        If Fachada.getInstancia.DevolverUsuarioActual.Rol <> Usuario.TIPO_ROL_ADMINISTRADOR Then
            LugaresBox.Items.Add(Fachada.getInstancia.TrabajaEnAcutual.Lugar)
            LugaresBox.Enabled = False
            tiposListas.Items.Remove("Entregados")
        Else
            LugaresBox.Items.AddRange(Fachada.getInstancia.LugaresObjetos)
        End If
        LugaresBox.SelectedIndex = 0
        Asignados()
        tabla.MultiSelect = False
        tiposListas.SelectedIndex = 0

    End Sub

    Private lugar As Lugar

    Dim t As DataTable

    Public Sub UpdateVehicles(Optional j As Boolean = True)
        If j Then
            criterios.Items.Clear()
            criterios.Items.Add("ID vehiculo")
        End If
        Select Case tiposListas.SelectedItem
            ' esto es, efectivamente, un hashtable de funciones pero en versión
            ' "la utu nunca dió hashtables ni mapas ni diccionarios y, discutiblemente, funciones"
            ' TODO: hacer esto con un hashtable, no seamos hijos de puta, respetemos el oficio
            Case "Asignados"
                If j Then
                    criterios.Items.Add("Vin")
                    criterios.Items.Add("Marca")
                    criterios.Items.Add("Modelo")
                    criterios.Items.Add("Tipo")
                    criterios.Items.Add("IdLote")
                    criterios.Items.Add("En el lugar")
                    criterios.Items.Add("Fuera del lugar")
                    criterios.Items.Add("Fuera del sistema")
                End If
                Asignados()
            Case "No asignados"
                If j Then
                    criterios.Items.Add("Vin")
                    criterios.Items.Add("IdLote")
                    criterios.Items.Add("En el lugar")
                End If

                NoAsignados()

            Case "Entregados"
                If j Then
                    criterios.Items.Add("Lugar entrega")
                End If
                Entregados()

            Case "Retirados"
                If j Then
                    criterios.Items.Add("Lugar retiro")
                End If
                Retirados()

            Case "Dañados"
                If j Then
                    criterios.Items.Add("Lugar retiro")
                End If
                Dañados()

            Case "Precargados"
                If j Then
                    criterios.Items.Add("VIN")
                End If
                Precargados()

            Case "En transporte"
                If j Then
                    criterios.Items.Add("VIN")
                    criterios.Items.Add("Nombre Lote")
                    criterios.Items.Add("Origen")
                    criterios.Items.Add("Destino")
                End If
                EnTransporte()
        End Select

    End Sub

    Private Sub EnTransporte()
        datos = Fachada.getInstancia.VehiculosEnTransporte()
        tabla.DataSource = datos
    End Sub

    Private Sub Precargados()
        datos = Fachada.getInstancia.VehiculosPrecargados()
        tabla.DataSource = datos
    End Sub

    Private Sub Dañados()
        datos = Fachada.getInstancia.VehiculosDañados()
        tabla.DataSource = datos
    End Sub

    Public Sub Retirados()
        datos = Fachada.getInstancia.VehiculosRetirados()
        tabla.DataSource = datos
    End Sub

    Public Sub Entregados()
        datos = Fachada.getInstancia.VehiculosEntregados()
        tabla.DataSource = datos
    End Sub

    Public Sub Asignados()
        If lugar IsNot Nothing Then
            datos = Fachada.getInstancia.ListaVehiculos(lugar)
            tabla.DataSource = datos
        End If
    End Sub

    Public Sub NoAsignados()
        If lugar IsNot Nothing Then
            datos = Controladores.Fachada.getInstancia.listaDeVehiculosSinLoteNiPosicion(lugar.IDLugar)
            tabla.DataSource = datos
        End If
    End Sub



    Private Sub nuevo_Click(sender As Object, e As EventArgs) Handles nuevo.Click
        Marco.getInstancia.CargarPanel(Of NuevoVehiculo)(New NuevoVehiculo)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles tabla.CellDoubleClick
        '            
        Select Case tiposListas.SelectedItem
            Case "No asignados"
                Dim eleme As New Asignacion(tabla.Rows(e.RowIndex).Cells(1).Value, lugar)
                eleme.ShowDialog()


            Case "Asignados"
                Dim row = tabla.Rows()(e.RowIndex)
                Marco.getInstancia.CargarPanel(New panelInfoVehiculo(row.Cells(1).Value, If(tiposListas.SelectedItem.Equals("Asignados"), If(tabla.Rows(e.RowIndex).Cells(6).Value.Equals("En el lugar"), True, False), False))).Show()
            Case Else
                Dim row = tabla.Rows()(e.RowIndex)
                Marco.getInstancia.CargarPanel(New panelInfoVehiculo(row.Cells(1).Value, False)).Show()
        End Select
        '

    End Sub

    Private Sub buscar_Click(sender As Object, e As EventArgs) Handles buscar.Click
        UpdateVehicles(False)

        If buscador.Text.Trim.Length = 0 Then
            Return
        End If

        Select Case tiposListas.SelectedItem
            Case "Asignados"
                Select Case criterios.SelectedIndex
                    Case 0
                        FiltadoCompleto(0, buscador.Text)
                    Case 1
                        FiltadoParcial(1, buscador.Text)
                    Case 2
                        FiltadoParcial(2, buscador.Text)
                    Case 3
                        FiltadoParcial(3, buscador.Text)
                    Case 4
                        FiltadoParcial(4, buscador.Text)
                    Case 5
                        FiltadoCompleto(5, buscador.Text)
                End Select


            Case "No asignados"
                Select Case criterios.SelectedIndex
                    Case 0
                        FiltadoCompleto(0, buscador.Text)
                    Case 1
                        FiltadoParcial(1, buscador.Text)
                    Case 2
                        FiltadoCompleto(2, buscador.Text)
                    Case 3
                        FiltadoParcial(3, buscador.Text)
                End Select
            Case "Entregados"
                'criterios.Items.Add("Lugar entrega")
                Select Case criterios.SelectedIndex
                    Case 0
                        FiltadoCompleto(0, buscador.Text)
                    Case 1
                        FiltadoParcial(1, buscador.Text)
                End Select

            Case "Retirados"
                Select Case criterios.SelectedIndex
                    Case 0
                        FiltadoCompleto(0, buscador.Text)
                    Case 1
                        FiltadoParcial(1, buscador.Text)
                End Select

            Case "Dañados"
                Select Case criterios.SelectedIndex
                    Case 0
                        FiltadoCompleto(0, buscador.Text)
                    Case 1
                        FiltadoParcial(1, buscador.Text)
                End Select

            Case "Precargados"
                Select Case criterios.SelectedIndex
                    Case 0
                        FiltadoCompleto(0, buscador.Text)
                    Case 1
                        FiltadoParcial(1, buscador.Text)
                End Select

            Case "En transporte"
                Select Case criterios.SelectedIndex
                    Case 0
                        FiltadoCompleto(0, buscador.Text)
                    Case 1
                        FiltadoParcial(1, buscador.Text)
                    Case 2
                        FiltadoParcial(2, buscador.Text)
                    Case 3
                        FiltadoParcial(3, buscador.Text)
                    Case 4
                        FiltadoParcial(4, buscador.Text)
                End Select
        End Select


    End Sub

    Private Sub FiltadoCompleto(posicion As Integer, elemento As String)
        Dim aEleminar As New List(Of DataRow)
        For Each r As DataRow In datos.Rows
            If Not r.Item(posicion).ToString.ToUpper.Equals(elemento.ToUpper) Then
                aEleminar.Add(r)
            End If
        Next
        aEleminar.ForEach(Sub(x) datos.Rows.Remove(x))
    End Sub

    Private Sub FiltadoParcial(posicion As Integer, elemento As String)
        Dim aEleminar As New List(Of DataRow)
        For Each r As DataRow In datos.Rows
            Dim rs = DirectCast(r.Item(posicion), String)
            If rs.Length < elemento.Length OrElse Not rs.Substring(0, elemento.Length).ToUpper.Equals(elemento.ToUpper) Then
                aEleminar.Add(r)
            End If
        Next
        aEleminar.ForEach(Sub(x) datos.Rows.Remove(x))

    End Sub

    Private Sub LugaresBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LugaresBox.SelectedIndexChanged
        lugar = LugaresBox.SelectedItem
        UpdateVehicles()
    End Sub

    Private Sub tiposListas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tiposListas.SelectedIndexChanged
        UpdateVehicles()
        criterios.SelectedIndex = 0
    End Sub

    Private Sub Criterios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles criterios.SelectedIndexChanged

        If tiposListas.SelectedIndex = 0 AndAlso criterios.SelectedIndex >= 6 Then
            buscador.Enabled = False
            buscar.Enabled = False
            UpdateVehicles(False)
            Select Case criterios.SelectedIndex
                Case 6
                    FiltadoCompleto(6, "En el lugar")
                Case 7
                    FiltadoCompleto(6, "Fuera del lugar")
                Case 8
                    FiltadoCompleto(6, "Salió del sistema en este lugar")
            End Select
        Else
            If Not buscador.Enabled Then 'SI ESTABA EN ALGUNA DE LAS OPCIONES DE ARRIBA PREFIERO MOSTRAR LA LISTA ENTREA DE NUEVO, SINO NO 
                UpdateVehicles(False)
            End If
            buscador.Enabled = True
            buscar.Enabled = True

        End If

    End Sub

    Private Sub tabla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tabla.CellContentClick

    End Sub
End Class


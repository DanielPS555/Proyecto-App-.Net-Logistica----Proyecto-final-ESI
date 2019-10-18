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
        DataGridView1.MultiSelect = False
        tiposListas.SelectedIndex = 0

    End Sub

    Private lugar As Lugar

    Dim t As DataTable

    Public Sub UpdateVehicles()
        criterios.Items.Clear()
        criterios.Items.Add("ID vehiculo")
        Select Case tiposListas.SelectedItem
            ' esto es, efectivamente, un hashtable de funciones pero en versión
            ' "la utu nunca dió hashtables ni mapas ni diccionarios y, discutiblemente, funciones"
            ' TODO: hacer esto con un hashtable, no seamos hijos de puta, respetemos el oficio
            Case "Asignados"
                criterios.Items.Add("Vin")
                criterios.Items.Add("IdLote")
                criterios.Items.Add("En el lugar")
                criterios.Items.Add("Fuera del lugar")
                criterios.Items.Add("Fuera del sistema")
                Asignados()
            Case "No asignados"
                criterios.Items.Add("Vin")
                criterios.Items.Add("IdLote")
                criterios.Items.Add("En el lugar")
                criterios.Items.Add("Fecha llegada")
                NoAsignados()
            Case "Entregados"
                criterios.Items.Add("Lugar entrega")
                Entregados()
            Case "Retirados"
                criterios.Items.Add("Lugar retiro")
                Retirados()
            Case "Dañados"
                criterios.Items.Add("Lugar retiro")
                Dañados()
            Case "Precargados"
                criterios.Items.Add("VIN")
                Precargados()
            Case "En transporte"

                criterios.Items.Add("VIN")
                criterios.Items.Add("Id Lote")
                criterios.Items.Add("Destino")
                EnTransporte()
        End Select
        criterios.SelectedIndex = 0
    End Sub

    Private Sub EnTransporte()
        datos = Fachada.getInstancia.VehiculosEnTransporte()
        DataGridView1.DataSource = datos
    End Sub

    Private Sub Precargados()
        datos = Fachada.getInstancia.VehiculosPrecargados()
        DataGridView1.DataSource = datos
    End Sub

    Private Sub Dañados()
        datos = Fachada.getInstancia.VehiculosDañados()
        DataGridView1.DataSource = datos
    End Sub

    Public Sub Retirados()
        datos = Fachada.getInstancia.VehiculosRetirados()
        DataGridView1.DataSource = datos
    End Sub

    Public Sub Entregados()
        datos = Fachada.getInstancia.VehiculosEntregados()
        DataGridView1.DataSource = datos
    End Sub

    Public Sub Asignados()
        If lugar IsNot Nothing Then
            datos = Fachada.getInstancia.ListaVehiculos(lugar)
            DataGridView1.DataSource = datos
        End If
    End Sub

    Public Sub NoAsignados()
        If lugar IsNot Nothing Then
            datos = Controladores.Fachada.getInstancia.listaDeVehiculosSinLoteNiPosicion(lugar.IDLugar)
            DataGridView1.DataSource = datos
        End If
    End Sub

    Private Sub ListaVehiculos_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim g As Graphics = e.Graphics
        g.DrawRectangle(New Pen(Color.FromArgb(35, 35, 35), 2), New Rectangle(criterios.Location, criterios.Size)) 'para dibujarle un rectangulo al combobox
    End Sub

    Private Sub nuevo_Click(sender As Object, e As EventArgs) Handles nuevo.Click
        Marco.getInstancia.CargarPanel(Of NuevoVehiculo)(New NuevoVehiculo)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        '            
        Select Case tiposListas.SelectedItem
            Case "No asignados"
                Dim eleme As New Asignacion(DataGridView1.Rows(e.RowIndex).Cells(1).Value, lugar)
                eleme.ShowDialog()
            Case Else
                Dim row = DataGridView1.Rows()(e.RowIndex)
                Marco.getInstancia.CargarPanel(New panelInfoVehiculo(row.Cells(1).Value)).Show()
        End Select
        '

    End Sub

    Private Sub buscar_Click(sender As Object, e As EventArgs) Handles buscar.Click




        Select Case tiposListas.SelectedItem
            Case "Asignados"
                'criterios.Items.Add("Vin")
                'criterios.Items.Add("IdLote")
                'criterios.Items.Add("En el lugar")
                'criterios.Items.Add("Fuera del lugar")
                'criterios.Items.Add("Fuera del sistema")
                Select Case criterios.SelectedIndex
                    Case 0
                        FiltadoCompleto(0, buscador.Text)
                    Case 1
                        FiltadoParcial(1, buscador.Text)
                    Case 2
                        FiltadoCompleto(5, buscador.Text)
                    Case 2

                    Case 3
                End Select


            Case "No asignados"
                'criterios.Items.Add("Vin")
                'criterios.Items.Add("IdLote")
                'criterios.Items.Add("En el lugar")
                'criterios.Items.Add("Fecha llegada")

            Case "Entregados"
                'criterios.Items.Add("Lugar entrega")

            Case "Retirados"
                'criterios.Items.Add("Lugar retiro")

            Case "Dañados"
                'criterios.Items.Add("Lugar retiro")

            Case "Precargados"
                'criterios.Items.Add("VIN")

            Case "En transporte"

                'criterios.Items.Add("VIN")
                'criterios.Items.Add("Id Lote")
                'criterios.Items.Add("Destino")
        End Select


    End Sub

    Private Sub FiltadoCompleto(posicion As Integer, elemento As String)
        Dim tabAux As New DataTable
        'For Each i As DataColumn In datos.Columns.Item
        '    tabAux.Columns.Add(New DataColumn(i.)
        'Next
        For Each r As DataRow In datos.Rows
            If r.Item(posicion).ToString.Equals(elemento) Then
                tabAux.Rows.Add(r)
            End If
        Next
        DataGridView1.DataSource = tabAux
    End Sub

    Private Sub FiltadoParcial(posicion As Integer, elemento As String)
        Dim tabAux As New DataTable
        'For Each i In datos.Columns
        '    tabAux.Columns.Add(i)
        'Next
        For Each r As DataRow In datos.Rows
            Dim rs = DirectCast(r.Item(posicion), String)
            If rs.Length >= elemento.Length AndAlso rs.Substring(0, elemento.Length).Equals(rs) Then
                tabAux.Rows.Add(r)
            End If
        Next
        DataGridView1.DataSource = tabAux
    End Sub

    Private Sub LugaresBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LugaresBox.SelectedIndexChanged
        lugar = LugaresBox.SelectedItem
        UpdateVehicles()
    End Sub

    Private Sub tiposListas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tiposListas.SelectedIndexChanged
        UpdateVehicles()
    End Sub


End Class


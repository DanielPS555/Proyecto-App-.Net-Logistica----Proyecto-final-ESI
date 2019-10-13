Public Class Incongrencia
    Private lugar_antigo As Controladores.Lugar
    Private lugar_nuevo As Controladores.Lugar
    Private tabla As New DataTable
    Private posiciones As List(Of Controladores.Posicion)
    Private anterior As AdministrarZonasYSubzonas
    Private posicion As Integer = 0
    Public Sub New(la As Controladores.Lugar, ln As Controladores.Lugar, padre As AdministrarZonasYSubzonas)
        lugar_antigo = la
        lugar_nuevo = ln
        anterior = padre
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        For Each z As Controladores.Zona In lugar_nuevo.Zonas
            zona_combo.Items.Add(z.Nombre)
        Next
        zona_combo.SelectedIndex = 0
        tabla.Columns.Add(New DataColumn("VIN"))
        tabla.Columns.Add(New DataColumn("Zona"))
        tabla.Columns.Add(New DataColumn("Subzona"))
        tabla.Columns.Add(New DataColumn("Posicion"))
        tabla.Columns.Add(New DataColumn("Estado"))
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub


    Private Sub cargarDatos()
        posiciones = Controladores.Fachada.getInstancia.PosicionesActualesPorIdlugar(lugar_antigo.IDLugar)
        For Each p As Controladores.Posicion In posiciones
            Dim r As DataRow = tabla.NewRow
            r.Item(0) = p.Vehiculo.VIN
            r.Item(1) = p.Subzona.ZonaPadre.Nombre
            r.Item(2) = p.Subzona.Nombre
            r.Item(3) = p.Posicion
            r.Item(4) = "Incorrecto"

            tabla.Rows.Add(r)
        Next
        detectarPosicionesCongruentes()
    End Sub

    Private Sub detectarPosicionesCongruentes()
        For i As Integer = 0 To posiciones.Count - 1
            If posiciones(i).Autorizado Then
                Continue For
            End If
            If lugar_nuevo.Zonas.Select(Function(x) x.Nombre).ToList.Contains(posiciones(i).Subzona.ZonaPadre.Nombre) Then 'COMPROBAMOS QUE LA ZONA DE LA POSICION EXISTE
                Dim zona = lugar_nuevo.Zonas.Where(Function(x) x.Nombre.Equals(posiciones(i).Subzona.ZonaPadre.Nombre)).Single
                If zona.Subzonas.Select(Function(x) x.Nombre).ToList.Contains(posiciones(i).Subzona.Nombre) Then 'COMPROBAMOS QUE LA SUBZONA EXISTA
                    Dim subzona = zona.Subzonas.Where(Function(x) x.Nombre.Equals(posiciones(i).Subzona.Nombre)).Single
                    If subzona.Capasidad >= posiciones(i).Posicion Then
                        If Not posiciones(i).Autorizado AndAlso comprobarCongruencia(subzona, posiciones(i).Posicion) Then
                            tabla.Rows(i).Item(4) = "Correcto (ESTIMADO)" 'SI PASO TODO ESO CONSIDERO QUE SU POSICION ANTERIOR SE ADECUA A LA NUEVA DISTRIBUCION
                            posiciones(i).Autorizado = True
                        End If
                    End If
                End If
            End If
        Next
        data.DataSource = tabla
        comprobacionTotal()
    End Sub

    Private Sub Zona_combo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles zona_combo.SelectedIndexChanged
        subzona_combo.Items.Clear()
        For Each s As Controladores.Subzona In lugar_nuevo.Zonas(zona_combo.SelectedIndex).Subzonas
            subzona_combo.Items.Add(s.Nombre)
        Next
        subzona_combo.SelectedIndex = 0
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles subzona_combo.SelectedIndexChanged
        posicones_combo.Items.Clear()
        For i As Integer = 1 To lugar_nuevo.Zonas(zona_combo.SelectedIndex).Subzonas(subzona_combo.SelectedIndex).Capasidad
            posicones_combo.Items.Add(i)
        Next
        posicones_combo.SelectedIndex = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Controladores.Marco.getInstancia.CargarPanel(Of AdministrarZonasYSubzonas)(anterior)
    End Sub

    Private Function comprobarCongruencia(subzona As Controladores.Subzona, posicion As Integer)
        Return posiciones.Where(Function(x) x.Subzona.Nombre.Equals(subzona.Nombre) And x.Autorizado).ToList.Where(Function(x) x.Posicion = posicion).ToList.Count = 0
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles modi.Click
        If comprobarCongruencia(lugar_nuevo.Zonas(zona_combo.SelectedIndex).Subzonas(subzona_combo.SelectedIndex), posicones_combo.SelectedItem) Then
            tabla.Rows(posicion).Item(1) = lugar_nuevo.Zonas(zona_combo.SelectedIndex).Nombre
            tabla.Rows(posicion).Item(2) = lugar_nuevo.Zonas(zona_combo.SelectedIndex).Subzonas(subzona_combo.SelectedIndex).Nombre
            tabla.Rows(posicion).Item(3) = posicones_combo.SelectedItem
            tabla.Rows(posicion).Item(4) = "Autorizado"
            posiciones(posicion).Autorizado = True
            posiciones(posicion).Subzona = lugar_nuevo.Zonas(zona_combo.SelectedIndex).Subzonas(subzona_combo.SelectedIndex)
            posiciones(posicion).Posicion = posicones_combo.SelectedItem
            data.DataSource = tabla
            comprobacionTotal()
        Else
            MsgBox("Debe selecionar una posicion la cual no este siendo utilizada por otro vehiculo que fue autorizado", MsgBoxStyle.Critical)
        End If

    End Sub

    Private Sub comprobacionTotal()
        If posiciones.Where(Function(x) x.Autorizado).ToList.Count = posiciones.Count Then
            aceptar.Enabled = True
            MsgBox("Ya puede realizar el cambio, De todas formas antes se comprobara que no hay nuevos vehiculos que solucionar")
        End If
    End Sub

    Private Sub Data_CellContentClick(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles data.CellClick
        posicion = e.RowIndex
        modi.Enabled = True
    End Sub

    Private Function actualizarValores()
        Dim p_aux = Controladores.Fachada.getInstancia.PosicionesActualesPorIdlugar(lugar_antigo.IDLugar)
        Dim j As Boolean = False
        For Each p As Controladores.Posicion In p_aux
            If Not posiciones.Select(Function(x) x.Vehiculo.VIN).Contains(p.Vehiculo.VIN) Then
                posiciones.Add(p)
                j = True
                MsgBox("Se ha encontrado un nuevo vehiculo " & p.Vehiculo.VIN & " se agrega a la lista")
            End If
        Next

        For Each p As Controladores.Posicion In posiciones
            If Not p_aux.Select(Function(x) x.Vehiculo.VIN).Contains(p.Vehiculo.VIN) Then
                posiciones.Remove(p)
                j = True
                MsgBox("No se encuentra mas en el lugar el vehiculo" & p.Vehiculo.VIN & " se eliminara de la lista")
            End If
        Next

        If j Then
            detectarPosicionesCongruentes()
            comprobacionTotal()
            Return False
        Else
            MsgBox("No se han encontrado variantes en la lista")
            Return True
        End If


    End Function

    Private Sub Incongrencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatos()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        actualizarValores()
    End Sub

    Private Sub Aceptar_Click(sender As Object, e As EventArgs) Handles aceptar.Click
        If Not actualizarValores() Then
            MsgBox("Realize los cambios nesesarios y luego vuelva a intentarlo")
            Return
        End If

        'LUEGO SE HACE LA ALTA
    End Sub
End Class
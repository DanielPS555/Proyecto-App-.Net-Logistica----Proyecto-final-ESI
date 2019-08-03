Imports Controladores
Imports Operario.Logica
Public Class ListaZonas
    Private estadoCom As Boolean

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()


        cargarZonas()
        cargarDatosPorDefectos()
        estadoCom = False
    End Sub

    Private Sub cargarDatosPorDefectos()
        zonas.SelectedIndex = 0
    End Sub

    Private Sub cargarZonas()
        Dim r As DataTable = Persistencia.getInstancia.Consultar("select zona.nombre, zona.IDZona from zona, lugar where 
                                              zona.idlugar=lugar.idlugar and lugar.nombre=?", Persistencia.getInstancia.TrabajaEn.Lugar.Nombre)
        zonas.Items.Clear()
        For i As Integer = 0 To r.Rows.Count - 1
            zonas.Items.Add(r.Rows(i).Item(0))
        Next
    End Sub

    Private Sub CargarSubzonas(zona As String)
        Dim r As DataTable = Persistencia.getInstancia.Consultar("select subzona.nombre from subzona,zona,lugar where 
                                              subzona.idzona=zona.idzona and zona.idlugar=lugar.idlugar and 
                                              lugar.nombre=? and zona.nombre=?", Persistencia.getInstancia.TrabajaEn.Lugar.Nombre, zona)
        subzonas.Items.Clear()

        For i As Integer = 0 To r.Rows.Count - 1
            subzonas.Items.Add(r.Rows(i).Item(0))
        Next
    End Sub



    Private Sub zonas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles zonas.SelectedIndexChanged

        CargarSubzonas(zonas.SelectedItem)
        subzonas.SelectedIndex = 0
        zonaNombre.Text = zonas.SelectedItem
        zonaCapasidad.Text = SRepo.Consultar("select zona.capacidad from zona, lugar where zona.nombre='" & zonas.SelectedItem & "'
                                  And zona.IDLugar = Lugar.idLugar and Lugar.Nombre ='" & URepo.ConectadoEn & "'").Rows(0).Item(0)
        Try
            zonaUso.Text = SRepo.Consultar("select zona.nombre, count(vin) from subzona,zona,lugar,posicionado where
                                        subzona.idzona=zona.idzona and zona.idlugar=lugar.idlugar and
                                        lugar.nombre='" & URepo.ConectadoEn & "' and zona.nombre='" & zonas.SelectedItem & "'
                                        and subzona.idSub = posicionado.idsub and posicionado.hasta is null
                                        group by zona.nombre").Rows(0).Item(1)
        Catch ex As Exception
            zonaUso.Text = "0"
        End Try

    End Sub

    Private Sub subzonas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles subzonas.SelectedIndexChanged
        subnombre.Text = subzonas.SelectedItem
        subcapasidad.Text = SRepo.Consultar("select subzona.capacidad from subzona, zona, lugar

                                            where lugar.nombre='" & URepo.ConectadoEn & "' and zona.IDLugar = lugar.idlugar

                                            and zona.nombre = '" & zonas.SelectedItem & "' and subzona.idzona = zona.idzona

                                            and subzona.nombre='" & subzonas.SelectedItem & "'").Rows(0).Item(0)
        Try
            subUso.Text = SRepo.Consultar("select zona.nombre, count(vin) from subzona,zona,lugar,posicionado where
                                        subzona.idzona=zona.idzona and zona.idlugar=lugar.idlugar and
                                        lugar.nombre='" & URepo.ConectadoEn & "' and zona.nombre='" & zonas.SelectedItem & "'
                                        and subzona.idSub = posicionado.idsub and subzona.nombre='" & subzonas.SelectedItem & "' and posicionado.hasta is null
                                        group by zona.nombre").Rows(0).Item(1)
        Catch ex As Exception
            subUso.Text = "0"
        End Try
        cargarTablaVehiculos(zonas.SelectedItem, subzonas.SelectedItem)
    End Sub

    Private Sub cargarTablaVehiculos(zona As String, subzona As String)

        Dim r As DataTable = SRepo.Consultar("select VIN, posicion, desde, hasta, usuario.nombredeUsuario

                                            From lugar, zona, subzona, posicionado, usuario

                                            where lugar.nombre ='" & URepo.ConectadoEn & "' And zona.idlugar = lugar.idLugar

                                            And zona.nombre = '" & zona & "' And subzona.idzona=zona.idzona And subzona.nombre ='" & subzona & "'

                                            And posicionado.idsub = subzona.idsub And posicionado.idusuario=usuario.idusuario")

        r.Columns.Add("CustLName", GetType(String))
        vehi.DataSource = r
        For i As Integer = 0 To r.Rows.Count - 1

            If Logica.Constantes.AutoNull(Of Date?)(vehi.Rows(i).Cells(3).Value) Is Nothing Then
                vehi.Rows(i).Cells(5).Value = "En la posicion"
            Else
                vehi.Rows(i).Cells(5).Value = "Fuera de la posicion"
            End If
        Next



    End Sub

    Private Sub vehi_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles vehi.CellContentClick
        'HACEMOS UN LLAMADO AL PANEL DE INFO DEL VEHICULO 
    End Sub
End Class
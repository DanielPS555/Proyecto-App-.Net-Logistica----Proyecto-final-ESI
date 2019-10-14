Imports Controladores.Extenciones.Extensiones
Imports Controladores

Public Class NuevoMedio
    Implements Controladores.DevolverMedio
    Private TipoMedioLocal As Controladores.TipoMedioTransporte
    Private mediosDeTransporte As List(Of Controladores.TipoMedioTransporte)

    Public Sub New()
        InitializeComponent()
        CrearButton.Traducir
        Label1.Traducir
        Label2.Traducir
        Label3.Traducir
        Label4.Traducir
        Label5.Traducir
        Label6.Traducir
        Label7.Traducir
        Label8.Traducir
        Label9.Traducir
        nuevoTipo.Traducir
        eliminar.Traducir
        mediosDeTransporte = Controladores.Fachada.getInstancia.TodosLosTiposDeMediosDisponibles()
        tipo.Items.AddRange(mediosDeTransporte.Select(Function(x) x.Nombre).ToArray)



        If tipo.Items.Count <> 0 Then
            tipo.SelectedIndex = 0
        End If
    End Sub

    Public Sub devolverTipoDeMedio(e As TipoMedioTransporte) Implements DevolverMedio.devolverTipoDeMedio
        TipoMedioLocal = e
        tipo.Items.Clear()
        tipo.Items.Add(e.Nombre)
        tipo.SelectedIndex = 0
        nuevoTipo.Enabled = False
    End Sub

    Private Sub CrearButton_Click(sender As Object, e As EventArgs) Handles CrearButton.Click
        If idBox.Text.Length = 0 Then
            MsgBoxI18N("identificador no puede ser vacio")
            Return
        End If

        If nombre.Text.Length = 0 Then
            MsgBoxI18N("Nombre no puede ser vacio")
            Return
        End If

        If idBox.Text.Length <> idBox.Text.Trim.Length Then
            MsgBoxI18N("El nombre no puede tener espacios en el inicio ni en el final")
            Return
        End If

        If tipo.SelectedIndex = -1 Then
            MsgBoxI18N("Debe seleccionar un tipo de medio")
            Return
        End If

        If autos.Value + camiones.Value + van.Value + Minivan.Value + suv.Value = 0 Then
            MsgBoxI18N("El medio tiene que poder transportar algun vehiculo")
            Return
        End If

        If TipoMedioLocal Is Nothing Then
            If Controladores.Fachada.getInstancia.ExistenciaDeMedioConIdTipoYIdLegak(mediosDeTransporte(tipo.SelectedIndex).ID, idBox.Text) Then
                MsgBoxI18N("Ya hay un medio de este tipo con este nombre")
                Return
            End If
        End If

        Controladores.Fachada.getInstancia.NuevoMedio(New MedioDeTransporte() With {.Tipo = If(TipoMedioLocal Is Nothing, mediosDeTransporte(tipo.SelectedIndex), TipoMedioLocal),
                                                                                    .ID = idBox.Text,
                                                                                    .Nombre = nombre.Text,
                                                                                    .CantAutos = autos.Value,
                                                                                    .CantCamiones = camiones.Value,
                                                                                    .CantVAN = van.Value,
                                                                                    .CantSUV = suv.Value,
                                                                                    .CantMiniVan = Minivan.Value}, If(TipoMedioLocal Is Nothing, True, False))
        MsgBoxI18N("Medio ingrezado con exito")

    End Sub

    Private Sub NuevoTipo_LinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles nuevoTipo.LinkClicked
        Dim s As New NuevoTipoDeMedio(Me)
        s.ShowDialog()
        eliminar.Visible = True
    End Sub

    Private Sub Eliminar_LinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles eliminar.LinkClicked
        TipoMedioLocal = Nothing
        eliminar.Visible = True
        tipo.Items.Clear()
        tipo.Items.AddRange(mediosDeTransporte.Select(Function(x) x.Nombre).ToArray)
        If tipo.Items.Count <> 0 Then
            tipo.SelectedIndex = 0
        End If
        nuevoTipo.Enabled = True
        eliminar.Visible = False
    End Sub
End Class
Imports Controladores
Imports Controladores.Extenciones
Public Class panel
    Implements Controladores.nuevoLugar
    Private lugares As List(Of Controladores.Lugar) = New List(Of Lugar)
    Private cliente As New Controladores.Cliente

    Public Sub New()
        InitializeComponent()
        Label3.Traducir


    End Sub

    Public Sub devolverlugar(lug As Lugar) Implements Controladores.nuevoLugar.devolverlugar
        If lugares.Select(Function(x) x.Nombre).Contains(lug.Nombre) Then
            Throw New Exception("Ese lugar ya esta cargado")
            Return
        Else
            cliente.Lugares.Add(lug)
            listaDeLugares.Items.Add(lug.Nombre)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If nombre.Text.Trim.Length = 0 Then
            MsgBox("Primero debe ingresar el nombre del cliente", MsgBoxStyle.Critical)
            Return
        End If

        If nombre.Text.Trim.Length = 0 Then
            MsgBox("Primero debe ingresar el nombre del cliente", MsgBoxStyle.Critical)
            Return
        End If
        cliente.Nombre = nombre.Text
        Controladores.Marco.getInstancia.CargarPanel(Of NuevoLugar)(New NuevoLugar(Me))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If listaDeLugares.SelectedIndex = -1 Then
            MsgBox("Debe selecionar un lugar que eliminar")
        Else
            cliente.Lugares.RemoveAt(listaDeLugares.SelectedIndex)
            listaDeLugares.Items.RemoveAt(listaDeLugares.SelectedIndex)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If rutTextBox.Text.Trim.Length = 0 OrElse nombre.Text.Trim.Length = 0 Then
            MsgBox("Error, Rut o nombre del cliente vacios", MsgBoxStyle.Critical)
            Return
        End If

        If rutTextBox.Text.Trim.Length <> 12 Then
            MsgBox("El Rut debe ser de 12 dijitos unicamente", MsgBoxStyle.Critical)
            Return
        End If

        If Not Funciones_comunes.soloNumeros(rutTextBox.Text.Trim) Then
            MsgBox("Debe ser unicamente numerico", MsgBoxStyle.Critical)
            Return
        End If

        If Controladores.Fachada.getInstancia.nombredeClienteEnUso(nombre.Text) Then
            MsgBox("Error, el nombre de este cliente ya esta en uso", MsgBoxStyle.Critical)
            Return
        End If

        If cliente.Lugares.Count = 0 Then
            MsgBox("Al menos debe cargar un establecimiento del cliente", MsgBoxStyle.Critical)
            Return
        End If
        cliente.Nombre = nombre.Text.Trim
        cliente.RUT = rutTextBox.Text.Trim
        Fachada.getInstancia.nuevoCliente(cliente)
        MsgBox("Agregado con exito")
        Marco.getInstancia.CargarPanel(Of ListarClientes)(New ListarClientes)
        Me.Close()
    End Sub

    Public Function DarCliente() As Cliente Implements Controladores.nuevoLugar.DarCliente
        Return cliente
    End Function
End Class
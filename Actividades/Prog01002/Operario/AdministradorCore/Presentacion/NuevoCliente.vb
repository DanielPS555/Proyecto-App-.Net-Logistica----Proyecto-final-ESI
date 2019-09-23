Imports Controladores

Public Class panel
    Implements Controladores.nuevoLugar
    Private lugares As List(Of Controladores.Lugar) = New List(Of Lugar)
    Private cliente As New Controladores.Cliente
    Public Sub devolverlugar(lug As Lugar) Implements Controladores.nuevoLugar.devolverlugar
        If lugares.Select(Function(x) x.Nombre).Contains(lug.Nombre) Then
            Throw New Exception("Ese lugar ya esta cargado")
            Return
        Else
            lugares.Add(lug)
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
        Controladores.Marco.getInstancia.cargarPanel(Of NuevoLugar)(New NuevoLugar(Me))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If listaDeLugares.SelectedIndex = -1 Then
            MsgBox("Debe selecionar un lugar que eliminar")
        Else
            lugares.RemoveAt(listaDeLugares.SelectedIndex)
            listaDeLugares.Items.RemoveAt(listaDeLugares.SelectedIndex)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If rutTextBox.Text.Trim.Length = 0 OrElse nombre.Text.Trim.Length = 0 Then
            MsgBox("Error, Rut o nombre del cliente vacios")
            Return
        End If

        If listaDeLugares.Items.Count = 0 Then
            MsgBox("Al menos debe cargar un establecimiento del cliente")
            Return
        End If

        'ENVIO EN INFORMACION A LA BBDD
    End Sub

    Public Function DarCliente() As Cliente Implements Controladores.nuevoLugar.DarCliente
        Return cliente
    End Function
End Class
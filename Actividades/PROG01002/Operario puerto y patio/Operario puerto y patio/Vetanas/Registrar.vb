Imports Operario_puerto_y_patio.Data

Public Class Registrar
    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        Dim nombres() As String = If(nombresBox.Text.Contains(" "), nombresBox.Text.Split(" "), {nombresBox.Text, Nothing})
        Dim apellidos() As String = If(apellidosBox.Text.Contains(" "), apellidosBox.Text.Split(" "), {apellidosBox.Text, Nothing})
        Dim usuario As New User(userBox.Text, pwdBox.Text, User.RolFromString(roleList.SelectedItem), emailBox.Text, datePicker.Value, telefonoBox.Text, nombres(0), nombres(1), apellidos(0), apellidos(1), CType(sexCombo.SelectedItem, String)(0))
        Dim lugares As New List(Of Integer)
        For Each i As DataRowView In CheckedListBox1.CheckedItems
            lugares.Add(i(0))
        Next
        If Data.Login.UserRegister(usuario, preguntaBox.Text, respuestaBox.Text, lugares) Then
            Principal.getInstancia.cargarPanel(Of Login)()
        Else
            MsgBox("No se pudo registrar el usuario XDDDDDDDDDDDDD")
        End If
    End Sub

    Private Sub Registrar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As New DataTable("Lugares")
        Dim selcmd As New Odbc.OdbcCommand("select IDLugar, Lugar.Nombre from lugar;", ODBCLogin.Connection)
        dt.Load(selcmd.ExecuteReader)
        CheckedListBox1.DataSource = New BindingSource(dt, Nothing)
        CheckedListBox1.DisplayMember = "Nombre"
        CheckedListBox1.ValueMember = "IDLugar"
    End Sub
End Class
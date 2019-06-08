Public Class AgregarInspección
    Public vehiculo As String
    Public registros As New List(Of Registro)
    Public selected As Registro = Nothing
    Private bs As New BindingSource()

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        registros.Add(New Registro)
        updateList()
        regImg.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub updateList()
        registerList.Items.Clear()
        registros.ForEach(Sub(x) registerList.Items.Add(x.descripcion))
    End Sub


    Private textDif As Integer = 0
    Private Sub registerList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles registerList.SelectedIndexChanged
        If registerList.SelectedIndex >= 0 AndAlso registerList.SelectedIndex < registros.Count Then
            selected = registros(registerList.SelectedIndex)
            RegBox.Text = selected.descripcion
            regImg.Image = If(Not IsNothing(selected.imagen), Bitmap.FromStream(New IO.MemoryStream(selected.imagen)), My.Resources.car)
        End If
    End Sub

    Private Sub RegBox_TextChanged(sender As Object, e As EventArgs) Handles RegBox.TextChanged
        selected.descripcion = RegBox.Text
        textDif += 1
        If textDif > 10 Then
            updateList()
            textDif = 0
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "Archivos BMP|*.bmp"
        ofd.Multiselect = False
        If ofd.ShowDialog() = DialogResult.OK Then
            Dim f = ofd.OpenFile
            Dim bytes(f.Length) As Byte
            f.Read(bytes, 0, f.Length)
            selected.imagen = bytes
            regImg.Image = Bitmap.FromStream(New IO.MemoryStream(selected.imagen))
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim inform = ODBCLogin.Connection.CreateCommand
        inform.CommandText = "insert into informedanios(descripcion, fecha, tipo, vehiculosobre) values (?, ?, ?, ?);"
        inform.CrearParametro(Odbc.OdbcType.VarChar, "desc", InspectBox.Text, False)
        inform.CrearParametro(Odbc.OdbcType.Date, "date", DateTimePicker1.Value, False)
        inform.CrearParametro(Odbc.OdbcType.VarChar, "tipo", Tipo.Text, False)
        inform.CrearParametro(Odbc.OdbcType.Char, "vehiculo", vehiculo, False)
        If Not inform.ExecuteNonQuery = 1 Then
            MsgBox("No se pudo agregar el informe")
            Return
        End If
        Dim getTuple = ODBCLogin.Connection.CreateCommand
        getTuple.CommandText = "select ID from informedanios where descripcion=? and fecha=? and tipo=? and vehiculosobre=?"
        getTuple.CrearParametro(Odbc.OdbcType.VarChar, "desc", InspectBox.Text, False)
        getTuple.CrearParametro(Odbc.OdbcType.Date, "date", DateTimePicker1.Value, False)
        getTuple.CrearParametro(Odbc.OdbcType.VarChar, "tipo", Tipo.Text, False)
        getTuple.CrearParametro(Odbc.OdbcType.Char, "vehiculo", vehiculo, False)
        Dim idTuple = getTuple.ExecuteScalar
        Dim registerinsert = ODBCLogin.Connection.CreateCommand
        registerinsert.CommandText = "insert into registrodanios(informedanios, nroenlista, descripcion) values (?, ?, ?);"
        registerinsert.CrearParametro(Odbc.OdbcType.Int, "informe", idTuple, False)
        Dim nrolista = registerinsert.CrearParametro(Odbc.OdbcType.Int, "nroLista", 0, False)
        Dim desc = registerinsert.CrearParametro(Odbc.OdbcType.VarChar, "desc", "", False)
        Dim imageninsert = ODBCLogin.Connection.CreateCommand
        imageninsert.CommandText = "insert into imagenregistro(rdid, imgit, imagen) values (?, 0, ?);"
        Dim rd = imageninsert.CrearParametro(Odbc.OdbcType.Int, "registro", 0, False)
        Dim img = imageninsert.CrearParametro(Odbc.OdbcType.Binary, "imagen", 0, False)
        For i As Integer = 0 To registros.Count - 1
            nrolista.Value = i
            desc.Value = registros(i).descripcion
            If registerinsert.ExecuteNonQuery <> 1 Then
                MsgBox("Error agregando el registro " & i)
            Else
                Dim selcmd = ODBCLogin.Connection.CreateCommand
                selcmd.CommandText = "select rd from registrodanios where informedanios=? and nroenlista=?;"
                selcmd.CrearParametro(Odbc.OdbcType.Int, "id", idTuple, False)
                selcmd.CrearParametro(Odbc.OdbcType.Int, "nrolista", i, False)
                rd.Value = selcmd.ExecuteScalar
                img.Value = registros(i).imagen
                If imageninsert.ExecuteNonQuery <> 1 Then
                    MsgBox("Error agregando imagenes del registro " & i)
                End If
            End If
        Next
    End Sub
End Class

Public Class Registro
    Public descripcion As String
    Public imagen() As Byte

    Public Sub New()
        Me.descripcion = ""
        Me.imagen = Nothing
    End Sub
End Class

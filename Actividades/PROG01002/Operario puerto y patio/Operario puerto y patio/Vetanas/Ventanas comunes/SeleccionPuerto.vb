Public Class SeleccionPuerto
    Inherits SeleccionLugar
    Public Sub New()
        MyBase.New()
        Me.lugarFilter = "Puerto"
    End Sub

    Public Sub ingresar() Handles Button1.Click
        Dim prt As MarcoPuerto = Principal.getInstancia.cargarPanel(Of MarcoPuerto)
        prt.Usuario = Usuario
        prt.Lugar = CType(LugaresList.SelectedItem, DataRowView)(0)
        Dim ingresaCommand = ODBCLogin.Connection.CreateCommand
        ingresaCommand.CommandText = "insert into usuarioingresa(ID_TE, FechaHoraInicio) values((select logID_TE from trabajaen, usuario where lugar=? and usuario.nombredeusuario=? and trabajaen.usuario=usuario.idusuario), ?);"
        ingresaCommand.CrearParametro(Odbc.OdbcType.Int, "lugar", prt.Lugar, False)
        ingresaCommand.CrearParametro(Odbc.OdbcType.VarChar, "usr", Usuario.Nombre, False)
        ingresaCommand.CrearParametro(Odbc.OdbcType.Date, "ahora", Date.Now, False)
        If ingresaCommand.ExecuteNonQuery <> 1 Then
            prt.Close()
            MsgBox("Falló al registrar su ingreso. Intente nuevamente o contacte a un desarrollador")
            Principal.getInstancia.cargarPanel(Of Login)()
        End If
        Usuario.lugaractual = prt.Lugar
    End Sub

End Class

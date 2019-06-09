Imports Operario_puerto_y_patio.Data

Public Class PuertoInicio
    Implements IHandlesUsers
    Private _usuario As User
    Public Lugar As String
    Public Property Usuario As User Implements IHandlesUsers.Usuario
        Get
            Return _usuario
        End Get
        Set(value As User)
            _usuario = value
            Label7.Text = _usuario.Nombre
            Label6.Text = User.StringFromRol(_usuario.Rol)
            Label2.Text = $"{_usuario.primernombre} {_usuario.primerapellido}"
            Dim connectioncount = ODBCLogin.Connection.CreateCommand
            connectioncount.CommandText = "select count(*) from usuarioingresa, usuario, trabajaen where usuario.nombredeusuario=? and trabajaen.usuario=usuario.idusuario and trabajaen.logID_TE=usuarioingresa.ID_TE;"
            connectioncount.CrearParametro(Odbc.OdbcType.VarChar, "Usuario", Usuario.Nombre, False)
            Label5.Text = $"{connectioncount.ExecuteScalar}"
            connectioncount.CommandText = "select fechahorainicio from usuarioingresa, usuario, trabajaen order by trabajaen.fechahorasalida desc where usuario.nombrdeusuario=? and usuario.idusuario=trabajaen.usuario and usuarioingresa.id_te=trabajaen.logid_te and usuarioingresa.fechahorafin is not null;"
            'Label3.Text = $"{DirectCast(connectioncount.ExecuteScalar, Date).ToShortDateString}"
        End Set
    End Property
    Private Sub PuertoInicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
End Class
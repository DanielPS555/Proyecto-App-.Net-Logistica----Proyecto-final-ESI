Imports Operario_puerto_y_patio
Imports Operario_puerto_y_patio.Data

Public Class SeleccionLugar
    Implements IHandlesUsers
    Private _usuario As User
    Public lugarFilter As String
    Private dt As DataTable

    Private Sub updateList()
        If lugarFilter Is Nothing Then
            lugarFilter = "%"
        End If
        Dim selcmd = New Odbc.OdbcCommand("select IDLugar, Lugar.Nombre from lugar, usuario, trabajaen where usuario.idusuario = trabajaen.usuario and trabajaen.lugar = lugar.idlugar and usuario.nombredeusuario=? and lugar.tipo like ?;", ODBCLogin.Connection)
        selcmd.CrearParametro(Odbc.OdbcType.VarChar, "usuario", _usuario.Nombre, False)
        selcmd.CrearParametro(Odbc.OdbcType.VarChar, "filtro", lugarFilter, False)
        Dim rdr = selcmd.ExecuteReader()
        dt = New DataTable("Lugares")
        dt.Load(rdr)
        LugaresList.DataSource = dt
        LugaresList.DisplayMember = "Nombre"
        LugaresList.ValueMember = "IDLugar"
    End Sub

    Public Property Usuario As User Implements IHandlesUsers.Usuario
        Get
            Return _usuario
        End Get
        Set(value As User)
            _usuario = value
            updateList()
        End Set
    End Property
End Class
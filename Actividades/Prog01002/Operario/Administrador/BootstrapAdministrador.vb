Imports AdministradorCore
Imports Controladores

Public Class BootstrapAdministrador
    Public Shared Sub Main()
        Funciones_comunes.Inter_test()
        Dim p = Principal.CrearInstancia(Sub()
                                             Dim paneles = New Dictionary(Of String, Type) From {
                                                 {"Listar Clientes", GetType(ListarClientes)},
                                                 {"Listar Lugares", GetType(ListarLugares)},
                                                 {"Listar Usuario", GetType(ListarUsuario)},
                                                 {"Nueva Precarga", GetType(NuevaPrecarga)},
                                                 {"Nuevo Cliente", GetType(NuevoCliente)},
                                                 {"Nuevo Lugar", GetType(NuevoLugar)},
                                                 {"Lista de medios", GetType(TransportistaCore.ListaDeMediosAutorizados)}
                                             }
                                             Marco.SetButtons(paneles)
                                             Marco.ReiniciarSingleton()
                                             Principal.getInstancia.cargarPanel(Marco.getInstancia())
                                         End Sub, Usuario.TIPO_ROL_ADMINISTRADOR)
        p.ShowDialog()
    End Sub
End Class

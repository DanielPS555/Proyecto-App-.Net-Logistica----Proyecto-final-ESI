

Public Class BootstrapAdministrador
    Public Shared Sub Main()
        Controladores.Funciones_comunes.Inter_test()
        Dim p = Controladores.Principal.CrearInstancia(Sub()
                                                           Dim paneles = New Dictionary(Of String, Type) From {
                                                 {"Listar Clientes", GetType(AdministradorCore.ListarClientes)},
                                                 {"Listar Lugares", GetType(AdministradorCore.ListarLugares)},
                                                 {"Listar Usuario", GetType(AdministradorCore.ListarUsuario)},
                                                 {"Nueva Precarga", GetType(AdministradorCore.NuevaPrecarga)},
                                                 {"Nuevo Cliente", GetType(AdministradorCore.panel)},
                                                 {"Nuevo Lugar", GetType(AdministradorCore.NuevoLugar)},
                                                 {"Lista de medios", GetType(TransportistaCore.ListaDeMediosAutorizados)}
                                             }
                                                           Controladores.Marco.SetButtons(paneles)
                                                           Controladores.Marco.ReiniciarSingleton()
                                                           Controladores.Principal.getInstancia.cargarPanel(Controladores.Marco.getInstancia())
                                                       End Sub, Controladores.Usuario.TIPO_ROL_ADMINISTRADOR)

        Application.Run(p)
    End Sub
End Class

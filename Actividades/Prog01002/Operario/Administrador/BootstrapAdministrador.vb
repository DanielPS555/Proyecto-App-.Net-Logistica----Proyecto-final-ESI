Public Class BootstrapAdministrador
    Public Shared Sub Main()
        Controladores.Funciones_comunes.Inter_test()
        Dim p = Controladores.Principal.CrearInstancia(
            Sub()
                Dim paneles = New Dictionary(Of String, Type) From {
                  {"Listar Clientes", GetType(AdministradorCore.ListarClientes)},
                  {"Listar Lugares", GetType(AdministradorCore.ListarLugares)},
                  {"Listar Usuario", GetType(AdministradorCore.ListarUsuario)},
                  {"Nueva Precarga", GetType(AdministradorCore.NuevaPrecarga)},
                  {"Lista de medios", GetType(TransportistaCore.ListaDeMediosAutorizados)},
                  {"Precargas masivas", GetType(AdministradorCore.PrecargaMasiva)},
                  {"Mensajes", GetType(AdministradorCore.EventMessenger)},
                  {"Consola de Python", GetType(AdministradorCore.PythonPanel)},
                  {"Lista vehiculos", GetType(OperarioCore.ListaVehiculos)},
                  {"Chat", GetType(Controladores.ChatInterno)},
                  {"Lista lotes", GetType(OperarioCore.ListaLotes)},
                  {"Nuevo vehiculo", GetType(OperarioCore.NuevoVehiculo)}
                }
                Controladores.Marco.SetButtons(paneles)
                Controladores.Marco.Imagenes = New Dictionary(Of String, Bitmap)
                For Each z In paneles.Keys
                    Try
                        Dim img As Bitmap = My.Resources.ResourceManager.GetObject(z.Replace(" ", "_"))
                        If img Is Nothing Then Continue For
                        Controladores.Marco.Imagenes(z) = img
                        My.Resources.ResourceManager.ReleaseAllResources()
                    Catch ex As Exception
                    End Try
                Next
                Controladores.Marco.ReiniciarSingleton()
                Controladores.Principal.getInstancia.cargarPanel(Controladores.Marco.getInstancia())
            End Sub, Controladores.Usuario.TIPO_ROL_ADMINISTRADOR)
        Application.Run(p)
    End Sub
End Class

Imports TransportistaCore
Imports Controladores

Public Class BootstrapTransportista
    Public Shared Sub Main()
        Funciones_comunes.Inter_test()
        Dim p = Controladores.Principal.CrearInstancia(Sub()
                                                           Dim paneles = New Dictionary(Of String, Type) From {
                                                 {"Lista de Lotes", GetType(TransportistaCore.Lista_de_trasportes)},
                                                 {"Lista de transportes", GetType(TransportistaCore.ListaDeTrasportes)},
                                                 {"Medios autorizados", GetType(TransportistaCore.ListaDeMediosAutorizados)}
                                             }
                                                           Controladores.Marco.SetButtons(paneles)
                                                           Marco.ReiniciarSingleton()
                                                           Principal.getInstancia.cargarPanel(Marco.getInstancia())
                                                       End Sub, Usuario.TIPO_ROL_TRANSPORTISTA)
        Windows.Forms.Application.Run(p)
    End Sub
End Class

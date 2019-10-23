Imports TransportistaCore
Imports Controladores
Imports System.Drawing

Public Class BootstrapTransportista
    Public Shared Sub Main()
        Funciones_comunes.Inter_test()
        Dim p = Controladores.Principal.CrearInstancia(Sub()
                                                           Dim paneles = New Dictionary(Of String, Type) From {
                                                 {"Lotes dispobibles", GetType(TransportistaCore.Lista_de_trasportes)},
                                                 {"Lista transportes", GetType(TransportistaCore.ListaDeTrasportes)},
                                                 {"Lista de medios", GetType(TransportistaCore.ListaDeMediosAutorizados)}
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
                                                           Marco.ReiniciarSingleton()
                                                           Principal.getInstancia.cargarPanel(Marco.getInstancia())
                                                       End Sub, Usuario.TIPO_ROL_TRANSPORTISTA)
        Windows.Forms.Application.Run(p)
    End Sub
End Class

Imports Controladores

Public Class BootstrapOperario
    Public Shared Sub Main()
        Funciones_comunes.Inter_test()
        Dim p = Principal.CrearInstancia(Sub()
                                             Dim lt = New OperarioCore.LugarDeTrabajo
                                             Principal.getInstancia.cargarPanel(lt)
                                         End Sub, Usuario.TIPO_ROL_OPERARIO)
        p.ShowDialog()
    End Sub
End Class

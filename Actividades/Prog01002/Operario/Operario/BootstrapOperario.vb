Imports Controladores

Public Class BootstrapOperario
    Public Shared Sub Main()
        Dim p As Principal
        Funciones_comunes.Inter_test()
        p = Principal.CrearInstancia(Sub()
                                         Dim lt = New OperarioCore.LugarDeTrabajo
                                         Principal.getInstancia.cargarPanel(lt)
                                     End Sub, Usuario.TIPO_ROL_OPERARIO)
        Application.Run(p)
    End Sub
End Class

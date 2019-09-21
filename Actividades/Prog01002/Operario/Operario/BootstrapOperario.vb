Public Class BootstrapOperario
    Public Shared Sub Main()
        Dim p = Controladores.Principal.CrearInstancia(Sub()
                                                           Dim lt = New OperarioCore.LugarDeTrabajo
                                                           Controladores.Principal.getInstancia.cargarPanel(lt)
                                                       End Sub, Controladores.Usuario.TIPO_ROL_OPERARIO)
        p.ShowDialog()
    End Sub
End Class

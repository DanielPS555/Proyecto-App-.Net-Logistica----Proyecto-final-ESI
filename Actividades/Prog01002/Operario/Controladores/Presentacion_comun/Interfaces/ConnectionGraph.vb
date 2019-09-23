Public Module ConnectionGraph
    Public Function CreateGraph() As Microsoft.Msagl.GraphViewerGdi.GViewer
        Dim connections = Controladores.Fachada.getInstancia.ConexionesLugares
        Dim graph = New Microsoft.Msagl.Drawing.Graph("Lugares")
        Dim viewer = New Microsoft.Msagl.GraphViewerGdi.GViewer()
        Dim cols = {Color.Black, Color.Brown, Color.Blue}
        For Each m In connections
            Dim e = graph.AddEdge(m.Item1, m.Item2)
            e.Attr.Color = New Microsoft.Msagl.Drawing.Color(cols(m.Item3 - 1).R, cols(m.Item3 - 1).G, cols(m.Item3 - 1).B)
        Next
        viewer.Graph = graph
        viewer.ToolBarIsVisible = False
        viewer.ContextMenu = Nothing
        viewer.LayoutEditingEnabled = False
        viewer.Size = New Size(880, 650)
        Return viewer
    End Function
End Module

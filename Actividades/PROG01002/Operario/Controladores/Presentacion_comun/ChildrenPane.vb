Imports Controladores

Public Class ChildrenPane

    Private Sub New(ChildrenOf As ScreenNode)

        InitializeComponent()

        RecursiveWalk(ChildrenOf, Me.GraphBox.Nodes.Add(ChildrenOf.Panel.GetType.Name))

    End Sub

    Private Sub RecursiveWalk(c As ScreenNode, node As TreeNode, Optional depth As Integer = 0)
        If depth > 3 Then
            Return
        End If
        For Each children In c.Children
            Dim newnode = node.Nodes.Add(children.Panel.GetType.Name)
            newnode.Tag = children
            RecursiveWalk(children, newnode, depth + 1)
        Next
    End Sub

    Private sn As ScreenNode = Nothing

    Public Shared Function GetChild(sn As ScreenNode) As ScreenNode
        Dim cp As New ChildrenPane(sn)
        cp.ShowDialog()
        Return cp.sn
    End Function

    Private changed As Boolean = False

    Private Sub GraphBox_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles GraphBox.AfterSelect
        If Not changed Then
            changed = True
            Return
        End If
        If e.Node IsNot Nothing Then
            sn = e.Node.Tag
            Close()
        End If
    End Sub
End Class
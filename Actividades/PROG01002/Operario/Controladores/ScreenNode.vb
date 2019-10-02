Imports Controladores

Public Structure Result(Of T1, T2)
    Public ReadOnly A As T1
    Public ReadOnly B As T2
    Public ReadOnly Type As Boolean

    Public Sub New(type As Boolean, obj As Object)
        Me.Type = type
        If type AndAlso GetType(T1).IsAssignableFrom(obj.GetType) Then
            A = obj
        ElseIf Not type AndAlso GetType(T2).IsAssignableFrom(obj.GetType) Then
            B = obj
        Else
            Dim expectedType = If(type, GetType(T1), GetType(T2))
            Throw New InvalidStateException(Of Result(Of T1, T2))("Se esperaba el tipo " & expectedType.Name & " o un heredero", Me)
        End If
    End Sub
End Structure

Public Class ScreenNode
    Public ReadOnly Parent As Result(Of ScreenNode, Marco)
    Public ReadOnly Children As New HashSet(Of ScreenNode)
    Public ReadOnly Panel As Form

    Public Function MarcoGrandParent() As Marco
        If Parent.Type Then
            Return Parent.A.MarcoGrandParent
        Else
            Return Parent.B
        End If
    End Function

    Public Sub Close()
        For Each sn In Children.ToList
            sn.Close()
        Next
        If Parent.Type Then
            Parent.A.Children.Remove(Me)
            Parent.A.MarcoGrandParent.CurrentPanel = Parent.A
        Else
            Parent.B.Controls.Remove(Panel)
            Parent.B.CurrentPanel = Nothing
        End If
        Panel.Close()
    End Sub

    Public Sub New(parent As Result(Of ScreenNode, Marco), panel As Form)
        Me.Parent = parent
        If parent.Type Then
            parent.A.Children.Add(Me)
        End If
        Me.Panel = panel
    End Sub
End Class
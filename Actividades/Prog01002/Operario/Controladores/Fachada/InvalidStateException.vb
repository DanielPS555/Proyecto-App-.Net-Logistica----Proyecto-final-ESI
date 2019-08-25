Imports System.Runtime.Serialization

<Serializable>
Public Class InvalidStateException(Of BrokenClass)
    Inherits Exception

    Public ReadOnly BrokenObject As BrokenClass

    Public Sub New()
    End Sub

    Public Sub New(message As String, broken As BrokenClass)
        MyBase.New(message)
        Me.BrokenObject = broken
    End Sub

    Public Sub New(message As String, innerException As Exception, broken As BrokenClass)
        MyBase.New(message, innerException)
        Me.BrokenObject = broken
    End Sub

    Protected Sub New(info As SerializationInfo, context As StreamingContext, broken As BrokenClass)
        MyBase.New(info, context)
        Me.BrokenObject = broken
    End Sub
End Class

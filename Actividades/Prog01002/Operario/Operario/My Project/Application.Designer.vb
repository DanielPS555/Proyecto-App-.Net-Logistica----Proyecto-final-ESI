﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    'NOTA: Este archivo se genera automáticamente; no lo modifique directamente.  Para hacer cambios,
    ' o si detecta errores de compilación en este archivo, vaya al Diseñador de proyectos
    ' (vaya a Propiedades del proyecto o haga doble clic en el nodo My Project en el
    ' Explorador de soluciones) y realice cambios en la pestaña Aplicación.
    '
    Partial Friend Class MyApplication

        <Global.System.Diagnostics.DebuggerStepThroughAttribute()>
        Public Sub New()
            MyBase.New(Global.Microsoft.VisualBasic.ApplicationServices.AuthenticationMode.Windows)
            Me.IsSingleInstance = False
            Me.EnableVisualStyles = True
            Me.SaveMySettingsOnExit = True
            Me.ShutdownStyle = Global.Microsoft.VisualBasic.ApplicationServices.ShutdownMode.AfterMainFormCloses
            AddHandler System.Windows.Forms.Application.ThreadException, Sub()
                                                                             UnhandledExceptionHandler(Nothing, Nothing)
                                                                         End Sub
        End Sub
        Public Shared Sub UnhandledExceptionHandler(sender As Object, e As UnhandledExceptionEventArgs)
            MsgBox("El programa ha encontrado un error fatal y será cerrado." & vbNewLine & "Por favor informe a su administrador.")
            If URepo IsNot Nothing Then
                URepo.Desconectar()
            End If
        End Sub
        <Global.System.Diagnostics.DebuggerStepThroughAttribute()>  _
        Protected Overrides Sub OnCreateMainForm()
            Me.MainForm = Global.Operario.Principal
        End Sub
    End Class
End Namespace

Imports System.Windows.Input

Namespace TempAzubiBerichtsheft.ViewModels
    Public Class RelayCommand
        Implements ICommand

        Private ReadOnly _execute As Action

        Public Sub New(execute As Action)
            _execute = execute
        End Sub

        Public Custom Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
            AddHandler(value As EventHandler)
            End AddHandler
            RemoveHandler(value As EventHandler)
            End RemoveHandler
            RaiseEvent(sender As Object, e As EventArgs)
            End RaiseEvent
        End Event

        Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
            Return True
        End Function

        Public Sub Execute(parameter As Object) Implements ICommand.Execute
            _execute()
        End Sub
    End Class
End Namespace

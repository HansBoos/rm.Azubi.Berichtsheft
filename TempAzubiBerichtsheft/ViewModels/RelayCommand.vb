'Imports System.Windows.Input

'Namespace TempAzubiBerichtsheft.ViewModels
'    Public Class RelayCommand
'        Implements ICommand

'        Private ReadOnly _execute As Action

'        Public Sub New(execute As Action)
'            _execute = execute
'        End Sub

'        Public Custom Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
'            AddHandler(value As EventHandler)
'            End AddHandler
'            RemoveHandler(value As EventHandler)
'            End RemoveHandler
'            RaiseEvent(sender As Object, e As EventArgs)
'            End RaiseEvent
'        End Event

'        Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
'            Return True
'        End Function

'        Public Sub Execute(parameter As Object) Implements ICommand.Execute
'            _execute()
'        End Sub
'    End Class
'End Namespace
Imports System.Windows.Input

Namespace TempAzubiBerichtsheft.ViewModels
    Public Class RelayCommand
        Implements ICommand

        Private ReadOnly _execute As Action
        Private ReadOnly _executeWithParam As Action(Of Object)
        Private ReadOnly _canExecute As Func(Of Object, Boolean)

        ' Konstruktor für Aktionen ohne Parameter
        Public Sub New(execute As Action)
            _execute = execute
        End Sub

        ' Konstruktor für Aktionen mit Parameter
        Public Sub New(execute As Action(Of Object), Optional canExecute As Func(Of Object, Boolean) = Nothing)
            _executeWithParam = execute
            _canExecute = If(canExecute, Function(p) True)
        End Sub

        Public Custom Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
            AddHandler(value As EventHandler)
                ' In WinForms benötigen wir den CommandManager nicht
                AddHandler InternalCanExecuteChanged, value
            End AddHandler
            RemoveHandler(value As EventHandler)
                RemoveHandler InternalCanExecuteChanged, value
            End RemoveHandler
            RaiseEvent(sender As Object, e As EventArgs)
                RaiseEvent InternalCanExecuteChanged(sender, e)
            End RaiseEvent
        End Event

        ' Internes Event für CanExecuteChanged
        Private Event InternalCanExecuteChanged As EventHandler

        Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
            If _canExecute IsNot Nothing Then
                Return _canExecute(parameter)
            End If
            Return True
        End Function

        Public Sub Execute(parameter As Object) Implements ICommand.Execute
            If _execute IsNot Nothing Then
                _execute()
            ElseIf _executeWithParam IsNot Nothing Then
                _executeWithParam(parameter)
            End If
        End Sub

        ' Methode zum Auslösen des CanExecuteChanged-Events
        Public Sub RaiseCanExecuteChanged()
            RaiseEvent InternalCanExecuteChanged(Me, EventArgs.Empty)
        End Sub
    End Class
End Namespace

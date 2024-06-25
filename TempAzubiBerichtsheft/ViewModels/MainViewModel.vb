Imports System.ComponentModel
Imports TempAzubiBerichtsheft.Models
Imports TempAzubiBerichtsheft.TempAzubiBerichtsheft.Models

Namespace TempAzubiBerichtsheft.ViewModels
    Public Class MainViewModel
        Implements INotifyPropertyChanged

        Private _benutzer As Benutzer

        Public Property Benutzer As Benutzer
            Get
                Return _benutzer
            End Get
            Set(value As Benutzer)
                _benutzer = value
                OnPropertyChanged("Benutzer")
            End Set
        End Property

        Public Sub New()
            ' Initialisieren Sie hier die notwendigen Daten
            Benutzer = New Benutzer(1, "Admin", "Administrator", "password")
        End Sub

        Protected Sub OnPropertyChanged(propertyName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    End Class
End Namespace

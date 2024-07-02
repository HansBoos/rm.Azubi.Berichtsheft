Imports System.ComponentModel
Imports TempAzubiBerichtsheft.Models
Imports TempAzubiBerichtsheft.TempAzubiBerichtsheft.Data
Imports TempAzubiBerichtsheft.TempAzubiBerichtsheft.Models

Namespace TempAzubiBerichtsheft.ViewModels
    Public Class MainViewModel
        Implements INotifyPropertyChanged

        Private _benutzer As Benutzer

        Public Property Ausbildungsberichte As New List(Of Ausbildungsbericht)

        Private ausbildungsberichtRepisotry As AusbildungsberichtRepository

        Public Property Benutzer As Benutzer
            Get
                Return _benutzer
            End Get
            Set(value As Benutzer)
                _benutzer = value
                OnPropertyChanged("Benutzer")
            End Set
        End Property

        Public Sub New(benutzer As Benutzer)
            ' Initialisieren Sie hier die notwendigen Daten
            Me.Benutzer = benutzer
            ausbildungsberichtRepisotry = New AusbildungsberichtRepository()
            Ausbildungsberichte = ausbildungsberichtRepisotry.LoadBerichte(benutzer.Name)
            If Ausbildungsberichte Is Nothing Then
                Ausbildungsberichte = New List(Of Ausbildungsbericht)()
            End If
        End Sub
        Public Sub SaveBerichte()
            ausbildungsberichtRepisotry.SaveBerichte(Benutzer.Name, Ausbildungsberichte)
        End Sub


        Public Sub AddBericht(bericht As Ausbildungsbericht)
            Debug.WriteLine("AddBericht")
            Ausbildungsberichte.Add(bericht)
            'SaveBerichte()
        End Sub



        Protected Sub OnPropertyChanged(propertyName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    End Class
End Namespace

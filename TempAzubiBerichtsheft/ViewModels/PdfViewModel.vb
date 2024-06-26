Imports System.ComponentModel
Imports System.Windows.Input
Imports TempAzubiBerichtsheft.Models
Imports TempAzubiBerichtsheft.TempAzubiBerichtsheft.Models

Namespace TempAzubiBerichtsheft.ViewModels
    Public Class PdfViewModel
        Implements INotifyPropertyChanged

        Private _pdfProcessor As PdfDocumentProcessor

        Public Sub New()
            _pdfProcessor = New PdfDocumentProcessor()
            LoadCommand = New RelayCommand(AddressOf LoadDocument)
            SignCommand = New RelayCommand(AddressOf SignDocument)
            SaveCommand = New RelayCommand(AddressOf SaveDocument)
        End Sub

        Private _inputFilePath As String
        Public Property InputFilePath As String
            Get
                Return _inputFilePath
            End Get
            Set(value As String)
                _inputFilePath = value
                OnPropertyChanged(NameOf(InputFilePath))
            End Set
        End Property

        Private _outputFilePath As String
        Public Property OutputFilePath As String
            Get
                Return _outputFilePath
            End Get
            Set(value As String)
                _outputFilePath = value
                OnPropertyChanged(NameOf(OutputFilePath))
            End Set
        End Property

        Public Property CertificatePath As String
        Public Property CertificatePassword As String
        'Public Property SignatureInfo As SignatureInfo

        Public Property LoadCommand As ICommand
        Public Property SignCommand As ICommand
        Public Property SaveCommand As ICommand

        Private Sub LoadDocument()
            '_pdfProcessor.LoadDocument(InputFilePath)
        End Sub

        Private Sub SignDocument()
            '_pdfProcessor.AddSignature(CertificatePath, CertificatePassword, SignatureInfo)
        End Sub

        Private Sub SaveDocument()
            '_pdfProcessor.SaveDocument(OutputFilePath)
        End Sub

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
        Protected Sub OnPropertyChanged(propertyName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub
    End Class
End Namespace

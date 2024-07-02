Imports System.Windows.Forms
Imports TempAzubiBerichtsheft.TempAzubiBerichtsheft.ViewModels
Imports System.Drawing
Imports System.Windows.Input

Namespace TempAzubiBerichtsheft.ViewModels
    Public Class BaseViewModel
        ' Gemeinsame Funktionen und Eigenschaften hier definieren
        Public Function GetResourcePath(fileName As String) As String

            Dim basePath As String = AppDomain.CurrentDomain.BaseDirectory
            Dim projectPath As String = System.IO.Path.Combine(basePath, "..", "..", "..")
            Return System.IO.Path.Combine(projectPath, "Resourcen", fileName)
        End Function
        ' Befehle für die Textformatierung
        Public Property ItalicCommand As RelayCommand
        Public Property BoldCommand As RelayCommand
        Public Property NormalCommand As RelayCommand
        Public Property ChangeFontSizeCommand As RelayCommand
        Public Property ChangeFontFamilyCommand As RelayCommand

        ' Konstruktor
        Public Sub New()
            ItalicCommand = New RelayCommand(AddressOf SetItalic)
            BoldCommand = New RelayCommand(AddressOf SetBold)
            NormalCommand = New RelayCommand(AddressOf SetNormal)
            ChangeFontSizeCommand = New RelayCommand(AddressOf ChangeFontSize)
            ChangeFontFamilyCommand = New RelayCommand(AddressOf ChangeFontFamily)
        End Sub

        ' Methoden zur Textformatierung
        Private Sub SetItalic(parameter As Object)
            Dim richTextBox = CType(parameter, RichTextBox)
            richTextBox.SelectionFont = New Font(richTextBox.SelectionFont, FontStyle.Italic)
        End Sub

        Private Sub SetBold(parameter As Object)
            Dim richTextBox = CType(parameter, RichTextBox)
            richTextBox.SelectionFont = New Font(richTextBox.SelectionFont, FontStyle.Bold)
        End Sub

        Private Sub SetNormal(parameter As Object)
            Dim richTextBox = CType(parameter, RichTextBox)
            richTextBox.SelectionFont = New Font(richTextBox.SelectionFont, FontStyle.Regular)
        End Sub

        Private Sub ChangeFontSize(parameter As Object)
            Dim parameters = CType(parameter, Tuple(Of RichTextBox, Single))
            Dim richTextBox = parameters.Item1
            Dim fontSize = parameters.Item2
            richTextBox.SelectionFont = New Font(richTextBox.SelectionFont.FontFamily, fontSize)
        End Sub

        Private Sub ChangeFontFamily(parameter As Object)
            Dim parameters = CType(parameter, Tuple(Of RichTextBox, String))
            Dim richTextBox = parameters.Item1
            Dim fontFamily = parameters.Item2
            richTextBox.SelectionFont = New Font(fontFamily, richTextBox.SelectionFont.Size)
        End Sub
    End Class
End Namespace
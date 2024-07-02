Imports System.IO
Imports System.Xml.Serialization
Imports TempAzubiBerichtsheft.TempAzubiBerichtsheft.Models

Namespace TempAzubiBerichtsheft.Data

    Public Class AusbildungsberichtRepository
        Private Const DirectoryPath As String = "Data/Ausbildungsberichte"

        Public Sub New()
            If Not Directory.Exists(DirectoryPath) Then
                Directory.CreateDirectory(DirectoryPath)
            End If
        End Sub

        Public Function LoadBerichte(username As String) As List(Of Ausbildungsbericht)
            Dim filePath As String = Path.Combine(DirectoryPath, $"{username}.xml")
            If Not File.Exists(filePath) Then
                Return New List(Of Ausbildungsbericht)()
            End If

            Dim serializer As New XmlSerializer(GetType(List(Of Ausbildungsbericht)))
            Using reader As New StreamReader(filePath)
                Return CType(serializer.Deserialize(reader), List(Of Ausbildungsbericht))
            End Using
        End Function

        Public Sub SaveBerichte(username As String, berichte As List(Of Ausbildungsbericht))
            Dim filePath As String = Path.Combine(DirectoryPath, $"{username}.xml")
            Dim serializer As New XmlSerializer(GetType(List(Of Ausbildungsbericht)))
            Using writer As New StreamWriter(filePath)
                serializer.Serialize(writer, berichte)
            End Using
        End Sub

    End Class
End Namespace

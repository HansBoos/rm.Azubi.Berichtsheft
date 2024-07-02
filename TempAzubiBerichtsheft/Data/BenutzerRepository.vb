Imports System.Xml.Serialization
Imports System.IO
Imports System
Imports TempAzubiBerichtsheft.TempAzubiBerichtsheft.Models

Public Class BenutzerRepository
    Private ReadOnly filePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "benutzer.xml")

    Public Sub New()
        ' Sicherstellen, dass der Ordner existiert
        Dim directory As String = Path.GetDirectoryName(filePath)

        If Not IO.Directory.Exists(directory) Then
            IO.Directory.CreateDirectory(directory)
        End If
    End Sub

    Public Sub SaveBenutzer(benutzerList As List(Of Benutzer))
        Dim serializer As New XmlSerializer(GetType(List(Of Benutzer)))
        Using writer As New StreamWriter(filePath)
            serializer.Serialize(writer, benutzerList)
        End Using
    End Sub

    Public Function LoadBenutzer() As List(Of Benutzer)
        If Not File.Exists(filePath) Then
            Return New List(Of Benutzer)()
        End If

        Dim serializer As New XmlSerializer(GetType(List(Of Benutzer)))
        Using reader As New StreamReader(filePath)
            Return CType(serializer.Deserialize(reader), List(Of Benutzer))
        End Using
    End Function
End Class

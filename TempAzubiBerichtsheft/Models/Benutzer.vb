Namespace TempAzubiBerichtsheft.Models
    Public Class Benutzer
        Public Property BenutzerID As Integer
        Public Property Name As String
        Public Property Rolle As String
        Public Property LoginDaten As String

        Public Property PLZ As String

        Public Property Password As String

        Public Sub New()
        End Sub

        Public Sub New(benutzerID As Integer, name As String, rolle As String, loginDaten As String, password As String)
            Me.BenutzerID = benutzerID
            Me.Name = name
            Me.Rolle = rolle
            Me.LoginDaten = loginDaten
            Me.Password = password
        End Sub
    End Class
End Namespace

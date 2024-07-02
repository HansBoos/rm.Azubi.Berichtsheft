Namespace TempAzubiBerichtsheft.Models
    Public Class Ausbildungsbericht
        Public Property Datum As DateTime
        Public Property Bericht As String
        Public Property Woche As Integer

        Public Property Ausbildungsplatz As String
        Public Property Berufsschule As String

        Public Sub New()
        End Sub

        Public Sub New(datum As DateTime, bericht As String, woche As Integer, ausbildungsplatz As String, berufsschule As String)
            Me.Datum = datum
            Me.Bericht = bericht
            Me.Woche = woche
            Me.Ausbildungsplatz = ausbildungsplatz
            Me.Berufsschule = berufsschule
        End Sub

    End Class
End Namespace

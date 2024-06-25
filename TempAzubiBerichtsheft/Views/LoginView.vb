Imports System.Windows.Forms
Imports TempAzubiBerichtsheft.TempAzubiBerichtsheft.ViewModels

Namespace TempAzubiBerichtsheft.Views
    Public Class LoginView
        Inherits Form

        Private cboUsername As ComboBox
        Private txtPassword As TextBox
        Private btnLogin As Button
        Private lblMessage As Label

        Public Sub New()
            InitializeComponent()
            cboUsername.Text = "admin"

            txtPassword.Text = "password"

        End Sub

        Private Sub InitializeComponent()
            Me.Text = "Login"
            Me.Width = 400
            Me.Height = 200

            cboUsername = New ComboBox() With {.Left = 50, .Top = 20, .Width = 300}
            txtPassword = New TextBox() With {.Left = 50, .Top = 60, .Width = 300, .PasswordChar = "*"c}
            btnLogin = New Button() With {.Text = "Login", .Left = 150, .Top = 100, .Width = 100}
            lblMessage = New Label() With {.Left = 50, .Top = 140, .Width = 300}

            AddHandler btnLogin.Click, AddressOf Me.BtnLogin_Click

            Me.Controls.Add(cboUsername)
            Me.Controls.Add(txtPassword)
            Me.Controls.Add(btnLogin)
            Me.Controls.Add(lblMessage)
        End Sub

        Private Sub BtnLogin_Click(sender As Object, e As EventArgs)
            ' Beispielhafte Überprüfung der Anmeldedaten
            If cboUsername.Text = "admin" AndAlso txtPassword.Text = "password" Then
                ' Anmeldedaten korrekt, MainView anzeigen
                Dim mainViewModel As New MainViewModel()
                Dim mainView As New MainView(mainViewModel)
                mainView.Show()
                Me.Hide()
            Else
                lblMessage.Text = "Ungültiger Benutzername oder Passwort"
            End If
        End Sub
    End Class
End Namespace

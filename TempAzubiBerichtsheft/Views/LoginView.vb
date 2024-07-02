Imports System.Windows.Forms
Imports TempAzubiBerichtsheft.TempAzubiBerichtsheft.ViewModels
Imports TempAzubiBerichtsheft.TempAzubiBerichtsheft.Models
Imports TempAzubiBerichtsheft.BenutzerRepository
Imports DevExpress.XtraWaitForm
Imports System.Linq
Imports System.Collections
Imports ramicro7.ui
Imports System.Drawing
Imports System.IO

Namespace TempAzubiBerichtsheft.Views
    Public Class LoginView
        Inherits XPForm

        Private cboUsername As XPComboSimple 'ComboBox
        Private txtPassword As TextBox
        Private WithEvents btnLogin As Button
        Private abschluss As XPSAbschluss
        'Private lblMessage As Label

        Private benutzerRepository As BenutzerRepository
        Private benutzerList As List(Of Benutzer)

        Public Sub New()
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance)
            Dim runtime As ramicro7.common.ramain.RARuntime
            Try
                runtime = ramicro7.common.ramain.RARuntime.Instance
            Catch ex As Exception
                MessageBox.Show("Fehler beim Starten der RA-MICRO Runtime: " & ex.Message)
            End Try

            InitializeComponent()
            benutzerRepository = New BenutzerRepository()
            benutzerList = benutzerRepository.LoadBenutzer()
            PopulateUserComboBox()
        End Sub

        Private Sub PopulateUserComboBox()
            ' Annahme: Sie haben eine ComboBox namens userComboBox im Formular
            Me.cboUsername.Items.Clear()
            For Each benutzer In benutzerList
                cboUsername.Items.Add(benutzer.Name)
            Next
        End Sub

        Private Sub InitializeComponent()
            Me.Text = "Login"
            Me.Width = 400
            Me.Height = 200
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Text = "RA-MICRO Berichtsheft für Auszubildende"
            cboUsername = New XPComboSimple() With {.Left = 50, .Top = 60, .Width = 300}
            txtPassword = New TextBox() With {.Left = 50, .Top = 100, .Width = 300, .PasswordChar = "*"c}
            btnLogin = New Button() With {.Text = "Login", .Left = 100, .Top = 150, .Width = 200}
            abschluss = New XPSAbschluss() With {.Left = 50, .Top = 200, .Width = 300}
            abschluss.ButtonOKEnabled = False
            'lblMessage = New Label() With {.Left = 50, .Top = 140, .Width = 300}

            AddHandler abschluss.ButtonOKClick, AddressOf Me.btnLogin_Click
            AddHandler abschluss.ButtonAbbruchClick, AddressOf Me.Close
            AddHandler cboUsername.TextChanged, AddressOf Me.cboUsername_TextChanged

            Me.Controls.Add(cboUsername)
            Me.Controls.Add(txtPassword)
            Me.Controls.Add(abschluss)
            'Me.Controls.Add(lblMessage)
            Me.Icon = New Icon(GetResourcePath("Azubi-Berichtsheft_3216.ico"))
        End Sub

        Private Sub cboUsername_TextChanged(sender As Object, e As EventArgs)
            Dim username As String = cboUsername.Text
            Dim user = benutzerList.FirstOrDefault(Function(b) b.Name = username)
            If user IsNot Nothing OrElse cboUsername.Text.Length > 0 Then
                abschluss.ButtonOKEnabled = True
            Else
                abschluss.ButtonOKEnabled = False
            End If
        End Sub

        Public Shared Function GetResourcePath(fileName As String) As String
            Dim basePath As String = AppDomain.CurrentDomain.BaseDirectory.Replace("\bin\Debug\net8.0-windows\", "")
            Dim resourcePath As String = Path.Combine(basePath, "Resourcen", fileName)
            Return resourcePath
        End Function

        Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
            Dim username As String = cboUsername.Text
            Dim password As String = txtPassword.Text

            If username = String.Empty Then

                Return
            End If

            Dim user = benutzerList.FirstOrDefault(Function(b) b.Name = username)

            If user IsNot Nothing Then
                'MessageBox.Show("Login erfolgreich!")
                Dim passwordMatch = benutzerList.FirstOrDefault(Function(b) b.Name = username AndAlso b.Password = password)
                If passwordMatch IsNot Nothing Then
                    Dim mainForm As New MainView(New MainViewModel(user))
                    mainForm.ShowDialog()
                    Me.Close()
                Else
                    MessageBox.Show("Passwort falsch!")
                    'Application.Exit()
                End If
            Else
                Dim result = MessageBox.Show("Benutzer nicht gefunden. Möchten Sie sich registrieren?", "Registrierung", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then
                    Dim registerForm As New RegisterView(username)
                    registerForm.ShowDialog()
                    benutzerList = benutzerRepository.LoadBenutzer() ' Benutzerdaten nach der Registrierung neu laden
                    PopulateUserComboBox()
                Else
                    MessageBox.Show("Login fehlgeschlagen!")
                End If
            End If
        End Sub



    End Class
End Namespace

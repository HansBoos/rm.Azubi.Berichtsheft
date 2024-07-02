Imports TempAzubiBerichtsheft.TempAzubiBerichtsheft.Models
Imports System.Windows.Forms
Imports ramicro7.ui
Imports System.IO
Imports System.Drawing
Imports TempAzubiBerichtsheft.TempAzubiBerichtsheft.ViewModels

Namespace TempAzubiBerichtsheft.Views
    Public Class RegisterView
        Inherits XPForm
        Private benutzerRepository As BenutzerRepository
        Private benutzerList As List(Of Benutzer)
        Private viewModel As RegisterViewModel

        Public Sub New(username As String)
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance)
            Dim runtime As ramicro7.common.ramain.RARuntime
            Try
                runtime = ramicro7.common.ramain.RARuntime.Instance
            Catch ex As Exception
                MessageBox.Show("Fehler beim Starten der RA-MICRO Runtime: " & ex.Message)
            End Try
            viewModel = New RegisterViewModel()
            InitializeComponent()
            benutzerRepository = New BenutzerRepository()
            benutzerList = benutzerRepository.LoadBenutzer()
            txtUsername.Text = username
        End Sub



        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            Dim username As String = txtUsername.Text
            Dim password As String = txtPassword.Text
            Dim confirmPassword As String = txtConfirmPassword.Text
            Dim role As String = If(rbRA.Checked, "RA-Fachangestellte/r", If(rbReno.Checked, "Reno-Fachangestellte/r", txtOtherRole.Text))
            Dim postalCode As String = "N/A" ' Placeholder, da es nicht im Screenshot gezeigt wird

            If password <> confirmPassword Then
                MessageBox.Show("Passwörter stimmen nicht überein!")
                Return
            End If

            If benutzerList.Any(Function(b) b.Name = username) Then
                MessageBox.Show("Benutzername bereits vergeben!")
            Else
                Dim newBenutzer As New Benutzer(0, username, password, role, password)
                benutzerList.Add(newBenutzer)
                benutzerRepository.SaveBenutzer(benutzerList)
                MessageBox.Show("Benutzer erfolgreich registriert!")
                Me.Close()
            End If
        End Sub

        Private Sub InitializeComponent()
            Me.txtUsername = New System.Windows.Forms.TextBox()
            Me.txtPassword = New System.Windows.Forms.TextBox()
            Me.txtConfirmPassword = New System.Windows.Forms.TextBox()
            Me.rbRA = New System.Windows.Forms.RadioButton()
            Me.rbReno = New System.Windows.Forms.RadioButton()
            Me.txtOtherRole = New System.Windows.Forms.TextBox()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.lblUsername = New System.Windows.Forms.Label()
            Me.lblPassword = New System.Windows.Forms.Label()
            Me.lblConfirmPassword = New System.Windows.Forms.Label()
            Me.lblRole = New System.Windows.Forms.Label()
            Me.lblPostalCode = New System.Windows.Forms.Label()
            Me.abschluss = New XPSAbschluss()
            Me.SuspendLayout()
            '
            'abschluss
            '
            Me.abschluss.Location = New System.Drawing.Point(12, 227)
            Me.abschluss.Name = "abschluss"
            Me.abschluss.Size = New System.Drawing.Size(200, 20)
            Me.abschluss.TabIndex = 7
            Me.abschluss.ButtonÜbernehmenVisible = True
            Me.abschluss.ButtonOKVisible = False
            Me.abschluss.ButtonCancelVisible = True
            AddHandler Me.abschluss.ButtonÜbernehmenClick, AddressOf Me.btnSave_Click
            AddHandler Me.abschluss.ButtonAbbruchClick, AddressOf Me.Close
            '
            'txtUsername
            '
            Me.txtUsername.Location = New System.Drawing.Point(12, 45)
            Me.txtUsername.Name = "txtUsername"
            Me.txtUsername.ReadOnly = True
            Me.txtUsername.Size = New System.Drawing.Size(200, 20)
            Me.txtUsername.TabIndex = 0
            '
            'txtPassword
            '
            Me.txtPassword.Location = New System.Drawing.Point(12, 84)
            Me.txtPassword.Name = "txtPassword"
            Me.txtPassword.PasswordChar = "*"c
            Me.txtPassword.Size = New System.Drawing.Size(200, 20)
            Me.txtPassword.TabIndex = 1
            '
            'txtConfirmPassword
            '
            Me.txtConfirmPassword.Location = New System.Drawing.Point(12, 123)
            Me.txtConfirmPassword.Name = "txtConfirmPassword"
            Me.txtConfirmPassword.PasswordChar = "*"c
            Me.txtConfirmPassword.Size = New System.Drawing.Size(200, 20)
            Me.txtConfirmPassword.TabIndex = 2
            '
            'rbRA
            '
            Me.rbRA.AutoSize = True
            Me.rbRA.Location = New System.Drawing.Point(12, 162)
            Me.rbRA.Name = "rbRA"
            Me.rbRA.Size = New System.Drawing.Size(120, 17)
            Me.rbRA.TabIndex = 3
            Me.rbRA.TabStop = True
            Me.rbRA.Text = "RA-Fachangestellte/r"
            Me.rbRA.UseVisualStyleBackColor = True
            '
            'rbReno
            '
            Me.rbReno.AutoSize = True
            Me.rbReno.Location = New System.Drawing.Point(12, 185)
            Me.rbReno.Name = "rbReno"
            Me.rbReno.Size = New System.Drawing.Size(126, 17)
            Me.rbReno.TabIndex = 4
            Me.rbReno.TabStop = True
            Me.rbReno.Text = "Reno-Fachangestellte/r"
            Me.rbReno.UseVisualStyleBackColor = True
            '
            'txtOtherRole
            '
            Me.txtOtherRole.Location = New System.Drawing.Point(12, 208)
            Me.txtOtherRole.Name = "txtOtherRole"
            Me.txtOtherRole.Size = New System.Drawing.Size(200, 20)
            Me.txtOtherRole.TabIndex = 5
            '
            'btnSave
            '
            Me.btnSave.Location = New System.Drawing.Point(12, 273)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(75, 23)
            Me.btnSave.TabIndex = 6
            Me.btnSave.Text = "Save"
            Me.btnSave.UseVisualStyleBackColor = True
            AddHandler Me.btnSave.Click, AddressOf Me.btnSave_Click
            '
            'lblUsername
            '
            Me.lblUsername.AutoSize = True
            Me.lblUsername.Location = New System.Drawing.Point(12, 29)
            Me.lblUsername.Name = "lblUsername"
            Me.lblUsername.Size = New System.Drawing.Size(75, 13)
            Me.lblUsername.TabIndex = 8
            Me.lblUsername.Text = "Benutzername"
            '
            'lblPassword
            '
            Me.lblPassword.AutoSize = True
            Me.lblPassword.Location = New System.Drawing.Point(12, 68)
            Me.lblPassword.Name = "lblPassword"
            Me.lblPassword.Size = New System.Drawing.Size(50, 13)
            Me.lblPassword.TabIndex = 9
            Me.lblPassword.Text = "Passwort"
            '
            'lblConfirmPassword
            '
            Me.lblConfirmPassword.AutoSize = True
            Me.lblConfirmPassword.Location = New System.Drawing.Point(12, 107)
            Me.lblConfirmPassword.Name = "lblConfirmPassword"
            Me.lblConfirmPassword.Size = New System.Drawing.Size(91, 13)
            Me.lblConfirmPassword.TabIndex = 10
            Me.lblConfirmPassword.Text = "Passwort bestätigen"
            '
            'lblRole
            '
            Me.lblRole.AutoSize = True
            Me.lblRole.Location = New System.Drawing.Point(12, 146)
            Me.lblRole.Name = "lblRole"
            Me.lblRole.Size = New System.Drawing.Size(33, 13)
            Me.lblRole.TabIndex = 11
            Me.lblRole.Text = "Rolle"
            '
            'lblPostalCode
            '
            Me.lblPostalCode.AutoSize = True
            Me.lblPostalCode.Location = New System.Drawing.Point(12, 231)
            Me.lblPostalCode.Name = "lblPostalCode"
            Me.lblPostalCode.Size = New System.Drawing.Size(62, 13)
            Me.lblPostalCode.TabIndex = 12
            Me.lblPostalCode.Text = "Postleitzahl"
            '
            'ViewRegister
            '
            Me.ClientSize = New System.Drawing.Size(300, 300)
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Controls.Add(Me.abschluss) 'Me.btnSave)
            Me.Controls.Add(Me.txtOtherRole)
            Me.Controls.Add(Me.rbReno)
            Me.Controls.Add(Me.rbRA)
            Me.Controls.Add(Me.txtConfirmPassword)
            Me.Controls.Add(Me.txtPassword)
            Me.Controls.Add(Me.txtUsername)
            Me.Controls.Add(Me.lblPostalCode)
            Me.Controls.Add(Me.lblRole)
            Me.Controls.Add(Me.lblConfirmPassword)
            Me.Controls.Add(Me.lblPassword)
            Me.Controls.Add(Me.lblUsername)
            Me.Name = "ViewRegister"
            Me.Icon = New Icon(viewModel.GetResourcePath("Azubi-Berichtsheft_3216.ico"))
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Private WithEvents txtUsername As System.Windows.Forms.TextBox
        Private WithEvents txtPassword As System.Windows.Forms.TextBox
        Private WithEvents txtConfirmPassword As System.Windows.Forms.TextBox
        Private WithEvents rbRA As System.Windows.Forms.RadioButton
        Private WithEvents rbReno As System.Windows.Forms.RadioButton
        Private WithEvents txtOtherRole As System.Windows.Forms.TextBox
        Private WithEvents btnSave As System.Windows.Forms.Button
        Private WithEvents abschluss As XPSAbschluss
        Private lblUsername As System.Windows.Forms.Label
        Private lblPassword As System.Windows.Forms.Label
        Private lblConfirmPassword As System.Windows.Forms.Label
        Private lblRole As System.Windows.Forms.Label
        Private lblPostalCode As System.Windows.Forms.Label
    End Class
End Namespace
Imports System.Windows.Forms
Imports TempAzubiBerichtsheft.TempAzubiBerichtsheft.ViewModels
Imports TempAzubiBerichtsheft.ViewModels
Imports System.Drawing
Imports pdftron



Public Class MainView
    Inherits Form

    Private components As System.ComponentModel.IContainer
    Private WithEvents btnLoad As Button
    Private WithEvents btnSave As Button
    Private WithEvents btnSend As Button
    Private comboBoxRole As ComboBox
    Private comboBoxYear As ComboBox
    Private comboBoxWeek As ComboBox
    Private textBoxName As TextBox
    Private panelLeft As Panel
    Private panelMiddle As Panel
    Private panelRight As Panel
    Private labelRole As Label
    Private labelYear As Label
    Private labelWeek As Label
    Private labelName As Label
    Private pdfViewCtrl As pdftron.PDF.PDFViewCtrl


    Private ReadOnly _viewModel As MainViewModel

    Public Sub New(viewModel As MainViewModel)
        _viewModel = viewModel
        InitializeComponent()
        ' PDFTron Lizenzschlüssel initialisieren
        Try
            pdftron.PDFNet.Initialize("RA MICRO GmbH and Co KGaA:OEM:See Agreement::W:AMS(20260616):08774AF01FE70F8F9EABC8E5E6614F8B5C700A7B2C1CACF2AFCF8B6DD33131F5C7")
            Dim doc As New PDF.PDFDoc("C:\Users\Public\Documents\alterhut.pdf")
            pdfViewCtrl = New PDF.PDFViewCtrl()
            pdfViewCtrl.Dock = DockStyle.Fill
            panelLeft.Controls.Add(pdfViewCtrl)
            Me.Controls.Add(panelLeft)
            pdfViewCtrl.SetDoc(doc)

        Catch ex As Exception
            MessageBox.Show($"Fehler bei der Initialisierung von PDFTron: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub InitializeComponent()
        Me.btnLoad = New Button()
        Me.btnSave = New Button()
        Me.btnSend = New Button()
        Me.comboBoxRole = New ComboBox()
        Me.comboBoxYear = New ComboBox()
        Me.comboBoxWeek = New ComboBox()
        Me.textBoxName = New TextBox()
        Me.panelLeft = New Panel()
        Me.panelMiddle = New Panel()
        Me.panelRight = New Panel()
        Me.labelRole = New Label()
        Me.labelYear = New Label()
        Me.labelWeek = New Label()
        Me.labelName = New Label()
        'Me.pdfViewCtrl = New pdftron.PDF.PDFViewCtrl()
        Me.SuspendLayout()
        '
        ' pdfViewCtrl
        '
        'Me.pdfViewCtrl.Dock = DockStyle.Fill
        'Me.pdfViewCtrl.Location = New Point(0, 0)
        'Me.pdfViewCtrl.Name = "pdfViewCtrl"
        'Me.pdfViewCtrl.Size = New Size(250, 500)
        'Me.pdfViewCtrl.TabIndex = 14



        '
        ' btnLoad
        '
        Me.btnLoad.Anchor = AnchorStyles.Top
        Me.btnLoad.Location = New Point(670, 10)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New Size(50, 23)
        Me.btnLoad.TabIndex = 8
        Me.btnLoad.Text = "Laden"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        ' btnSave
        '
        Me.btnSave.Anchor = AnchorStyles.Top
        Me.btnSave.Location = New Point(730, 10)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New Size(50, 23)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Speichern"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        ' btnSend
        '
        Me.btnSend.Anchor = AnchorStyles.Top
        Me.btnSend.Location = New Point(790, 10)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New Size(50, 23)
        Me.btnSend.TabIndex = 10
        Me.btnSend.Text = "Senden"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        ' comboBoxRole
        '
        Me.comboBoxRole.Anchor = AnchorStyles.Top
        Me.comboBoxRole.Location = New Point(123, 11)
        Me.comboBoxRole.Name = "comboBoxRole"
        Me.comboBoxRole.Size = New Size(121, 23)
        Me.comboBoxRole.TabIndex = 11
        '
        ' comboBoxYear
        '
        Me.comboBoxYear.Anchor = AnchorStyles.Top
        Me.comboBoxYear.FormattingEnabled = True
        Me.comboBoxYear.Location = New Point(250, 10)
        Me.comboBoxYear.Name = "comboBoxYear"
        Me.comboBoxYear.Size = New Size(121, 23)
        Me.comboBoxYear.TabIndex = 1
        '
        ' comboBoxWeek
        '
        Me.comboBoxWeek.Anchor = AnchorStyles.Top
        Me.comboBoxWeek.FormattingEnabled = True
        Me.comboBoxWeek.Location = New Point(380, 10)
        Me.comboBoxWeek.Name = "comboBoxWeek"
        Me.comboBoxWeek.Size = New Size(121, 23)
        Me.comboBoxWeek.TabIndex = 2
        '
        ' textBoxName
        '
        Me.textBoxName.Anchor = AnchorStyles.Top
        Me.textBoxName.Location = New Point(510, 10)
        Me.textBoxName.Name = "textBoxName"
        Me.textBoxName.Size = New Size(150, 23)
        Me.textBoxName.TabIndex = 3
        '
        ' panelLeft
        '
        Me.panelLeft.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Me.panelLeft.BorderStyle = BorderStyle.FixedSingle
        Me.panelLeft.Location = New Point(12, 50)
        Me.panelLeft.Name = "panelLeft"
        Me.panelLeft.Size = New Size(250, 500)
        Me.panelLeft.TabIndex = 11
        '
        ' panelMiddle
        '
        Me.panelMiddle.Anchor = AnchorStyles.Bottom
        Me.panelMiddle.BorderStyle = BorderStyle.FixedSingle
        Me.panelMiddle.Location = New Point(286, 50)
        Me.panelMiddle.Name = "panelMiddle"
        Me.panelMiddle.Size = New Size(280, 500)
        Me.panelMiddle.TabIndex = 12
        '
        ' panelRight
        '
        Me.panelRight.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        Me.panelRight.BorderStyle = BorderStyle.FixedSingle
        Me.panelRight.Location = New Point(590, 50)
        Me.panelRight.Name = "panelRight"
        Me.panelRight.Size = New Size(250, 500)
        Me.panelRight.TabIndex = 13
        '
        ' labelRole
        '
        Me.labelRole.Anchor = AnchorStyles.Top
        Me.labelRole.AutoSize = True
        Me.labelRole.Location = New Point(12, 18)
        Me.labelRole.Name = "labelRole"
        Me.labelRole.Size = New Size(94, 15)
        Me.labelRole.TabIndex = 4
        Me.labelRole.Text = "Auszubildende/r"
        '
        ' labelYear
        '
        Me.labelYear.AutoSize = True
        Me.labelYear.Location = New Point(250, 13)
        Me.labelYear.Name = "labelYear"
        Me.labelYear.Size = New Size(28, 15)
        Me.labelYear.TabIndex = 5
        Me.labelYear.Text = "Jahr"
        '
        ' labelWeek
        '
        Me.labelWeek.AutoSize = True
        Me.labelWeek.Location = New Point(380, 13)
        Me.labelWeek.Name = "labelWeek"
        Me.labelWeek.Size = New Size(25, 15)
        Me.labelWeek.TabIndex = 6
        Me.labelWeek.Text = "KW"
        '
        ' labelName
        '
        Me.labelName.AutoSize = True
        Me.labelName.Location = New Point(510, 13)
        Me.labelName.Name = "labelName"
        Me.labelName.Size = New Size(100, 15)
        Me.labelName.TabIndex = 7
        Me.labelName.Text = "Vor- und Zuname"
        '
        ' MainView
        '
        Me.AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(859, 560)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.comboBoxRole)
        Me.Controls.Add(Me.comboBoxYear)
        Me.Controls.Add(Me.comboBoxWeek)
        Me.Controls.Add(Me.textBoxName)
        Me.Controls.Add(Me.panelLeft)
        Me.Controls.Add(Me.panelMiddle)
        Me.Controls.Add(Me.panelRight)
        Me.Controls.Add(Me.labelRole)
        Me.Controls.Add(Me.labelYear)
        Me.Controls.Add(Me.labelWeek)
        Me.Controls.Add(Me.labelName)
        Me.panelLeft.Controls.Add(Me.pdfViewCtrl)
        Me.Name = "MainView"
        Me.Text = "RA-MICRO Cockpit Berichtsheft"
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class

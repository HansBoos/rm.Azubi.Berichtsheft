Imports System.Windows.Forms
Imports DevExpress.XtraPdfViewer
Imports TempAzubiBerichtsheft.ViewModels
Imports System.Drawing
Imports TempAzubiBerichtsheft.TempAzubiBerichtsheft.ViewModels

Namespace TempAzubiBerichtsheft.Views
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
        'Private panelLeft As Panel
        'Private panelMiddle As Panel
        'Private panelRight As Panel
        Private labelRole As Label
        Private labelYear As Label
        Private labelWeek As Label
        Private labelName As Label
        Private pdfViewer As PdfViewer
        Private richTextEditor As RichTextBox

        Private ReadOnly _viewModel As MainViewModel

        Private tlpPanel As TableLayoutPanel

        Public Sub New(viewModel As MainViewModel)
            _viewModel = viewModel
            InitializeComponent()

            ' PDF Viewer Initialisierung
            'pdfViewer = New PdfViewer()
            'pdfViewer.Dock = DockStyle.Fill
            'tlpPanel.Controls.Add(pdfViewer, 0, 0)
        End Sub

        ' Initialisieren Sie die Komponenten des Formulars
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.tlpPanel = New TableLayoutPanel()

            Me.btnLoad = New Button()
            Me.btnSave = New Button()
            Me.btnSend = New Button()
            Me.comboBoxRole = New ComboBox()
            Me.comboBoxYear = New ComboBox()
            Me.comboBoxWeek = New ComboBox()
            Me.textBoxName = New TextBox()
            'Me.panelLeft = New Panel()
            'Me.panelMiddle = New Panel()
            'Me.panelRight = New Panel()
            Me.labelRole = New Label()
            Me.labelYear = New Label()
            Me.labelWeek = New Label()
            Me.labelName = New Label()
            Me.pdfViewer = New PdfViewer()
            Me.richTextEditor = New RichTextBox()
            Me.SuspendLayout()
            '
            ' tlpPanel
            '
            Me.tlpPanel.ColumnCount = 3
            Me.tlpPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33333!))
            Me.tlpPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33333!))
            Me.tlpPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33333!))
            Me.tlpPanel.Location = New Point(12, 50)
            Me.tlpPanel.Name = "tlpPanel"
            Me.tlpPanel.RowCount = 1
            Me.tlpPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0!))
            Me.tlpPanel.Size = New Size(828, 500)
            Me.tlpPanel.TabIndex = 0
            Me.tlpPanel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
            '
            ' btnLoad
            '
            Me.btnLoad.Anchor = AnchorStyles.Top
            Me.btnLoad.Location = New Point(670, 10)
            Me.btnLoad.Name = "btnLoad"
            Me.btnLoad.Size = New Size(50, 23)
            Me.btnLoad.TabIndex = 8
            Me.btnLoad.Text = "Load"
            Me.btnLoad.UseVisualStyleBackColor = True
            AddHandler Me.btnLoad.Click, AddressOf Me.btnLoad_Click
            '
            ' btnSave
            '
            Me.btnSave.Anchor = AnchorStyles.Top
            Me.btnSave.Location = New Point(730, 10)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New Size(50, 23)
            Me.btnSave.TabIndex = 9
            Me.btnSave.Text = "Save"
            Me.btnSave.UseVisualStyleBackColor = True
            AddHandler Me.btnSave.Click, AddressOf Me.btnSave_Click
            '
            ' btnSend
            '
            Me.btnSend.Anchor = AnchorStyles.Top
            Me.btnSend.Location = New Point(790, 10)
            Me.btnSend.Name = "btnSend"
            Me.btnSend.Size = New Size(50, 23)
            Me.btnSend.TabIndex = 10
            Me.btnSend.Text = "Send"
            Me.btnSend.UseVisualStyleBackColor = True
            AddHandler Me.btnSend.Click, AddressOf Me.btnSend_Click
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
            'Me.panelLeft.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Top
            'Me.panelLeft.BorderStyle = BorderStyle.FixedSingle
            'Me.panelLeft.Location = New Point(12, 50)
            'Me.panelLeft.Name = "panelLeft"
            'Me.panelLeft.Size = New Size(250, 500)
            'Me.panelLeft.TabIndex = 11
            ''
            '' panelMiddle
            ''
            'Me.panelMiddle.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top
            'Me.panelMiddle.BorderStyle = BorderStyle.FixedSingle
            'Me.panelMiddle.Location = New Point(286, 50)
            'Me.panelMiddle.Name = "panelMiddle"
            'Me.panelMiddle.Size = New Size(280, 500)
            'Me.panelMiddle.TabIndex = 12
            ''
            '' panelRight
            ''
            'Me.panelRight.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right Or AnchorStyles.Top
            'Me.panelRight.BorderStyle = BorderStyle.FixedSingle
            'Me.panelRight.Location = New Point(590, 50)
            'Me.panelRight.Name = "panelRight"
            'Me.panelRight.Size = New Size(250, 500)
            'Me.panelRight.TabIndex = 13
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
            ' pdfViewer
            '
            Me.pdfViewer.Dock = DockStyle.Fill
            Me.pdfViewer.Location = New Point(0, 0)
            Me.pdfViewer.Name = "pdfViewer"
            Me.pdfViewer.Size = New Size(250, 500)
            Me.pdfViewer.TabIndex = 14
            '
            ' richTextEditor
            '
            Me.richTextEditor.Dock = DockStyle.Fill
            Me.richTextEditor.Location = New Point(0, 0)
            Me.richTextEditor.Name = "richTextEditor"
            Me.richTextEditor.Size = New Size(280, 500)
            Me.richTextEditor.TabIndex = 15
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
            'Me.Controls.Add(Me.panelLeft)
            'Me.Controls.Add(Me.panelMiddle)
            'Me.Controls.Add(Me.panelRight)
            Me.Controls.Add(Me.tlpPanel)
            Me.Controls.Add(Me.labelRole)
            Me.Controls.Add(Me.labelYear)
            Me.Controls.Add(Me.labelWeek)
            Me.Controls.Add(Me.labelName)
            Me.tlpPanel.Controls.Add(pdfViewer, 0, 0)
            Me.tlpPanel.Controls.Add(richTextEditor, 1, 0)
            'Me.panelLeft.Controls.Add(Me.pdfViewer)
            'Me.panelMiddle.Controls.Add(Me.richTextEditor)
            Me.Name = "MainView"
            Me.Text = "RA-MICRO Cockpit Berichtsheft"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        ' Event-Handler für die Buttons
        Private Sub btnLoad_Click(sender As Object, e As EventArgs)
            Try
                pdfViewer.LoadDocument("path_to_pdf_file.pdf")
                MessageBox.Show("PDF-Dokument erfolgreich geladen")
            Catch ex As Exception
                MessageBox.Show("Fehler beim Laden des PDF-Dokuments: " & ex.Message)
            End Try
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs)
            Try
                pdfViewer.SaveDocument("path_to_save_pdf_file.pdf")
                MessageBox.Show("PDF-Dokument erfolgreich gespeichert")
            Catch ex As Exception
                MessageBox.Show("Fehler beim Speichern des PDF-Dokuments: " & ex.Message)
            End Try
        End Sub

        Private Sub btnSend_Click(sender As Object, e As EventArgs)
            ' Beispielhafter Code zum Senden des PDF-Dokuments
            MessageBox.Show("PDF-Dokument erfolgreich gesendet")
        End Sub

        Private Sub MainView_Closed(sender As Object, e As EventArgs) Handles Me.Closed
            Application.Exit()

        End Sub
    End Class
End Namespace


Imports System.Windows.Forms
Imports DevExpress.XtraPdfViewer
Imports TempAzubiBerichtsheft.ViewModels
Imports System.Drawing
Imports TempAzubiBerichtsheft.TempAzubiBerichtsheft.ViewModels
Imports System.IO

Namespace TempAzubiBerichtsheft.Views
    Public Class MainView
        Inherits Form

        Private components As System.ComponentModel.IContainer
        Private WithEvents btnLoad As Button
        Private WithEvents btnSave As Button
        Private WithEvents btnSend As Button
        Private WithEvents btnClose As Button
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
        Private pdfViewerRahmen As PdfViewer
        Private pdfViewerAusbildungsNachweis As PdfViewer
        Private richTextEditor As RichTextBox
        Private fontComboBox As ComboBox
        Private fontSizeNumericUpDown As NumericUpDown
        Private colorPickerButton As Button
        Private boldButton As Button
        Private italicButton As Button
        Private normalButton As Button
        Private ReadOnly _viewModel As MainViewModel

        Private tlpPanel As TableLayoutPanel
        Private tlpRichtext As TableLayoutPanel

        Dim pfadZurVorlage1 As String = GetResourcePath("Berufsausbild_Rahmenplan.pdf")
        Dim pfadZurVorlage2 As String = GetResourcePath("Ausbildungsnachweis.pdf")

        Public Sub New(viewModel As MainViewModel)
            _viewModel = viewModel
            InitializeComponent()

            pdfViewerRahmen.LoadDocument(pfadZurVorlage1)
            pdfViewerAusbildungsNachweis.LoadDocument(pfadZurVorlage2)
            ' PDF Viewer Initialisierung
            'pdfViewer = New PdfViewer()
            'pdfViewer.Dock = DockStyle.Fill
            'tlpPanel.Controls.Add(pdfViewer, 0, 0)
        End Sub



        Public Shared Function GetResourcePath(fileName As String) As String
            Dim basePath As String = AppDomain.CurrentDomain.BaseDirectory.Replace("\bin\Debug\net8.0-windows\", "")
            Dim resourcePath As String = Path.Combine(basePath, "Resourcen", fileName)
            Return resourcePath
        End Function


        ' Initialisieren Sie die Komponenten des Formulars
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.tlpPanel = New TableLayoutPanel()
            Me.tlpRichtext = New TableLayoutPanel()
            Me.btnLoad = New Button()
            Me.btnSave = New Button()
            Me.btnSend = New Button()
            Me.btnClose = New Button()
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
            Me.pdfViewerRahmen = New PdfViewer()
            Me.pdfViewerAusbildungsNachweis = New PdfViewer()
            Me.richTextEditor = New RichTextBox()
            Me.fontComboBox = New ComboBox()
            Me.fontSizeNumericUpDown = New NumericUpDown()
            Me.colorPickerButton = New Button()
            Me.boldButton = New Button()
            Me.italicButton = New Button()
            Me.normalButton = New Button()

            Me.SuspendLayout()

            '
            ' tlpRichtext
            '
            Me.tlpRichtext.ColumnCount = 6
            Me.tlpRichtext.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20.0!))
            Me.tlpRichtext.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20.0!))
            Me.tlpRichtext.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20.0!))
            Me.tlpRichtext.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20.0!))
            Me.tlpRichtext.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20.0!))
            Me.tlpRichtext.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20.0!))
            Me.tlpRichtext.Location = New Point(590, 50)
            Me.tlpRichtext.Name = "tlpRichtext"
            Me.tlpRichtext.RowCount = 2
            Me.tlpRichtext.RowStyles.Add(New RowStyle(SizeType.Absolute, 40.0!))
            Me.tlpRichtext.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0!))
            Me.tlpRichtext.Size = New Size(250, 500)
            Me.tlpRichtext.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
            Me.tlpRichtext.Controls.Add(fontComboBox, 0, 0)
            Me.tlpRichtext.Controls.Add(fontSizeNumericUpDown, 1, 0)
            Me.tlpRichtext.Controls.Add(colorPickerButton, 2, 0)
            Me.tlpRichtext.Controls.Add(boldButton, 3, 0)
            Me.tlpRichtext.Controls.Add(italicButton, 4, 0)
            Me.tlpRichtext.Controls.Add(normalButton, 5, 0)
            Me.tlpRichtext.Controls.Add(richTextEditor, 0, 1)
            Me.tlpRichtext.SetColumnSpan(richTextEditor, 6)
            Me.tlpRichtext.Dock = DockStyle.Fill
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
            ' btnClose
            '
            Me.btnClose.Anchor = AnchorStyles.Top
            Me.btnClose.Location = New Point(850, 10)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New Size(50, 23)
            Me.btnClose.TabIndex = 11
            Me.btnClose.Text = "Close"
            Me.btnClose.UseVisualStyleBackColor = True
            AddHandler Me.btnClose.Click, AddressOf Me.btnClose_Click
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
            ' pdfViewerRahmen
            '
            Me.pdfViewerRahmen.Dock = DockStyle.Fill
            Me.pdfViewerRahmen.Location = New Point(0, 0)
            Me.pdfViewerRahmen.Name = "pdfViewer"
            Me.pdfViewerRahmen.Size = New Size(250, 500)
            Me.pdfViewerRahmen.TabIndex = 14
            Me.pdfViewerRahmen.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.FitToWidth
            '
            ' pdfViewerAusbildungsNachweis
            '
            Me.pdfViewerAusbildungsNachweis.Dock = DockStyle.Fill
            Me.pdfViewerAusbildungsNachweis.Location = New Point(0, 0)
            Me.pdfViewerAusbildungsNachweis.Name = "pdfViewer"
            Me.pdfViewerAusbildungsNachweis.Size = New Size(250, 500)
            Me.pdfViewerAusbildungsNachweis.TabIndex = 15
            Me.pdfViewerAusbildungsNachweis.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.FitToWidth
            ' fontComboBox
            Me.fontComboBox.Location = New Point(12, 50)
            Me.fontComboBox.Name = "fontComboBox"
            Me.fontComboBox.Size = New Size(121, 23)
            Me.fontComboBox.TabIndex = 16
            Me.fontComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            Me.fontComboBox.Dock = DockStyle.Fill
            For Each font As FontFamily In FontFamily.Families
                Me.fontComboBox.Items.Add(font.Name)
            Next
            AddHandler Me.fontComboBox.SelectedIndexChanged, AddressOf Me.fontComboBox_SelectedIndexChanged

            ' fontSizeNumericUpDown
            Me.fontSizeNumericUpDown.Location = New Point(140, 50)
            Me.fontSizeNumericUpDown.Name = "fontSizeNumericUpDown"
            Me.fontSizeNumericUpDown.Size = New Size(50, 23)
            Me.fontSizeNumericUpDown.TabIndex = 17
            Me.fontSizeNumericUpDown.Minimum = 8
            Me.fontSizeNumericUpDown.Maximum = 72
            Me.fontSizeNumericUpDown.Dock = DockStyle.Fill
            AddHandler Me.fontSizeNumericUpDown.ValueChanged, AddressOf Me.fontSizeNumericUpDown_ValueChanged

            ' colorPickerButton
            Me.colorPickerButton.Location = New Point(200, 50)
            Me.colorPickerButton.Name = "colorPickerButton"
            Me.colorPickerButton.Size = New Size(75, 23)
            Me.colorPickerButton.TabIndex = 18
            Me.colorPickerButton.Text = "Color"
            Me.colorPickerButton.UseVisualStyleBackColor = True
            Me.colorPickerButton.Dock = DockStyle.Fill
            AddHandler Me.colorPickerButton.Click, AddressOf Me.colorPickerButton_Click
            ' boldButton
            Me.boldButton.Location = New Point(280, 50)
            Me.boldButton.Name = "boldButton"
            Me.boldButton.Size = New Size(35, 23)
            Me.boldButton.TabIndex = 19
            Me.boldButton.Text = "B"
            Me.boldButton.Font = New Font(Me.boldButton.Font, FontStyle.Bold)
            Me.boldButton.UseVisualStyleBackColor = True
            Me.boldButton.Dock = DockStyle.Fill
            AddHandler Me.boldButton.Click, AddressOf Me.boldButton_Click
            '
            ' italicButton
            '
            Me.italicButton.Location = New Point(320, 50)
            Me.italicButton.Name = "italicButton"
            Me.italicButton.Size = New Size(35, 23)
            Me.italicButton.TabIndex = 20
            Me.italicButton.Text = "I"
            Me.italicButton.Font = New Font(Me.italicButton.Font, FontStyle.Italic)
            Me.italicButton.UseVisualStyleBackColor = True
            Me.italicButton.Dock = DockStyle.Fill
            AddHandler Me.italicButton.Click, AddressOf Me.italicButton_Click
            '
            ' normalButton
            '
            Me.normalButton.Location = New Point(360, 50)
            Me.normalButton.Name = "normalButton"
            Me.normalButton.Size = New Size(35, 23)
            Me.normalButton.TabIndex = 21
            Me.normalButton.Text = "N"
            Me.normalButton.Font = New Font(Me.normalButton.Font, FontStyle.Regular)
            Me.normalButton.UseVisualStyleBackColor = True
            Me.normalButton.Dock = DockStyle.Fill
            AddHandler Me.normalButton.Click, AddressOf Me.normalButton_Click

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
            Me.Controls.Add(Me.btnClose)
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
            Me.tlpPanel.Controls.Add(pdfViewerRahmen, 0, 0)
            Me.tlpPanel.Controls.Add(pdfViewerAusbildungsNachweis, 1, 0)
            Me.tlpPanel.Controls.Add(tlpRichtext, 2, 0)
            'Me.panelLeft.Controls.Add(Me.pdfViewer)
            'Me.panelMiddle.Controls.Add(Me.richTextEditor)
            Me.Name = "MainView"
            Me.Text = "RA-MICRO Cockpit Berichtsheft"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Private Sub btnClose_Click(sender As Object, e As EventArgs)
            Me.Close()
        End Sub

        Private Sub normalButton_Click(obj As Object, e As EventArgs)
            Dim currentFont As Font = richTextEditor.SelectionFont
            Dim newFontStyle As FontStyle = FontStyle.Regular
            richTextEditor.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
        End Sub

        Private Sub italicButton_Click(obj As Object, e As EventArgs)
            Dim currentFont As Font = richTextEditor.SelectionFont
            Dim newFontStyle As FontStyle

            If currentFont.Italic = True Then
                newFontStyle = FontStyle.Regular
            Else
                newFontStyle = FontStyle.Italic
            End If

            richTextEditor.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
        End Sub

        Private Sub fontSizeNumericUpDown_ValueChanged(obj As Object, e As EventArgs)
            Dim currentFont As Font = richTextEditor.SelectionFont
            richTextEditor.SelectionFont = New Font(currentFont.FontFamily, fontSizeNumericUpDown.Value, currentFont.Style)
        End Sub
        Private Sub colorPickerButton_Click(sender As Object, e As EventArgs)
            Dim colorDialog As New ColorDialog()
            If colorDialog.ShowDialog() = DialogResult.OK Then
                richTextEditor.SelectionColor = colorDialog.Color
            End If
        End Sub

        Private Sub fontComboBox_SelectedIndexChanged(obj As Object, e As EventArgs)
            Dim currentFont As Font = richTextEditor.SelectionFont
            Dim newFontFamily As FontFamily = New FontFamily(fontComboBox.SelectedItem.ToString())
            richTextEditor.SelectionFont = New Font(newFontFamily, currentFont.Size, currentFont.Style)
        End Sub

        Private Sub boldButton_Click(sender As Object, e As EventArgs)
            Dim currentFont As Font = richTextEditor.SelectionFont
            Dim newFontStyle As FontStyle

            If currentFont.Bold = True Then
                newFontStyle = FontStyle.Regular
            Else
                newFontStyle = FontStyle.Bold
            End If

            richTextEditor.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
        End Sub

        ' Event-Handler für die Buttons
        Private Sub btnLoad_Click(sender As Object, e As EventArgs)
            Try
                Dim openFileDialog As New OpenFileDialog()
                openFileDialog.Filter = "PDF-Dateien|*.pdf"
                openFileDialog.Title = "PDF-Datei öffnen"
                If openFileDialog.ShowDialog() = DialogResult.OK Then
                    pdfViewerAusbildungsNachweis.LoadDocument(openFileDialog.FileName)
                    MessageBox.Show("PDF-Dokument erfolgreich geladen")
                End If

            Catch ex As Exception
                MessageBox.Show("Fehler beim Laden des PDF-Dokuments: " & ex.Message)
            End Try
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs)
            Try
                'pdfViewer.SaveDocument("path_to_save_pdf_file.pdf")
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

        Private Sub MainView_Load(sender As Object, e As EventArgs) Handles Me.Load
            fontComboBox.Text = "Segoe UI"
            fontSizeNumericUpDown.Value = 12

        End Sub
    End Class
End Namespace


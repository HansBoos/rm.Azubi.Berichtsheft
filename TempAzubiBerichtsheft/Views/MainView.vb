Imports System.Windows.Forms
Imports DevExpress.XtraPdfViewer
Imports TempAzubiBerichtsheft.ViewModels
Imports System.Drawing
Imports TempAzubiBerichtsheft.TempAzubiBerichtsheft.ViewModels
Imports System.IO
Imports rm.ChatGPTiumViewerEditor
Imports System.Runtime.InteropServices
Imports TempAzubiBerichtsheft.TempAzubiBerichtsheft.Models
Imports System.Collections.Generic
Imports TempAzubiBerichtsheft.TempAzubiBerichtsheft.Data
Imports ramicro7.ui
Imports System.Text


Namespace TempAzubiBerichtsheft.Views
    Public Class MainView
        Inherits Form



        Private components As System.ComponentModel.IContainer

        Private pdfViewer As PdfViewerControl
        Private pdfEditor As PdfEditor

        Dim docOrigin As String
        Dim docDestination As String

        Private benutzerRepository As BenutzerRepository
        Private benutzerList As List(Of Benutzer)

        Private ausbildungsberichtRepository As AusbildungsberichtRepository
        Private berichte As List(Of Ausbildungsbericht)
        Private currentUSer As Benutzer
        Private labelYear As Label
        Private labelWeek As Label
        Private labelName As Label
        Private pdfViewerRahmen As rm.ChatGPTiumViewerEditor.PdfViewerControl 'As PdfViewer
        Private pdfViewerAusbildungsNachweis As rm.ChatGPTiumViewerEditor.PdfViewerControl 'As PdfViewer

        Private richTextAusbildungsplatz As RichTextBox
        Private richTextBerufsschule As RichTextBox
        Private btnItalicAusbildungsplatz As Button
        Private btnBoldAusbildungsplatz As Button
        Private btnNormalAusbildungsplatz As Button
        Private numFontSizeAusbildungsplatz As NumericUpDown
        Private cmbFontFamilyAusbildungsplatz As ComboBox
        Private colorPickerButtonAusbildungsplatz As Button

        Private btnItalicBerufsschule As Button
        Private btnBoldBerufsschule As Button
        Private btnNormalBerufsschule As Button
        Private numFontSizeBerufsschule As NumericUpDown
        Private cmbFontFamilyBerufsschule As ComboBox
        Private normalButton As Button
        Private colorPickerButtonBerufsschule As Button

        Private listBoxBerichte As System.Windows.Forms.ListBox
        Private treeViewBerichte As System.Windows.Forms.TreeView
        Private WithEvents abschluss As XPSAbschluss

        Private ReadOnly _viewModel As MainViewModel

        Private tlpPanel As TableLayoutPanel
        Private tlpRichtext As TableLayoutPanel

        Private pfadZurVorlage1 As String
        Private pfadZurVorlage2 As String



        Public Sub New(viewModel As MainViewModel)
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance)
            Dim runtime As ramicro7.common.ramain.RARuntime
            Try
                runtime = ramicro7.common.ramain.RARuntime.Instance
            Catch ex As Exception
                MessageBox.Show("Fehler beim Starten der RA-MICRO Runtime: " & ex.Message)
            End Try



            _viewModel = viewModel

            pfadZurVorlage1 = viewModel.GetResourcePath("Berufsausbild_Rahmenplan.pdf")
            pfadZurVorlage2 = viewModel.GetResourcePath("Ausbildungsnachweis.pdf")
            InitializeComponent()
            BindCommands(viewModel)
            DisplayBerichte()
            Me.labelName.Text = $"Benutzer: {_viewModel.Benutzer.Name }"
            Me.labelYear.Text = $"Jahr: {DateTime.Now.Year}"
            Me.labelWeek.Text = $"KW: {DatePart(DateInterval.WeekOfYear, Now)}"
        End Sub

        Private Sub BindCommands(viewModel As MainViewModel)
            ' Binden der Befehle an die Steuerelemente
            AddHandler btnItalicAusbildungsplatz.Click, Sub() viewModel.ItalicCommand.Execute(richTextAusbildungsplatz)
            AddHandler btnBoldAusbildungsplatz.Click, Sub() viewModel.BoldCommand.Execute(richTextAusbildungsplatz)
            AddHandler btnNormalAusbildungsplatz.Click, Sub() viewModel.NormalCommand.Execute(richTextAusbildungsplatz)
            AddHandler numFontSizeAusbildungsplatz.ValueChanged, Sub() viewModel.ChangeFontSizeCommand.Execute(New Tuple(Of RichTextBox, Single)(richTextAusbildungsplatz, CType(numFontSizeAusbildungsplatz.Value, Single)))
            AddHandler cmbFontFamilyAusbildungsplatz.SelectedIndexChanged, Sub() viewModel.ChangeFontFamilyCommand.Execute(New Tuple(Of RichTextBox, String)(richTextAusbildungsplatz, cmbFontFamilyAusbildungsplatz.SelectedItem.ToString()))

            'AddHandler btnItalicBerufsschule.Click, Sub() viewModel.ItalicCommand.Execute(richTextBerufsschule)
            'AddHandler btnBoldBerufsschule.Click, Sub() viewModel.BoldCommand.Execute(richTextBerufsschule)
            'AddHandler btnNormalBerufsschule.Click, Sub() viewModel.NormalCommand.Execute(richTextBerufsschule)
            'AddHandler numFontSizeBerufsschule.ValueChanged, Sub() viewModel.ChangeFontSizeCommand.Execute(New Tuple(Of RichTextBox, Single)(richTextBerufsschule, CType(numFontSizeBerufsschule.Value, Single)))
            'AddHandler cmbFontFamilyBerufsschule.SelectedIndexChanged, Sub() viewModel.ChangeFontFamilyCommand.Execute(New Tuple(Of RichTextBox, String)(richTextBerufsschule, cmbFontFamilyBerufsschule.SelectedItem.ToString()))
        End Sub

        Private Sub DisplayBerichte()

            treeViewBerichte.Nodes.Clear()
            Dim rootNode As New TreeNode($"Berichtsheft von {_viewModel.Benutzer.Name}")

            For Each bericht In _viewModel.Ausbildungsberichte
                Dim node As New TreeNode($"Ausbildungsnachweis vom {bericht.Datum.ToShortDateString()} bis zum {bericht.Datum.AddDays(bericht.Woche * 7).ToShortDateString()}")
                rootNode.Nodes.Add(node)
            Next

            Dim newBerichtNode As New TreeNode("neuer Ausbildungsnachweis")
            rootNode.Nodes.Add(newBerichtNode)

            treeViewBerichte.Nodes.Add(rootNode)
            treeViewBerichte.ExpandAll()
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles abschluss.ButtonAbbruchClick

            ' Beispielcode zum Hinzufügen eines neuen Berichts
            Dim bericht As New Ausbildungsbericht(DateTime.Now, "Neuer Bericht", DatePart(DateInterval.WeekOfYear, Now), richTextAusbildungsplatz.Text, richTextBerufsschule.Text)
            _viewModel.AddBericht(bericht)
            DisplayBerichte()
        End Sub


        'Public Shared Function GetResourcePath(fileName As String) As String
        '    Dim basePath As String = AppDomain.CurrentDomain.BaseDirectory.Replace("\bin\Debug\net8.0-windows\", "")
        '    Dim resourcePath As String = Path.Combine(basePath, "Resourcen", fileName)
        '    Return resourcePath
        'End Function


        ' Initialisieren Sie die Komponenten des Formulars
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.tlpPanel = New TableLayoutPanel()
            Me.tlpRichtext = New TableLayoutPanel()

            Me.labelYear = New Label()
            Me.labelWeek = New Label()
            Me.labelName = New Label()
            Me.pdfViewerRahmen = New rm.ChatGPTiumViewerEditor.PdfViewerControl() ' New PdfViewer()
            Me.pdfViewerAusbildungsNachweis = New PdfViewerControl() ' New PdfViewer()
            Me.richTextAusbildungsplatz = New RichTextBox()
            Me.richTextBerufsschule = New RichTextBox()
            Me.cmbFontFamilyAusbildungsplatz = New ComboBox()
            Me.numFontSizeAusbildungsplatz = New NumericUpDown()
            Me.colorPickerButtonAusbildungsplatz = New Button()
            Me.btnBoldAusbildungsplatz = New Button()
            Me.btnItalicAusbildungsplatz = New Button()
            Me.btnNormalAusbildungsplatz = New Button()
            Me.listBoxBerichte = New ListBox()
            Me.treeViewBerichte = New TreeView()
            Me.abschluss = New XPSAbschluss()
            Me.SuspendLayout()


            Me.abschluss.ButtonÜbernehmenVisible = True
            Me.abschluss.Dock = DockStyle.Fill
            Me.abschluss.Location = New Point(0, 0)
            Me.abschluss.Name = "abschluss"
            Me.abschluss.Size = New Size(828, 40)
            Me.abschluss.TabIndex = 0
            Me.abschluss.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top


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
            Me.tlpRichtext.RowCount = 3
            Me.tlpRichtext.RowStyles.Add(New RowStyle(SizeType.Absolute, 40.0!))
            Me.tlpRichtext.RowStyles.Add(New RowStyle(SizeType.Percent, 60.0!))
            Me.tlpRichtext.RowStyles.Add(New RowStyle(SizeType.Percent, 40.0!))
            Me.tlpRichtext.Size = New Size(250, 500)
            Me.tlpRichtext.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
            Me.tlpRichtext.Controls.Add(cmbFontFamilyAusbildungsplatz, 0, 0)
            Me.tlpRichtext.Controls.Add(numFontSizeAusbildungsplatz, 1, 0)
            Me.tlpRichtext.Controls.Add(colorPickerButtonAusbildungsplatz, 2, 0)
            Me.tlpRichtext.Controls.Add(btnBoldAusbildungsplatz, 3, 0)
            Me.tlpRichtext.Controls.Add(btnItalicAusbildungsplatz, 4, 0)
            Me.tlpRichtext.Controls.Add(btnNormalAusbildungsplatz, 5, 0)
            Me.tlpRichtext.Controls.Add(richTextAusbildungsplatz, 0, 1)
            Me.tlpRichtext.SetColumnSpan(richTextAusbildungsplatz, 6)
            Me.tlpRichtext.Controls.Add(richTextBerufsschule, 0, 2)
            Me.tlpRichtext.SetColumnSpan(richTextBerufsschule, 6)
            Me.tlpRichtext.Dock = DockStyle.Fill
            '
            'treeViewBerichte
            '
            Me.treeViewBerichte.Location = New System.Drawing.Point(12, 12)
            Me.treeViewBerichte.Name = "treeViewBerichte"
            Me.treeViewBerichte.Size = New System.Drawing.Size(776, 394)
            Me.treeViewBerichte.TabIndex = 0
            Me.treeViewBerichte.Dock = DockStyle.Fill
            '
            ' tlpPanel
            '
            Me.tlpPanel.ColumnCount = 4
            Me.tlpPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 10.0!))
            Me.tlpPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30.0!))
            Me.tlpPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30.0!))
            Me.tlpPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30.0!))
            Me.tlpPanel.Location = New Point(12, 50)
            Me.tlpPanel.Name = "tlpPanel"
            Me.tlpPanel.RowCount = 2
            Me.tlpPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0!))
            Me.tlpPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 40.0!))
            Me.tlpPanel.Size = New Size(828, 500)
            Me.tlpPanel.TabIndex = 0
            Me.tlpPanel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top

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
            'Me.pdfViewerRahmen.'.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.FitToWidth
            '
            ' pdfViewerAusbildungsNachweis
            '
            Me.pdfViewerAusbildungsNachweis.Dock = DockStyle.Fill
            Me.pdfViewerAusbildungsNachweis.Location = New Point(0, 0)
            Me.pdfViewerAusbildungsNachweis.Name = "pdfViewer"
            Me.pdfViewerAusbildungsNachweis.Size = New Size(250, 500)
            Me.pdfViewerAusbildungsNachweis.TabIndex = 15
            'Me.pdfViewerAusbildungsNachweis.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.FitToWidth
            ' fontComboBox
            Me.cmbFontFamilyAusbildungsplatz.Location = New Point(12, 50)
            Me.cmbFontFamilyAusbildungsplatz.Name = "fontComboBox"
            Me.cmbFontFamilyAusbildungsplatz.Size = New Size(121, 23)
            Me.cmbFontFamilyAusbildungsplatz.TabIndex = 16
            Me.cmbFontFamilyAusbildungsplatz.DropDownStyle = ComboBoxStyle.DropDownList
            Me.cmbFontFamilyAusbildungsplatz.Dock = DockStyle.Fill
            For Each font As FontFamily In FontFamily.Families
                Me.cmbFontFamilyAusbildungsplatz.Items.Add(font.Name)
            Next
            AddHandler Me.cmbFontFamilyAusbildungsplatz.SelectedIndexChanged, AddressOf Me.fontComboBox_SelectedIndexChanged

            ' fontSizeNumericUpDown
            Me.numFontSizeAusbildungsplatz.Location = New Point(140, 50)
            Me.numFontSizeAusbildungsplatz.Name = "fontSizeNumericUpDown"
            Me.numFontSizeAusbildungsplatz.Size = New Size(50, 23)
            Me.numFontSizeAusbildungsplatz.TabIndex = 17
            Me.numFontSizeAusbildungsplatz.Minimum = 8
            Me.numFontSizeAusbildungsplatz.Maximum = 72
            Me.numFontSizeAusbildungsplatz.Dock = DockStyle.Fill
            AddHandler Me.numFontSizeAusbildungsplatz.ValueChanged, AddressOf Me.fontSizeNumericUpDown_ValueChanged

            ' colorPickerButton
            Me.colorPickerButtonAusbildungsplatz.Location = New Point(200, 50)
            Me.colorPickerButtonAusbildungsplatz.Name = "colorPickerButton"
            Me.colorPickerButtonAusbildungsplatz.Size = New Size(75, 23)
            Me.colorPickerButtonAusbildungsplatz.TabIndex = 18
            Me.colorPickerButtonAusbildungsplatz.Text = "Color"
            Me.colorPickerButtonAusbildungsplatz.UseVisualStyleBackColor = True
            Me.colorPickerButtonAusbildungsplatz.Dock = DockStyle.Fill
            AddHandler Me.colorPickerButtonAusbildungsplatz.Click, AddressOf Me.colorPickerButton_Click
            ' boldButton
            Me.btnBoldAusbildungsplatz.Location = New Point(280, 50)
            Me.btnBoldAusbildungsplatz.Name = "boldButton"
            Me.btnBoldAusbildungsplatz.Size = New Size(35, 23)
            Me.btnBoldAusbildungsplatz.TabIndex = 19
            Me.btnBoldAusbildungsplatz.Text = "B"
            Me.btnBoldAusbildungsplatz.Font = New Font(Me.btnBoldAusbildungsplatz.Font, FontStyle.Bold)
            Me.btnBoldAusbildungsplatz.UseVisualStyleBackColor = True
            Me.btnBoldAusbildungsplatz.Dock = DockStyle.Fill
            AddHandler Me.btnBoldAusbildungsplatz.Click, AddressOf Me.boldButton_Click
            '
            ' italicButton
            '
            Me.btnItalicAusbildungsplatz.Location = New Point(320, 50)
            Me.btnItalicAusbildungsplatz.Name = "italicButton"
            Me.btnItalicAusbildungsplatz.Size = New Size(35, 23)
            Me.btnItalicAusbildungsplatz.TabIndex = 20
            Me.btnItalicAusbildungsplatz.Text = "I"
            Me.btnItalicAusbildungsplatz.Font = New Font(Me.btnItalicAusbildungsplatz.Font, FontStyle.Italic)
            Me.btnItalicAusbildungsplatz.UseVisualStyleBackColor = True
            Me.btnItalicAusbildungsplatz.Dock = DockStyle.Fill
            AddHandler Me.btnItalicAusbildungsplatz.Click, AddressOf Me.italicButton_Click
            '
            ' normalButton
            '
            Me.btnNormalAusbildungsplatz.Location = New Point(360, 50)
            Me.btnNormalAusbildungsplatz.Name = "normalButton"
            Me.btnNormalAusbildungsplatz.Size = New Size(35, 23)
            Me.btnNormalAusbildungsplatz.TabIndex = 21
            Me.btnNormalAusbildungsplatz.Text = "N"
            Me.btnNormalAusbildungsplatz.Font = New Font(Me.btnNormalAusbildungsplatz.Font, FontStyle.Regular)
            Me.btnNormalAusbildungsplatz.UseVisualStyleBackColor = True
            Me.btnNormalAusbildungsplatz.Dock = DockStyle.Fill
            AddHandler Me.btnNormalAusbildungsplatz.Click, AddressOf Me.normalButton_Click

            '
            ' richTextAusbildungsplatz
            '
            Me.richTextAusbildungsplatz.Dock = DockStyle.Fill
            Me.richTextAusbildungsplatz.Location = New Point(0, 0)
            Me.richTextAusbildungsplatz.Name = "richTextAusbildungsplatz"
            Me.richTextAusbildungsplatz.Size = New Size(280, 500)
            Me.richTextAusbildungsplatz.TabIndex = 15

            Me.richTextBerufsschule.Dock = DockStyle.Fill
            Me.richTextBerufsschule.Location = New Point(0, 0)
            Me.richTextBerufsschule.Name = "richTextBerufsschule"
            Me.richTextBerufsschule.Size = New Size(280, 500)
            Me.richTextBerufsschule.TabIndex = 16

            '
            ' MainView
            '
            Me.AutoScaleDimensions = New SizeF(7.0F, 15.0F)
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.ClientSize = New Size(859, 560)
            Me.StartPosition = FormStartPosition.CenterScreen

            Me.Controls.Add(Me.tlpPanel)

            Me.Controls.Add(Me.labelYear)
            Me.Controls.Add(Me.labelWeek)
            Me.Controls.Add(Me.labelName)

            Me.tlpPanel.Controls.Add(Me.treeViewBerichte, 0, 0)
            Me.tlpPanel.Controls.Add(pdfViewerRahmen, 1, 0)
            Me.tlpPanel.Controls.Add(pdfViewerAusbildungsNachweis, 2, 0)
            Me.tlpPanel.Controls.Add(Me.tlpRichtext, 3, 0)
            Me.tlpPanel.Controls.Add(Me.abschluss, 0, 1)
            Me.tlpPanel.SetColumnSpan(Me.abschluss, 4)
            'Me.panelLeft.Controls.Add(Me.pdfViewer)
            'Me.panelMiddle.Controls.Add(Me.richTextAusbildungsplatz)
            Me.Name = "MainView"
            Me.Text = "RA-MICRO Cockpit Berichtsheft"
            Me.Icon = New Icon(_viewModel.GetResourcePath("Azubi-Berichtsheft_3216.ico"))
            Me.WindowState = FormWindowState.Maximized
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub




        Private Sub normalButton_Click(obj As Object, e As EventArgs)
            Dim currentFont As Font = richTextAusbildungsplatz.SelectionFont
            Dim newFontStyle As FontStyle = FontStyle.Regular
            richTextAusbildungsplatz.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
        End Sub

        Private Sub italicButton_Click(obj As Object, e As EventArgs)
            Dim currentFont As Font = richTextAusbildungsplatz.SelectionFont
            Dim newFontStyle As FontStyle

            If currentFont.Italic = True Then
                newFontStyle = FontStyle.Regular
            Else
                newFontStyle = FontStyle.Italic
            End If

            richTextAusbildungsplatz.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
        End Sub

        Private Sub fontSizeNumericUpDown_ValueChanged(obj As Object, e As EventArgs)
            Dim currentFont As Font = richTextAusbildungsplatz.SelectionFont
            richTextAusbildungsplatz.SelectionFont = New Font(currentFont.FontFamily, numFontSizeAusbildungsplatz.Value, currentFont.Style)
        End Sub
        Private Sub colorPickerButton_Click(sender As Object, e As EventArgs)
            Dim colorDialog As New ColorDialog()
            If colorDialog.ShowDialog() = DialogResult.OK Then
                richTextAusbildungsplatz.SelectionColor = colorDialog.Color
            End If
        End Sub

        Private Sub fontComboBox_SelectedIndexChanged(obj As Object, e As EventArgs)
            Dim currentFont As Font = richTextAusbildungsplatz.SelectionFont
            Dim newFontFamily As FontFamily = New FontFamily(cmbFontFamilyAusbildungsplatz.SelectedItem.ToString())
            richTextAusbildungsplatz.SelectionFont = New Font(newFontFamily, currentFont.Size, currentFont.Style)
        End Sub

        Private Sub boldButton_Click(sender As Object, e As EventArgs)
            Dim currentFont As Font = richTextAusbildungsplatz.SelectionFont
            Dim newFontStyle As FontStyle

            If currentFont.Bold = True Then
                newFontStyle = FontStyle.Regular
            Else
                newFontStyle = FontStyle.Bold
            End If

            richTextAusbildungsplatz.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
        End Sub









        Private Sub MainView_Load(sender As Object, e As EventArgs) Handles Me.Load
            'fontComboBox.Text = "Segoe UI"
            'fontSizeNumericUpDown.Value = 12
            pdfViewerRahmen.LoadPdf(pfadZurVorlage1)
            pdfViewerAusbildungsNachweis.LoadPdf(pfadZurVorlage2)


        End Sub



        Private Sub abschluss_ButtonClick(sender As Object, e As EventArgs) Handles abschluss.ButtonAbbruchClick
            Me.Close()
        End Sub
    End Class
End Namespace


﻿Imports System.Windows.Forms
Imports TempAzubiBerichtsheft.TempAzubiBerichtsheft.ViewModels
Imports TempAzubiBerichtsheft.ViewModels

Public Class LoginView
    Inherits Form

    Private txtUsername As TextBox
    Private txtPassword As TextBox
    Private btnLogin As Button
    Private lblMessage As Label

    Public Sub New()
        InitializeComponent()
        txtUsername.Text = "admin"
        txtPassword.Text = "password"

    End Sub

    Private Sub InitializeComponent()
        Me.Text = "Login"
        Me.Width = 400
        Me.Height = 200

        txtUsername = New TextBox() With {.Left = 50, .Top = 20, .Width = 300}
        txtPassword = New TextBox() With {.Left = 50, .Top = 60, .Width = 300, .PasswordChar = "*"c}
        btnLogin = New Button() With {.Text = "Login", .Left = 150, .Top = 100, .Width = 100}
        lblMessage = New Label() With {.Left = 50, .Top = 140, .Width = 300}

        AddHandler btnLogin.Click, AddressOf Me.BtnLogin_Click

        Me.Controls.Add(txtUsername)
        Me.Controls.Add(txtPassword)
        Me.Controls.Add(btnLogin)
        Me.Controls.Add(lblMessage)
    End Sub

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs)
        ' Beispielhafte Überprüfung der Anmeldedaten
        If txtUsername.Text = "admin" AndAlso txtPassword.Text = "password" Then
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

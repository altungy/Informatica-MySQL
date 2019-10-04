Imports System.Windows.Forms

Public Class TimedMessage
    Private Shared nSegundos As Integer
    Private Shared nBotón As Integer
    Private dtFin As DateTime
    Private lSalir As Boolean = False

    Private Sub Cmd1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd1.Click
        txtResultado.Text = "1"
        lSalir = True
        Me.Close()
    End Sub

    Private Sub Cmd2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd2.Click
        txtResultado.Text = "2"
        lSalir = True
        Me.Close()
    End Sub

    Private Sub Cmd3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd3.Click
        txtResultado.Text = "3"
        lSalir = True
        Me.Close()
    End Sub

    Private Sub TimedMessage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim fontTexto As Font = New Font("Microsoft Sans Serif", 8.5)
        Dim g As Graphics = Me.CreateGraphics
        Dim TextWidth As Single = g.MeasureString(lblMensaje.Text, fontTexto).Width()
        Dim nBotones As Integer = 1
        Dim nAlto As Integer

        If TextWidth > 175 Then
            If TextWidth > 290 Then
                Me.Width = 400
                lblMensaje.Width = 315
            Else
                Me.Width = TextWidth + 85
                lblMensaje.Width = TextWidth
            End If
        End If

        nAlto = Int(TextWidth / (lblMensaje.Width * 1.1) + 0.999)
        nAlto *= 16
        lblMensaje.Height = nAlto

        If nAlto > 26 Then
            Me.Height = 120 + nAlto - 26
            picCritical.Location = New Point(12, 12 + (nAlto - 26) / 2)
            picExclamation.Location = New Point(12, 12 + (nAlto - 26) / 2)
            picInformation.Location = New Point(12, 12 + (nAlto - 26) / 2)
            picQuestion.Location = New Point(12, 12 + (nAlto - 26) / 2)
        End If

        If cmd2.Visible Then nBotones = 2
        If cmd3.Visible Then nBotones = 3

        Select Case nBotones
            Case 1
                cmd1.Location = New Point((Me.Width - 75) / 2, Me.Height - 70)

            Case 2

                cmd1.Location = New Point(Me.Width / 2 - 80, Me.Height - 70)
                cmd2.Location = New Point(Me.Width / 2 + 5, Me.Height - 70)

            Case 3
                cmd1.Location = New Point((Me.Width - 75) / 2 - 80, Me.Height - 70)
                cmd2.Location = New Point((Me.Width - 75) / 2, Me.Height - 70)
                cmd3.Location = New Point((Me.Width - 75) / 2 + 80, Me.Height - 70)
        End Select

        Beep()

        nBotón = Val(Microsoft.VisualBasic.Left(txtResultado.Text, 1))
        nSegundos = Val(Mid(txtResultado.Text, 2))

        dtFin = Now.AddSeconds(nSegundos)
        Me.Show()

        If nSegundos <> 0 Then
            While Now < dtFin And Not lSalir
                Application.DoEvents()
            End While

            If Not lSalir Then
                Select Case nBotón
                    Case 1
                        cmd1_Click(Nothing, Nothing)

                    Case 2
                        cmd2_Click(Nothing, Nothing)

                    Case 3
                        cmd3_Click(Nothing, Nothing)
                End Select
            End If
        End If
    End Sub
End Class

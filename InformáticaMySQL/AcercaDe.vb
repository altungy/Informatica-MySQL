Imports System.IO
Imports Rutinas45.Rutinas
Imports System.Globalization
Imports System.Threading

Public Class FrmAcercaDe
    Private ReadOnly Altungy = New Rutinas45.Rutinas
    Private Sub AcercaDe_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim cFichero As String = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName

        lblProducto.Text = frmMenú.Text
        lblFecha.Text = "Compilación: " + File.GetLastWriteTime(cFichero).ToString("dd/MM/yyyy", Nothing)
    End Sub

    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Me.Close()
    End Sub

    Private Sub LblRafael_DoubleClick(sender As Object, e As EventArgs) Handles lblRafael.DoubleClick
        Altungy.Rafael(Me.Location.X + Me.Size.Width / 2, Me.Location.Y)
    End Sub

    Private Sub Rafael(ByVal nX As Integer, ByVal nY As Integer)
        Dim frmRafael As New System.Windows.Forms.Form
        Dim picRafael As New System.Windows.Forms.PictureBox
        Dim lblRafael As New System.Windows.Forms.Label

        With frmRafael
            .Size = New Drawing.Size(118, 185)
            .AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            .BackColor = Drawing.Color.White
            .ControlBox = False
            .FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
            .ShowIcon = False
            .ShowInTaskbar = False
            .StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            .Text = ""
            .Opacity = 0
            .TopMost = True
            .Show()
        End With

        nX -= frmRafael.Size.Width / 2
        nY -= 200
        frmRafael.Location = New Drawing.Point(nX, nY)
        'frmRafael.Location = New Drawing.Point(My.Computer.Screen.WorkingArea.Size.Width / 2 - frmRafael.Size.Width / 2, My.Computer.Screen.WorkingArea.Size.Height / 2 - frmRafael.Size.Height / 2)


        With picRafael
            .BackgroundImage = My.Resources.rafael
            .BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            .BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            .Size = New Drawing.Size(90, 125)
            .Location = New Drawing.Point((frmRafael.Size.Width - picRafael.Size.Width) / 2, 10)
        End With

        frmRafael.Controls.Add(picRafael)

        With lblRafael
            .Text = "Rafael Altungy"
            .TextAlign = Drawing.ContentAlignment.MiddleCenter
            .AutoSize = False
            .Size = New Drawing.Size(90, 27)
            .Location = New Drawing.Point((frmRafael.Size.Width - lblRafael.Size.Width) / 2, frmRafael.Size.Height - 40)
        End With

        frmRafael.Controls.Add(lblRafael)

        For n = 1 To 100
            frmRafael.Opacity = n / 100
            Threading.Thread.Sleep(10)
            System.Windows.Forms.Application.DoEvents()
        Next

        AddHandler picRafael.Click, AddressOf CierraRafael
        AddHandler lblRafael.Click, AddressOf CierraRafael

        frmRafael.Hide()
        frmRafael.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        frmRafael.Location = New Drawing.Point(nX, nY)
        frmRafael.ShowDialog()
    End Sub

    Private Sub CierraRafael(sender As Object, e As EventArgs)
        sender.Parent.Close()
    End Sub
End Class
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TimedMessage
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TimedMessage))
        Me.cmd1 = New System.Windows.Forms.Button()
        Me.cmd3 = New System.Windows.Forms.Button()
        Me.cmd2 = New System.Windows.Forms.Button()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.txtResultado = New System.Windows.Forms.TextBox()
        Me.picQuestion = New System.Windows.Forms.PictureBox()
        Me.picCritical = New System.Windows.Forms.PictureBox()
        Me.picInformation = New System.Windows.Forms.PictureBox()
        Me.picExclamation = New System.Windows.Forms.PictureBox()
        CType(Me.picQuestion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCritical, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picExclamation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmd1
        '
        Me.cmd1.Location = New System.Drawing.Point(15, 58)
        Me.cmd1.Name = "cmd1"
        Me.cmd1.Size = New System.Drawing.Size(75, 23)
        Me.cmd1.TabIndex = 0
        Me.cmd1.Text = "Button1"
        Me.cmd1.UseVisualStyleBackColor = True
        '
        'cmd3
        '
        Me.cmd3.Location = New System.Drawing.Point(177, 58)
        Me.cmd3.Name = "cmd3"
        Me.cmd3.Size = New System.Drawing.Size(75, 23)
        Me.cmd3.TabIndex = 2
        Me.cmd3.Text = "Button3"
        Me.cmd3.UseVisualStyleBackColor = True
        '
        'cmd2
        '
        Me.cmd2.Location = New System.Drawing.Point(96, 58)
        Me.cmd2.Name = "cmd2"
        Me.cmd2.Size = New System.Drawing.Size(75, 23)
        Me.cmd2.TabIndex = 1
        Me.cmd2.Text = "Button2"
        Me.cmd2.UseVisualStyleBackColor = True
        '
        'lblMensaje
        '
        Me.lblMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensaje.Location = New System.Drawing.Point(67, 19)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(175, 27)
        Me.lblMensaje.TabIndex = 0
        Me.lblMensaje.Text = "Label1"
        Me.lblMensaje.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtResultado
        '
        Me.txtResultado.Location = New System.Drawing.Point(-2, 12)
        Me.txtResultado.Name = "txtResultado"
        Me.txtResultado.Size = New System.Drawing.Size(10, 20)
        Me.txtResultado.TabIndex = 1
        Me.txtResultado.Visible = False
        '
        'picQuestion
        '
        Me.picQuestion.Image = CType(resources.GetObject("picQuestion.Image"), System.Drawing.Image)
        Me.picQuestion.Location = New System.Drawing.Point(12, 12)
        Me.picQuestion.Name = "picQuestion"
        Me.picQuestion.Size = New System.Drawing.Size(34, 34)
        Me.picQuestion.TabIndex = 6
        Me.picQuestion.TabStop = False
        Me.picQuestion.Visible = False
        '
        'picCritical
        '
        Me.picCritical.Image = CType(resources.GetObject("picCritical.Image"), System.Drawing.Image)
        Me.picCritical.Location = New System.Drawing.Point(11, 12)
        Me.picCritical.Name = "picCritical"
        Me.picCritical.Size = New System.Drawing.Size(34, 34)
        Me.picCritical.TabIndex = 5
        Me.picCritical.TabStop = False
        Me.picCritical.Visible = False
        '
        'picInformation
        '
        Me.picInformation.Image = CType(resources.GetObject("picInformation.Image"), System.Drawing.Image)
        Me.picInformation.Location = New System.Drawing.Point(11, 12)
        Me.picInformation.Name = "picInformation"
        Me.picInformation.Size = New System.Drawing.Size(35, 35)
        Me.picInformation.TabIndex = 4
        Me.picInformation.TabStop = False
        Me.picInformation.Visible = False
        '
        'picExclamation
        '
        Me.picExclamation.Image = CType(resources.GetObject("picExclamation.Image"), System.Drawing.Image)
        Me.picExclamation.Location = New System.Drawing.Point(14, 15)
        Me.picExclamation.Name = "picExclamation"
        Me.picExclamation.Size = New System.Drawing.Size(32, 32)
        Me.picExclamation.TabIndex = 3
        Me.picExclamation.TabStop = False
        Me.picExclamation.Visible = False
        '
        'TimedMessage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(254, 88)
        Me.ControlBox = False
        Me.Controls.Add(Me.picQuestion)
        Me.Controls.Add(Me.picCritical)
        Me.Controls.Add(Me.picInformation)
        Me.Controls.Add(Me.picExclamation)
        Me.Controls.Add(Me.cmd1)
        Me.Controls.Add(Me.txtResultado)
        Me.Controls.Add(Me.cmd2)
        Me.Controls.Add(Me.cmd3)
        Me.Controls.Add(Me.lblMensaje)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TimedMessage"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.picQuestion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCritical, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picInformation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picExclamation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmd1 As System.Windows.Forms.Button
    Friend WithEvents cmd2 As System.Windows.Forms.Button
    Friend WithEvents cmd3 As System.Windows.Forms.Button
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
    Friend WithEvents txtResultado As System.Windows.Forms.TextBox
    Friend WithEvents picExclamation As System.Windows.Forms.PictureBox
    Friend WithEvents picInformation As System.Windows.Forms.PictureBox
    Friend WithEvents picCritical As System.Windows.Forms.PictureBox
    Friend WithEvents picQuestion As System.Windows.Forms.PictureBox

End Class

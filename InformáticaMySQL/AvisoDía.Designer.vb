<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAvisoDía
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAvisoDía))
        Me.groupFestivo = New System.Windows.Forms.GroupBox()
        Me.picCumpleaños = New System.Windows.Forms.PictureBox()
        Me.txtFestivo = New System.Windows.Forms.TextBox()
        Me.groupCumpleaños = New System.Windows.Forms.GroupBox()
        Me.txtCumpleaños = New System.Windows.Forms.TextBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.groupFestivo.SuspendLayout()
        CType(Me.picCumpleaños, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupCumpleaños.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupFestivo
        '
        Me.groupFestivo.Controls.Add(Me.picCumpleaños)
        Me.groupFestivo.Controls.Add(Me.txtFestivo)
        Me.groupFestivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupFestivo.Location = New System.Drawing.Point(12, 12)
        Me.groupFestivo.Name = "groupFestivo"
        Me.groupFestivo.Size = New System.Drawing.Size(365, 245)
        Me.groupFestivo.TabIndex = 0
        Me.groupFestivo.TabStop = False
        Me.groupFestivo.Text = "Hoy es festivo en"
        '
        'picCumpleaños
        '
        Me.picCumpleaños.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picCumpleaños.Image = Global.InformáticaMySQL.My.Resources.Resources.cumpleaños
        Me.picCumpleaños.Location = New System.Drawing.Point(34, 34)
        Me.picCumpleaños.Name = "picCumpleaños"
        Me.picCumpleaños.Size = New System.Drawing.Size(300, 300)
        Me.picCumpleaños.TabIndex = 1
        Me.picCumpleaños.TabStop = False
        Me.picCumpleaños.Visible = False
        '
        'txtFestivo
        '
        Me.txtFestivo.BackColor = System.Drawing.Color.White
        Me.txtFestivo.Location = New System.Drawing.Point(6, 19)
        Me.txtFestivo.Multiline = True
        Me.txtFestivo.Name = "txtFestivo"
        Me.txtFestivo.ReadOnly = True
        Me.txtFestivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtFestivo.Size = New System.Drawing.Size(353, 220)
        Me.txtFestivo.TabIndex = 0
        Me.txtFestivo.TabStop = False
        '
        'groupCumpleaños
        '
        Me.groupCumpleaños.Controls.Add(Me.txtCumpleaños)
        Me.groupCumpleaños.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupCumpleaños.Location = New System.Drawing.Point(12, 263)
        Me.groupCumpleaños.Name = "groupCumpleaños"
        Me.groupCumpleaños.Size = New System.Drawing.Size(365, 100)
        Me.groupCumpleaños.TabIndex = 1
        Me.groupCumpleaños.TabStop = False
        Me.groupCumpleaños.Text = "Cumpleaños"
        '
        'txtCumpleaños
        '
        Me.txtCumpleaños.BackColor = System.Drawing.Color.White
        Me.txtCumpleaños.Location = New System.Drawing.Point(6, 19)
        Me.txtCumpleaños.Multiline = True
        Me.txtCumpleaños.Name = "txtCumpleaños"
        Me.txtCumpleaños.ReadOnly = True
        Me.txtCumpleaños.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCumpleaños.Size = New System.Drawing.Size(353, 75)
        Me.txtCumpleaños.TabIndex = 0
        Me.txtCumpleaños.TabStop = False
        '
        'btnSalir
        '
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Location = New System.Drawing.Point(159, 385)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmAvisoDía
        '
        Me.AcceptButton = Me.btnSalir
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(390, 420)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.groupCumpleaños)
        Me.Controls.Add(Me.groupFestivo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAvisoDía"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "AvisoDía"
        Me.groupFestivo.ResumeLayout(False)
        Me.groupFestivo.PerformLayout()
        CType(Me.picCumpleaños, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupCumpleaños.ResumeLayout(False)
        Me.groupCumpleaños.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents groupFestivo As GroupBox
    Friend WithEvents txtFestivo As TextBox
    Friend WithEvents groupCumpleaños As GroupBox
    Friend WithEvents txtCumpleaños As TextBox
    Friend WithEvents btnSalir As Button
    Friend WithEvents picCumpleaños As PictureBox
End Class

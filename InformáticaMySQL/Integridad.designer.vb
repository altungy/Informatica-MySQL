<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmIntegridad
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.radioRumanía = New System.Windows.Forms.RadioButton()
        Me.radioPolonia = New System.Windows.Forms.RadioButton()
        Me.txtPedido = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbPaís = New System.Windows.Forms.GroupBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.radioPolinesia = New System.Windows.Forms.RadioButton()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.radioAdidas = New System.Windows.Forms.RadioButton()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.radioInvain = New System.Windows.Forms.RadioButton()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.radioDécimas = New System.Windows.Forms.RadioButton()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtCompra = New System.Windows.Forms.TextBox()
        Me.lblCompra = New System.Windows.Forms.Label()
        Me.btnBuscarPedido = New System.Windows.Forms.Button()
        Me.lblIntegridad = New System.Windows.Forms.Label()
        Me.txtCambio = New System.Windows.Forms.TextBox()
        Me.lblCambio = New System.Windows.Forms.Label()
        Me.lvwDiferencias = New System.Windows.Forms.ListView()
        Me.txtSQL = New System.Windows.Forms.TextBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.txtEntrada = New System.Windows.Forms.TextBox()
        Me.lblEntrada = New System.Windows.Forms.Label()
        Me.gbPaís.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'radioRumanía
        '
        Me.radioRumanía.AutoSize = True
        Me.radioRumanía.Location = New System.Drawing.Point(71, 27)
        Me.radioRumanía.Name = "radioRumanía"
        Me.radioRumanía.Size = New System.Drawing.Size(14, 13)
        Me.radioRumanía.TabIndex = 0
        Me.radioRumanía.TabStop = True
        Me.radioRumanía.UseVisualStyleBackColor = True
        '
        'radioPolonia
        '
        Me.radioPolonia.AutoSize = True
        Me.radioPolonia.Location = New System.Drawing.Point(133, 27)
        Me.radioPolonia.Name = "radioPolonia"
        Me.radioPolonia.Size = New System.Drawing.Size(14, 13)
        Me.radioPolonia.TabIndex = 1
        Me.radioPolonia.TabStop = True
        Me.radioPolonia.UseVisualStyleBackColor = True
        '
        'txtPedido
        '
        Me.txtPedido.BackColor = System.Drawing.Color.White
        Me.txtPedido.Location = New System.Drawing.Point(125, 121)
        Me.txtPedido.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPedido.MaxLength = 15
        Me.txtPedido.Name = "txtPedido"
        Me.txtPedido.Size = New System.Drawing.Size(114, 20)
        Me.txtPedido.TabIndex = 2
        Me.txtPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(71, 124)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Pedido"
        '
        'gbPaís
        '
        Me.gbPaís.Controls.Add(Me.PictureBox6)
        Me.gbPaís.Controls.Add(Me.radioPolinesia)
        Me.gbPaís.Controls.Add(Me.PictureBox5)
        Me.gbPaís.Controls.Add(Me.radioAdidas)
        Me.gbPaís.Controls.Add(Me.PictureBox4)
        Me.gbPaís.Controls.Add(Me.radioInvain)
        Me.gbPaís.Controls.Add(Me.PictureBox3)
        Me.gbPaís.Controls.Add(Me.radioDécimas)
        Me.gbPaís.Controls.Add(Me.PictureBox2)
        Me.gbPaís.Controls.Add(Me.radioRumanía)
        Me.gbPaís.Controls.Add(Me.PictureBox1)
        Me.gbPaís.Controls.Add(Me.radioPolonia)
        Me.gbPaís.Location = New System.Drawing.Point(34, 14)
        Me.gbPaís.Name = "gbPaís"
        Me.gbPaís.Size = New System.Drawing.Size(261, 85)
        Me.gbPaís.TabIndex = 0
        Me.gbPaís.TabStop = False
        Me.gbPaís.Text = "País / Empresa"
        '
        'PictureBox6
        '
        Me.PictureBox6.BackgroundImage = Global.InformáticaMySQL.My.Resources.Resources.polinesia
        Me.PictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox6.Location = New System.Drawing.Point(223, 52)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(26, 20)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox6.TabIndex = 11
        Me.PictureBox6.TabStop = False
        '
        'radioPolinesia
        '
        Me.radioPolinesia.AutoSize = True
        Me.radioPolinesia.Location = New System.Drawing.Point(203, 59)
        Me.radioPolinesia.Name = "radioPolinesia"
        Me.radioPolinesia.Size = New System.Drawing.Size(14, 13)
        Me.radioPolinesia.TabIndex = 5
        Me.radioPolinesia.TabStop = True
        Me.radioPolinesia.UseVisualStyleBackColor = True
        '
        'PictureBox5
        '
        Me.PictureBox5.BackgroundImage = Global.InformáticaMySQL.My.Resources.Resources.adidas
        Me.PictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox5.Location = New System.Drawing.Point(30, 52)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(26, 20)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 9
        Me.PictureBox5.TabStop = False
        '
        'radioAdidas
        '
        Me.radioAdidas.AutoSize = True
        Me.radioAdidas.Location = New System.Drawing.Point(10, 59)
        Me.radioAdidas.Name = "radioAdidas"
        Me.radioAdidas.Size = New System.Drawing.Size(14, 13)
        Me.radioAdidas.TabIndex = 2
        Me.radioAdidas.TabStop = True
        Me.radioAdidas.UseVisualStyleBackColor = True
        '
        'PictureBox4
        '
        Me.PictureBox4.BackgroundImage = Global.InformáticaMySQL.My.Resources.Resources.invain
        Me.PictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox4.Location = New System.Drawing.Point(155, 52)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(26, 20)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 7
        Me.PictureBox4.TabStop = False
        '
        'radioInvain
        '
        Me.radioInvain.AutoSize = True
        Me.radioInvain.Location = New System.Drawing.Point(135, 59)
        Me.radioInvain.Name = "radioInvain"
        Me.radioInvain.Size = New System.Drawing.Size(14, 13)
        Me.radioInvain.TabIndex = 4
        Me.radioInvain.TabStop = True
        Me.radioInvain.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImage = Global.InformáticaMySQL.My.Resources.Resources.decimas_peq
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox3.Location = New System.Drawing.Point(91, 52)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(26, 20)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 5
        Me.PictureBox3.TabStop = False
        '
        'radioDécimas
        '
        Me.radioDécimas.AutoSize = True
        Me.radioDécimas.Location = New System.Drawing.Point(71, 59)
        Me.radioDécimas.Name = "radioDécimas"
        Me.radioDécimas.Size = New System.Drawing.Size(14, 13)
        Me.radioDécimas.TabIndex = 3
        Me.radioDécimas.TabStop = True
        Me.radioDécimas.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.InformáticaMySQL.My.Resources.Resources.Polonia
        Me.PictureBox2.Location = New System.Drawing.Point(155, 19)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(26, 20)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.InformáticaMySQL.My.Resources.Resources.Rumanía
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(92, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(26, 20)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'txtCompra
        '
        Me.txtCompra.BackColor = System.Drawing.Color.White
        Me.txtCompra.Location = New System.Drawing.Point(125, 145)
        Me.txtCompra.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCompra.MaxLength = 6
        Me.txtCompra.Name = "txtCompra"
        Me.txtCompra.ReadOnly = True
        Me.txtCompra.Size = New System.Drawing.Size(114, 20)
        Me.txtCompra.TabIndex = 5
        Me.txtCompra.TabStop = False
        Me.txtCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCompra.Visible = False
        '
        'lblCompra
        '
        Me.lblCompra.AutoSize = True
        Me.lblCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompra.Location = New System.Drawing.Point(31, 147)
        Me.lblCompra.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCompra.Name = "lblCompra"
        Me.lblCompra.Size = New System.Drawing.Size(84, 13)
        Me.lblCompra.TabIndex = 4
        Me.lblCompra.Text = "Nº de compra"
        Me.lblCompra.Visible = False
        '
        'btnBuscarPedido
        '
        Me.btnBuscarPedido.Image = Global.InformáticaMySQL.My.Resources.Resources.Lupa
        Me.btnBuscarPedido.Location = New System.Drawing.Point(244, 119)
        Me.btnBuscarPedido.Name = "btnBuscarPedido"
        Me.btnBuscarPedido.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarPedido.TabIndex = 3
        Me.btnBuscarPedido.UseVisualStyleBackColor = True
        '
        'lblIntegridad
        '
        Me.lblIntegridad.AutoSize = True
        Me.lblIntegridad.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntegridad.Location = New System.Drawing.Point(243, 171)
        Me.lblIntegridad.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblIntegridad.Name = "lblIntegridad"
        Me.lblIntegridad.Size = New System.Drawing.Size(102, 13)
        Me.lblIntegridad.TabIndex = 8
        Me.lblIntegridad.Text = "Integridad fallida"
        Me.lblIntegridad.Visible = False
        '
        'txtCambio
        '
        Me.txtCambio.BackColor = System.Drawing.Color.White
        Me.txtCambio.Location = New System.Drawing.Point(125, 192)
        Me.txtCambio.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCambio.MaxLength = 6
        Me.txtCambio.Name = "txtCambio"
        Me.txtCambio.ReadOnly = True
        Me.txtCambio.Size = New System.Drawing.Size(114, 20)
        Me.txtCambio.TabIndex = 10
        Me.txtCambio.TabStop = False
        Me.txtCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCambio.Visible = False
        '
        'lblCambio
        '
        Me.lblCambio.AutoSize = True
        Me.lblCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCambio.Location = New System.Drawing.Point(70, 194)
        Me.lblCambio.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCambio.Name = "lblCambio"
        Me.lblCambio.Size = New System.Drawing.Size(48, 13)
        Me.lblCambio.TabIndex = 9
        Me.lblCambio.Text = "Cambio"
        Me.lblCambio.Visible = False
        '
        'lvwDiferencias
        '
        Me.lvwDiferencias.FullRowSelect = True
        Me.lvwDiferencias.GridLines = True
        Me.lvwDiferencias.Location = New System.Drawing.Point(378, 14)
        Me.lvwDiferencias.Margin = New System.Windows.Forms.Padding(2)
        Me.lvwDiferencias.MultiSelect = False
        Me.lvwDiferencias.Name = "lvwDiferencias"
        Me.lvwDiferencias.Size = New System.Drawing.Size(365, 129)
        Me.lvwDiferencias.TabIndex = 11
        Me.lvwDiferencias.UseCompatibleStateImageBehavior = False
        Me.lvwDiferencias.View = System.Windows.Forms.View.Details
        Me.lvwDiferencias.Visible = False
        '
        'txtSQL
        '
        Me.txtSQL.AcceptsReturn = True
        Me.txtSQL.AcceptsTab = True
        Me.txtSQL.BackColor = System.Drawing.Color.White
        Me.txtSQL.Location = New System.Drawing.Point(378, 148)
        Me.txtSQL.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSQL.MaxLength = 65535
        Me.txtSQL.Multiline = True
        Me.txtSQL.Name = "txtSQL"
        Me.txtSQL.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSQL.Size = New System.Drawing.Size(365, 198)
        Me.txtSQL.TabIndex = 12
        Me.txtSQL.TabStop = False
        Me.txtSQL.Visible = False
        Me.txtSQL.WordWrap = False
        '
        'btnSalir
        '
        Me.btnSalir.Image = Global.InformáticaMySQL.My.Resources.Resources.salir
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(34, 265)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(56, 22)
        Me.btnSalir.TabIndex = 13
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnEjecutar
        '
        Me.btnEjecutar.Image = Global.InformáticaMySQL.My.Resources.Resources.ejecutar
        Me.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEjecutar.Location = New System.Drawing.Point(292, 225)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(80, 22)
        Me.btnEjecutar.TabIndex = 14
        Me.btnEjecutar.Text = "&Ejecutar"
        Me.btnEjecutar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEjecutar.UseVisualStyleBackColor = True
        Me.btnEjecutar.Visible = False
        '
        'txtEntrada
        '
        Me.txtEntrada.BackColor = System.Drawing.Color.White
        Me.txtEntrada.Location = New System.Drawing.Point(125, 168)
        Me.txtEntrada.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEntrada.MaxLength = 6
        Me.txtEntrada.Name = "txtEntrada"
        Me.txtEntrada.ReadOnly = True
        Me.txtEntrada.Size = New System.Drawing.Size(114, 20)
        Me.txtEntrada.TabIndex = 7
        Me.txtEntrada.TabStop = False
        Me.txtEntrada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtEntrada.Visible = False
        '
        'lblEntrada
        '
        Me.lblEntrada.AutoSize = True
        Me.lblEntrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEntrada.Location = New System.Drawing.Point(31, 171)
        Me.lblEntrada.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblEntrada.Name = "lblEntrada"
        Me.lblEntrada.Size = New System.Drawing.Size(86, 13)
        Me.lblEntrada.TabIndex = 6
        Me.lblEntrada.Text = "Nº de entrada"
        Me.lblEntrada.Visible = False
        '
        'FrmIntegridad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(754, 355)
        Me.Controls.Add(Me.txtEntrada)
        Me.Controls.Add(Me.lblEntrada)
        Me.Controls.Add(Me.btnEjecutar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.txtSQL)
        Me.Controls.Add(Me.lvwDiferencias)
        Me.Controls.Add(Me.txtCambio)
        Me.Controls.Add(Me.lblCambio)
        Me.Controls.Add(Me.lblIntegridad)
        Me.Controls.Add(Me.btnBuscarPedido)
        Me.Controls.Add(Me.txtCompra)
        Me.Controls.Add(Me.lblCompra)
        Me.Controls.Add(Me.gbPaís)
        Me.Controls.Add(Me.txtPedido)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmIntegridad"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Integridad de moneda V07/19"
        Me.gbPaís.ResumeLayout(False)
        Me.gbPaís.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents radioRumanía As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents radioPolonia As System.Windows.Forms.RadioButton
    Friend WithEvents txtPedido As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbPaís As System.Windows.Forms.GroupBox
    Friend WithEvents txtCompra As System.Windows.Forms.TextBox
    Friend WithEvents lblCompra As System.Windows.Forms.Label
    Friend WithEvents btnBuscarPedido As System.Windows.Forms.Button
    Friend WithEvents lblIntegridad As System.Windows.Forms.Label
    Friend WithEvents txtCambio As System.Windows.Forms.TextBox
    Friend WithEvents lblCambio As System.Windows.Forms.Label
    Friend WithEvents lvwDiferencias As System.Windows.Forms.ListView
    Friend WithEvents txtSQL As System.Windows.Forms.TextBox
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnEjecutar As System.Windows.Forms.Button
    Friend WithEvents txtEntrada As System.Windows.Forms.TextBox
    Friend WithEvents lblEntrada As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents radioDécimas As RadioButton
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents radioPolinesia As RadioButton
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents radioAdidas As RadioButton
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents radioInvain As RadioButton
End Class

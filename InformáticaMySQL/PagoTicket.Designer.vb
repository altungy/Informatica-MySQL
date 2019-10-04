<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPagoTicket
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
        Me.comboTipo = New System.Windows.Forms.ComboBox()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.comboPago = New System.Windows.Forms.ComboBox()
        Me.lblFormaPago = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtImporte = New System.Windows.Forms.TextBox()
        Me.lblVale = New System.Windows.Forms.Label()
        Me.txtVale = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'comboTipo
        '
        Me.comboTipo.FormattingEnabled = True
        Me.comboTipo.Location = New System.Drawing.Point(139, 64)
        Me.comboTipo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.comboTipo.Name = "comboTipo"
        Me.comboTipo.Size = New System.Drawing.Size(217, 24)
        Me.comboTipo.TabIndex = 3
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.Location = New System.Drawing.Point(7, 66)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(126, 17)
        Me.Label61.TabIndex = 2
        Me.Label61.Text = "Tipo movimiento"
        '
        'comboPago
        '
        Me.comboPago.FormattingEnabled = True
        Me.comboPago.Location = New System.Drawing.Point(139, 94)
        Me.comboPago.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.comboPago.Name = "comboPago"
        Me.comboPago.Size = New System.Drawing.Size(217, 24)
        Me.comboPago.TabIndex = 5
        '
        'lblFormaPago
        '
        Me.lblFormaPago.AutoSize = True
        Me.lblFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormaPago.Location = New System.Drawing.Point(16, 97)
        Me.lblFormaPago.Name = "lblFormaPago"
        Me.lblFormaPago.Size = New System.Drawing.Size(117, 17)
        Me.lblFormaPago.TabIndex = 4
        Me.lblFormaPago.Text = "Forma de pago"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(173, 194)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(100, 28)
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(65, 194)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(100, 28)
        Me.btnAceptar.TabIndex = 8
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(72, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Importe"
        '
        'txtImporte
        '
        Me.txtImporte.Location = New System.Drawing.Point(139, 33)
        Me.txtImporte.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Size = New System.Drawing.Size(89, 22)
        Me.txtImporte.TabIndex = 1
        Me.txtImporte.Text = "0.00"
        Me.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblVale
        '
        Me.lblVale.AutoSize = True
        Me.lblVale.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVale.Location = New System.Drawing.Point(72, 135)
        Me.lblVale.Name = "lblVale"
        Me.lblVale.Size = New System.Drawing.Size(60, 17)
        Me.lblVale.TabIndex = 6
        Me.lblVale.Text = "Nº vale"
        Me.lblVale.Visible = False
        '
        'txtVale
        '
        Me.txtVale.Location = New System.Drawing.Point(139, 132)
        Me.txtVale.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtVale.Name = "txtVale"
        Me.txtVale.Size = New System.Drawing.Size(111, 22)
        Me.txtVale.TabIndex = 7
        Me.txtVale.Visible = False
        '
        'FrmPagoTicket
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.ClientSize = New System.Drawing.Size(372, 249)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtVale)
        Me.Controls.Add(Me.lblVale)
        Me.Controls.Add(Me.txtImporte)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.comboTipo)
        Me.Controls.Add(Me.Label61)
        Me.Controls.Add(Me.comboPago)
        Me.Controls.Add(Me.lblFormaPago)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "FrmPagoTicket"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents comboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents comboPago As System.Windows.Forms.ComboBox
    Friend WithEvents lblFormaPago As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtImporte As System.Windows.Forms.TextBox
    Friend WithEvents lblVale As System.Windows.Forms.Label
    Friend WithEvents txtVale As System.Windows.Forms.TextBox
End Class

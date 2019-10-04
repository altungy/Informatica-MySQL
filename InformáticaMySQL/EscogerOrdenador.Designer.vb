<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEscogerOrdenador
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
        Me.gbOrdenador = New System.Windows.Forms.GroupBox()
        Me.radioCliente3 = New System.Windows.Forms.RadioButton()
        Me.radioCliente2 = New System.Windows.Forms.RadioButton()
        Me.radioCliente1 = New System.Windows.Forms.RadioButton()
        Me.radioServidor = New System.Windows.Forms.RadioButton()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtIP = New System.Windows.Forms.TextBox()
        Me.gbOrdenador.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbOrdenador
        '
        Me.gbOrdenador.Controls.Add(Me.radioCliente3)
        Me.gbOrdenador.Controls.Add(Me.radioCliente2)
        Me.gbOrdenador.Controls.Add(Me.radioCliente1)
        Me.gbOrdenador.Controls.Add(Me.radioServidor)
        Me.gbOrdenador.Location = New System.Drawing.Point(10, 10)
        Me.gbOrdenador.Margin = New System.Windows.Forms.Padding(2)
        Me.gbOrdenador.Name = "gbOrdenador"
        Me.gbOrdenador.Padding = New System.Windows.Forms.Padding(2)
        Me.gbOrdenador.Size = New System.Drawing.Size(150, 138)
        Me.gbOrdenador.TabIndex = 0
        Me.gbOrdenador.TabStop = False
        '
        'radioCliente3
        '
        Me.radioCliente3.AutoSize = True
        Me.radioCliente3.Location = New System.Drawing.Point(38, 100)
        Me.radioCliente3.Margin = New System.Windows.Forms.Padding(2)
        Me.radioCliente3.Name = "radioCliente3"
        Me.radioCliente3.Size = New System.Drawing.Size(66, 17)
        Me.radioCliente3.TabIndex = 3
        Me.radioCliente3.TabStop = True
        Me.radioCliente3.Text = "Cliente &3"
        Me.radioCliente3.UseVisualStyleBackColor = True
        '
        'radioCliente2
        '
        Me.radioCliente2.AutoSize = True
        Me.radioCliente2.Location = New System.Drawing.Point(38, 79)
        Me.radioCliente2.Margin = New System.Windows.Forms.Padding(2)
        Me.radioCliente2.Name = "radioCliente2"
        Me.radioCliente2.Size = New System.Drawing.Size(66, 17)
        Me.radioCliente2.TabIndex = 2
        Me.radioCliente2.TabStop = True
        Me.radioCliente2.Text = "Cliente &2"
        Me.radioCliente2.UseVisualStyleBackColor = True
        '
        'radioCliente1
        '
        Me.radioCliente1.AutoSize = True
        Me.radioCliente1.Location = New System.Drawing.Point(38, 58)
        Me.radioCliente1.Margin = New System.Windows.Forms.Padding(2)
        Me.radioCliente1.Name = "radioCliente1"
        Me.radioCliente1.Size = New System.Drawing.Size(66, 17)
        Me.radioCliente1.TabIndex = 1
        Me.radioCliente1.TabStop = True
        Me.radioCliente1.Text = "Cliente &1"
        Me.radioCliente1.UseVisualStyleBackColor = True
        '
        'radioServidor
        '
        Me.radioServidor.AutoSize = True
        Me.radioServidor.Checked = True
        Me.radioServidor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radioServidor.Location = New System.Drawing.Point(38, 17)
        Me.radioServidor.Margin = New System.Windows.Forms.Padding(2)
        Me.radioServidor.Name = "radioServidor"
        Me.radioServidor.Size = New System.Drawing.Size(72, 17)
        Me.radioServidor.TabIndex = 0
        Me.radioServidor.TabStop = True
        Me.radioServidor.Text = "&Servidor"
        Me.radioServidor.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAceptar.Location = New System.Drawing.Point(20, 198)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(64, 22)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(89, 198)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(64, 22)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 163)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "IP"
        '
        'txtIP
        '
        Me.txtIP.Location = New System.Drawing.Point(48, 160)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(92, 20)
        Me.txtIP.TabIndex = 2
        '
        'FrmEscogerOrdenador
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(164, 244)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtIP)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.gbOrdenador)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmEscogerOrdenador"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Conectar a ..."
        Me.gbOrdenador.ResumeLayout(False)
        Me.gbOrdenador.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbOrdenador As System.Windows.Forms.GroupBox
    Friend WithEvents radioCliente1 As System.Windows.Forms.RadioButton
    Friend WithEvents radioServidor As System.Windows.Forms.RadioButton
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents radioCliente3 As RadioButton
    Friend WithEvents radioCliente2 As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents txtIP As TextBox
End Class

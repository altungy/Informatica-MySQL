<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmImportarMilenium
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
        Me.btnIniciar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lblTabla = New System.Windows.Forms.Label()
        Me.lblPorcentaje = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.pbPorcentaje = New System.Windows.Forms.ProgressBar()
        Me.pbTotal = New System.Windows.Forms.ProgressBar()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnIniciar
        '
        Me.btnIniciar.Location = New System.Drawing.Point(193, 169)
        Me.btnIniciar.Name = "btnIniciar"
        Me.btnIniciar.Size = New System.Drawing.Size(75, 23)
        Me.btnIniciar.TabIndex = 0
        Me.btnIniciar.Text = "&Iniciar"
        Me.btnIniciar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.DialogResult = DialogResult.Cancel
        Me.btnSalir.Location = New System.Drawing.Point(274, 169)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 1
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lblTabla
        '
        Me.lblTabla.AutoSize = True
        Me.lblTabla.Location = New System.Drawing.Point(22, 63)
        Me.lblTabla.Name = "lblTabla"
        Me.lblTabla.Size = New System.Drawing.Size(34, 13)
        Me.lblTabla.TabIndex = 2
        Me.lblTabla.Text = "Tabla"
        Me.lblTabla.Visible = False
        '
        'lblPorcentaje
        '
        Me.lblPorcentaje.AutoSize = True
        Me.lblPorcentaje.Location = New System.Drawing.Point(22, 97)
        Me.lblPorcentaje.Name = "lblPorcentaje"
        Me.lblPorcentaje.Size = New System.Drawing.Size(49, 13)
        Me.lblPorcentaje.TabIndex = 3
        Me.lblPorcentaje.Text = "Progreso"
        Me.lblPorcentaje.Visible = False
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(40, 138)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(31, 13)
        Me.lblTotal.TabIndex = 4
        Me.lblTotal.Text = "Total"
        Me.lblTotal.Visible = False
        '
        'pbPorcentaje
        '
        Me.pbPorcentaje.Location = New System.Drawing.Point(90, 87)
        Me.pbPorcentaje.Name = "pbPorcentaje"
        Me.pbPorcentaje.Size = New System.Drawing.Size(430, 23)
        Me.pbPorcentaje.TabIndex = 5
        Me.pbPorcentaje.Visible = False
        '
        'pbTotal
        '
        Me.pbTotal.Location = New System.Drawing.Point(90, 128)
        Me.pbTotal.Name = "pbTotal"
        Me.pbTotal.Size = New System.Drawing.Size(430, 23)
        Me.pbTotal.TabIndex = 6
        Me.pbTotal.Visible = False
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Location = New System.Drawing.Point(22, 30)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(48, 13)
        Me.lblEmpresa.TabIndex = 7
        Me.lblEmpresa.Text = "Empresa"
        Me.lblEmpresa.Visible = False
        '
        'frmImportarMilenium
        '
        Me.AcceptButton = Me.btnIniciar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(532, 209)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblEmpresa)
        Me.Controls.Add(Me.pbTotal)
        Me.Controls.Add(Me.pbPorcentaje)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblPorcentaje)
        Me.Controls.Add(Me.lblTabla)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnIniciar)
        Me.Name = "frmImportarMilenium"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Importar Milenium V02/18"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnIniciar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents lblTabla As System.Windows.Forms.Label
    Friend WithEvents lblPorcentaje As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents pbPorcentaje As System.Windows.Forms.ProgressBar
    Friend WithEvents pbTotal As System.Windows.Forms.ProgressBar
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
End Class

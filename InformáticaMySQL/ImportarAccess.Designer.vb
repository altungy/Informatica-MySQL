<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImportarAccess
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
        Me.pbPorcentaje = New System.Windows.Forms.ProgressBar()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnIniciar = New System.Windows.Forms.Button()
        Me.lblTítulo = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'pbPorcentaje
        '
        Me.pbPorcentaje.Location = New System.Drawing.Point(12, 40)
        Me.pbPorcentaje.Name = "pbPorcentaje"
        Me.pbPorcentaje.Size = New System.Drawing.Size(430, 23)
        Me.pbPorcentaje.TabIndex = 0
        Me.pbPorcentaje.Visible = False
        '
        'btnSalir
        '
        Me.btnSalir.DialogResult = DialogResult.Cancel
        Me.btnSalir.Location = New System.Drawing.Point(208, 77)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnIniciar
        '
        Me.btnIniciar.Location = New System.Drawing.Point(128, 77)
        Me.btnIniciar.Name = "btnIniciar"
        Me.btnIniciar.Size = New System.Drawing.Size(75, 23)
        Me.btnIniciar.TabIndex = 1
        Me.btnIniciar.Text = "&Iniciar"
        Me.btnIniciar.UseVisualStyleBackColor = True
        '
        'lblTítulo
        '
        Me.lblTítulo.AutoSize = True
        Me.lblTítulo.Location = New System.Drawing.Point(12, 9)
        Me.lblTítulo.Name = "lblTítulo"
        Me.lblTítulo.Size = New System.Drawing.Size(0, 13)
        Me.lblTítulo.TabIndex = 3
        '
        'FrmImportarAccess
        '
        Me.AcceptButton = Me.btnIniciar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(451, 109)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblTítulo)
        Me.Controls.Add(Me.pbPorcentaje)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnIniciar)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmImportarAccess"
        Me.Text = "Importar Access V03/18"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbPorcentaje As System.Windows.Forms.ProgressBar
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnIniciar As System.Windows.Forms.Button
    Friend WithEvents lblTítulo As System.Windows.Forms.Label
End Class

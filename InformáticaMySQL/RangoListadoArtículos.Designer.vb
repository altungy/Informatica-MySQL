<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmRangoListadoArtículos
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nudInicio = New System.Windows.Forms.NumericUpDown()
        Me.nudFin = New System.Windows.Forms.NumericUpDown()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        CType(Me.nudInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudFin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código inicio"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(28, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Código fin"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudInicio
        '
        Me.nudInicio.Location = New System.Drawing.Point(98, 18)
        Me.nudInicio.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.nudInicio.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudInicio.Name = "nudInicio"
        Me.nudInicio.Size = New System.Drawing.Size(62, 20)
        Me.nudInicio.TabIndex = 2
        Me.nudInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudInicio.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nudFin
        '
        Me.nudFin.Location = New System.Drawing.Point(98, 50)
        Me.nudFin.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.nudFin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudFin.Name = "nudFin"
        Me.nudFin.Size = New System.Drawing.Size(62, 20)
        Me.nudFin.TabIndex = 3
        Me.nudFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudFin.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(12, 98)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(98, 98)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'FrmRangoListadoArtículos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(194, 132)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.nudFin)
        Me.Controls.Add(Me.nudInicio)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmRangoListadoArtículos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.nudInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudFin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents nudInicio As NumericUpDown
    Friend WithEvents nudFin As NumericUpDown
    Friend WithEvents btnAceptar As Button
    Friend WithEvents btnCancelar As Button
End Class

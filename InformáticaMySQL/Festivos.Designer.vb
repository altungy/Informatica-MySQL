<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFestivos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFestivos))
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.txtFestivos = New System.Windows.Forms.RichTextBox()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnFecha = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(131, 399)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 26
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'txtFestivos
        '
        Me.txtFestivos.BackColor = System.Drawing.Color.White
        Me.txtFestivos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFestivos.Location = New System.Drawing.Point(12, 48)
        Me.txtFestivos.Name = "txtFestivos"
        Me.txtFestivos.ReadOnly = True
        Me.txtFestivos.Size = New System.Drawing.Size(307, 316)
        Me.txtFestivos.TabIndex = 25
        Me.txtFestivos.Text = ""
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.Color.White
        Me.txtFecha.Location = New System.Drawing.Point(75, 10)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(65, 20)
        Me.txtFecha.TabIndex = 23
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(31, 12)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(42, 13)
        Me.Label16.TabIndex = 22
        Me.Label16.Text = "Fecha"
        '
        'btnFecha
        '
        Me.btnFecha.Image = CType(resources.GetObject("btnFecha.Image"), System.Drawing.Image)
        Me.btnFecha.Location = New System.Drawing.Point(145, 8)
        Me.btnFecha.Margin = New System.Windows.Forms.Padding(2)
        Me.btnFecha.Name = "btnFecha"
        Me.btnFecha.Size = New System.Drawing.Size(21, 23)
        Me.btnFecha.TabIndex = 24
        Me.btnFecha.UseVisualStyleBackColor = True
        '
        'frmFestivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(335, 436)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.txtFestivos)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.btnFecha)
        Me.Name = "frmFestivos"
        Me.Text = "Festivos V01/19"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSalir As Button
    Friend WithEvents txtFestivos As RichTextBox
    Friend WithEvents txtFecha As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents btnFecha As Button
End Class

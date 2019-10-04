<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIncidenciasPeriodo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIncidenciasPeriodo))
        Me.txtInicio = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnInicio = New System.Windows.Forms.Button()
        Me.txtFin = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnFin = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtInicio
        '
        Me.txtInicio.BackColor = System.Drawing.Color.White
        Me.txtInicio.Location = New System.Drawing.Point(57, 19)
        Me.txtInicio.Name = "txtInicio"
        Me.txtInicio.Size = New System.Drawing.Size(65, 20)
        Me.txtInicio.TabIndex = 1
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(13, 21)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(38, 13)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Inicio"
        '
        'btnInicio
        '
        Me.btnInicio.Image = CType(resources.GetObject("btnInicio.Image"), System.Drawing.Image)
        Me.btnInicio.Location = New System.Drawing.Point(127, 17)
        Me.btnInicio.Margin = New System.Windows.Forms.Padding(2)
        Me.btnInicio.Name = "btnInicio"
        Me.btnInicio.Size = New System.Drawing.Size(21, 23)
        Me.btnInicio.TabIndex = 2
        Me.btnInicio.UseVisualStyleBackColor = True
        '
        'txtFin
        '
        Me.txtFin.BackColor = System.Drawing.Color.White
        Me.txtFin.Location = New System.Drawing.Point(223, 19)
        Me.txtFin.Name = "txtFin"
        Me.txtFin.Size = New System.Drawing.Size(65, 20)
        Me.txtFin.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(193, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Fin"
        '
        'btnFin
        '
        Me.btnFin.Image = CType(resources.GetObject("btnFin.Image"), System.Drawing.Image)
        Me.btnFin.Location = New System.Drawing.Point(293, 17)
        Me.btnFin.Margin = New System.Windows.Forms.Padding(2)
        Me.btnFin.Name = "btnFin"
        Me.btnFin.Size = New System.Drawing.Size(21, 23)
        Me.btnFin.TabIndex = 5
        Me.btnFin.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(82, 83)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(177, 83)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 7
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmIncidenciasPeriodo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(333, 118)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtFin)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnFin)
        Me.Controls.Add(Me.txtInicio)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.btnInicio)
        Me.Name = "frmIncidenciasPeriodo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Incidencias resueltas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtInicio As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents btnInicio As Button
    Friend WithEvents txtFin As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnFin As Button
    Friend WithEvents btnAceptar As Button
    Friend WithEvents btnSalir As Button
End Class

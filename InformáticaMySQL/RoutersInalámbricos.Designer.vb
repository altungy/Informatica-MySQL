<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRoutersInalámbricos
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
        Me.components = New System.ComponentModel.Container()
        Me.lvwRouters = New System.Windows.Forms.ListView()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.cmRouters = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AgregarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.txtSubred = New System.Windows.Forms.TextBox()
        Me.comboTiendas = New System.Windows.Forms.ComboBox()
        Me.cmRouters.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvwRouters
        '
        Me.lvwRouters.FullRowSelect = True
        Me.lvwRouters.GridLines = True
        Me.lvwRouters.Location = New System.Drawing.Point(29, 20)
        Me.lvwRouters.Margin = New System.Windows.Forms.Padding(2)
        Me.lvwRouters.MultiSelect = False
        Me.lvwRouters.Name = "lvwRouters"
        Me.lvwRouters.Size = New System.Drawing.Size(320, 160)
        Me.lvwRouters.TabIndex = 0
        Me.lvwRouters.UseCompatibleStateImageBehavior = False
        Me.lvwRouters.View = System.Windows.Forms.View.Details
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(152, 229)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 4
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'cmRouters
        '
        Me.cmRouters.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgregarToolStripMenuItem, Me.ModificarToolStripMenuItem, Me.EliminarToolStripMenuItem})
        Me.cmRouters.Name = "cmRouters"
        Me.cmRouters.Size = New System.Drawing.Size(126, 70)
        '
        'AgregarToolStripMenuItem
        '
        Me.AgregarToolStripMenuItem.Name = "AgregarToolStripMenuItem"
        Me.AgregarToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AgregarToolStripMenuItem.Text = "&Agregar"
        '
        'ModificarToolStripMenuItem
        '
        Me.ModificarToolStripMenuItem.Name = "ModificarToolStripMenuItem"
        Me.ModificarToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ModificarToolStripMenuItem.Text = "&Modificar"
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.EliminarToolStripMenuItem.Text = "&Eliminar"
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(71, 229)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        Me.btnAceptar.Visible = False
        '
        'txtSubred
        '
        Me.txtSubred.BackColor = System.Drawing.Color.White
        Me.txtSubred.Location = New System.Drawing.Point(38, 193)
        Me.txtSubred.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSubred.MaxLength = 15
        Me.txtSubred.Name = "txtSubred"
        Me.txtSubred.Size = New System.Drawing.Size(84, 20)
        Me.txtSubred.TabIndex = 1
        Me.txtSubred.Visible = False
        '
        'comboTiendas
        '
        Me.comboTiendas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.comboTiendas.FormattingEnabled = True
        Me.comboTiendas.Location = New System.Drawing.Point(127, 192)
        Me.comboTiendas.Name = "comboTiendas"
        Me.comboTiendas.Size = New System.Drawing.Size(222, 21)
        Me.comboTiendas.TabIndex = 2
        Me.comboTiendas.Visible = False
        '
        'FrmRoutersInalámbricos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(379, 266)
        Me.ControlBox = False
        Me.Controls.Add(Me.comboTiendas)
        Me.Controls.Add(Me.txtSubred)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.lvwRouters)
        Me.Name = "FrmRoutersInalámbricos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Routers Inalámbricos V10/18"
        Me.cmRouters.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lvwRouters As ListView
    Friend WithEvents btnSalir As Button
    Friend WithEvents cmRouters As ContextMenuStrip
    Friend WithEvents AgregarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModificarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnAceptar As Button
    Friend WithEvents txtSubred As TextBox
    Friend WithEvents comboTiendas As ComboBox
End Class

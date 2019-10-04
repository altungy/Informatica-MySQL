<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRangoFechas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRangoFechas))
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.txtFin = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtInicio = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnInicio = New System.Windows.Forms.Button()
        Me.btnFin = New System.Windows.Forms.Button()
        Me.txtAño = New System.Windows.Forms.TextBox()
        Me.btnAnterior = New System.Windows.Forms.Button()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnDiciembre = New System.Windows.Forms.Button()
        Me.btnNoviembre = New System.Windows.Forms.Button()
        Me.btnOctubre = New System.Windows.Forms.Button()
        Me.btnSeptiembre = New System.Windows.Forms.Button()
        Me.btnAgosto = New System.Windows.Forms.Button()
        Me.btnJulio = New System.Windows.Forms.Button()
        Me.btnJunio = New System.Windows.Forms.Button()
        Me.btnMayo = New System.Windows.Forms.Button()
        Me.btnAbril = New System.Windows.Forms.Button()
        Me.btnMarzo = New System.Windows.Forms.Button()
        Me.btnFebrero = New System.Windows.Forms.Button()
        Me.btnEnero = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(123, 121)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(100, 28)
        Me.btnCancelar.TabIndex = 11
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(13, 121)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(100, 28)
        Me.btnAceptar.TabIndex = 10
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'txtFin
        '
        Me.txtFin.BackColor = System.Drawing.Color.White
        Me.txtFin.Location = New System.Drawing.Point(87, 85)
        Me.txtFin.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFin.Name = "txtFin"
        Me.txtFin.Size = New System.Drawing.Size(85, 22)
        Me.txtFin.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(49, 87)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Fin"
        '
        'txtInicio
        '
        Me.txtInicio.BackColor = System.Drawing.Color.White
        Me.txtInicio.Location = New System.Drawing.Point(87, 46)
        Me.txtInicio.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtInicio.Name = "txtInicio"
        Me.txtInicio.Size = New System.Drawing.Size(85, 22)
        Me.txtInicio.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(33, 49)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Inicio"
        '
        'btnInicio
        '
        Me.btnInicio.Image = CType(resources.GetObject("btnInicio.Image"), System.Drawing.Image)
        Me.btnInicio.Location = New System.Drawing.Point(179, 44)
        Me.btnInicio.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnInicio.Name = "btnInicio"
        Me.btnInicio.Size = New System.Drawing.Size(28, 28)
        Me.btnInicio.TabIndex = 2
        Me.btnInicio.UseVisualStyleBackColor = True
        '
        'btnFin
        '
        Me.btnFin.Image = CType(resources.GetObject("btnFin.Image"), System.Drawing.Image)
        Me.btnFin.Location = New System.Drawing.Point(179, 82)
        Me.btnFin.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFin.Name = "btnFin"
        Me.btnFin.Size = New System.Drawing.Size(28, 28)
        Me.btnFin.TabIndex = 5
        Me.btnFin.UseVisualStyleBackColor = True
        '
        'txtAño
        '
        Me.txtAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAño.Location = New System.Drawing.Point(328, 12)
        Me.txtAño.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAño.Name = "txtAño"
        Me.txtAño.ReadOnly = True
        Me.txtAño.Size = New System.Drawing.Size(53, 22)
        Me.txtAño.TabIndex = 7
        Me.txtAño.Text = "2012"
        Me.txtAño.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnAnterior
        '
        Me.btnAnterior.BackColor = System.Drawing.Color.White
        Me.btnAnterior.FlatAppearance.BorderSize = 0
        Me.btnAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAnterior.Image = Global.InformáticaMySQL.My.Resources.Resources.back
        Me.btnAnterior.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAnterior.Location = New System.Drawing.Point(300, 12)
        Me.btnAnterior.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(21, 22)
        Me.btnAnterior.TabIndex = 6
        Me.btnAnterior.UseVisualStyleBackColor = False
        '
        'btnSiguiente
        '
        Me.btnSiguiente.BackColor = System.Drawing.Color.White
        Me.btnSiguiente.FlatAppearance.BorderSize = 0
        Me.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSiguiente.Image = Global.InformáticaMySQL.My.Resources.Resources.siguiente
        Me.btnSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSiguiente.Location = New System.Drawing.Point(388, 14)
        Me.btnSiguiente.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(21, 22)
        Me.btnSiguiente.TabIndex = 8
        Me.btnSiguiente.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.btnDiciembre)
        Me.GroupBox1.Controls.Add(Me.btnNoviembre)
        Me.GroupBox1.Controls.Add(Me.btnOctubre)
        Me.GroupBox1.Controls.Add(Me.btnSeptiembre)
        Me.GroupBox1.Controls.Add(Me.btnAgosto)
        Me.GroupBox1.Controls.Add(Me.btnJulio)
        Me.GroupBox1.Controls.Add(Me.btnJunio)
        Me.GroupBox1.Controls.Add(Me.btnMayo)
        Me.GroupBox1.Controls.Add(Me.btnAbril)
        Me.GroupBox1.Controls.Add(Me.btnMarzo)
        Me.GroupBox1.Controls.Add(Me.btnFebrero)
        Me.GroupBox1.Controls.Add(Me.btnEnero)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(241, 39)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(211, 117)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'btnDiciembre
        '
        Me.btnDiciembre.BackColor = System.Drawing.Color.White
        Me.btnDiciembre.Location = New System.Drawing.Point(159, 80)
        Me.btnDiciembre.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnDiciembre.Name = "btnDiciembre"
        Me.btnDiciembre.Size = New System.Drawing.Size(44, 30)
        Me.btnDiciembre.TabIndex = 11
        Me.btnDiciembre.Text = "&Dic"
        Me.btnDiciembre.UseVisualStyleBackColor = False
        '
        'btnNoviembre
        '
        Me.btnNoviembre.BackColor = System.Drawing.Color.White
        Me.btnNoviembre.Location = New System.Drawing.Point(109, 80)
        Me.btnNoviembre.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnNoviembre.Name = "btnNoviembre"
        Me.btnNoviembre.Size = New System.Drawing.Size(44, 30)
        Me.btnNoviembre.TabIndex = 10
        Me.btnNoviembre.Text = "&Nov"
        Me.btnNoviembre.UseVisualStyleBackColor = False
        '
        'btnOctubre
        '
        Me.btnOctubre.BackColor = System.Drawing.Color.White
        Me.btnOctubre.Location = New System.Drawing.Point(59, 80)
        Me.btnOctubre.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnOctubre.Name = "btnOctubre"
        Me.btnOctubre.Size = New System.Drawing.Size(44, 30)
        Me.btnOctubre.TabIndex = 9
        Me.btnOctubre.Text = "&Oct"
        Me.btnOctubre.UseVisualStyleBackColor = False
        '
        'btnSeptiembre
        '
        Me.btnSeptiembre.BackColor = System.Drawing.Color.White
        Me.btnSeptiembre.Location = New System.Drawing.Point(9, 80)
        Me.btnSeptiembre.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSeptiembre.Name = "btnSeptiembre"
        Me.btnSeptiembre.Size = New System.Drawing.Size(44, 30)
        Me.btnSeptiembre.TabIndex = 8
        Me.btnSeptiembre.Text = "&Sep"
        Me.btnSeptiembre.UseVisualStyleBackColor = False
        '
        'btnAgosto
        '
        Me.btnAgosto.BackColor = System.Drawing.Color.White
        Me.btnAgosto.Location = New System.Drawing.Point(159, 46)
        Me.btnAgosto.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAgosto.Name = "btnAgosto"
        Me.btnAgosto.Size = New System.Drawing.Size(44, 30)
        Me.btnAgosto.TabIndex = 7
        Me.btnAgosto.Text = "A&go"
        Me.btnAgosto.UseVisualStyleBackColor = False
        '
        'btnJulio
        '
        Me.btnJulio.BackColor = System.Drawing.Color.White
        Me.btnJulio.Location = New System.Drawing.Point(109, 46)
        Me.btnJulio.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnJulio.Name = "btnJulio"
        Me.btnJulio.Size = New System.Drawing.Size(44, 30)
        Me.btnJulio.TabIndex = 6
        Me.btnJulio.Text = "J&ul"
        Me.btnJulio.UseVisualStyleBackColor = False
        '
        'btnJunio
        '
        Me.btnJunio.BackColor = System.Drawing.Color.White
        Me.btnJunio.Location = New System.Drawing.Point(59, 46)
        Me.btnJunio.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnJunio.Name = "btnJunio"
        Me.btnJunio.Size = New System.Drawing.Size(44, 30)
        Me.btnJunio.TabIndex = 5
        Me.btnJunio.Text = "&Jun"
        Me.btnJunio.UseVisualStyleBackColor = False
        '
        'btnMayo
        '
        Me.btnMayo.BackColor = System.Drawing.Color.White
        Me.btnMayo.Location = New System.Drawing.Point(9, 46)
        Me.btnMayo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnMayo.Name = "btnMayo"
        Me.btnMayo.Size = New System.Drawing.Size(44, 30)
        Me.btnMayo.TabIndex = 4
        Me.btnMayo.Text = "Ma&y"
        Me.btnMayo.UseVisualStyleBackColor = False
        '
        'btnAbril
        '
        Me.btnAbril.BackColor = System.Drawing.Color.White
        Me.btnAbril.Location = New System.Drawing.Point(159, 10)
        Me.btnAbril.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAbril.Name = "btnAbril"
        Me.btnAbril.Size = New System.Drawing.Size(44, 30)
        Me.btnAbril.TabIndex = 3
        Me.btnAbril.Text = "A&br"
        Me.btnAbril.UseVisualStyleBackColor = False
        '
        'btnMarzo
        '
        Me.btnMarzo.BackColor = System.Drawing.Color.White
        Me.btnMarzo.Location = New System.Drawing.Point(109, 10)
        Me.btnMarzo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnMarzo.Name = "btnMarzo"
        Me.btnMarzo.Size = New System.Drawing.Size(44, 30)
        Me.btnMarzo.TabIndex = 2
        Me.btnMarzo.Text = "&Mar"
        Me.btnMarzo.UseVisualStyleBackColor = False
        '
        'btnFebrero
        '
        Me.btnFebrero.BackColor = System.Drawing.Color.White
        Me.btnFebrero.Location = New System.Drawing.Point(59, 10)
        Me.btnFebrero.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFebrero.Name = "btnFebrero"
        Me.btnFebrero.Size = New System.Drawing.Size(44, 30)
        Me.btnFebrero.TabIndex = 1
        Me.btnFebrero.Text = "&Feb"
        Me.btnFebrero.UseVisualStyleBackColor = False
        '
        'btnEnero
        '
        Me.btnEnero.BackColor = System.Drawing.Color.White
        Me.btnEnero.Location = New System.Drawing.Point(9, 10)
        Me.btnEnero.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEnero.Name = "btnEnero"
        Me.btnEnero.Size = New System.Drawing.Size(44, 30)
        Me.btnEnero.TabIndex = 0
        Me.btnEnero.Text = "&Ene"
        Me.btnEnero.UseVisualStyleBackColor = False
        '
        'frmRangoFechas
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(461, 170)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSiguiente)
        Me.Controls.Add(Me.btnAnterior)
        Me.Controls.Add(Me.txtAño)
        Me.Controls.Add(Me.btnFin)
        Me.Controls.Add(Me.btnInicio)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtFin)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtInicio)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmRangoFechas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtFin As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtInicio As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnInicio As System.Windows.Forms.Button
    Friend WithEvents btnFin As System.Windows.Forms.Button
    Friend WithEvents txtAño As System.Windows.Forms.TextBox
    Friend WithEvents btnAnterior As System.Windows.Forms.Button
    Friend WithEvents btnSiguiente As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDiciembre As System.Windows.Forms.Button
    Friend WithEvents btnNoviembre As System.Windows.Forms.Button
    Friend WithEvents btnOctubre As System.Windows.Forms.Button
    Friend WithEvents btnSeptiembre As System.Windows.Forms.Button
    Friend WithEvents btnAgosto As System.Windows.Forms.Button
    Friend WithEvents btnJulio As System.Windows.Forms.Button
    Friend WithEvents btnJunio As System.Windows.Forms.Button
    Friend WithEvents btnMayo As System.Windows.Forms.Button
    Friend WithEvents btnAbril As System.Windows.Forms.Button
    Friend WithEvents btnMarzo As System.Windows.Forms.Button
    Friend WithEvents btnFebrero As System.Windows.Forms.Button
    Friend WithEvents btnEnero As System.Windows.Forms.Button
End Class

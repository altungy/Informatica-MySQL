<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParámetros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmParámetros))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTeamViewer = New System.Windows.Forms.TextBox()
        Me.txtUVNC = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnTeamViewer = New System.Windows.Forms.Button()
        Me.btnUVNC = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnTightVNC = New System.Windows.Forms.Button()
        Me.txtTightVNC = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnMySQLWorkbench = New System.Windows.Forms.Button()
        Me.txtMySQLWorkbench = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnAccess = New System.Windows.Forms.Button()
        Me.txtAccess = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkRevisarCorreo = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(52, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "TeamViewer"
        '
        'txtTeamViewer
        '
        Me.txtTeamViewer.Location = New System.Drawing.Point(130, 14)
        Me.txtTeamViewer.Margin = New System.Windows.Forms.Padding(2)
        Me.txtTeamViewer.Name = "txtTeamViewer"
        Me.txtTeamViewer.Size = New System.Drawing.Size(176, 20)
        Me.txtTeamViewer.TabIndex = 1
        '
        'txtUVNC
        '
        Me.txtUVNC.Location = New System.Drawing.Point(130, 41)
        Me.txtUVNC.Margin = New System.Windows.Forms.Padding(2)
        Me.txtUVNC.Name = "txtUVNC"
        Me.txtUVNC.Size = New System.Drawing.Size(176, 20)
        Me.txtUVNC.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(86, 45)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "UVNC"
        '
        'btnTeamViewer
        '
        Me.btnTeamViewer.Image = CType(resources.GetObject("btnTeamViewer.Image"), System.Drawing.Image)
        Me.btnTeamViewer.Location = New System.Drawing.Point(310, 12)
        Me.btnTeamViewer.Margin = New System.Windows.Forms.Padding(2)
        Me.btnTeamViewer.Name = "btnTeamViewer"
        Me.btnTeamViewer.Size = New System.Drawing.Size(20, 22)
        Me.btnTeamViewer.TabIndex = 2
        Me.btnTeamViewer.UseVisualStyleBackColor = True
        '
        'btnUVNC
        '
        Me.btnUVNC.Image = Global.InformáticaMySQL.My.Resources.Resources.folder
        Me.btnUVNC.Location = New System.Drawing.Point(310, 39)
        Me.btnUVNC.Margin = New System.Windows.Forms.Padding(2)
        Me.btnUVNC.Name = "btnUVNC"
        Me.btnUVNC.Size = New System.Drawing.Size(20, 22)
        Me.btnUVNC.TabIndex = 5
        Me.btnUVNC.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(178, 201)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(65, 22)
        Me.btnCancelar.TabIndex = 17
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(112, 201)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(56, 22)
        Me.btnAceptar.TabIndex = 16
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnTightVNC
        '
        Me.btnTightVNC.Image = Global.InformáticaMySQL.My.Resources.Resources.folder
        Me.btnTightVNC.Location = New System.Drawing.Point(310, 72)
        Me.btnTightVNC.Margin = New System.Windows.Forms.Padding(2)
        Me.btnTightVNC.Name = "btnTightVNC"
        Me.btnTightVNC.Size = New System.Drawing.Size(20, 22)
        Me.btnTightVNC.TabIndex = 8
        Me.btnTightVNC.UseVisualStyleBackColor = True
        '
        'txtTightVNC
        '
        Me.txtTightVNC.Location = New System.Drawing.Point(130, 74)
        Me.txtTightVNC.Margin = New System.Windows.Forms.Padding(2)
        Me.txtTightVNC.Name = "txtTightVNC"
        Me.txtTightVNC.Size = New System.Drawing.Size(176, 20)
        Me.txtTightVNC.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(67, 77)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "TightVNC"
        '
        'btnMySQLWorkbench
        '
        Me.btnMySQLWorkbench.Image = Global.InformáticaMySQL.My.Resources.Resources.folder
        Me.btnMySQLWorkbench.Location = New System.Drawing.Point(310, 96)
        Me.btnMySQLWorkbench.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMySQLWorkbench.Name = "btnMySQLWorkbench"
        Me.btnMySQLWorkbench.Size = New System.Drawing.Size(20, 22)
        Me.btnMySQLWorkbench.TabIndex = 11
        Me.btnMySQLWorkbench.UseVisualStyleBackColor = True
        '
        'txtMySQLWorkbench
        '
        Me.txtMySQLWorkbench.Location = New System.Drawing.Point(130, 98)
        Me.txtMySQLWorkbench.Margin = New System.Windows.Forms.Padding(2)
        Me.txtMySQLWorkbench.Name = "txtMySQLWorkbench"
        Me.txtMySQLWorkbench.Size = New System.Drawing.Size(176, 20)
        Me.txtMySQLWorkbench.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 101)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "MySQL Workbench"
        '
        'btnAccess
        '
        Me.btnAccess.Image = Global.InformáticaMySQL.My.Resources.Resources.folder
        Me.btnAccess.Location = New System.Drawing.Point(310, 130)
        Me.btnAccess.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAccess.Name = "btnAccess"
        Me.btnAccess.Size = New System.Drawing.Size(20, 22)
        Me.btnAccess.TabIndex = 14
        Me.btnAccess.UseVisualStyleBackColor = True
        Me.btnAccess.Visible = False
        '
        'txtAccess
        '
        Me.txtAccess.Location = New System.Drawing.Point(130, 132)
        Me.txtAccess.Margin = New System.Windows.Forms.Padding(2)
        Me.txtAccess.Name = "txtAccess"
        Me.txtAccess.Size = New System.Drawing.Size(176, 20)
        Me.txtAccess.TabIndex = 13
        Me.txtAccess.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(43, 135)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Datos Access"
        Me.Label5.Visible = False
        '
        'chkRevisarCorreo
        '
        Me.chkRevisarCorreo.AutoSize = True
        Me.chkRevisarCorreo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRevisarCorreo.Location = New System.Drawing.Point(130, 167)
        Me.chkRevisarCorreo.Name = "chkRevisarCorreo"
        Me.chkRevisarCorreo.Size = New System.Drawing.Size(109, 17)
        Me.chkRevisarCorreo.TabIndex = 15
        Me.chkRevisarCorreo.Text = "Revisar correo"
        Me.chkRevisarCorreo.UseVisualStyleBackColor = True
        '
        'frmParámetros
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(348, 234)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkRevisarCorreo)
        Me.Controls.Add(Me.btnAccess)
        Me.Controls.Add(Me.txtAccess)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnMySQLWorkbench)
        Me.Controls.Add(Me.txtMySQLWorkbench)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnTightVNC)
        Me.Controls.Add(Me.txtTightVNC)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnUVNC)
        Me.Controls.Add(Me.btnTeamViewer)
        Me.Controls.Add(Me.txtUVNC)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTeamViewer)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmParámetros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Parámetros"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTeamViewer As System.Windows.Forms.TextBox
    Friend WithEvents txtUVNC As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnTeamViewer As System.Windows.Forms.Button
    Friend WithEvents btnUVNC As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnTightVNC As Button
    Friend WithEvents txtTightVNC As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnMySQLWorkbench As Button
    Friend WithEvents txtMySQLWorkbench As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnAccess As System.Windows.Forms.Button
    Friend WithEvents txtAccess As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkRevisarCorreo As CheckBox
End Class

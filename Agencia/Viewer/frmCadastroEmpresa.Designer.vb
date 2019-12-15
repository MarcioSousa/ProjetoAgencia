<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroEmpresa
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.grpPrincipal = New System.Windows.Forms.GroupBox()
        Me.cmbCidade = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkCliente = New System.Windows.Forms.CheckBox()
        Me.chkAtivo = New System.Windows.Forms.CheckBox()
        Me.txtNomeFan = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRazSoc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSair = New System.Windows.Forms.Button()
        Me.btnGravar = New System.Windows.Forms.Button()
        Me.pPrincipal = New System.Windows.Forms.Panel()
        Me.btnNovaCidade = New System.Windows.Forms.Button()
        Me.grpPrincipal.SuspendLayout()
        Me.pPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpPrincipal
        '
        Me.grpPrincipal.BackColor = System.Drawing.Color.White
        Me.grpPrincipal.Controls.Add(Me.btnNovaCidade)
        Me.grpPrincipal.Controls.Add(Me.cmbCidade)
        Me.grpPrincipal.Controls.Add(Me.Label7)
        Me.grpPrincipal.Controls.Add(Me.chkCliente)
        Me.grpPrincipal.Controls.Add(Me.chkAtivo)
        Me.grpPrincipal.Controls.Add(Me.txtNomeFan)
        Me.grpPrincipal.Controls.Add(Me.Label3)
        Me.grpPrincipal.Controls.Add(Me.txtRazSoc)
        Me.grpPrincipal.Controls.Add(Me.Label2)
        Me.grpPrincipal.Controls.Add(Me.txtCodigo)
        Me.grpPrincipal.Controls.Add(Me.Label1)
        Me.grpPrincipal.Location = New System.Drawing.Point(7, 55)
        Me.grpPrincipal.Name = "grpPrincipal"
        Me.grpPrincipal.Size = New System.Drawing.Size(948, 106)
        Me.grpPrincipal.TabIndex = 0
        Me.grpPrincipal.TabStop = False
        '
        'cmbCidade
        '
        Me.cmbCidade.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCidade.ForeColor = System.Drawing.Color.Blue
        Me.cmbCidade.FormattingEnabled = True
        Me.cmbCidade.Location = New System.Drawing.Point(748, 37)
        Me.cmbCidade.Name = "cmbCidade"
        Me.cmbCidade.Size = New System.Drawing.Size(191, 21)
        Me.cmbCidade.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(745, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Cidade:"
        '
        'chkCliente
        '
        Me.chkCliente.AutoSize = True
        Me.chkCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCliente.Location = New System.Drawing.Point(72, 64)
        Me.chkCliente.Name = "chkCliente"
        Me.chkCliente.Size = New System.Drawing.Size(65, 17)
        Me.chkCliente.TabIndex = 7
        Me.chkCliente.TabStop = False
        Me.chkCliente.Text = "Cliente"
        Me.chkCliente.UseVisualStyleBackColor = True
        '
        'chkAtivo
        '
        Me.chkAtivo.AutoSize = True
        Me.chkAtivo.Checked = True
        Me.chkAtivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAtivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAtivo.ForeColor = System.Drawing.Color.Red
        Me.chkAtivo.Location = New System.Drawing.Point(11, 63)
        Me.chkAtivo.Name = "chkAtivo"
        Me.chkAtivo.Size = New System.Drawing.Size(55, 17)
        Me.chkAtivo.TabIndex = 6
        Me.chkAtivo.TabStop = False
        Me.chkAtivo.Text = "Ativo"
        Me.chkAtivo.UseVisualStyleBackColor = True
        '
        'txtNomeFan
        '
        Me.txtNomeFan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNomeFan.ForeColor = System.Drawing.Color.Blue
        Me.txtNomeFan.Location = New System.Drawing.Point(401, 37)
        Me.txtNomeFan.MaxLength = 100
        Me.txtNomeFan.Name = "txtNomeFan"
        Me.txtNomeFan.Size = New System.Drawing.Size(341, 20)
        Me.txtNomeFan.TabIndex = 1
        Me.txtNomeFan.Tag = "O"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(399, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Nome fantasia:"
        '
        'txtRazSoc
        '
        Me.txtRazSoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRazSoc.ForeColor = System.Drawing.Color.Blue
        Me.txtRazSoc.Location = New System.Drawing.Point(119, 37)
        Me.txtRazSoc.MaxLength = 100
        Me.txtRazSoc.Name = "txtRazSoc"
        Me.txtRazSoc.Size = New System.Drawing.Size(278, 20)
        Me.txtRazSoc.TabIndex = 0
        Me.txtRazSoc.Tag = "O"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(117, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Razão social:"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.ForeColor = System.Drawing.Color.Blue
        Me.txtCodigo.Location = New System.Drawing.Point(11, 37)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(100, 20)
        Me.txtCodigo.TabIndex = 1
        Me.txtCodigo.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo:"
        '
        'btnSair
        '
        Me.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSair.ForeColor = System.Drawing.Color.Blue
        Me.btnSair.Location = New System.Drawing.Point(7, 3)
        Me.btnSair.Name = "btnSair"
        Me.btnSair.Size = New System.Drawing.Size(66, 46)
        Me.btnSair.TabIndex = 4
        Me.btnSair.Text = "Sair"
        Me.btnSair.UseVisualStyleBackColor = True
        '
        'btnGravar
        '
        Me.btnGravar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGravar.ForeColor = System.Drawing.Color.Red
        Me.btnGravar.Location = New System.Drawing.Point(79, 3)
        Me.btnGravar.Name = "btnGravar"
        Me.btnGravar.Size = New System.Drawing.Size(75, 46)
        Me.btnGravar.TabIndex = 3
        Me.btnGravar.Text = "Gravar"
        Me.btnGravar.UseVisualStyleBackColor = True
        '
        'pPrincipal
        '
        Me.pPrincipal.Controls.Add(Me.btnSair)
        Me.pPrincipal.Controls.Add(Me.btnGravar)
        Me.pPrincipal.Controls.Add(Me.grpPrincipal)
        Me.pPrincipal.Location = New System.Drawing.Point(2, 8)
        Me.pPrincipal.Name = "pPrincipal"
        Me.pPrincipal.Size = New System.Drawing.Size(959, 167)
        Me.pPrincipal.TabIndex = 5
        '
        'btnNovaCidade
        '
        Me.btnNovaCidade.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNovaCidade.ForeColor = System.Drawing.Color.Blue
        Me.btnNovaCidade.Location = New System.Drawing.Point(748, 64)
        Me.btnNovaCidade.Name = "btnNovaCidade"
        Me.btnNovaCidade.Size = New System.Drawing.Size(130, 23)
        Me.btnNovaCidade.TabIndex = 10
        Me.btnNovaCidade.Text = "Nova cidade"
        Me.btnNovaCidade.UseVisualStyleBackColor = True
        '
        'frmCadastroEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(967, 182)
        Me.Controls.Add(Me.pPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmCadastroEmpresa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmCadastroEmpresa"
        Me.grpPrincipal.ResumeLayout(False)
        Me.grpPrincipal.PerformLayout()
        Me.pPrincipal.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpPrincipal As System.Windows.Forms.GroupBox
    Friend WithEvents chkCliente As System.Windows.Forms.CheckBox
    Friend WithEvents chkAtivo As System.Windows.Forms.CheckBox
    Friend WithEvents txtNomeFan As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRazSoc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSair As System.Windows.Forms.Button
    Friend WithEvents btnGravar As System.Windows.Forms.Button
    Friend WithEvents cmbCidade As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pPrincipal As System.Windows.Forms.Panel
    Friend WithEvents btnNovaCidade As System.Windows.Forms.Button
End Class

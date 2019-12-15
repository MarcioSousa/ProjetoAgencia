<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCidade
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
        Me.grpCidade = New System.Windows.Forms.GroupBox()
        Me.chkAtivo = New System.Windows.Forms.CheckBox()
        Me.txtUf = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCidade = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pPrincipal = New System.Windows.Forms.Panel()
        Me.btnGravar = New System.Windows.Forms.Button()
        Me.btnSair = New System.Windows.Forms.Button()
        Me.grpCidade.SuspendLayout()
        Me.pPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpCidade
        '
        Me.grpCidade.Controls.Add(Me.chkAtivo)
        Me.grpCidade.Controls.Add(Me.txtUf)
        Me.grpCidade.Controls.Add(Me.Label3)
        Me.grpCidade.Controls.Add(Me.txtCidade)
        Me.grpCidade.Controls.Add(Me.Label2)
        Me.grpCidade.Controls.Add(Me.txtCodigo)
        Me.grpCidade.Controls.Add(Me.Label1)
        Me.grpCidade.Location = New System.Drawing.Point(3, 71)
        Me.grpCidade.Name = "grpCidade"
        Me.grpCidade.Size = New System.Drawing.Size(506, 92)
        Me.grpCidade.TabIndex = 0
        Me.grpCidade.TabStop = False
        '
        'chkAtivo
        '
        Me.chkAtivo.AutoSize = True
        Me.chkAtivo.Checked = True
        Me.chkAtivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAtivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAtivo.ForeColor = System.Drawing.Color.Red
        Me.chkAtivo.Location = New System.Drawing.Point(10, 64)
        Me.chkAtivo.Name = "chkAtivo"
        Me.chkAtivo.Size = New System.Drawing.Size(55, 17)
        Me.chkAtivo.TabIndex = 6
        Me.chkAtivo.Text = "Ativo"
        Me.chkAtivo.UseVisualStyleBackColor = True
        '
        'txtUf
        '
        Me.txtUf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUf.ForeColor = System.Drawing.Color.Blue
        Me.txtUf.Location = New System.Drawing.Point(434, 36)
        Me.txtUf.Name = "txtUf"
        Me.txtUf.Size = New System.Drawing.Size(62, 20)
        Me.txtUf.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(431, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "UF:"
        '
        'txtCidade
        '
        Me.txtCidade.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCidade.ForeColor = System.Drawing.Color.Blue
        Me.txtCidade.Location = New System.Drawing.Point(101, 37)
        Me.txtCidade.Name = "txtCidade"
        Me.txtCidade.Size = New System.Drawing.Size(323, 20)
        Me.txtCidade.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(98, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Cidade:"
        '
        'txtCodigo
        '
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.ForeColor = System.Drawing.Color.Blue
        Me.txtCodigo.Location = New System.Drawing.Point(10, 37)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(81, 20)
        Me.txtCodigo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo:"
        '
        'pPrincipal
        '
        Me.pPrincipal.Controls.Add(Me.btnGravar)
        Me.pPrincipal.Controls.Add(Me.btnSair)
        Me.pPrincipal.Controls.Add(Me.grpCidade)
        Me.pPrincipal.Location = New System.Drawing.Point(3, 3)
        Me.pPrincipal.Name = "pPrincipal"
        Me.pPrincipal.Size = New System.Drawing.Size(514, 181)
        Me.pPrincipal.TabIndex = 1
        '
        'btnGravar
        '
        Me.btnGravar.BackColor = System.Drawing.Color.White
        Me.btnGravar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGravar.ForeColor = System.Drawing.Color.Red
        Me.btnGravar.Location = New System.Drawing.Point(86, 17)
        Me.btnGravar.Name = "btnGravar"
        Me.btnGravar.Size = New System.Drawing.Size(75, 48)
        Me.btnGravar.TabIndex = 3
        Me.btnGravar.Text = "Gravar"
        Me.btnGravar.UseVisualStyleBackColor = False
        '
        'btnSair
        '
        Me.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSair.ForeColor = System.Drawing.Color.Blue
        Me.btnSair.Location = New System.Drawing.Point(4, 17)
        Me.btnSair.Name = "btnSair"
        Me.btnSair.Size = New System.Drawing.Size(75, 48)
        Me.btnSair.TabIndex = 4
        Me.btnSair.Text = "Sair"
        Me.btnSair.UseVisualStyleBackColor = True
        '
        'frmCidade
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(520, 182)
        Me.Controls.Add(Me.pPrincipal)
        Me.Name = "frmCidade"
        Me.grpCidade.ResumeLayout(False)
        Me.grpCidade.PerformLayout()
        Me.pPrincipal.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpCidade As System.Windows.Forms.GroupBox
    Friend WithEvents txtCidade As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkAtivo As System.Windows.Forms.CheckBox
    Friend WithEvents txtUf As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pPrincipal As System.Windows.Forms.Panel
    Friend WithEvents btnGravar As System.Windows.Forms.Button
    Friend WithEvents btnSair As System.Windows.Forms.Button
End Class

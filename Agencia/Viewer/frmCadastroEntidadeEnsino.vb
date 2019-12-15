Imports DTO
Imports BLL

Public Class frmCadastroEntidadeEnsino

    Private _tipoOperacao As Char = ""

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Try
            Call CarregarCidades()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        _tipoOperacao = "N"

        Me.Text = "Cadastro de entidades de ensino [Novo registro]"
    End Sub

    Public Sub New(ByVal pEntidade As Entidade)
        InitializeComponent()

        Try
            Call CarregarCidades()

            Me.txtCodigo.Text = pEntidade.Codigo
            Me.txtNome.Text = pEntidade.Descricao
            Me.cmbCidade.Text = pEntidade.Cidade.Descricao
            Me.chkAtivo.Checked = IIf(pEntidade.Situacao = "A", True, False)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        _tipoOperacao = "A"

        Me.Text = "Cadastro de entidades de ensino [Alterar registro]"
    End Sub

    Private Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        If txtNome.Text = "" Then
            txtNome.BackColor = Color.Salmon
            MessageBox.Show("Campo obrigatorio nao preenchido", "Campo inválido", MessageBoxButtons.OK)
        End If

        Dim _entidade As New Entidade

        _entidade.Descricao = Me.txtNome.Text.ToUpper.Trim
        _entidade.Cidade = Me.cmbCidade.SelectedItem
        _entidade.Situacao = IIf(Me.chkAtivo.Checked, "A", "I")

        Try
            If _tipoOperacao = "N" Then
                RegrasDeNegocio.InserirEntidade(_entidade)
                Me.Close()
            Else
                _entidade.Codigo = Me.txtCodigo.Text

                RegrasDeNegocio.AlterarEntidade(_entidade)
                Me.Close()
            End If
        Catch ex As Exception
            If ex.Message = "-1" Then
                MessageBox.Show("Ocorreu um erro ao inserir a entidade: Esta entidade de ensino ja está cadastrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Ocorreu um erro ao inserir a entidade: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
        
    End Sub

    Private Sub CarregarCidades()
        Try
            Me.cmbCidade.DataSource = RegrasDeNegocio.GetCidades("")
            Me.cmbCidade.DisplayMember = "Descricao"
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub cmbCidade_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCidade.SelectedIndexChanged
        lblUF.Text = CType(cmbCidade.SelectedItem, Cidade).UF
    End Sub

    Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub

    Private Sub txtNome_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNome.KeyDown, cmbCidade.KeyDown
        If e.KeyData = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmCadastroEntidadeEnsino_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmCadastroEntidadeEnsino_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.pPrincipal.Left = (Me.Width / 2) - (pPrincipal.Width / 2)
    End Sub
End Class
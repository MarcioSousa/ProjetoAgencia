Imports DTO
Imports BLL

Public Class frmCadastroEmpresa
    Private _empresa As Empresa = Nothing
    Private _tipoOperacao As Char = ""
    Private _modoAlteracao As Boolean

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        Try
            Call CarregaListaCidades()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        _empresa = New Empresa

        Me.Text = "Cadastro de empresa[Novo registro]"
        Me._tipoOperacao = "N"
    End Sub

    Public Sub New(ByVal pEmpresa As Empresa)
        InitializeComponent()

        Try
            Call CarregaListaCidades()
            _empresa = pEmpresa

            Me.txtCodigo.Text = _empresa.Codigo
            Me.txtRazSoc.Text = _empresa.RazaoSocial
            Me.txtNomeFan.Text = _empresa.NomeFantasia
            Me.cmbCidade.Text = _empresa.Cidade.Descricao
            Me.chkAtivo.Checked = IIf(_empresa.Situacao = "A", True, False)
            Me.chkCliente.Checked = IIf(_empresa.Cliente = 1, True, False)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Me.Text = "Cadastro de empresa[Alterar registro]"
        Me._tipoOperacao = "A"
    End Sub

    Private Sub CarregaListaCidades()
        Try
            cmbCidade.DataSource = RegrasDeNegocio.GetCidades("")
            cmbCidade.DisplayMember = "Descricao"
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        Try
            _empresa.NomeFantasia = Me.txtNomeFan.Text.ToUpper.Trim
            _empresa.RazaoSocial = Me.txtRazSoc.Text.ToUpper.Trim
            _empresa.Situacao = IIf(Me.chkAtivo.Checked = True, "A", "I")
            _empresa.Cliente = IIf(Me.chkCliente.Checked = True, 1, 0)
            _empresa.Cidade = Me.cmbCidade.SelectedItem

            If _tipoOperacao = "N" Then
                RegrasDeNegocio.InserirEmpresa(_empresa)

                Me.Close()
            Else
                RegrasDeNegocio.AlterarEmpresa(_empresa)

                Me.Close()

            End If
        Catch ex As Exception
            If ex.Message = "-1" Then
                MessageBox.Show("Ja existe uma empresa com essas características.", "Duplicidade", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub

    Private Sub frmCadastroEmpresa_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not _empresa Is Nothing Then _empresa.Dispose()
    End Sub

    Private Sub cmbCidade_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCidade.Leave
        Dim combo As ComboBox = CType(sender, ComboBox)
        If combo.SelectedItem Is Nothing Then
            MessageBox.Show("Selecione uma cidade válida", "Cidade inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            combo.Focus()
        End If
    End Sub

    Private Sub cmbAreas_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim combo As ComboBox = CType(sender, ComboBox)
        If combo.SelectedItem Is Nothing Then
            MessageBox.Show("Selecione uma área válida", "área inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            combo.Focus()
        End If
    End Sub

    Private Sub cmbCargos_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim combo As ComboBox = CType(sender, ComboBox)
        If combo.SelectedItem Is Nothing Then
            MessageBox.Show("Selecione um cargo válido", "Cargo inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            combo.Focus()
        End If
    End Sub

    Private Sub LimparCampos()
        Me.txtRazSoc.Text = ""
        Me.txtNomeFan.Text = ""
    End Sub

    Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub

    Private Sub txtRazSoc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRazSoc.KeyDown, txtNomeFan.KeyDown, cmbCidade.KeyDown
        If e.KeyData = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnNovaCidade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNovaCidade.Click
        Dim _cidade As New frmCidade
        _cidade.ShowDialog()

        Call CarregaListaCidades()
    End Sub
End Class
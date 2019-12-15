Imports BLL
Imports DTO

Public Class frmCurso
    Private _tipoOperacao As Char = ""
    Private _entidade As Entidade = Nothing

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Try
            Call CarregarCursos()
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar lista de cursos " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        _tipoOperacao = "N"

        Me.Text = "Cadastro de cursos [Novo registro]"
    End Sub

    Private Sub CarregarCursos()
        Try
            Me.cmbDescricao.DataSource = RegrasDeNegocio.GetCursos("", "")
            Me.cmbDescricao.DisplayMember = "Descricao"
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub New(ByVal pCurso As Curso)
        InitializeComponent()

        Try
            Call CarregarCursos()

            Me.txtCodigo.Text = pCurso.Codigo
            Me.cmbDescricao.Text = pCurso.Descricao
            Me.cmbCategoria.SelectedIndex = pCurso.Categoria
            Me.txtEntidade.Text = pCurso.Entidade.Descricao & " - " & pCurso.Entidade.Cidade.Descricao & "(" & pCurso.Entidade.Cidade.UF & ")"
            Me.txtCargaHoraria.Text = pCurso.CargaHoraria
            Me.chkAtivo.Checked = IIf(pCurso.Situacao = "A", True, False)

            Me._entidade = pCurso.Entidade
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        _tipoOperacao = "A"

        Me.Text = "Cadastro de cursos [Alterar registro]"
    End Sub

    Private Sub btnDeletar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeletar.Click
        Call ZerarEntidade()
    End Sub

    Private Sub ZerarEntidade()
        _entidade = Nothing
        Me.txtEntidade.Text = ""
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim buscarEntidade As New frmBuscaEntidade
        buscarEntidade.ShowDialog()

        If Not buscarEntidade.Entidade Is Nothing Then
            Me._entidade = buscarEntidade.Entidade
            Me.txtEntidade.Text = _entidade.Descricao & " - " & _entidade.Cidade.Descricao & "(" & _entidade.Cidade.UF & ")"
        End If
    End Sub

    Private Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        If TemCamposInvalidos() Then
            MessageBox.Show("Existem campos obrigatorios em branco", "Campos em branco", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If _entidade Is Nothing Then
            MessageBox.Show("Selecione uma entidade de ensino", "Entidade inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Dim _curso As New Curso

        _curso.Descricao = Me.cmbDescricao.Text.ToUpper
        _curso.CargaHoraria = Me.txtCargaHoraria.Text
        _curso.Categoria = Me.cmbCategoria.SelectedIndex
        _curso.Situacao = CChar(IIf(chkAtivo.Checked, "A", "I"))

        _curso.Entidade = Me._entidade

        Try
            If _tipoOperacao = "N" Then
                RegrasDeNegocio.InserirCurso(_curso)

                Me.Close()
            Else
                _curso.Codigo = Me.txtCodigo.Text
                RegrasDeNegocio.AlterarCurso(_curso)

                Me.Close()
            End If
        Catch ex As Exception
            If ex.Message = "-1" Then
                MessageBox.Show("Ocorreu um erro ao salvar este registro: Ja existe um curso com essas caracsterísticas pra esta entidade de ensino", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub

    Private Sub LimparCampos()
        Dim campos = From campo In Me.GroupBox1.Controls Where TypeOf campo Is TextBox

        For Each campo As TextBox In campos
            If Not campo.Name = "txtEntidade" Then campo.Text = ""
        Next

        cmbCategoria.SelectedIndex = 0
    End Sub

    Private Function TemCamposInvalidos() As Boolean
        Dim _retorno As Boolean = False

        Dim campos = From campo In Me.GroupBox1.Controls Where TypeOf campo Is TextBox

        For Each campo As TextBox In campos
            If campo.Tag = "O" And campo.Text = "" Then
                campo.BackColor = Color.Salmon
                _retorno = True
            Else
                campo.BackColor = Color.White
            End If
        Next

        Return _retorno
    End Function

    Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub

    Private Sub frmCurso_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not _entidade Is Nothing Then _entidade.Dispose()
    End Sub

    Private Sub txtDescricao_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEntidade.KeyDown, txtCargaHoraria.KeyDown, cmbCategoria.KeyDown
        If e.KeyData = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmCurso_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.pPrincipal.Left = (Me.Width / 2) - (pPrincipal.Width / 2)
    End Sub
End Class
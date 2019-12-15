Imports DTO
Imports BLL
Imports Utilidades
Imports System.IO

Public Class frmCurriculo
    'objetos
    Private _candidato As Candidato = Nothing
    Private _curso As Curso = Nothing
    Private _cargo As CurriculoCargo = Nothing
    Private _cargoPretendido As CargoPretendidoCurriculo = Nothing

    'imagens/documentos
    Private _caminhoCurriculo As String = ""
    Private _caminhoCurriculo_2 As String = ""
    Private _caminhoCurriculo_3 As String = ""

    Private _caminhoDigitalizacaoCertificado As String = ""

    'controle do form
    Private _tipoOperacao As Char = ""

    Private _alteracaoCargo As Boolean
    Private _alterarCurso As Boolean
    Private _alterarCargoPretendido As Boolean

    'informações do curriculo
    Private _classificacao As Curriculo.TipoClassificação
    Private _escolaridade As Curriculo.NivelEscolaridade

    'informações sobre turnos
    Private _turno As Curriculo.TurnoDisponivel

    ' ''' <summary>
    ' ''' Novo registro
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Public Sub New()
    '    ' This call is required by the designer.
    '    InitializeComponent()
    '    ' Add any initialization after the InitializeComponent() call.
    '    _tipoOperacao = "N"

    '    Me.Text = "Cadastro de curriculo [Novo registro]"

    '    'habilita para buscar um candidato
    '    Me.btnSelecionarCandidato.Enabled = True

    '    'desabilita gravar
    '    Me.btnGravar.Enabled = False
    'End Sub

    ''' <summary>
    ''' Alteração de registro
    ''' </summary>
    ''' <param name="pCandidato"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal pCandidato As Candidato)
        InitializeComponent()

        Try
            _candidato = pCandidato

            lblCodigoNome.Text = _candidato.Codigo & " - " & _candidato.Nome & "(" & _candidato.Cidade.Descricao & "-" & _candidato.Cidade.UF & ")"

            'Call ListarCaracteristicas()

            'verifica se candidato NAO tem curriculo cadastrado
            If Not _candidato.Curriculo Is Nothing Then
                If _candidato.Curriculo.Classificacao = Curriculo.TipoClassificação.Bom Then
                    Me.optBom.Checked = True
                ElseIf _candidato.Curriculo.Classificacao = Curriculo.TipoClassificação.Excelente Then
                    Me.optExcelente.Checked = True
                ElseIf _candidato.Curriculo.Classificacao = Curriculo.TipoClassificação.Regular Then
                    Me.optRegular.Checked = True
                Else
                    Me.optRuim.Checked = True
                End If

                If _candidato.Curriculo.Escolaridade = Curriculo.NivelEscolaridade.Ensino_Fundamental_Completo Then
                    Me.optEnsinoFundamentalCompleto.Checked = True
                ElseIf _candidato.Curriculo.Escolaridade = Curriculo.NivelEscolaridade.Ensino_Fundamental_Incompleto Then
                    Me.optEnsinoFundamentalIncompleto.Checked = True
                ElseIf _candidato.Curriculo.Escolaridade = Curriculo.NivelEscolaridade.Ensino_Medio_Completo Then
                    Me.optEnsinoMedioCompleto.Checked = True
                ElseIf _candidato.Curriculo.Escolaridade = Curriculo.NivelEscolaridade.Ensino_Medio_Incompleto Then
                    Me.optEnsinoMedioIncompleto.Checked = True
                ElseIf _candidato.Curriculo.Escolaridade = Curriculo.NivelEscolaridade.Ensino_Superior_Completo Then
                    Me.optEnsinoSuperiorCompleto.Checked = True
                ElseIf _candidato.Curriculo.Escolaridade = Curriculo.NivelEscolaridade.Ensino_Superior_Incompleto Then
                    Me.optEnsinoSuperiorIncompleto.Checked = True
                ElseIf _candidato.Curriculo.Escolaridade = Curriculo.NivelEscolaridade.Pos_Graduacao_Completa Then
                    Me.optPosCompleta.Checked = True
                Else
                    Me.optPosIncompleta.Checked = True
                End If

                If _candidato.Curriculo.Turno = 0 Then
                    Me.optPrimeiro.Checked = True
                ElseIf _candidato.Curriculo.Turno = 1 Then
                    Me.optSegundo.Checked = True
                ElseIf _candidato.Curriculo.Turno = 2 Then
                    Me.optTerceiro.Checked = True
                ElseIf _candidato.Curriculo.Turno = 3 Then
                    Me.optComercial.Enabled = True
                Else
                    Me.optIndiferente.Checked = True
                End If

                _caminhoCurriculo = _candidato.Curriculo.Digitalizacao
                _caminhoCurriculo_2 = _candidato.Curriculo.Digitalizacao_2
                _caminhoCurriculo_3 = _candidato.Curriculo.Digitalizacao_3

                Me.txtObs.Text = _candidato.Curriculo.Obs
                'Me.mskUltimoSalario.Text = Utils.FormataMoeda(_candidato.Curriculo.UltimoSalario)
                Me.txtPretensaoSalarial.Text = Utils.FormataMoeda(_candidato.Curriculo.PretensaoSalarial)
                Me.txtInserido.Text = _candidato.Curriculo.DataInclusao
                Me.txtAtualizado.Text = _candidato.Curriculo.DataAlteracao

                Call AtualizarListaCursos()
                Call AtualizaListaCargosPretendidos()
                Call AtualizarListaCargos()
                Call AtualizarListaIdioma()
                _tipoOperacao = "A"
                Me.Text = "Cadastro de curriculo [Alterar registro] - " & _candidato.Codigo & " - " & _candidato.Nome & "(" & _candidato.Cidade.Descricao & "-" & _candidato.Cidade.UF & ")"

                cmbSerie.SelectedIndex = _candidato.Curriculo.UltimaSerieIncompleta

                chkEstudando.Checked = IIf(_candidato.Curriculo.Estudando = 1, True, False)
            Else
                _candidato.Curriculo = New Curriculo
                _tipoOperacao = "N"
                Me.Text = "Cadastro de curriculo [Novo registro] - " & _candidato.Codigo & " - " & _candidato.Nome & "(" & _candidato.Cidade.Descricao & "-" & _candidato.Cidade.UF & ")"

                cmbSerie.SelectedIndex = 0
            End If

            'habilita a alteração de informações do candidatos
            'Me.btnAlterarInfo.Enabled = True

            'habilitar botão de gravacao
            btnGravar.Enabled = True

            'grpFormacao.Enabled = True
            'grpExpProfissional.Enabled = True
            'grpPretensaoCargo.Enabled = True
            'lblVisualizarCurriculo.Enabled = True


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    'Private Sub btnSelecionarCandidato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelecionarCandidato.Click
    '    'form de busca
    '    Dim BuscarDandidato As New frmBuscaCandidato
    '    BuscarDandidato.ShowDialog()

    '    'propriedade do form que contem o objeto Candidato
    '    If BuscarDandidato.Candidato Is Nothing Then Return

    '    'verifica se o candidato ja tem um curriculo
    '    If Not BuscarDandidato.Candidato.Curriculo Is Nothing Then
    '        MessageBox.Show("Este candidato já possui um curriculo cadastrado, para visualizar vá em Candidatos, selecione-o e em seguida clique em Curriculo na parte superior da janela", "Curriculo cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    '        Return
    '    End If

    '    grpFormacao.Enabled = True
    '    grpExpProfissional.Enabled = True
    '    grpPretensaoCargo.Enabled = True

    '    'habilitar botão de gravar
    '    btnGravar.Enabled = True

    '    'alterar informações
    '    btnAlterarInfo.Enabled = True

    '    'visualizar curriculo
    '    btnVisualizarCurriculo.Enabled = True

    '    'visualizar historico
    '    btnHistorico.Enabled = True

    '    'link para abrir a imagem/documento anexado ao curriculo
    '    lblVisualizarCurriculo.Enabled = True

    '    'passa o objeto selecionado
    '    _candidato = BuscarDandidato.Candidato

    '    'instancia um novo objeto do tipo curriculo
    '    _candidato.Curriculo = New Curriculo

    '    'carrega a exibição das informações pessoais do candidato
    '    Call ListarCaracteristicas()
    'End Sub

    ' ''' <summary>
    ' ''' Alterar informações pessoais do candidato
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    'Private Sub btnAlterarInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlterarInfo.Click
    '    'passando a classe atual como referencia
    '    Dim AlterarCandidato As New frmCandidato(_candidato)
    '    AlterarCandidato.ShowDialog()

    '    'recarregar lista de caracteristicas
    '    ListarCaracteristicas()
    'End Sub

    ''' <summary>
    ''' Pesquisar cursos para inserir na sessão de graduações
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnPesquisa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisa.Click
        Dim BuscarCurso As New frmBuscaCurso
        BuscarCurso.Alterar = False
        BuscarCurso.ShowDialog()

        If BuscarCurso.Curso Is Nothing Then Return

        _curso = BuscarCurso.Curso

        'carrega as informações do curso nos textos respectivos
        Me.txtEntidade.Text = _curso.Entidade.Descricao & " - " & _curso.Entidade.Cidade.Descricao & "(" & _curso.Entidade.Cidade.UF & ")"
        Me.txtCurso.Text = _curso.Descricao
        Me.txtCargaHoraria.Text = _curso.CargaHoraria
        Me.txtCategoria.Text = [Enum].GetName(GetType(Curso.CategoriaCurso), _curso.Categoria).Replace("_", Chr(32))
    End Sub

    ''' <summary>
    ''' Adiciona o curso selecionado na coleção
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAdicionarCurso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdicionarCurso.Click
        Try
            If _curso Is Nothing Then
                MessageBox.Show("Selecione um curso", "Curso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Return
            End If

            If Utils.temCampoInvalido(CType(sender, Control).Parent) Then
                MessageBox.Show("Campos inválidos", "Campos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            'verifica se o curso ja foi inserido, se nao foi, dar continuidade
            If Not CursoJaInserido(_curso.Codigo) Then
                Dim _cursoCurriculo = New CursoCurriculo

                _cursoCurriculo.Curso = _curso

                If txtInicial.Text = "" Then
                    _cursoCurriculo.DataInicial = Nothing
                Else
                    _cursoCurriculo.DataInicial = txtInicial.Text
                End If

                If txtFinal.Text = "" Then
                    _cursoCurriculo.DataFinal = Nothing
                Else
                    _cursoCurriculo.DataFinal = txtFinal.Text
                End If

                _cursoCurriculo.Obs = txtObsCurso.Text
                _cursoCurriculo.Concluido = IIf(chkConcluido.Checked = True, 1, 0)

                If _caminhoDigitalizacaoCertificado <> "" Then
                    _cursoCurriculo.PathCertificado = Utils.DiretorioCertificados & Path.GetFileName(_caminhoDigitalizacaoCertificado)
                Else
                    _cursoCurriculo.PathCertificado = ""
                End If

                _cursoCurriculo.Status = "A"

                _candidato.Curriculo.Cursos.Add(_cursoCurriculo)

                If _caminhoDigitalizacaoCertificado <> "" Then
                    If Not System.IO.Directory.Exists(Utils.DiretorioCertificados) Then
                        System.IO.Directory.CreateDirectory(Utils.DiretorioCertificados)
                    End If

                    If Not File.Exists(_cursoCurriculo.PathCertificado) Then
                        System.IO.File.Copy(_caminhoDigitalizacaoCertificado, _cursoCurriculo.PathCertificado)
                    End If
                End If

                Me._curso = Nothing
                Me._caminhoDigitalizacaoCertificado = ""
                Call Me.LimparCampos(grpCursosComplementares)
            Else
                MessageBox.Show("Este curso já está selecionado para a lista atual", "Duplicidade", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            Call AtualizarListaCursos()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Formata a data inicial
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtInicial_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInicial.Leave, txtFinal.Leave, txtDtInicialCargo.Leave, txtDtFinalCargo.Leave
        Dim data As TextBox = CType(sender, TextBox)

        Try
            If data.Text = "" Then Return
            data.Text = Utils.FormatarData(data.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            data.Focus()
        End Try
    End Sub

    ''' <summary>
    ''' Limpa os campos de acordo com o groupbox passado como parametro
    ''' </summary>
    ''' <param name="pGrp"></param>
    ''' <remarks></remarks>
    Private Sub LimparCampos(ByVal pGrp As GroupBox)
        Dim campos = From campo In pGrp.Controls Where TypeOf campo Is TextBox

        For Each campo As TextBox In campos
            campo.Text = ""
        Next
    End Sub

    ''' <summary>
    ''' Verifica quando a tecla delete é acionada
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvCursos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCursos.KeyDown
        Dim dgrid As DataGridView = CType(sender, DataGridView)

        If dgrid.RowCount = 0 Then Return

        If e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Deseja excluir este curso do curriculo?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim _curso = (From c In _candidato.Curriculo.Cursos Where c.Curso.Codigo = dgrid.Rows(dgrid.SelectedCells(0).RowIndex).Cells(0).Value).FirstOrDefault
                _curso.Status = "I"

                If File.Exists(_curso.PathCertificado) Then
                    File.Delete(_curso.PathCertificado)
                End If

                Call AtualizarListaCursos()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Grava o registro no banco de dados
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        Call GravarRegistro()
    End Sub

    Private Sub GravarRegistro()
        Try
            'alteração como agora
            _candidato.Curriculo.DataAlteracao = Now

            'grava a obervacao
            _candidato.Curriculo.Obs = Me.txtObs.Text.Trim

            'pretensao salariial
            _candidato.Curriculo.PretensaoSalarial = Me.txtPretensaoSalarial.Text.Trim

            'escolaridade
            _candidato.Curriculo.Escolaridade = _escolaridade

            'classificação do candidato
            _candidato.Curriculo.Classificacao = _classificacao

            'digitalização
            If _caminhoCurriculo <> "" Then
                _candidato.Curriculo.Digitalizacao = Utils.DiretorioCurriculos & Path.GetFileName(_caminhoCurriculo)
            Else
                _candidato.Curriculo.Digitalizacao = ""
            End If

            If _caminhoCurriculo_2 <> "" Then
                _candidato.Curriculo.Digitalizacao_2 = Utils.DiretorioCurriculos & Path.GetFileName(_caminhoCurriculo_2)
            Else
                _candidato.Curriculo.Digitalizacao_2 = ""
            End If

            If _caminhoCurriculo_3 <> "" Then
                _candidato.Curriculo.Digitalizacao_3 = Utils.DiretorioCurriculos & Path.GetFileName(_caminhoCurriculo_3)
            Else
                _candidato.Curriculo.Digitalizacao_3 = ""
            End If

            'ultimo salario
            _candidato.Curriculo.UltimoSalario = 0

            'turno
            _candidato.Curriculo.Turno = _turno

            'status de estudante
            _candidato.Curriculo.Estudando = IIf(chkEstudando.Checked, 1, 0)

            'caso ainda nao tenha terminado
            _candidato.Curriculo.UltimaSerieIncompleta = cmbSerie.SelectedIndex


            'tipo de operação como novo registro
            If _tipoOperacao = "N" Then
                Dim _codigoCurriculo As Integer

                'setar data/hora inclusao do curriculo
                _candidato.Curriculo.DataInclusao = Now

                'obtem o codigo do curriculo pra ir salvando as demais informações
                _codigoCurriculo = RegrasDeNegocio.InserirCurriculo(_candidato)

                'Inserir o restante das informações que compoem o curriculo
                If _codigoCurriculo <> 0 Then
                    _candidato.Curriculo.Codigo = _codigoCurriculo

                    RegrasDeNegocio.InserirCursosCurriculo(_candidato)
                    RegrasDeNegocio.InserirIdiomas(_candidato.Curriculo)
                    RegrasDeNegocio.InserirCargosCurriculo(_candidato)
                    RegrasDeNegocio.InserirCargosPretendidos(_candidato.Curriculo)
                End If
            Else
                'alterar
                RegrasDeNegocio.ALterarCurriculo(_candidato)

                RegrasDeNegocio.DeletarCargosCurriculo(_candidato.Curriculo)
                RegrasDeNegocio.InserirCargosCurriculo(_candidato)

                RegrasDeNegocio.DeletarCursosCurriculo(_candidato.Curriculo)
                RegrasDeNegocio.InserirCursosCurriculo(_candidato)

                RegrasDeNegocio.DeletaIdiomasCurriculo(_candidato.Curriculo)
                RegrasDeNegocio.InserirIdiomas(_candidato.Curriculo)

                RegrasDeNegocio.DeletarCargoPretendidoCurriculo(_candidato.Curriculo)
                RegrasDeNegocio.InserirCargosPretendidos(_candidato.Curriculo)

            End If

            Call SalvarCurriculoDigitalizado(_caminhoCurriculo, _candidato.Curriculo.Digitalizacao)
            Call SalvarCurriculoDigitalizado(_caminhoCurriculo_2, _candidato.Curriculo.Digitalizacao_2)
            Call SalvarCurriculoDigitalizado(_caminhoCurriculo_3, _candidato.Curriculo.Digitalizacao_3)

            _candidato.Dispose()

            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SalvarCurriculoDigitalizado(ByVal pCaminhoAntigo As String, ByVal pCaminho As String)
        If pCaminho <> "" Then
            If Not System.IO.Directory.Exists(Utils.DiretorioCurriculos) Then
                System.IO.Directory.CreateDirectory(Utils.DiretorioCurriculos)
            End If

            If Not File.Exists(pCaminho) Then
                System.IO.File.Copy(pCaminhoAntigo, pCaminho)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Seta a classificação atual
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub optRegular_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optRegular.CheckedChanged, optRuim.CheckedChanged, optExcelente.CheckedChanged, optBom.CheckedChanged
        Dim classificacao As RadioButton = CType(sender, RadioButton)
        Me._classificacao = classificacao.Tag
    End Sub

    Private Sub btnAnexarCertificado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnexarCertificado.Click
        _caminhoDigitalizacaoCertificado = CarregaImagem()
    End Sub

    Private Function CarregaImagem() As String
        Dim _caminho As String = ""

        Dim _openFile As New OpenFileDialog

        If _openFile.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            _caminho = _openFile.FileName
        End If

        Return _caminho
    End Function

    ''' <summary>
    ''' Visualiza o certificado
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvCursos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvCursos.DoubleClick
        Dim dgrid As DataGridView = CType(sender, DataGridView)

        If dgrid.RowCount = 0 Then
            Return
        End If

        Try
            Dim _img As String = (From _certificado In _candidato.Curriculo.Cursos Where _certificado.Curso.Codigo = dgrid.Rows(dgrid.SelectedCells(0).RowIndex).Cells(0).Value Select _certificado.PathCertificado).FirstOrDefault

            If _img <> "" Then
                Process.Start(_img)
            Else
                MessageBox.Show("Nao possui certificado relacionado com este curso", "Sem certificado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub optInserir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optInserirIdioma.Click
        Dim _informacaoIdioma As New IdiomaCurriculo

        Try
            If IdiomaJaInserido(CType(cmbIdioma.SelectedItem, Idioma).Codigo) Then
                MessageBox.Show("Este idioma ja está inserido.", "idioma inserido", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            _informacaoIdioma.Idioma = cmbIdioma.SelectedItem
            _informacaoIdioma.Nativo = IIf(chkNativo.Checked = True, 1, 0)
            _informacaoIdioma.Obs = txtObsIdioma.Text
            _informacaoIdioma.Status = "A"

            _candidato.Curriculo.Idiomas.Add(_informacaoIdioma)

            chkNativo.Checked = False
            txtObsIdioma.Text = ""

            Call AtualizarListaIdioma()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvIdioma_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvIdioma.KeyDown
        Dim dgrid As DataGridView = CType(sender, DataGridView)

        If dgrid.RowCount = 0 Then Return

        Try
            If e.KeyCode = Keys.Delete Then
                If MessageBox.Show("Deseja deletar este idioma da lista?", "Deletar idioma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return
                Dim _idiomaCurriculo = (From i In _candidato.Curriculo.Idiomas Where i.Idioma.Codigo = dgrid.Rows(dgrid.SelectedCells(0).RowIndex).Cells(0).Value).FirstOrDefault

                _idiomaCurriculo.Status = "I"
                Call AtualizarListaIdioma()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnNovaEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNovaEmpresa.Click
        Dim _novaEmpresa As New frmCadastroEmpresa
        _novaEmpresa.ShowDialog()

        Call CarregarListaEmpresa()
    End Sub

    Private Sub btnNovoCargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim _novoCargo As New frmCadastroEmpresa(cmbEmpresa.SelectedItem)
        _novoCargo.ShowDialog()

        Call CarregarListaEmpresa()
    End Sub

    Private Sub btnSelecionarBeneficios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelecionarBeneficios.Click
        Dim _beneficios As New frmBeneficios(_cargo)
        _beneficios.ShowDialog()
    End Sub

    Private Sub btnSalvarCargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvarCargo.Click
        'If Utils.temCampoInvalido(grpExpProfissional) Then
        '    MessageBox.Show("Existem campos obrigatórios nao preenchidos", "Campos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return
        'End If

        Dim botao = CType(sender, Button)

        Try
            If _alteracaoCargo Then
                Dim _duplicadoAtivo As New CurriculoCargo

                _duplicadoAtivo.Empresa = cmbEmpresa.SelectedItem
                _duplicadoAtivo.Cargo = cmbCargosExperiencia.SelectedItem
                _duplicadoAtivo.DataInicio = Me.txtDtInicialCargo.Text
                _duplicadoAtivo.MotivoSaida = Me.txtMotivoSaida.Text
                _duplicadoAtivo.FuncoesDesempenhadas = Me.txtFuncoesDesempenhadas.Text
                _duplicadoAtivo.Registrado = IIf(chkRegistrado.Checked, 1, 0)

                If mskUltimoSalario.Text = "" Then
                    _duplicadoAtivo.Salario = Utils.FormataMoeda("0")
                Else
                    _duplicadoAtivo.Salario = Utils.FormataMoeda(mskUltimoSalario.Text)
                End If

                _duplicadoAtivo.CestaBasica = _cargo.CestaBasica
                _duplicadoAtivo.ValeTransporte = _cargo.ValeTransporte
                _duplicadoAtivo.PLR = _cargo.PLR
                _duplicadoAtivo.ConvenioMedico = _cargo.ConvenioMedico
                _duplicadoAtivo.ValeRefeicao = _cargo.ValeRefeicao
                _duplicadoAtivo.SeguroDeVida = _cargo.SeguroDeVida
                _duplicadoAtivo.AjudaCustoEstudo = _cargo.AjudaCustoEstudo
                _duplicadoAtivo.AuxilioCreche = _cargo.AuxilioCreche
                _duplicadoAtivo.AuxilioDentista = _cargo.AuxilioDentista
                _duplicadoAtivo.ValorCestaBasica = _cargo.ValorCestaBasica
                _duplicadoAtivo.ValorTransporte = _cargo.ValorTransporte
                _duplicadoAtivo.ValorPLR = _cargo.ValorPLR
                _duplicadoAtivo.ValorConvenioMedico = _cargo.ValorConvenioMedico
                _duplicadoAtivo.ValorRefeicao = _cargo.ValorRefeicao
                _duplicadoAtivo.ValorSeguroVida = _cargo.ValorSeguroVida
                _duplicadoAtivo.ValorAjudaCustoEnsino = _cargo.ValorAjudaCustoEnsino
                _duplicadoAtivo.ValorAuxilioCreche = _cargo.ValorAuxilioCreche
                _duplicadoAtivo.ValorAuxilioDentista = _cargo.ValorAuxilioDentista
                _duplicadoAtivo.ValorRecebidoFora = _cargo.ValorRecebidoFora
                _duplicadoAtivo.Status = "A"

                If chkAtual.Checked Then
                    _duplicadoAtivo.Atual = 1
                    _duplicadoAtivo.DataFinal = Nothing
                Else
                    _duplicadoAtivo.Atual = 0
                    _duplicadoAtivo.DataFinal = Me.txtDtFinalCargo.Text
                End If

                _candidato.Curriculo.Cargos.Add(_duplicadoAtivo)

                'indica que o cargo que foi alterado fica como inativo
                _cargo.Status = "I"

                _alteracaoCargo = False
                botao.Text = "Adicionar cargo"
            Else
                'If CargoJaInserido(CType(cmbCargos.SelectedItem, Cargo).Codigo, CType(cmbEmpresa.SelectedItem, Empresa).Codigo) Then
                'MessageBox.Show("Ja existe um cargo nesta mesma empresa inserida", "Dados ja cadastrados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'Return
                'End If

                _cargo.Cargo = cmbCargosExperiencia.SelectedItem
                _cargo.Empresa = cmbEmpresa.SelectedItem
                _candidato.Curriculo.UltimoSalario = 0
                _cargo.DataInicio = txtDtInicialCargo.Text
                _cargo.FuncoesDesempenhadas = Me.txtFuncoesDesempenhadas.Text
                _cargo.MotivoSaida = Me.txtMotivoSaida.Text
                _cargo.Status = "A"
                _cargo.Registrado = IIf(chkRegistrado.Checked, 1, 0)

                If mskUltimoSalario.Text = "" Then
                    _cargo.Salario = Utils.FormataMoeda("0")
                Else
                    _cargo.Salario = Utils.FormataMoeda(mskUltimoSalario.Text)
                End If

                If chkAtual.Checked Then
                    _cargo.Atual = 1
                    _cargo.DataFinal = Nothing
                Else
                    _cargo.Atual = 0
                    _cargo.DataFinal = Me.txtDtFinalCargo.Text
                End If

                _candidato.Curriculo.Cargos.Add(_cargo)
            End If

            Call CarregarListaEmpresa()
            Call AtualizarListaCargos()
            Call LimparCampos(GroupBox2)

            _cargo = New CurriculoCargo
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnLimpar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpar.Click
        If MessageBox.Show("Deseja limpar os campos? Isso fará com que perca as informações atuais.", "Limpar campos?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Call LimparCampos(GroupBox2)
            Call CarregarListaEmpresa()
            Call AtualizarListaCargos()

            _alteracaoCargo = False
            _cargo = New CurriculoCargo

            btnSalvarCargo.Text = "Adicionar cargo"
            chkRegistrado.Checked = False
        End If
    End Sub


#Region "Atualizar Grids"

    ''' <summary>
    ''' Atualiza a grid com os cursos na coleção
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AtualizarListaCursos()
        Try
            Me.dgvCursos.DataSource = (From _cursos In _candidato.Curriculo.Cursos Where _cursos.Status = "A" Select CodigoCurso = _cursos.Curso.Codigo, NomeCurso = _cursos.Curso.Descricao, DataInicio = _cursos.DataInicial, DataFinalizacao = _cursos.DataFinal).ToList
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Atualiza a lista de idiomas na grid
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AtualizarListaIdioma()
        Try
            Me.dgvIdioma.DataSource = (From _idioma In _candidato.Curriculo.Idiomas Where _idioma.Status = "A" Select _idioma.Idioma.Codigo, _idioma.Idioma.Descricao, _idioma.Nativo).ToList
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Atualiza a lista de cargos anteriores no datagrid
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AtualizarListaCargos()
        Try
            'Me.dgvCargos.DataSource = (From _cargos In _candidato.Curriculo.Cargos Where _cargos.Status = "A" Select Empresa = _cargos.Empresa.NomeFantasia, Cargo = _cargos.Cargo.Descricao, Admissao = _cargos.DataInicio, Demissao = _cargos.DataFinal, Salario = "R$" & Utils.FormataMoeda(_cargos.Salario)).ToList
            Dim _c = (From c In _candidato.Curriculo.Cargos).ToList
            Dim _indice As Integer = 0

            Me.dgvCargos.Rows.Clear()

            For Each c In _c
                If c.Status <> "I" Then
                    Me.dgvCargos.Rows.Add(_indice, c.Empresa.NomeFantasia, c.Cargo.Descricao, CDate(c.DataInicio), CDate(c.DataFinal), "R$" & Utils.FormataMoeda(c.Salario))
                End If

                _indice += 1
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Atualiza a lista de cargos pretendidos no datagrid
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AtualizaListaCargosPretendidos()
        Try
            Me.dgvPretendidos.DataSource = (From _cargosPretendidos In _candidato.Curriculo.CargosPretendidos Where _cargosPretendidos.Status = "A" Select Codigo = _cargosPretendidos.Cargo.Codigo, Area = _cargosPretendidos.Cargo.Area.Descricao, Cargo = _cargosPretendidos.Cargo.Descricao, Principal = IIf(_cargosPretendidos.Principal = 1, "SIM", "NAO")).ToList
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

#End Region

#Region "Busca nas coleções para evitar duplicação"

    ''' <summary>
    ''' Retorna se o curso ja está selecionado na coleção
    ''' </summary>
    ''' <param name="pCodigoCurso"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CursoJaInserido(ByVal pCodigoCurso As String) As Boolean
        Try
            Return (From _cursoAtual In _candidato.Curriculo.Cursos Where _cursoAtual.Curso.Codigo = pCodigoCurso And _cursoAtual.Status = "A").Any
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Retorna se o idioma ja está selecionado na coleção
    ''' </summary>
    ''' <param name="pCodigoIdioma"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IdiomaJaInserido(ByVal pCodigoIdioma As String) As Boolean
        Try
            Return (From _idiomaInserido In _candidato.Curriculo.Idiomas Where _idiomaInserido.Idioma.Codigo = pCodigoIdioma And _idiomaInserido.Status = "A").Any
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Verifica se a empresa e o cargo ja existe inserido
    ''' </summary>
    ''' <param name="pCodigoCargo"></param>
    ''' <param name="pCodigoEmpresa"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CargoJaInserido(ByVal pCodigoCargo As String, ByVal pCodigoEmpresa As String)
        Try
            Return (From _cargoInserido In _candidato.Curriculo.Cargos Where _cargoInserido.Cargo.Codigo = pCodigoCargo And _cargoInserido.Empresa.Codigo = pCodigoEmpresa And _cargoInserido.Status = "A").Any
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    ' ''' <summary>
    ' ''' Verifica na alteração se ja existe algum objeto igual, mas ignorando o proprio objeto sendo alterado
    ' ''' </summary>
    ' ''' <param name="pCodigoCargo"></param>
    ' ''' <param name="pCodigoEmpresa"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Private Function AlterarCargoJaInserido(ByVal pCodigoCargo As String, ByVal pCodigoEmpresa As String) As Boolean
    '    Dim _jaExiste As Boolean = False
    '    Dim _total As Integer = 0

    '    Try
    '        _total = (From _cargoInserido In _candidato.Curriculo.Cargos Where _cargoInserido.Cargo.Codigo = pCodigoCargo And _cargoInserido.Empresa.Codigo = pCodigoEmpresa And _cargoInserido.Status = "A").Count

    '        If _total > 1 Then
    '            _jaExiste = True
    '        End If
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    End Try

    '    Return _jaExiste
    'End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="pCodigoCargo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CargoPretendidoJaInserido(ByVal pCodigoCargo As String) As Integer
        Dim _total As Integer = 0
        Try
            _total = (From _cargoPretendido In _candidato.Curriculo.CargosPretendidos Where _cargoPretendido.Cargo.Codigo = pCodigoCargo And _cargoPretendido.Status = "A").Count

            Return _total
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

#End Region

#Region "Carrega os comboboxes e listas"

    ' ''' <summary>
    ' ''' Carrega os dados pessoais
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private Sub ListarCaracteristicas()
    '    Try
    '        TextBox1.Text =
    '        "Codigo: " & _candidato.Codigo & vbCrLf & _
    '        "-----------------------------------------------" & vbCrLf & _
    '        "Informações pessoais: " & vbCrLf & _
    '        "-----------------------------------------------" & vbCrLf & _
    '        "Nome completo: " & _candidato.Nome & vbCrLf & _
    '        "Nome social: " & _candidato.NomeSocial & vbCrLf & _
    '        "Data de nascimento: " & _candidato.DataNascimento & " - Idade: " & Math.Floor(Now.Subtract(_candidato.DataNascimento).Days / 365) & " anos" & vbCrLf & _
    '        "Tipo de documento: " & [Enum].GetName(GetType(Candidato.TipoDeDocumento), _candidato.TipoDoc) & vbCrLf & _
    '        "Numero de documento: " & _candidato.Documento & vbCrLf & _
    '        "Sexo: " & IIf(_candidato.Sexo = "M", "Masculino", "Feminino") & vbCrLf & _
    '        "Nacionalidade: " & _candidato.Nacionalidade.Descricao & vbCrLf & _
    '        "-----------------------------------------------" & vbCrLf & _
    '        "Logradouro: " & vbCrLf & _
    '        "-----------------------------------------------" & vbCrLf & _
    '        "Endereço: " & _candidato.Endereco & vbCrLf & _
    '        "Cidade: " & _candidato.Cidade.Descricao & " - " & _candidato.Cidade.UF & vbCrLf

    '        If _candidato.Foto <> "" Then
    '            Me.PictureBox1.Load(Utils.DiretorioFotoCandidato & _candidato.Foto)
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show("Ocorreu um erro ao preencher o resumo: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    ''' <summary>
    ''' Carrega idiomas
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CarregarListaIdioma()
        Try
            Me.cmbIdioma.DataSource = RegrasDeNegocio.GetIdiomas
            Me.cmbIdioma.DisplayMember = "Descricao"

            Me.cmbIdioma.SelectedIndex = 36
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Carrega empresas
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CarregarListaEmpresa()
        Try
            Me.cmbEmpresa.DataSource = RegrasDeNegocio.GetEmpresas("", "", True)
            Me.cmbEmpresa.DisplayMember = "NomeFantasia"
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ' ''' <summary>
    ' ''' Carrega lista de cargos
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private Sub CarregaListaCargos()
    '    Try
    '        Me.cmbCargosExperiencia.DataSource = RegrasDeNegocio.GetCargos("", "")
    '        Me.cmbCargosExperiencia.DisplayMember = "Descricao"
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    End Try
    'End Sub

    ''' <summary>
    ''' Carrega areas
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CarregaListaAreas()
        Try
            Dim _listaAreas As List(Of Area) = RegrasDeNegocio.GetAreas("", "A")

            Me.cmbAreas.DataSource = _listaAreas
            Me.cmbAreas.DisplayMember = "Descricao"

            Me.cmbAreaExperiencia.DataSource = _listaAreas
            Me.cmbAreaExperiencia.DisplayMember = "Descricao"
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Carrega lista de cargos
    ''' </summary>
    ''' <param name="pCodigoArea"></param>
    ''' <remarks></remarks>
    Private Function CarregaListaCargos(ByVal pCodigoArea As String) As List(Of Cargo)
        Try
            'Me.cmbCargoPretendido.DataSource = RegrasDeNegocio.GetCargos(pCodigoArea, "")
            'Me.cmbCargoPretendido.DisplayMember = "Descricao"
            Return RegrasDeNegocio.GetCargos(pCodigoArea, "")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
#End Region


    Private Sub cmbEmpresa_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEmpresa.Leave
        Dim combo As ComboBox = CType(sender, ComboBox)

        If combo.SelectedItem Is Nothing Then
            MessageBox.Show("Nenhuma empresa válida selecionada", "Empresa inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'combo.Focus
        End If
    End Sub

    Private Sub cmbCargos_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCargosExperiencia.Leave
        Dim combo As ComboBox = CType(sender, ComboBox)

        If combo.SelectedItem Is Nothing Then
            MessageBox.Show("Nenhum cargo válido selecionado", "Cargo inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'combo.Focus()
        End If
    End Sub


    Private Sub dgvCargos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCargos.KeyDown
        Dim dgrid As DataGridView = CType(sender, DataGridView)

        If dgrid.RowCount = 0 Then
            Return
        End If

        Try
            If e.KeyData = Keys.Delete Then
                'caso estiver havendo uma alteração de cargo, bloquear para nao ter exclusao enquanto nao for salvo
                If _alteracaoCargo Then
                    Return
                End If

                If MessageBox.Show("Deseja excluir este cargo?", "Excluir cargo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    'Dim _cargo = (From c In _candidato.Curriculo.Cargos Where c.Cargo.Descricao = dgrid.Rows(dgrid.SelectedCells(0).RowIndex).Cells(1).Value And c.Empresa.NomeFantasia = dgrid.Rows(dgrid.SelectedCells(0).RowIndex).Cells(0).Value And c.Status = "A").FirstOrDefault
                    Dim _indice As Integer = dgrid.Rows(dgrid.SelectedCells(0).RowIndex).Cells(0).Value
                    Dim _cargo = _candidato.Curriculo.Cargos(_indice)

                    _cargo.Status = "I"

                    Call AtualizarListaCargos()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvCargos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvCargos.DoubleClick
        Dim dgrid As DataGridView = CType(sender, DataGridView)

        If dgrid.RowCount = 0 Then
            Return
        End If

        Try
            Dim _indice As Integer = dgrid.Rows(dgrid.SelectedCells(0).RowIndex).Cells(0).Value
            _cargo = _candidato.Curriculo.Cargos(_indice)

            cmbCargosExperiencia.Text = _cargo.Cargo.Descricao
            cmbEmpresa.Text = _cargo.Empresa.NomeFantasia
            txtDtInicialCargo.Text = _cargo.DataInicio
            txtDtFinalCargo.Text = _cargo.DataFinal
            txtFuncoesDesempenhadas.Text = _cargo.FuncoesDesempenhadas
            txtMotivoSaida.Text = _cargo.MotivoSaida
            chkRegistrado.Checked = IIf(_cargo.Registrado = 1, True, False)
            mskUltimoSalario.Text = Utils.FormataMoeda(_cargo.Salario)
            chkAtual.Checked = IIf(_cargo.Atual = 1, True, False)

            _alteracaoCargo = True

            Me.btnSalvarCargo.Text = "Alterar cargo"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBuscarDigitalizacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarDigitalizacao1.Click
        _caminhoCurriculo = CarregaImagem()
    End Sub

    Private Sub mskUltimoSalario_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mskUltimoSalario.Leave, txtPretensaoSalarial.Leave
        Dim texto = CType(sender, TextBox)
        Try
            If texto.Text = "" Then
                texto.Text = 0
            End If

            texto.Text = Utils.FormataMoeda(texto.Text)
        Catch ex As Exception
            MessageBox.Show("Neste campo só é valido numeros e vírgula", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            texto.Focus()
        End Try
    End Sub

    Private Sub cmbAreas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAreas.SelectedIndexChanged
        Dim combo = CType(sender, ComboBox)

        Try
            'Call CarregaListaCargos(CType(combo.SelectedItem, Area).Codigo)
            Me.cmbCargoPretendido.DataSource = CarregaListaCargos(CType(combo.SelectedItem, Area).Codigo)
            Me.cmbCargoPretendido.DisplayMember = "Descricao"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAdcCargoPretendido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdcCargoPretendido.Click
        Dim _botao = CType(sender, Button)

        Try
            If CargoPretendidoJaInserido(CType(cmbCargoPretendido.SelectedItem, Cargo).Codigo) >= 1 And _alterarCargoPretendido = False Then
                MessageBox.Show("Esta pretensão já existe na lista", "Pretensão", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Return
            End If

            If _alterarCargoPretendido Then
                Dim _cargoDuplicado As New CargoPretendidoCurriculo

                _cargoDuplicado.Cargo = cmbCargoPretendido.SelectedItem
                _cargoDuplicado.Status = "A"
                _cargoDuplicado.Principal = IIf(chkPrincipal.Checked, 1, 0)

                'exclui o atual
                _cargoPretendido.Status = "I"

                _candidato.Curriculo.CargosPretendidos.Add(_cargoDuplicado)

                'Call CarregaListaCargos()

                _alterarCargoPretendido = False
                _botao.Text = "Adicionar"
            Else
                _cargoPretendido.Cargo = cmbCargoPretendido.SelectedItem
                _cargoPretendido.Status = "A"
                _cargoPretendido.Principal = IIf(chkPrincipal.Checked, 1, 0)

                _candidato.Curriculo.CargosPretendidos.Add(_cargoPretendido)
            End If

            _cargoPretendido = New CargoPretendidoCurriculo

            Call AtualizaListaCargosPretendidos()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvPretendidos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvPretendidos.KeyDown
        Dim dgrid = CType(sender, DataGridView)

        If dgrid.RowCount = 0 Then
            Return
        End If

        If e.KeyData = Keys.Delete Then
            If MessageBox.Show("Deseja remover este cargo da lista?", "Remover cargo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim _pretendido = (From p In _candidato.Curriculo.CargosPretendidos Where p.Cargo.Codigo = dgrid.Rows(dgrid.SelectedCells(0).RowIndex).Cells(0).Value And p.Status = "A").FirstOrDefault
                    _pretendido.Status = "I"

                    Call AtualizaListaCargosPretendidos()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub frmCurriculo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _cargo = New CurriculoCargo
        _cargoPretendido = New CargoPretendidoCurriculo

        Try
            Call CarregarListaIdioma()
            Call CarregarListaEmpresa()
            Call CarregaListaAreas()
            'Call CarregaListaCargos()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvIdioma_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvIdioma.DoubleClick
        Dim dgrid = CType(sender, DataGridView)

        If dgrid.RowCount = 0 Then
            Return
        End If

        Dim _indice As Integer = dgrid.CurrentCell.RowIndex
        txtObsIdioma.Text = _candidato.Curriculo.Idiomas(_indice).Obs
    End Sub

    Private Sub btnVisualizarCurriculo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizarCurriculo.Click
        RegrasDeNegocio.GerarRelatorio(_candidato.Codigo)
    End Sub

    Private Sub frmCurriculo_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not _candidato Is Nothing Then _candidato.Dispose()
    End Sub

    Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub

    Private Sub frmCurriculo_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.pPainelPrincipal.Left = (Me.Width / 2) - (pPainelPrincipal.Width / 2)
    End Sub

    Private Sub txtInicial_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInicial.KeyDown, txtPretensaoSalarial.KeyDown, txtFinal.KeyDown, txtDtInicialCargo.KeyDown, txtDtFinalCargo.KeyDown, mskUltimoSalario.KeyDown
        If e.KeyData = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmbAreas_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAreas.Leave
        Dim combo = CType(sender, ComboBox)

        If combo.SelectedItem Is Nothing Then
            MessageBox.Show("Selecione uma área válida", "Area inválida", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            combo.Focus()
        End If
    End Sub

    Private Sub cmbCargoPretendido_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCargoPretendido.Leave
        Dim combo = CType(sender, ComboBox)

        If combo.SelectedItem Is Nothing Then
            MessageBox.Show("Selecione um cargo válido", "Cargo inválido", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            combo.Focus()
        End If
    End Sub

    Private Sub lblVisualizarCurriculo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblVisualizarCurriculo.Click
        Call CarregaDigitalizacao(_caminhoCurriculo)
    End Sub

    Private Sub CarregaDigitalizacao(ByVal pNome As String)
        If pNome <> "" Then
            Try
                Process.Start(pNome)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Nao existe digitalização vinculado com este curriculo", "Sem digitalização", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub btnCurso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCurso.Click
        Dim novoCurso As New frmCurso
        novoCurso.ShowDialog()
    End Sub

    Private Sub btnGravar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call GravarRegistro()
    End Sub

    Private Sub HabilitarDesabilitarBotoes(ByVal pHabilitar As Boolean)

    End Sub

    Private Sub btnBuscarDigitalizacao2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarDigitalizacao2.Click
        _caminhoCurriculo_2 = CarregaImagem()
    End Sub

    Private Sub btnBuscarDigitalizacao3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarDigitalizacao3.Click
        _caminhoCurriculo_3 = CarregaImagem()
    End Sub

    Private Sub lblVisualizarCurriculo2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblVisualizarCurriculo2.Click
        Call CarregaDigitalizacao(_caminhoCurriculo_2)
    End Sub

    Private Sub lblVisualizarCurriculo3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblVisualizarCurriculo3.Click
        Call CarregaDigitalizacao(_caminhoCurriculo_3)
    End Sub

    Private Sub dgvPretendidos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvPretendidos.DoubleClick
        Dim dgrid = CType(sender, DataGridView)

        If dgrid.RowCount = 0 Then Return

        Try
            _cargoPretendido = (From _cargo In _candidato.Curriculo.CargosPretendidos Where _cargo.Cargo.Codigo = dgrid.Rows(dgrid.SelectedCells(0).RowIndex).Cells(0).Value And _cargo.Status = "A").FirstOrDefault

            _alterarCargoPretendido = True

            cmbAreas.Text = _cargoPretendido.Cargo.Area.Descricao
            cmbCargoPretendido.Text = _cargoPretendido.Cargo.Descricao

            chkPrincipal.Checked = IIf(_cargoPretendido.Principal = 1, True, False)

            btnAdcCargoPretendido.Text = "Alterar"
        Catch ex As Exception
            MessageBox.Show("Erro ao alterar cargos pretendidos, motivo: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)

            _alterarCargoPretendido = False
        End Try
    End Sub

    Private Sub optComercial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optComercial.CheckedChanged, optTerceiro.CheckedChanged, optSegundo.CheckedChanged, optPrimeiro.CheckedChanged, optIndiferente.CheckedChanged
        Dim _check = CType(sender, RadioButton)
        _turno = IIf(_check.Checked, _check.Tag, 0)
    End Sub

    Private Sub cmbAreaExperiencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAreaExperiencia.SelectedIndexChanged
        Dim combo = CType(sender, ComboBox)

        Try
            Me.cmbCargosExperiencia.DataSource = CarregaListaCargos(CType(combo.SelectedItem, Area).Codigo)
            Me.cmbCargosExperiencia.DisplayMember = "Descricao"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub optEnsinoFundamentalIncompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optEnsinoFundamentalIncompleto.CheckedChanged
        Dim ensino = CType(sender, RadioButton)
        Me._escolaridade = ensino.Tag

        cmbSerie.Enabled = True
    End Sub


    Private Sub optEnsinoFundamentalCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optEnsinoFundamentalCompleto.CheckedChanged
        Dim ensino = CType(sender, RadioButton)
        Me._escolaridade = ensino.Tag

        cmbSerie.Enabled = False
        cmbSerie.SelectedIndex = 0
    End Sub

    Private Sub optEnsinoMedioIncompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optEnsinoMedioIncompleto.CheckedChanged
        Dim ensino = CType(sender, RadioButton)
        Me._escolaridade = ensino.Tag

        cmbSerie.Enabled = True
    End Sub

    Private Sub optEnsinoMedioCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optEnsinoMedioCompleto.CheckedChanged
        Dim ensino = CType(sender, RadioButton)
        Me._escolaridade = ensino.Tag

        cmbSerie.Enabled = False
        cmbSerie.SelectedIndex = 0
    End Sub

    Private Sub optEnsinoSuperiorIncompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optEnsinoSuperiorIncompleto.CheckedChanged
        Dim ensino = CType(sender, RadioButton)
        Me._escolaridade = ensino.Tag

        cmbSerie.Enabled = False
        cmbSerie.SelectedIndex = 0
    End Sub

    Private Sub optEnsinoSuperiorCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optEnsinoSuperiorCompleto.CheckedChanged
        Dim ensino = CType(sender, RadioButton)
        Me._escolaridade = ensino.Tag

        cmbSerie.Enabled = False
        cmbSerie.SelectedIndex = 0
    End Sub

    Private Sub optPosIncompleta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPosIncompleta.CheckedChanged
        Dim ensino = CType(sender, RadioButton)
        Me._escolaridade = ensino.Tag

        cmbSerie.Enabled = False
        cmbSerie.SelectedIndex = 0
    End Sub

    Private Sub optPosCompleta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPosCompleta.CheckedChanged
        Dim ensino = CType(sender, RadioButton)
        Me._escolaridade = ensino.Tag

        cmbSerie.Enabled = False
        cmbSerie.SelectedIndex = 0
    End Sub

    Private Sub chkAtual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAtual.CheckedChanged
        Dim atual = CType(sender, CheckBox)

        If atual.Checked Then
            txtDtFinalCargo.Text = ""
            txtDtFinalCargo.Enabled = False
        Else
            txtDtFinalCargo.Enabled = True
        End If
    End Sub
End Class

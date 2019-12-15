Imports BLL
Imports DTO
Imports Utilidades

Public Class frmCandidato

    Private _tipoOperacao As Char = ""

    Private _tipoDocumento As Candidato.TipoDeDocumento
    Private _estadoCivil As Candidato.TipoEstadoCivil

    Private _habilitacaoA, _habilitacaoB, _habilitacaoC, _habilitacaoD, _habilitacaoE, _conducao, _indicado As Integer
    Private _candidato As Candidato = Nothing
    Private _sexo As Char = ""
    Private _nomeJaVerificado As Integer = 0

    ''' <summary>
    ''' Novo registro
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        'titulo da janela
        Me.Text = "Cadastro de candidato [Novo registro]"

        'carrega as operadores (enum)
        Me.cmbOperadora.DataSource = [Enum].GetValues(GetType(Candidato.OperadoraCelular))

        Try
            'carrega as cidades
            Call Me.PreencheCidadesCombo()

            'carrega as nacionalidades
            Call Me.CarregarNacionalidades()

            'instancia o objeto candidato
            _candidato = New Candidato

            'libera o form
            grpInfo.Enabled = True

            'novo registro
            _tipoOperacao = "N"

            'setar valores como raça, fumante, boa aparencia e observações.
            Call SetarValoresPadroes()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Alterar candidato
    ''' </summary>
    ''' <param name="pCandidato"></param>
    ''' <remarks></remarks>
    Public Sub New(ByRef pCandidato As Candidato)
        InitializeComponent()

        'titulo da janela
        Me.Text = "Cadastro de candidato [Alterar registro]"

        'verifica se o candidato tem curriculo ja cadastrado
        If Not pCandidato.Curriculo Is Nothing Then
            Me.btnCurriculo.Enabled = True
        End If

        'carrega as operadores (enum)
        Me.cmbOperadora.DataSource = [Enum].GetValues(GetType(Candidato.OperadoraCelular))

        Try
            'carrega as cidades
            Call Me.PreencheCidadesCombo()

            'carrega nacionalidades
            Call Me.CarregarNacionalidades()

            'verifica se o candidato ja tem curriculo cadastrado
            If Not pCandidato.Curriculo Is Nothing Then
                btnCurriculo.Enabled = True
            End If

            'codigo do candidato
            Me.txtCodigo.Text = pCandidato.Codigo

            'nome completo
            Me.txtNomeCompleto.Text = pCandidato.Nome

            'data de nascimento
            Me.mskNascimento.Text = pCandidato.DataNascimento

            'sexo Masculino ou Feminino
            If pCandidato.Sexo = "M" Then
                optMasc.Checked = True
            Else
                optFem.Checked = True
            End If

            'tipo de documento
            If pCandidato.TipoDoc = Candidato.TipoDeDocumento.cpf Then
                Me.optCPF.Checked = True
            ElseIf pCandidato.TipoDoc = Candidato.TipoDeDocumento.rg Then
                Me.optRG.Checked = True
            Else
                Me.optOutros.Checked = True
            End If

            'documento
            Me.txtDocumento.Text = pCandidato.Documento

            'endereco completo
            Me.txtEndereco.Text = pCandidato.Endereco

            'email
            Me.txtEmail.Text = pCandidato.Email

            'facbook do candidato
            Me.txtFacebook.Text = pCandidato.Facebook

            'data de inserção
            Me.txtInserido.Text = pCandidato.DataInclusao

            'data de atualizaçao dos dados
            Me.txtAtualizado.Text = pCandidato.DataAtualizacao

            'cidade do candidato
            Me.cmbCidade.Text = pCandidato.Cidade.Descricao

            'situacao Ativo ou Inativo
            If pCandidato.Situacao = "A" Then chkAtivo.Checked = True Else chkAtivo.Checked = False

            'nome social
            Me.txtNomeSocial.Text = pCandidato.NomeSocial

            'o numero de celular é um whatsapp?
            Me.chkWhatsapp.Checked = IIf(pCandidato.Whatsapp = 1, True, False)

            'observações
            'Me.txtObs.Text = pCandidato.Obs

            If Not pCandidato.Foto = "" And System.IO.File.Exists(Utils.DiretorioFotoCandidato & pCandidato.Foto) Then
                'carrega foto
                Me.PictureBox1.Load(Utils.DiretorioFotoCandidato & pCandidato.Foto)
            End If

            'filhos menores de 18 anos
            Me.txtMenor.Text = pCandidato.FilhosMenor

            'filhos maiores de 18 anos
            Me.txtMaior.Text = pCandidato.FilhosMaior

            'Estado civil
            If pCandidato.EstadoCivil = Candidato.TipoEstadoCivil.Solteiro Then
                Me.optSolteiro.Checked = True
            ElseIf pCandidato.EstadoCivil = Candidato.TipoEstadoCivil.Casado Then
                Me.optCasado.Checked = True
            ElseIf pCandidato.EstadoCivil = Candidato.TipoEstadoCivil.Separado Then
                Me.optSeparado.Checked = True
            ElseIf pCandidato.EstadoCivil = Candidato.TipoEstadoCivil.Divorciado Then
                Me.optDivorciado.Checked = True
            ElseIf pCandidato.EstadoCivil = Candidato.TipoEstadoCivil.UniaoEstavel Then
                Me.optUniaoEstavel.Checked = True
            Else
                Me.optViuvo.Checked = True
            End If

            'habilitacões
            If pCandidato.HabilitacaoA = 1 Then Me.chkA.Checked = True Else chkA.Checked = False
            If pCandidato.HabilitacaoB = 1 Then Me.chkB.Checked = True Else chkB.Checked = False
            If pCandidato.HabilitacaoC = 1 Then Me.chkC.Checked = True Else chkC.Checked = False
            If pCandidato.HabilitacaoD = 1 Then Me.chkD.Checked = True Else chkD.Checked = False
            If pCandidato.HabilitacaoE = 1 Then Me.chkE.Checked = True Else chkE.Checked = False
            If pCandidato.ConducaoPropria = 1 Then Me.chkConducao.Checked = True Else chkConducao.Checked = False

            'nacionalidade
            Me.cmbNacionalidade.Text = pCandidato.Nacionalidade.Descricao

            'operadora
            Me.cmbOperadora.Text = [Enum].GetName(GetType(Candidato.OperadoraCelular), pCandidato.Operadora)

            'mostra idade
            CalcularIdade()

            'passando o atributo para gravar as caracteristicas fisicas
            _candidato = pCandidato

            'telefone
            If pCandidato.Telefone <> "" Then
                Me.mskTelefoneFixo.Text = Utils.FormatarTelefoneFixo(pCandidato.Telefone)
            Else
                Me.mskTelefoneFixo.Text = pCandidato.Telefone
            End If

            'celular
            If pCandidato.Celular <> "" Then
                Me.mskCelular.Text = Utils.FormatarCelular(pCandidato.Celular)
            Else
                Me.mskCelular.Text = pCandidato.Celular
            End If

            chkIndicado.Checked = IIf(_candidato.Indicado = 1, True, False)
            txtIndicador.Text = IIf(_candidato.Indicado = 1, _candidato.Indicador, "")

            If _candidato.Tel_Recado_1.Length = 11 Then
                Me.txtTelRecado1.Text = Utils.FormatarCelular(_candidato.Tel_Recado_1)
            ElseIf _candidato.Tel_Recado_1.Length = 10 Then
                Me.txtTelRecado1.Text = Utils.FormatarTelefoneFixo(_candidato.Tel_Recado_1)
            End If

            Me.txtNomeRecado1.Text = _candidato.Nome_Recado_1

            If _candidato.Tel_Recado_2.Length = 11 Then
                Me.txtTelRecado2.Text = Utils.FormatarCelular(_candidato.Tel_Recado_2)
            ElseIf _candidato.Tel_Recado_2.Length = 10 Then
                Me.txtTelRecado2.Text = Utils.FormatarTelefoneFixo(_candidato.Tel_Recado_2)
            End If

            Me.txtNomeRecado2.Text = _candidato.Nome_Recado_2

            If _candidato.Tel_Recado_3.Length = 11 Then
                Me.txtTelRecado3.Text = Utils.FormatarCelular(_candidato.Tel_Recado_3)
            ElseIf _candidato.Tel_Recado_3.Length = 10 Then
                Me.txtTelRecado3.Text = Utils.FormatarTelefoneFixo(_candidato.Tel_Recado_3)
            End If

            Me.txtNomeRecado3.Text = _candidato.Nome_Recado_3
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'alterando registro
        _tipoOperacao = "A"
    End Sub



    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        If Utils.temCampoInvalido(grpInfo) Then
            MsgBox("Existem campos invalidos, estão destacados em cor diferente", MsgBoxStyle.Critical, "Campos invalidos")
            Return
        End If

        Try
            'nome do candidato
            _candidato.Nome = Me.txtNomeCompleto.Text.ToUpper.Trim

            'data de nascimento
            _candidato.DataNascimento = Me.mskNascimento.Text.Trim

            'carrega o sexo selecionado
            _candidato.Sexo = _sexo

            'carrega a cidade
            _candidato.Cidade = Me.cmbCidade.SelectedItem

            'documento
            _candidato.Documento = txtDocumento.Text.Trim

            'endereco
            _candidato.Endereco = txtEndereco.Text.ToUpper.Trim

            'telefone limpa ()-
            _candidato.Telefone = mskTelefoneFixo.Text.Replace("(", "").Replace(")", "").Replace("-", "")

            'celular limpa ()-
            _candidato.Celular = mskCelular.Text.Replace("(", "").Replace(")", "").Replace("-", "")

            'verifica se é whatsapp
            _candidato.Whatsapp = IIf(chkWhatsapp.Checked, 1, 0)

            'email
            _candidato.Email = Me.txtEmail.Text.ToUpper.Trim

            'carrega facebook
            _candidato.Facebook = Me.txtFacebook.Text.Trim

            'carrega nome social
            _candidato.NomeSocial = Me.txtNomeSocial.Text.ToUpper.Trim

            'carrega tipo de documento
            _candidato.TipoDoc = _tipoDocumento

            'carrega situação Ativo ou Inativo
            _candidato.Situacao = IIf(chkAtivo.Checked, "A", "I")

            'filhos menores de 18 anos
            If txtMenor.Text = "" Then
                _candidato.FilhosMenor = 0
            Else
                _candidato.FilhosMenor = Me.txtMenor.Text.Trim
            End If


            'filhos maiores de 18 anos
            If txtMaior.Text = "" Then
                _candidato.FilhosMaior = 0
            Else
                _candidato.FilhosMaior = Me.txtMaior.Text.Trim
            End If

            'estado civil
            _candidato.EstadoCivil = _estadoCivil

            'habilitacao a
            _candidato.HabilitacaoA = _habilitacaoA

            'habilitacao b
            _candidato.HabilitacaoB = _habilitacaoB

            'habilitacao c
            _candidato.HabilitacaoC = _habilitacaoC

            'habilitacao d
            _candidato.HabilitacaoD = _habilitacaoD

            'nacionalidade
            _candidato.Nacionalidade = cmbNacionalidade.SelectedItem

            'operadora
            _candidato.Operadora = cmbOperadora.SelectedItem

            'data de inserção
            _candidato.DataInclusao = Now

            'data de atualização
            _candidato.DataAtualizacao = Now

            'habilitacao E
            _candidato.HabilitacaoE = _habilitacaoE

            'conducao
            _candidato.ConducaoPropria = _conducao

            _candidato.Indicado = IIf(chkIndicado.Checked = True, 1, 0)

            If chkIndicado.Checked And txtIndicador.Text = "" Then
                MessageBox.Show("Coloque o nome de um indicador", "Erro indicador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtIndicador.Focus()
                Return
            Else
                _candidato.Indicador = txtIndicador.Text
            End If

            'telefone recado 1
            _candidato.Tel_Recado_1 = Me.txtTelRecado1.Text.Replace("(", "").Replace(")", "").Replace("-", "")

            'nome recado 1
            _candidato.Nome_Recado_1 = Me.txtNomeRecado1.Text

            'telefone recado 2
            _candidato.Tel_Recado_2 = Me.txtTelRecado2.Text.Replace("(", "").Replace(")", "").Replace("-", "")

            'nome recado 2
            _candidato.Nome_Recado_2 = Me.txtNomeRecado2.Text

            'telefone recado 3
            _candidato.Tel_Recado_3 = Me.txtTelRecado3.Text.Replace("(", "").Replace(")", "").Replace("-", "")

            'nome recado 3
            _candidato.Nome_Recado_3 = Me.txtNomeRecado3.Text

            'se o registro for novo
            If _tipoOperacao = "N" Then

                'foto
                If Not PictureBox1.Image Is Nothing Then
                    _candidato.Foto = txtNomeCompleto.Text.Replace(Chr(32), "_") & "_" & Now.ToShortDateString.Replace("/", "-") & "_" & Now.ToLongTimeString.Replace(":", "-") & ".jpg"
                Else
                    _candidato.Foto = ""
                End If

                'recebe o codigo do candidato inserido na hora
                _candidato.Codigo = RegrasDeNegocio.InserirCandidato(_candidato)

                'salva o video no HDD
                Call SalvarFoto(_candidato.Foto)

                'inicia um novo objeto curriculo
                Dim _curriculo As New frmCurriculo(_candidato)
                _curriculo.ShowDialog()

                Me.Close()

                'Call LimparCampos()
                '_candidato = New Candidato

                'setar valores padroes
                'Call SetarValoresPadroes()
            Else
                'foto
                If Not PictureBox1.Image Is Nothing Then
                    _candidato.Foto = txtNomeCompleto.Text.Replace(Chr(32), "_") & "_" & Now.ToShortDateString.Replace("/", "-") & "_" & Now.ToLongTimeString.Replace(":", "-") & ".jpg"
                Else
                    _candidato.Foto = ""
                End If

                RegrasDeNegocio.AlterarCandidato(_candidato)

                Call SalvarFoto(_candidato.Foto)

                Dim _curriculo As New frmCurriculo(_candidato)
                _curriculo.ShowDialog()
                Me.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SalvarFoto(ByVal pNomeArquivo As String)
        If pNomeArquivo <> "" Then
            If Not System.IO.Directory.Exists(Utils.DiretorioFotoCandidato) Then
                System.IO.Directory.CreateDirectory(Utils.DiretorioFotoCandidato)
            End If

            PictureBox1.Image.Save(Utils.DiretorioFotoCandidato & pNomeArquivo)
        End If
    End Sub

    Private Sub PreencheCidadesCombo()
        Try
            Me.cmbCidade.DataSource = RegrasDeNegocio.GetCidades("")
            Me.cmbCidade.DisplayMember = "Descricao"

            Me.cmbCidade.SelectedIndex = 63
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub frmCandidato_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not _candidato Is Nothing Then _candidato.Dispose()
    End Sub

    Private Sub mskCelular_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mskCelular.Leave
        Dim texto As TextBox = CType(sender, TextBox)
        Try
            If texto.Text = "" Then Return
            texto.Text = Utils.FormatarCelular(texto.Text)
        Catch ex As Exception
            MsgBox(ex.Message)
            texto.Focus()
        End Try
    End Sub

    Private Sub mskTelefone_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mskTelefoneFixo.Leave
        Dim texto As TextBox = CType(sender, TextBox)
        Try
            If texto.Text = "" Then Return
            texto.Text = Utils.FormatarTelefoneFixo(texto.Text)
        Catch ex As Exception
            MsgBox(ex.Message)
            texto.Focus()
        End Try
    End Sub

    Private Sub mskDataNascimento_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mskNascimento.Leave
        Dim texto As TextBox = CType(sender, TextBox)

        Try
            If texto.Text = "" Then Return
            texto.Text = Utils.FormatarData(texto.Text)

            Call CalcularIdade()
        Catch ex As Exception
            MsgBox(ex.Message)
            texto.Focus()
        End Try
    End Sub

    Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Foto As New frmCapturaFoto()
        Foto.ShowDialog()

        If Not Foto.FotoCandidato Is Nothing Then
            Me.PictureBox1.Image = Foto.FotoCandidato
            'Me.PictureBox1.Refresh()
        End If
    End Sub

    Private Sub LimparCampos()
        Call LimparGroups(grpInfo)
        Call LimparGroups(grpContato)
        Call LimparGroups(grpFilhos)

        Try
            Me.optSolteiro.Checked = True
            Me.optMasc.Checked = True
            lblIdade.Text = ""

            Me.chkA.Checked = False
            Me.chkB.Checked = False
            Me.chkC.Checked = False
            Me.chkD.Checked = False
            Me.chkWhatsapp.Checked = False

            Call PreencheCidadesCombo()
            Call CarregarNacionalidades()

            Me.PictureBox1.Image = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LimparGroups(ByVal grpAtual As GroupBox)
        Dim textos = From texto In grpAtual.Controls Where TypeOf texto Is TextBox

        For Each texto As TextBox In textos
            If texto.Name = "txtFilhosMenor" Or texto.Name = "txtFilhosMaior" Then
                texto.Text = "0"
            Else
                texto.Text = ""
            End If
        Next
    End Sub

    Private Sub optCPF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCPF.CheckedChanged
        _tipoDocumento = CType(sender, RadioButton).Tag
    End Sub

    Private Sub optRG_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optRG.CheckedChanged
        _tipoDocumento = CType(sender, RadioButton).Tag
    End Sub

    Private Sub optOutros_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optOutros.CheckedChanged
        _tipoDocumento = CType(sender, RadioButton).Tag
    End Sub

    Private Sub optMasc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMasc.CheckedChanged
        Me._sexo = "M"
    End Sub

    Private Sub optFem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optFem.CheckedChanged
        Me._sexo = "F"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.PictureBox1.Image = Nothing
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim InformacoesAdicionais As New frmInformacoesRestritas(_candidato)
        InformacoesAdicionais.ShowDialog()

        If InformacoesAdicionais.Salvo Then
            btnGravar.Enabled = True
        End If
    End Sub

    Private Sub CalcularIdade()
        lblIdade.Text = CStr(Math.Floor((CDate(Now)).Subtract(CDate(mskNascimento.Text)).Days / 365)) & " anos de idade"
    End Sub

    Private Sub txtMenor_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMenor.Leave
        Dim texto As TextBox = CType(sender, TextBox)
        If texto.Text = "" Then
            texto.Text = "0"
        End If
    End Sub

    Private Sub txtMaior_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMaior.Leave
        Dim texto As TextBox = CType(sender, TextBox)
        If texto.Text = "" Then
            texto.Text = "0"
        End If
    End Sub

    Private Sub optSolteiro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optSolteiro.CheckedChanged
        Dim radio As RadioButton = CType(sender, RadioButton)
        If radio.Checked Then _estadoCivil = radio.Tag
    End Sub

    Private Sub optCasado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCasado.CheckedChanged
        Dim radio As RadioButton = CType(sender, RadioButton)
        If radio.Checked Then _estadoCivil = radio.Tag
    End Sub

    Private Sub optSeparado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optSeparado.CheckedChanged
        Dim radio As RadioButton = CType(sender, RadioButton)
        If radio.Checked Then _estadoCivil = radio.Tag
    End Sub

    Private Sub optDivorciado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optDivorciado.CheckedChanged
        Dim radio As RadioButton = CType(sender, RadioButton)
        If radio.Checked Then _estadoCivil = radio.Tag
    End Sub

    Private Sub optUniaoEstavel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optUniaoEstavel.CheckedChanged
        Dim radio As RadioButton = CType(sender, RadioButton)
        If radio.Checked Then _estadoCivil = radio.Tag
    End Sub

    Private Sub chkA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkA.CheckedChanged
        Dim check As CheckBox = CType(sender, CheckBox)
        If check.Checked Then _habilitacaoA = 1 Else _habilitacaoA = 0
    End Sub

    Private Sub chkB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkB.CheckedChanged
        Dim check As CheckBox = CType(sender, CheckBox)
        If check.Checked Then _habilitacaoB = 1 Else _habilitacaoB = 0
    End Sub

    Private Sub chkC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkC.CheckedChanged
        Dim check As CheckBox = CType(sender, CheckBox)
        If check.Checked Then _habilitacaoC = 1 Else _habilitacaoC = 0
    End Sub

    Private Sub chkD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkD.CheckedChanged
        Dim check As CheckBox = CType(sender, CheckBox)
        If check.Checked Then _habilitacaoD = 1 Else _habilitacaoD = 0
    End Sub

    Private Sub optViuvo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optViuvo.CheckedChanged
        Dim radio As RadioButton = CType(sender, RadioButton)
        If radio.Checked Then _estadoCivil = radio.Tag
    End Sub

    Private Sub CarregarNacionalidades()
        Try
            Me.cmbNacionalidade.DataSource = RegrasDeNegocio.GetNacionalidades("")
            Me.cmbNacionalidade.DisplayMember = "DESCRICAO"

            'inicia com brasileiro selecionado
            Me.cmbNacionalidade.SelectedIndex = 18
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Process.Start("https://www.facebook.com/search/top/?q=" & txtFacebook.Text)
    End Sub

    Private Sub cmbCidade_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCidade.Leave
        Dim combo As ComboBox = CType(sender, ComboBox)
        If combo.SelectedItem Is Nothing Then
            MessageBox.Show("Selecione uma cidade válida", "Cidade inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            combo.Focus()
        End If
    End Sub

    Private Sub cmbNacionalidade_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNacionalidade.Leave
        Dim combo As ComboBox = CType(sender, ComboBox)
        If combo.SelectedItem Is Nothing Then
            MessageBox.Show("Selecione uma nacionalidade válida", "Cidade inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            combo.Focus()
        End If
    End Sub

    Private Sub btnCurriculo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCurriculo.Click
        Dim trabalharCurriculo As New frmCurriculo(_candidato)
        trabalharCurriculo.MdiParent = frmPrincipal.MdiParent
        trabalharCurriculo.WindowState = FormWindowState.Maximized
        trabalharCurriculo.Show()
    End Sub

    Private Sub txtNomeCompleto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNomeCompleto.KeyDown, txtNomeSocial.KeyDown, txtMenor.KeyDown, txtMaior.KeyDown, txtFacebook.KeyDown, txtEndereco.KeyDown, txtEmail.KeyDown, txtDocumento.KeyDown, mskTelefoneFixo.KeyDown, mskNascimento.KeyDown, mskCelular.KeyDown, cmbOperadora.KeyDown, cmbCidade.KeyDown, cmbNacionalidade.KeyDown, optUniaoEstavel.KeyDown, optSolteiro.KeyDown, optSeparado.KeyDown, optRG.KeyDown, optOutros.KeyDown, optMasc.KeyDown, optFem.KeyDown, optDivorciado.KeyDown, optCPF.KeyDown, optCasado.KeyDown, txtTelRecado3.KeyDown, txtTelRecado2.KeyDown, txtTelRecado1.KeyDown, txtNomeRecado3.KeyDown, txtNomeRecado2.KeyDown, txtNomeRecado1.KeyDown
        If e.KeyData = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtNomeCompleto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNomeCompleto.Leave
        Dim _texto = CType(sender, TextBox)
        _texto.Text = _texto.Text.ToUpper()

        Try
            If _nomeJaVerificado = 0 Then
                If RegrasDeNegocio.NomeExistente(_texto.Text, _tipoOperacao) Then
                    If MessageBox.Show("Nome já cadastrado, deseja continuar assim mesmo?", "Nome duplicado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                        _texto.SelectAll()
                        _texto.Focus()
                    End If

                    _nomeJaVerificado += 1
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        
    End Sub

    Private Sub SetarValoresPadroes()
        _candidato.Raca = 1
        _candidato.Fumante = 0
        _candidato.TatuagemAmostra = 0
        _candidato.BoaAparencia = 1
        _candidato.Obs = ""
    End Sub

    Private Sub frmCandidato_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.pPrincipal.Left = (Me.Width / 2) - (pPrincipal.Width / 2)
        'Me.pPrincipal.Right = (Me.Height / 2) - (pPrincipal.Height / 2)
    End Sub

    Private Sub BtnHist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHist.Click
        Dim hist As New frmHistoricoAntigo(_candidato.Nome, _candidato.Codigo)
        hist.TopMost = True
        hist.Show()
    End Sub

    Private Sub chkE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkE.CheckedChanged
        Dim check As CheckBox = CType(sender, CheckBox)
        If check.Checked Then _habilitacaoE = 1 Else _habilitacaoE = 0
    End Sub

    Private Sub chkConducao_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkConducao.CheckedChanged
        Dim check As CheckBox = CType(sender, CheckBox)
        If check.Checked Then _conducao = 1 Else _conducao = 0
    End Sub

    Private Sub chkIndicado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIndicado.CheckedChanged
        Dim check As CheckBox = CType(sender, CheckBox)
        If check.Checked Then
            _indicado = 1
            txtIndicador.Enabled = True
        Else
            _indicado = 0
            txtIndicador.Enabled = False
            txtIndicador.Text = ""
        End If
    End Sub

    Private Sub txtTelRecado1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTelRecado1.Leave, txtTelRecado3.Leave, txtTelRecado2.Leave
        Dim texto As TextBox = CType(sender, TextBox)
        Try
            If texto.Text = "" Then Return

            If texto.TextLength = 10 Then
                texto.Text = Utils.FormatarTelefoneFixo(texto.Text)
            Else
                texto.Text = Utils.FormatarCelular(texto.Text)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            texto.Focus()
        End Try
    End Sub
End Class

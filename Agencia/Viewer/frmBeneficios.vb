Imports DTO
Imports Utilidades

Public Class frmBeneficios
    Private _curriculoCargos As CurriculoCargo = Nothing

    Public Sub New(ByVal pCurriculoCargos As CurriculoCargo)
        InitializeComponent()

        Me.chkCestaBasica.Checked = IIf(pCurriculoCargos.CestaBasica = 1, True, False)
        Me.mskCestaBasica.Text = Utils.FormataMoeda(pCurriculoCargos.ValorCestaBasica)

        Me.chkValeTransporte.Checked = IIf(pCurriculoCargos.ValeTransporte = 1, True, False)
        Me.mskValeTransporte.Text = Utils.FormataMoeda(pCurriculoCargos.ValorTransporte)

        Me.chkPLR.Checked = IIf(pCurriculoCargos.PLR = 1, True, False)
        Me.mskPLR.Text = Utils.FormataMoeda(pCurriculoCargos.ValorPLR)

        Me.chkConvenioMedico.Checked = IIf(pCurriculoCargos.ConvenioMedico = 1, True, False)
        Me.mskConvenio.Text = Utils.FormataMoeda(pCurriculoCargos.ValorConvenioMedico)

        Me.chkValeRefeicao.Checked = IIf(pCurriculoCargos.ValeRefeicao = 1, True, False)
        Me.mskValeRefeicao.Text = Utils.FormataMoeda(pCurriculoCargos.ValorRefeicao)

        Me.chkSeguroVida.Checked = IIf(pCurriculoCargos.SeguroDeVida = 1, True, False)
        Me.mskSeguroVida.Text = Utils.FormataMoeda(pCurriculoCargos.ValorSeguroVida)

        Me.chkAjudaCustoEnsino.Checked = IIf(pCurriculoCargos.AjudaCustoEstudo = 1, True, False)
        Me.mskAjudaCustoEnsino.Text = Utils.FormataMoeda(pCurriculoCargos.ValorAjudaCustoEnsino)

        Me.chkAuxilioCreche.Checked = IIf(pCurriculoCargos.AuxilioCreche = 1, True, False)
        Me.mskAuxilioCreche.Text = Utils.FormataMoeda(pCurriculoCargos.ValorAuxilioCreche)

        Me.chkAuxilioDentista.Checked = IIf(pCurriculoCargos.AuxilioDentista = 1, True, False)
        Me.mskAuxilioCreche.Text = Utils.FormataMoeda(pCurriculoCargos.ValorAuxilioCreche)

        Me.chkAuxilioDentista.Checked = IIf(pCurriculoCargos.AuxilioDentista = 1, True, False)
        Me.mskDentista.Text = Utils.FormataMoeda(pCurriculoCargos.ValorAuxilioDentista)

        mskValorRecebidoFora.Text = Utils.FormataMoeda(pCurriculoCargos.ValorRecebidoFora)

        _curriculoCargos = pCurriculoCargos
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        _curriculoCargos.CestaBasica = IIf(chkCestaBasica.Checked, 1, 0)
        _curriculoCargos.ValorCestaBasica = mskCestaBasica.Text.Trim

        _curriculoCargos.ValeTransporte = IIf(chkValeTransporte.Checked, 1, 0)
        _curriculoCargos.ValorTransporte = mskValeTransporte.Text.Trim

        _curriculoCargos.PLR = IIf(chkPLR.Checked, 1, 0)
        _curriculoCargos.ValorPLR = mskPLR.Text.Trim

        _curriculoCargos.ConvenioMedico = IIf(chkConvenioMedico.Checked, 1, 0)
        _curriculoCargos.ValorConvenioMedico = mskConvenio.Text.Trim

        _curriculoCargos.ValeRefeicao = IIf(chkValeRefeicao.Checked, 1, 0)
        _curriculoCargos.ValorRefeicao = mskValeRefeicao.Text.Trim

        _curriculoCargos.SeguroDeVida = IIf(chkSeguroVida.Checked, 1, 0)
        _curriculoCargos.ValorSeguroVida = mskSeguroVida.Text.Trim

        _curriculoCargos.AjudaCustoEstudo = IIf(chkAjudaCustoEnsino.Checked, 1, 0)
        _curriculoCargos.ValorAjudaCustoEnsino = mskAjudaCustoEnsino.Text.Trim

        _curriculoCargos.AuxilioCreche = IIf(chkAuxilioCreche.Checked, 1, 0)
        _curriculoCargos.ValorAuxilioCreche = mskAuxilioCreche.Text.Trim

        _curriculoCargos.AuxilioDentista = IIf(chkAuxilioDentista.Checked, 1, 0)
        _curriculoCargos.ValorAuxilioDentista = mskDentista.Text.Trim

        _curriculoCargos.ValorRecebidoFora = mskValorRecebidoFora.Text.Trim

        Me.Close()
    End Sub

    Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub


    Private Sub HabilitarDesabilitar(ByVal pCheckbox As CheckBox, ByVal pMascara As TextBox)
        If pCheckbox.Checked Then
            pMascara.Enabled = True
        Else
            pMascara.Enabled = False
            pMascara.Text = 0
        End If
    End Sub

    Private Sub chkValeTransporte_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkValeTransporte.CheckedChanged
        HabilitarDesabilitar(sender, mskValeTransporte)
    End Sub

    Private Sub chkPLR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPLR.CheckedChanged
        HabilitarDesabilitar(sender, mskPLR)
    End Sub

    Private Sub chkConvenioMedico_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkConvenioMedico.CheckedChanged
        HabilitarDesabilitar(sender, mskConvenio)
    End Sub

    Private Sub chkValeRefeicao_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkValeRefeicao.CheckedChanged
        HabilitarDesabilitar(sender, mskValeRefeicao)
    End Sub

    Private Sub chkSeguroVida_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSeguroVida.CheckedChanged
        HabilitarDesabilitar(sender, mskSeguroVida)
    End Sub

    Private Sub chkAjudaCustoEnsino_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAjudaCustoEnsino.CheckedChanged
        HabilitarDesabilitar(sender, mskAjudaCustoEnsino)
    End Sub

    Private Sub chkAuxilioCreche_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAuxilioCreche.CheckedChanged
        HabilitarDesabilitar(sender, mskAuxilioCreche)
    End Sub

    Private Sub chkAuxilioDentista_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAuxilioDentista.CheckedChanged
        HabilitarDesabilitar(sender, mskDentista)
    End Sub

    Private Sub mskCestaBasica_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mskCestaBasica.Leave, mskValorRecebidoFora.Leave, mskValeTransporte.Leave, mskValeRefeicao.Leave, mskSeguroVida.Leave, mskPLR.Leave, mskDentista.Leave, mskConvenio.Leave, mskAuxilioCreche.Leave, mskAjudaCustoEnsino.Leave
        Dim msk As TextBox = CType(sender, TextBox)
        If msk.Text = "" Then
            msk.Text = 0
        End If

        msk.Text = Utilidades.Utils.FormataMoeda(msk.Text)
    End Sub

    Private Sub chkCestaBasica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCestaBasica.CheckedChanged
        HabilitarDesabilitar(sender, mskCestaBasica)
    End Sub
End Class
Imports DTO

Public Class frmInformacoesRestritas

    Private _candidato As Candidato = Nothing
    Private _raca As Candidato.TipoRaça
    Private _fumante As Integer = 0
    Private _tatuagemAmostra As Integer = 0
    Private _boaAparencia As Integer = 0
    Private _obs As String = ""
    Private _salvo As Boolean

    Public ReadOnly Property Salvo
        Get
            Return _salvo
        End Get
    End Property


    Public Sub New(ByRef pCandidato As Candidato)
        InitializeComponent()

        'carrega os enumeradores de raça
        Me.optBranco.Tag = Candidato.TipoRaça.branco
        Me.optNegro.Tag = Candidato.TipoRaça.negro
        Me.optPardo.Tag = Candidato.TipoRaça.pardo
        Me.optIndigina.Tag = Candidato.TipoRaça.indigena

        'raça do candidato
        If pCandidato.Raca = Candidato.TipoRaça.branco Then
            optBranco.Checked = True
        ElseIf pCandidato.Raca = Candidato.TipoRaça.negro Then
            optNegro.Checked = True
        ElseIf pCandidato.Raca = Candidato.TipoRaça.pardo Then
            optPardo.Checked = True
        Else
            optIndigina.Checked = True
        End If

        If pCandidato.Fumante = 1 Then Me.optFumanteSim.Checked = True Else Me.optFumanteNao.Checked = True
        If pCandidato.TatuagemAmostra = 1 Then Me.optTatuagemSim.Checked = True Else optTatuagemNao.Checked = True
        If pCandidato.BoaAparencia = 1 Then Me.optBoaAparenciaSim.Checked = True Else optBoaAparenciaNao.Checked = True

        Me.txtObs.Text = pCandidato.Obs

        _candidato = pCandidato
    End Sub

    Private Sub optBranco_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optBranco.CheckedChanged
        _raca = CType(sender, RadioButton).Tag
    End Sub

    Private Sub optNegro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optNegro.CheckedChanged
        _raca = CType(sender, RadioButton).Tag
    End Sub

    Private Sub optPardo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPardo.CheckedChanged
        _raca = CType(sender, RadioButton).Tag
    End Sub

    Private Sub optIndigina_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optIndigina.CheckedChanged
        _raca = CType(sender, RadioButton).Tag
    End Sub

    Private Sub optFumanteSim_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optFumanteSim.CheckedChanged
        _fumante = IIf(CType(sender, RadioButton).Checked, 1, 0)
    End Sub

    Private Sub optTatuagemSim_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTatuagemSim.CheckedChanged
        _tatuagemAmostra = IIf(CType(sender, RadioButton).Checked, 1, 0)
    End Sub

    Private Sub optBoaAparenciaSim_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optBoaAparenciaSim.CheckedChanged
        _boaAparencia = IIf(CType(sender, RadioButton).Checked, 1, 0)
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        _candidato.Raca = _raca
        _candidato.Fumante = _fumante
        _candidato.TatuagemAmostra = _tatuagemAmostra
        _candidato.Obs = txtObs.Text
        _candidato.BoaAparencia = _boaAparencia
        _salvo = True

        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub
End Class
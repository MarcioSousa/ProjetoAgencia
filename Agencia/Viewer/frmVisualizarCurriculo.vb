Imports DTO
Imports BLL
Imports Utilidades

Public Class frmVisualizarCurriculo

    Public Sub New(ByVal pCandidato As Candidato)
        InitializeComponent()

        txtCurriculo.Text =
            "Informações pessoais: " & vbCrLf & vbCrLf & _
            "Nome completo: " & pCandidato.Nome & vbCrLf & _
            "Nome social: " & pCandidato.NomeSocial & vbCrLf & _
            "Data de nascimento: " & pCandidato.DataNascimento & " - Idade: " & Math.Floor(Now.Subtract(pCandidato.DataNascimento).Days / 365) & " anos" & vbCrLf & _
            "Tipo de documento: " & [Enum].GetName(GetType(Candidato.TipoDeDocumento), pCandidato.TipoDoc) & vbCrLf & _
            "Numero de documento: " & pCandidato.Documento & vbCrLf & _
            "Sexo: " & IIf(pCandidato.Sexo = "M", "Masculino", "Feminino") & vbCrLf & _
            "Nacionalidade: " & pCandidato.Nacionalidade.Descricao & vbCrLf & _
            "-----------------------------------------------" & vbCrLf & _
            "Informações de contato: " & vbCrLf & vbCrLf & _
            "Facebook: " & pCandidato.Facebook & vbCrLf & _
            "Telefone fixo: " & Utils.FormatarTelefoneFixo(pCandidato.Telefone) & vbCrLf & _
            "Celular: " & Utils.FormatarCelular(pCandidato.Celular) & " " & [Enum].GetName(GetType(Candidato.OperadoraCelular), pCandidato.Operadora) & " " & IIf(pCandidato.Whatsapp = 1, "<Whatsapp>", "") & vbCrLf &
            "Email: " & pCandidato.Email & vbCrLf & _
            "-----------------------------------------------" & vbCrLf & _
            "Logradouro: " & vbCrLf & vbCrLf & _
            "Endereço: " & pCandidato.Endereco & vbCrLf & _
            "Cidade: " & pCandidato.Cidade.Descricao & " - " & pCandidato.Cidade.UF & vbCrLf & _
            "-----------------------------------------------" & vbCrLf & _
            "Classificação do candidato:" & vbCrLf & vbCrLf & _
            [Enum].GetName(GetType(Curriculo.TipoClassificação), pCandidato.Curriculo.Classificacao) & vbCrLf & _
            "-----------------------------------------------" & vbCrLf & _
            "Escolaridade:" & vbCrLf & vbCrLf & _
           [Enum].GetName(GetType(Curriculo.NivelEscolaridade), pCandidato.Curriculo.Escolaridade).Replace("_", Chr(32)) & vbCrLf & _
           "-----------------------------------------------" & vbCrLf & _
            "Cursos complementares:" & vbCrLf & vbCrLf & _
            GetCursos(pCandidato.Curriculo.Cursos) & _
            "-----------------------------------------------" & vbCrLf & _
            "Idioma(s):" & vbCrLf & vbCrLf & _
            GetIdiomas(pCandidato.Curriculo.Idiomas)

    End Sub

    Private Function GetCursos(ByVal pCursos As List(Of CursoCurriculo)) As String
        Dim _cursos As String = ""

        For Each _curso In pCursos
            _cursos += "Instituição: " & _curso.Curso.Entidade.Descricao & Chr(32) & _curso.Curso.Entidade.Cidade.Descricao & "(" & _curso.Curso.Entidade.Cidade.UF & ")" & vbCrLf & _
                       "Curso: " & _curso.Curso.Descricao & vbCrLf & _
                       "Carga horaria: " & _curso.Curso.CargaHoraria & " hs" & vbCrLf & _
                       "Período de: " & _curso.DataInicial & " à " & _curso.DataFinal & vbCrLf & _
                       "Status: " & IIf(_curso.Concluido = 1, "Concluido", "Interrompido") & vbCrLf & _
                       "Observações: " & _curso.Obs & vbCrLf & vbCrLf
        Next

        Return _cursos
    End Function

    Private Function GetIdiomas(ByVal pIdiomas As List(Of IdiomaCurriculo))
        Dim _idiomas As String = ""

        For Each _idioma In pIdiomas
            _idiomas += _idioma.Idioma.Descricao & Chr(32) & IIf(_idioma.Nativo = 1, "(Nativo)", "") & vbCrLf & "Observações: " & _idioma.Obs & vbCrLf
        Next

        Return _idiomas
    End Function

    Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub
End Class
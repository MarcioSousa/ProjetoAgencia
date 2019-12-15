Imports System.Collections.Generic
Imports DAL
Imports DTO

Public Class RegrasDeNegocio

#Region "Gets"

    Public Shared Function GetCidades(ByVal pNomeCidade As String) As List(Of Cidade)
        pNomeCidade = pNomeCidade.Replace("'", "")

        Dim _query As String = "select * from tb_cidade "
        Try
            If pNomeCidade <> "" Then
                _query += "where nome like '%" & pNomeCidade & "%' order by nome"
            Else
                _query += "order by nome"
            End If

            Return Persistencia.GetCidades(_query)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Shared Function GetCandidatos(ByVal pNome As String, ByVal pDocumento As String, ByVal pAtivo As Boolean) As List(Of Candidato)
        pNome = pNome.Replace("'", "")

        Dim _query As String = "select a.*,b.*,c.*,d.* from TB_CANDIDATO a inner join TB_CIDADE b on a.CIDADE = b.CODIGO inner join tb_nacionalidade c on a.NACIONALIDADE = c.CODIGO left outer join TB_CURRICULO d on d.CANDIDATO = a.CODIGO "
        Try
            If pNome <> "" And pAtivo Then
                _query += "WHERE a.NOME LIKE '%" & pNome & "%' AND a.SITUACAO = 'A' ORDER BY a.NOME"
            ElseIf pNome <> "" And Not pAtivo Then
                _query += "WHERE a.NOME LIKE '%" & pNome & "%' AND a.SITUACAO = 'I' ORDER BY a.NOME"
            ElseIf pDocumento <> "" And pAtivo Then
                _query += "WHERE a.DOCUMENTO LIKE '%" & pDocumento & "%' AND a.SITUACAO = 'A' ORDER BY a.NOME"
            ElseIf pDocumento <> "" And Not pAtivo Then
                _query += "WHERE a.DOCUMENTO LIKE '%" & pDocumento & "%' AND a.SITUACAO = 'I' ORDER BY a.NOME"
            ElseIf pNome = "" And pDocumento = "" And pAtivo Then
                _query += "WHERE a.NOME LIKE '%" & pNome & "%' AND a.SITUACAO = 'A' ORDER BY a.NOME"
            ElseIf pNome = "" And pDocumento = "" And Not pAtivo Then
                _query += "WHERE a.NOME LIKE '%" & pNome & "%' AND a.SITUACAO = 'I' ORDER BY a.NOME"
            End If

            Return Persistencia.GetCandidatos(_query)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Shared Function GetNacionalidades(ByVal pNacionalidade As String) As List(Of Nacionalidade)
        pNacionalidade = pNacionalidade.Replace("'", "")
        Dim _query As String = "select * from tb_nacionalidade "

        Try
            If pNacionalidade <> "" Then
                _query += "where descricao like '%" & pNacionalidade & "%' order by descricao"
            Else
                _query += "order by descricao"
            End If

            Return Persistencia.GetNacionalidades(_query)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Shared Function GetEmpresas(ByVal pRazSocial As String, ByVal pNomeFan As String, ByVal pAtivo As Boolean) As List(Of Empresa)
        Dim _query As String = "select a.*,b.* from TB_EMPRESA a inner join TB_CIDADE b on a.CIDADE = b.CODIGO "
        Try
            If pRazSocial <> "" And pAtivo Then
                _query += "WHERE a.RAZ_SOCIAL LIKE '%" & pRazSocial & "%' AND a.SITUACAO = 'A' ORDER BY a.NOME_FANTASIA"
            ElseIf pRazSocial <> "" And Not pAtivo Then
                _query += "WHERE a.RAZ_SOCIAL LIKE '%" & pRazSocial & "%' AND a.SITUACAO = 'I' ORDER BY a.NOME_FANTASIA"
            ElseIf pNomeFan <> "" And pAtivo Then
                _query += "WHERE a.NOME_FANTASIA LIKE '%" & pNomeFan & "%' AND a.SITUACAO = 'A' ORDER BY a.NOME_FANTASIA"
            ElseIf pNomeFan <> "" And Not pAtivo Then
                _query += "WHERE a.NOME_FANTASIA LIKE '%" & pNomeFan & "%' AND a.SITUACAO = 'I' ORDER BY a.NOME_FANTASIA"
            ElseIf pNomeFan <> "" And pRazSocial <> "" And pAtivo Then
                _query += "WHERE a.NOME_FANTASIA LIKE '%" & pNomeFan & "%' AND a.RAZ_SOCIAL LIKE '%" & pRazSocial & "%' AND a.SITUACAO = 'A' ORDER BY a.NOME_FANTASIA"
            ElseIf pNomeFan <> "" And pRazSocial <> "" And Not pAtivo Then
                _query += "WHERE a.NOME_FANTASIA LIKE '%" & pNomeFan & "%' AND a.RAZ_SOCIAL LIKE '%" & pRazSocial & "%' AND a.SITUACAO = 'I' ORDER BY a.NOME_FANTASIA"
            ElseIf pNomeFan = "" And pRazSocial = "" And pAtivo Then
                _query += "WHERE a.SITUACAO = 'A' ORDER BY a.NOME_FANTASIA"
            ElseIf pNomeFan = "" And pRazSocial = "" And Not pAtivo Then
                _query += "WHERE a.SITUACAO = 'I' ORDER BY a.NOME_FANTASIA"
            End If

            Return Persistencia.GetEmpresas(_query)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

    Public Shared Function GetIdiomas() As List(Of Idioma)
        Try
            Return Persistencia.GetIdiomas("SELECT * FROM TB_IDIOMA ORDER BY DESCRICAO")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Shared Function GetAreas(ByVal pNomeArea As String, ByVal pSituacao As Char) As List(Of Area)
        Dim _query As String = "SELECT * FROM TB_AREA "

        Try
            If pNomeArea <> "" And pSituacao = "A" Then
                _query += "WHERE DESCRICAO LIKE '%" & pNomeArea & "%' AND SITUACAO = 'A'"
            ElseIf pNomeArea <> "" And pSituacao = "I" Then
                _query += "WHERE DESCRICAO LIKE '%" & pNomeArea & "%' AND SITUACAO = 'I'"
            ElseIf pNomeArea = "" And pSituacao = "A" Then
                _query += "WHERE SITUACAO = 'A'"
            ElseIf pNomeArea = "" And pSituacao = "I" Then
                _query += "WHERE SITUACAO = 'I'"
            End If

            Return Persistencia.GetAreas(_query)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Shared Function GetCargos(ByVal pCodigoArea As String, ByVal pNomeCargo As String) As List(Of Cargo)
        pCodigoArea = pCodigoArea.Replace("'", "")
        pNomeCargo = pNomeCargo.Replace("'", "")

        Dim _query As String = "select a.*,b.* from TB_CARGO a inner join TB_AREA b on a.AREA = b.CODIGO "
        Try
            If pCodigoArea <> "" Then
                _query += "where b.codigo = " & pCodigoArea & " order by a.descricao"
            ElseIf pNomeCargo <> "" Then
                _query += "where a.descricao like '%" & pNomeCargo & "%' order by a.descricao"
            Else
                _query += "order by a.descricao"
            End If

            Return Persistencia.GetCargos(_query)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Shared Function GetEntidades(ByVal pNomeEntidade As String, ByVal pStatus As Char) As List(Of Entidade)
        pNomeEntidade = pNomeEntidade.Replace("'", "")

        Dim _query As String = "select a.*,b.* from TB_ENTIDADE_ENSINO a inner join TB_CIDADE b on a.CIDADE = b.CODIGO "

        Try
            If pNomeEntidade <> "" And pStatus = "A" Then
                _query += "where a.nome_entidade like '%" & pNomeEntidade & "%' and a.situacao = 'A' order by nome_entidade"
            ElseIf pNomeEntidade <> "" And pStatus = "I" Then
                _query += "where a.nome_entidade like '%" & pNomeEntidade & "%' and a.situacao = 'I' order by nome_entidade"
            ElseIf pNomeEntidade = "" And pStatus = "A" Then
                _query += "where a.situacao = 'A' order by nome_entidade"
            ElseIf pNomeEntidade = "" And pStatus = "I" Then
                _query += "where a.situacao = 'I' order by nome_entidade"
            End If

            Return Persistencia.GetEntidades(_query)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Shared Function GetHistorico(ByVal pCodigoCandidato As String) As List(Of HistoricoFB)
        Try
            Return Persistencia.GetHistoricoFirebird(pCodigoCandidato)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function



    Public Shared Function GetCursos(ByVal pNomeCurso As String, ByVal pAtivo As Char) As List(Of Curso)
        pNomeCurso = pNomeCurso.Replace("'", "")

        Dim _query As String = "select a.*,b.*,c.* from TB_CURSO a inner join TB_ENTIDADE_ENSINO b on a.ENTIDADE = b.CODIGO inner join TB_CIDADE c on b.CIDADE = c.CODIGO "
        Try

            If pNomeCurso <> "" And pAtivo = "A" Then
                _query += "WHERE a.DESCRICAO collate Latin1_General_CI_AI LIKE '%" & pNomeCurso & "%' AND a.SITUACAO = 'A' ORDER BY a.DESCRICAO"
            ElseIf pNomeCurso <> "" And pAtivo = "I" Then
                _query += "WHERE a.DESCRICAO collate Latin1_General_CI_AI LIKE '%" & pNomeCurso & "%' AND a.SITUACAO = 'I' ORDER BY a.DESCRICAO"
            ElseIf pNomeCurso = "" And pAtivo = "A" Then
                _query += "WHERE a.SITUACAO = 'A' ORDER BY a.DESCRICAO"
            ElseIf pNomeCurso = "" And pAtivo = "I" Then
                _query += "WHERE a.SITUACAO = 'I' ORDER BY a.DESCRICAO"
            Else
                _query += "ORDER BY A.DESCRICAO"
            End If

            Return Persistencia.GetCursos(_query)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Shared Sub Login(ByVal pUsuario As String, ByVal pSenha As String)
        Try
            Persistencia.Login(pUsuario.Replace("'", ""), pSenha.Replace("'", ""))
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Shared Sub GerarRelatorio(ByVal pCandidato As String)
        Dim _query As String =
        "select candidato.nome as 'nome',candidato.data_nascimento as 'nascimento',candidato.tipo_doc as 'tipo_doc',candidato.documento as 'documento',candidato.sexo as 'sexo',candidato.telefone as 'telefone',candidato.celular as 'celular',candidato.endereco as 'endereco'," & _
        "candidato.whatsapp as 'whatsapp',candidato.filhos_menor as 'filhos_menor',candidato.filhos_maior as 'filhos_maior',candidato.estado_civil as 'estado_civil',candidato.hab_a as 'hab_a',candidato.hab_b as 'hab_b',candidato.hab_c as 'hab_c',candidato.hab_d as 'hab_d'," & _
        "candidato.operadora_celular as 'operadora',cidade_candidato.nome as 'cidade_candidato',cidade_candidato.uf as 'uf',nacionalidade.descricao as 'nacionalidade',curriculo.ultimo_salario as 'ultimo_salario'," & _
        "curriculo.pretensao_salarial as 'pretensao',area.descricao as 'area_cargo',cargo.descricao as 'cargo_pretendido',idioma.descricao as 'idioma',curriculo_idioma.NATIVO as 'nativo'," & _
        "curriculo_idioma.OBS as 'obs_idioma',curso.DESCRICAO as 'curso',curso.CATEGORIA as 'categoria_curso',curso.CARGA_HORARIA as 'carga_horaria'," & _
        "curso_curriculo.DATA_INICIAL as 'data_inicial',curso_curriculo.DATA_FINAL as 'data_final',curso_curriculo.CONCLUIDO as 'concluido',curso_curriculo.OBS as 'obs_curso'," & _
        "entidade_ensino.NOME_ENTIDADE as 'nome_entidade',cidade_entidade.NOME as 'cidade_entidade',cargo_empresa.NOME_FANTASIA As 'empresa',cidade_empresa.NOME as 'cidade_empresa'," & _
        "cargo_anterior.DESCRICAO as 'experiencia',cargo_curriculo.DATA_INICIO as 'data_admissao',cargo_curriculo.DATA_FINAL as 'data_demissao',cargo_curriculo.FUNCOES_DESEMP as 'funcoes_desempenhadas'," & _
        "cargo_curriculo.MOTIVO_SAIDA as 'motivo_saida',curriculo.obs as 'obs_curriculo',curriculo.ESCOLARIDADE as 'escolaridade',cargo_curriculo.REGISTRADO as 'registrado',cidade_entidade.UF as 'uf_entidade' " & _
        "from TB_CANDIDATO candidato inner join TB_CIDADE cidade_candidato on candidato.CIDADE = cidade_candidato.CODIGO inner join tb_nacionalidade nacionalidade on candidato.NACIONALIDADE = nacionalidade.CODIGO " & _
        "left outer join TB_CURRICULO curriculo on curriculo.CANDIDATO = candidato.CODIGO left outer join TB_CARGO_PRETENDIDO pretensao_cargo on pretensao_cargo.CURRICULO = curriculo.CODIGO " & _
        "left outer join TB_CARGO cargo on pretensao_cargo.CARGO = cargo.CODIGO left outer join TB_AREA area on cargo.AREA = area.CODIGO left outer join TB_IDIOMA_CURRICULO curriculo_idioma " & _
        "on curriculo_idioma.CURRICULO = curriculo.CODIGO left outer join TB_IDIOMA idioma on curriculo_idioma.IDIOMA = idioma.CODIGO left outer join TB_CURSO_CURRICULO curso_curriculo " & _
        "on curso_curriculo.CURRICULO = curriculo.CODIGO left outer join TB_CURSO curso on curso_curriculo.CURSO = curso.CODIGO left outer join TB_ENTIDADE_ENSINO entidade_ensino " & _
        "on curso.ENTIDADE = entidade_ensino.CODIGO left outer join TB_CIDADE cidade_entidade on entidade_ensino.CIDADE = cidade_entidade.CODIGO left outer join TB_CARGO_CURRICULO cargo_curriculo " & _
        "on cargo_curriculo.CURRICULO = curriculo.CODIGO left outer join TB_CARGO cargo_anterior on cargo_curriculo.CARGO = cargo_anterior.CODIGO left outer join TB_EMPRESA cargo_empresa " & _
        "on cargo_curriculo.EMPRESA = cargo_empresa.CODIGO left outer join TB_CIDADE cidade_empresa on cargo_empresa.CIDADE = cidade_empresa.CODIGO where candidato.codigo = " & pCandidato

        Try
            Persistencia.GerarRelatorio(_query)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Shared Function NomeExistente(ByVal pNome As String, ByVal pOperacao As Char) As Integer
        Try
            Return Persistencia.NomeExistente(pNome, pOperacao)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

#End Region

#Region "Sets"

    Public Shared Sub InserirCargosCurriculo(ByVal pCargoCurriculo As Candidato)
        Try
            Persistencia.InserirCargoCurriculo(pCargoCurriculo)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Shared Sub InserirCargosPretendidos(ByVal pCargosPretendidos As Curriculo)
        Try
            Persistencia.InserirCargoPretendidoCurriculo(pCargosPretendidos)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Shared Sub InserirEmpresa(ByVal pEmpresa As Empresa)
        Try
            Persistencia.InserirEmpresa(pEmpresa)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Shared Sub InserirIdiomas(ByVal pCurriculo As Curriculo)
        Try
            Persistencia.InserirIdiomas(pCurriculo)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Shared Function InserirCurriculo(ByVal pCandidato As Candidato) As string
        Try
            Return Persistencia.InserirCurriculo(pCandidato)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Shared Sub InserirCursosCurriculo(ByVal pCandidato As Candidato)
        Try
            Persistencia.InserirCursoCurriculo(pCandidato)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Shared Sub InserirCurso(ByVal pCurso As Curso)
        Try
            Persistencia.InserirCurso(pCurso)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Shared Sub InserirEntidade(ByVal pEntidade As Entidade)
        Try
            Persistencia.InserirEntidadeDeEnsino(pEntidade)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Shared Function InserirCandidato(ByVal pCandidado As Candidato) As String
        Try
            Return Persistencia.GravarCandidato(pCandidado)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Shared Sub InserirCidade(ByVal pCidade As Cidade)
        Try
            Persistencia.InserirCidade(pCidade)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region

#Region "Alterações"

    Public Shared Sub AlterarCandidato(ByVal pCandidato As Candidato)
        Try
            Persistencia.AlterarCandidato(pCandidato)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub


    Public Shared Sub AlterarEntidade(ByVal pEntidade As Entidade)
        Try
            Persistencia.AlterarEntidadeEnsino(pEntidade)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub



    Public Shared Sub AlterarCurso(ByVal pCurso As Curso)
        Try
            Persistencia.AlterarCurso(pCurso)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub


    Public Shared Sub AlterarEmpresa(ByVal pEmpresa As Empresa)
        Try
            Persistencia.AlterarEmpresa(pEmpresa)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Shared Sub ALterarCurriculo(ByVal pCandidato As Candidato)
        Try
            Persistencia.AlterarCurriculo(pCandidato)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region

#Region "Exclusoes"
    Public Shared Sub DeletarCargosCurriculo(ByVal pCurriculo As Curriculo)
        Try
            Persistencia.DeletarCargoCurriculo(pCurriculo)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Shared Sub DeletarCursosCurriculo(ByVal pCurriculo As Curriculo)
        Try
            Persistencia.DeletarCursoCurriculo(pCurriculo)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Shared Sub DeletaIdiomasCurriculo(ByVal pCurriculo As Curriculo)
        Try
            Persistencia.DeletarIdiomaCurriculo(pCurriculo)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Shared Sub DeletarCargoPretendidoCurriculo(ByVal pCurriculo As Curriculo)
        Try
            Persistencia.DeletarCargoPretendidoCurriculo(pCurriculo)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

#End Region

End Class

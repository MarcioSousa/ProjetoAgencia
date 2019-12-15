Imports System.Data.SqlClient
Imports System.Data
Imports FirebirdSql.Data.FirebirdClient
Imports System.Collections.Generic
Imports System.Linq

Imports DTO
Imports Utilidades

Public Class Persistencia

#Region "INSERTS"
    ''' <summary>
    ''' Inserir novo candidato no banco de dados
    ''' </summary>
    ''' <param name="pCandidato">Objeto Candidato</param>
    ''' <remarks></remarks>
    Public Shared Function GravarCandidato(ByVal pCandidato As Candidato) As String
        Dim _codigo As String = ""

        Using conexao As New ConexaoSQL
            Using comando As New SqlCommand
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = "SP_INSERIR_CANDIDATO"
                comando.Connection = conexao.Conexao

                'PARAMETROS DA SP
                comando.Parameters.Add("@CODIGO", SqlDbType.Int).Direction = ParameterDirection.Output
                comando.Parameters.Add("@NOME", SqlDbType.NVarChar, 150).Value = pCandidato.Nome
                comando.Parameters.Add("@DATA_NASCIMENTO", SqlDbType.Date).Value = pCandidato.DataNascimento
                comando.Parameters.Add("@TIPO_DOC", SqlDbType.Int).Value = pCandidato.TipoDoc
                comando.Parameters.Add("@DOCUMENTO", SqlDbType.NVarChar, 15).Value = pCandidato.Documento
                comando.Parameters.Add("@SEXO", SqlDbType.Char).Value = pCandidato.Sexo
                comando.Parameters.Add("@CIDADE", SqlDbType.Int).Value = pCandidato.Cidade.Codigo
                comando.Parameters.Add("@OBS", SqlDbType.NVarChar).Value = pCandidato.Obs
                comando.Parameters.Add("@FACEBOOK", SqlDbType.NVarChar, 70).Value = pCandidato.Facebook
                comando.Parameters.Add("@TELEFONE", SqlDbType.NVarChar, 10).Value = pCandidato.Telefone
                comando.Parameters.Add("@CELULAR", SqlDbType.NVarChar, 11).Value = pCandidato.Celular
                comando.Parameters.Add("@ENDERECO", SqlDbType.NVarChar, 100).Value = pCandidato.Endereco
                comando.Parameters.Add("@DATA_INCLUSAO", SqlDbType.DateTime).Value = pCandidato.DataInclusao
                comando.Parameters.Add("@DATA_ATUALIZACAO", SqlDbType.DateTime).Value = pCandidato.DataAtualizacao
                comando.Parameters.Add("@SITUACAO", SqlDbType.Char, 1).Value = pCandidato.Situacao
                comando.Parameters.Add("@EMAIL", SqlDbType.NVarChar, 100).Value = pCandidato.Email
                comando.Parameters.Add("@RACA", SqlDbType.Int).Value = pCandidato.Raca
                comando.Parameters.Add("@FUMANTE", SqlDbType.Int).Value = pCandidato.Fumante
                comando.Parameters.Add("@TATUAGEM_AMOSTRA", SqlDbType.Int).Value = pCandidato.TatuagemAmostra
                comando.Parameters.Add("@WHATSAPP", SqlDbType.Int).Value = pCandidato.Whatsapp
                comando.Parameters.Add("@NOME_SOCIAL", SqlDbType.NVarChar, 50).Value = pCandidato.NomeSocial
                comando.Parameters.Add("@FOTO", SqlDbType.NVarChar).Value = pCandidato.Foto
                comando.Parameters.Add("@BOA_APARENCIA", SqlDbType.Int).Value = pCandidato.BoaAparencia
                comando.Parameters.Add("@FILHOS_MENOR", SqlDbType.Int).Value = pCandidato.FilhosMenor
                comando.Parameters.Add("@FILHOS_MAIOR", SqlDbType.Int).Value = pCandidato.FilhosMaior
                comando.Parameters.Add("@ESTADO_CIVIL", SqlDbType.Int).Value = pCandidato.EstadoCivil
                comando.Parameters.Add("@HAB_A", SqlDbType.Int).Value = pCandidato.HabilitacaoA
                comando.Parameters.Add("@HAB_B", SqlDbType.Int).Value = pCandidato.HabilitacaoB
                comando.Parameters.Add("@HAB_C", SqlDbType.Int).Value = pCandidato.HabilitacaoC
                comando.Parameters.Add("@HAB_D", SqlDbType.Int).Value = pCandidato.HabilitacaoD
                comando.Parameters.Add("@NACIONALIDADE", SqlDbType.Int).Value = pCandidato.Nacionalidade.Codigo
                comando.Parameters.Add("@OPERADORA_CELULAR", SqlDbType.Int).Value = pCandidato.Operadora
                comando.Parameters.Add("@HAB_E", SqlDbType.Int).Value = pCandidato.HabilitacaoE
                comando.Parameters.Add("@CONDUCAO_PROPRIA", SqlDbType.Int).Value = pCandidato.ConducaoPropria
                comando.Parameters.Add("@INDICADO", SqlDbType.Int).Value = pCandidato.Indicado
                comando.Parameters.Add("@NOME_INDICADOR", SqlDbType.NVarChar, 30).Value = pCandidato.Indicador
                comando.Parameters.Add("@TEL_RECADO_1", SqlDbType.NVarChar, 11).Value = pCandidato.Tel_Recado_1
                comando.Parameters.Add("@NOME_RECADO_1", SqlDbType.NVarChar, 30).Value = pCandidato.Nome_Recado_1
                comando.Parameters.Add("@TEL_RECADO_2", SqlDbType.NVarChar, 11).Value = pCandidato.Tel_Recado_2
                comando.Parameters.Add("@NOME_RECADO_2", SqlDbType.NVarChar, 30).Value = pCandidato.Nome_Recado_2
                comando.Parameters.Add("@TEL_RECADO_3", SqlDbType.NVarChar, 11).Value = pCandidato.Tel_Recado_3
                comando.Parameters.Add("@NOME_RECADO_3", SqlDbType.NVarChar, 30).Value = pCandidato.Nome_Recado_3

                Try
                    'ABRE CONEXAO
                    conexao.Conexao.Open()

                    'EXECUTA A STORED PROCEDURE
                    comando.ExecuteNonQuery()

                    _codigo = comando.Parameters("@CODIGO").Value

                    'OBTENDO O VALOR DE OUTPUT
                    '_codigo = comando.Parameters("@CODIGO").Value
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Using
        End Using

        Return _codigo
    End Function

    ''' <summary>
    ''' Inserir cidade
    ''' </summary>
    ''' <param name="pCidade"></param>
    ''' <remarks></remarks>
    Public Shared Sub GravarCidade(ByVal pCidade As Cidade)
        Dim _status As String = ""

        Using conexao As New ConexaoSQL
            Using comando As New SqlCommand
                comando.CommandText = "SP_INSERIR_CIDADE"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexao.Conexao

                comando.Parameters.Add("@STATUS", SqlDbType.Int).Direction = ParameterDirection.Output
                comando.Parameters.Add("@NOME", SqlDbType.NVarChar, 50).Value = pCidade.Descricao
                comando.Parameters.Add("@UF", SqlDbType.NVarChar, 2).Value = pCidade.UF
                comando.Parameters.Add("@SITUACAO", SqlDbType.Char, 1).Value = pCidade.Situacao

                Try
                    conexao.Conexao.Open()

                    comando.ExecuteNonQuery()

                    _status = comando.Parameters("@STATUS").Value

                    If _status <> 1 Then
                        Throw New Exception(_status)
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Public Shared Function InserirCurriculo(ByVal pCandidato As Candidato) As String
        Dim _codigoCurriculo As String = ""
        Dim _existe As String = ""

        Using conexao As New ConexaoSQL
            Using comando As New SqlCommand
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = "SP_INSERIR_CURRICULO"
                comando.Connection = conexao.Conexao

                comando.Parameters.Add("@CODIGO", SqlDbType.Int).Direction = ParameterDirection.Output
                comando.Parameters.Add("@EXISTE", SqlDbType.Int).Direction = ParameterDirection.Output
                comando.Parameters.Add("@DATA_INCLUSAO", SqlDbType.DateTime).Value = pCandidato.Curriculo.DataInclusao
                comando.Parameters.Add("@CANDIDATO", SqlDbType.Int).Value = pCandidato.Codigo
                comando.Parameters.Add("@CLASSIFICACAO", SqlDbType.Int).Value = pCandidato.Curriculo.Classificacao
                comando.Parameters.Add("@OBS", SqlDbType.NVarChar).Value = pCandidato.Curriculo.Obs
                comando.Parameters.Add("@ESCOLARIDADE", SqlDbType.Int).Value = pCandidato.Curriculo.Escolaridade
                comando.Parameters.Add("@DATA_ATUALIZACAO", SqlDbType.DateTime).Value = pCandidato.Curriculo.DataAlteracao
                comando.Parameters.Add("@ULTIMO_SALARIO", SqlDbType.Decimal).Value = pCandidato.Curriculo.UltimoSalario
                comando.Parameters.Add("@DIGITALIZACAO_CURRICULO", SqlDbType.NVarChar).Value = pCandidato.Curriculo.Digitalizacao
                comando.Parameters.Add("@PRETENSAO_SALARIAL", SqlDbType.Decimal).Value = pCandidato.Curriculo.PretensaoSalarial
                comando.Parameters.Add("@DIGITALIZACAO_CURRICULO_2", SqlDbType.NVarChar).Value = pCandidato.Curriculo.Digitalizacao_2
                comando.Parameters.Add("@DIGITALIZACAO_CURRICULO_3", SqlDbType.NVarChar).Value = pCandidato.Curriculo.Digitalizacao_3
                comando.Parameters.Add("@TURNO", SqlDbType.Int).Value = pCandidato.Curriculo.Turno
                comando.Parameters.Add("@ESTUDANDO", SqlDbType.Int).Value = pCandidato.Curriculo.Estudando
                comando.Parameters.Add("@ULTIMA_SERIE", SqlDbType.Int).Value = pCandidato.Curriculo.UltimaSerieIncompleta


                Try
                    conexao.Conexao.Open()
                    comando.ExecuteNonQuery()

                    If comando.Parameters("@EXISTE").Value <> 0 Then
                        Throw New Exception("Este candidato ja possui um curriculo cadastrado")
                    End If

                    _codigoCurriculo = comando.Parameters("@CODIGO").Value
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Using
        End Using

        Return _codigoCurriculo
    End Function

    Public Shared Sub InserirCursoCurriculo(ByVal pCandidato As Candidato)
        Try
            Using conexao As New ConexaoSQL
                conexao.Conexao.Open()

                Dim _cursos = From c In pCandidato.Curriculo.Cursos Where c.Status = "A"

                For Each Curso In _cursos
                    Using comando As New SqlCommand
                        comando.CommandText = "SP_INSERIR_CURSO_CURRICULO"
                        comando.CommandType = CommandType.StoredProcedure
                        comando.Connection = conexao.Conexao

                        comando.Parameters.Add("@CURSO", SqlDbType.Int).Value = Curso.Curso.Codigo
                        comando.Parameters.Add("@CURRICULO", SqlDbType.Int).Value = pCandidato.Curriculo.Codigo
                        comando.Parameters.Add("@DATA_INICIO", SqlDbType.Date).Value = Curso.DataInicial
                        comando.Parameters.Add("@DATA_FINAL", SqlDbType.Date).Value = Curso.DataFinal
                        comando.Parameters.Add("@CONCLUIDO", SqlDbType.Char).Value = Curso.Concluido
                        comando.Parameters.Add("@OBS", SqlDbType.NVarChar).Value = Curso.Obs
                        comando.Parameters.Add("@DIG_CERTIFICADO", SqlDbType.NVarChar).Value = Curso.PathCertificado

                        comando.ExecuteNonQuery()
                    End Using
                Next
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    Public Shared Sub InserirCargoCurriculo(ByVal pCandidato As Candidato)
        Try
            Using conexao As New ConexaoSQL
                conexao.Conexao.Open()

                Dim _cargos = From c In pCandidato.Curriculo.Cargos Where c.Status = "A"

                For Each _cargo In _cargos
                    Using comando As New SqlCommand
                        comando.CommandText = "SP_INSERIR_CARGO_CURRICULO"
                        comando.CommandType = CommandType.StoredProcedure
                        comando.Connection = conexao.Conexao

                        comando.Parameters.Add("@CURRICULO", SqlDbType.Int).Value = pCandidato.Curriculo.Codigo
                        comando.Parameters.Add("@DATA_INICIO", SqlDbType.Date).Value = _cargo.DataInicio
                        comando.Parameters.Add("@DATA_FINAL", SqlDbType.Date).Value = _cargo.DataFinal
                        comando.Parameters.Add("@FUNCOES_DESEMP", SqlDbType.NVarChar).Value = _cargo.FuncoesDesempenhadas
                        comando.Parameters.Add("@CESTA_BASICA", SqlDbType.Int).Value = _cargo.CestaBasica
                        comando.Parameters.Add("@VALE_TRANSPORTE", SqlDbType.Int).Value = _cargo.ValeTransporte
                        comando.Parameters.Add("@PLR", SqlDbType.Int).Value = _cargo.PLR
                        comando.Parameters.Add("@CONVENIO_MEDICO", SqlDbType.Int).Value = _cargo.ConvenioMedico
                        comando.Parameters.Add("@VALE_REFEICAO", SqlDbType.Int).Value = _cargo.ValeRefeicao
                        comando.Parameters.Add("@SEGURO_VIDA", SqlDbType.Int).Value = _cargo.SeguroDeVida
                        comando.Parameters.Add("@AJUDA_CUSTO_ENSINO", SqlDbType.Int).Value = _cargo.AjudaCustoEstudo
                        comando.Parameters.Add("@AUX_CRECHE", SqlDbType.Int).Value = _cargo.AuxilioCreche
                        comando.Parameters.Add("@AUX_DENTISTA", SqlDbType.Int).Value = _cargo.AuxilioDentista
                        comando.Parameters.Add("@MOTIVO_SAIDA", SqlDbType.NVarChar).Value = _cargo.MotivoSaida
                        comando.Parameters.Add("@VL_CESTA_BASICA", SqlDbType.Decimal).Value = _cargo.ValorCestaBasica
                        comando.Parameters.Add("@VL_VALE_TRANSPORTE", SqlDbType.Decimal).Value = _cargo.ValorTransporte
                        comando.Parameters.Add("@VL_PLR", SqlDbType.Decimal).Value = _cargo.ValorPLR
                        comando.Parameters.Add("@VL_CONVENIO_MEDICO", SqlDbType.Decimal).Value = _cargo.ValorConvenioMedico
                        comando.Parameters.Add("@VL_VALE_REFEICAO", SqlDbType.Decimal).Value = _cargo.ValorRefeicao
                        comando.Parameters.Add("@VL_SEGURO_VIDA", SqlDbType.Decimal).Value = _cargo.ValorSeguroVida
                        comando.Parameters.Add("@VL_AJUDA_CUSTO_ENSINO", SqlDbType.Decimal).Value = _cargo.ValorAjudaCustoEnsino
                        comando.Parameters.Add("@VL_AUX_CRECHE", SqlDbType.Decimal).Value = _cargo.ValorAuxilioCreche
                        comando.Parameters.Add("@VL_AUX_DENTISTA", SqlDbType.Decimal).Value = _cargo.ValorAuxilioDentista
                        comando.Parameters.Add("@CARGO", SqlDbType.Int).Value = _cargo.Cargo.Codigo
                        comando.Parameters.Add("@EMPRESA", SqlDbType.Int).Value = _cargo.Empresa.Codigo
                        comando.Parameters.Add("@VL_RECEBIDO_FORA", SqlDbType.Decimal).Value = _cargo.ValorRecebidoFora
                        comando.Parameters.Add("@REGISTRADO", SqlDbType.Int).Value = _cargo.Registrado
                        comando.Parameters.Add("@SALARIO", SqlDbType.Decimal).Value = _cargo.Salario
                        comando.Parameters.Add("@ATUAL", SqlDbType.Int).Value = _cargo.Atual

                        comando.ExecuteNonQuery()
                    End Using
                Next
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Shared Sub InserirEntidadeDeEnsino(ByVal pEntidade As Entidade)
        Dim _status As String = ""

        Using conexao As New ConexaoSQL
            Using comando As New SqlCommand
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = "SP_INSERIR_ENTIDADE"
                comando.Connection = conexao.Conexao

                comando.Parameters.Add("@STATUS", SqlDbType.Int).Direction = ParameterDirection.Output
                comando.Parameters.Add("@NOME_ENTIDADE", SqlDbType.NVarChar, 50).Value = pEntidade.Descricao
                comando.Parameters.Add("@CIDADE", SqlDbType.Int).Value = pEntidade.Cidade.Codigo
                comando.Parameters.Add("@SITUACAO", SqlDbType.Char).Value = pEntidade.Situacao

                Try
                    conexao.Conexao.Open()

                    comando.ExecuteNonQuery()

                    _status = comando.Parameters("@STATUS").Value

                    If _status <> 1 Then
                        Throw New Exception(_status)
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub InserirCurso(ByVal pCurso As Curso)
        Dim _status As String = ""

        Using conexao As New ConexaoSQL
            Using comando As New SqlCommand
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = "SP_INCLUIR_CURSO"
                comando.Connection = conexao.Conexao

                comando.Parameters.Add("@STATUS", SqlDbType.Int).Direction = ParameterDirection.Output
                comando.Parameters.Add("@DESCRICAO", SqlDbType.NVarChar, 50).Value = pCurso.Descricao
                comando.Parameters.Add("@ENTIDADE", SqlDbType.Int).Value = pCurso.Entidade.Codigo
                comando.Parameters.Add("@SITUACAO", SqlDbType.Char).Value = pCurso.Situacao
                comando.Parameters.Add("@CATEGORIA", SqlDbType.Int).Value = pCurso.Categoria
                comando.Parameters.Add("@CARGA_HORARIA", SqlDbType.NVarChar, 10).Value = pCurso.CargaHoraria

                Try
                    conexao.Conexao.Open()

                    comando.ExecuteNonQuery()

                    _status = comando.Parameters("@STATUS").Value

                    If _status <> 1 Then
                        Throw New Exception(_status)
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub InserirIdiomas(ByVal pCurriculo As Curriculo)
        Try
            Using conexao As New ConexaoSQL
                conexao.Conexao.Open()
                Dim _idiomas = From i In pCurriculo.Idiomas Where i.Status = "A"


                For Each _idioma In _idiomas
                    Using comando As New SqlCommand()
                        comando.CommandText = "SP_INSERIR_IDIOMAS_CURRICULO"
                        comando.CommandType = CommandType.StoredProcedure
                        comando.Connection = conexao.Conexao

                        comando.Parameters.Add("@CURRICULO", SqlDbType.Int).Value = pCurriculo.Codigo
                        comando.Parameters.Add("@IDIOMA", SqlDbType.Int).Value = _idioma.Idioma.Codigo
                        comando.Parameters.Add("@NATIVO", SqlDbType.Int).Value = _idioma.Nativo
                        comando.Parameters.Add("@OBS", SqlDbType.NVarChar).Value = _idioma.Obs

                        comando.ExecuteNonQuery()
                    End Using
                Next
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Shared Sub InserirEmpresa(ByVal pEmpresa As Empresa)
        Dim _status As String = ""

        Using conexao As New ConexaoSQL
            Using comando As New SqlCommand
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = "SP_INSERIR_EMPRESA"
                comando.Connection = conexao.Conexao

                comando.Parameters.Add("@STATUS", SqlDbType.Int).Direction = ParameterDirection.Output
                comando.Parameters.Add("@RAZ_SOCIAL", SqlDbType.NVarChar, 100).Value = pEmpresa.RazaoSocial
                comando.Parameters.Add("@NOME_FANTASIA", SqlDbType.NVarChar, 100).Value = pEmpresa.NomeFantasia
                comando.Parameters.Add("@SITUACAO", SqlDbType.Char).Value = pEmpresa.Situacao
                comando.Parameters.Add("@CLIENTE", SqlDbType.Int).Value = pEmpresa.Cliente
                comando.Parameters.Add("@CIDADE", SqlDbType.Int).Value = pEmpresa.Cidade.Codigo

                Try
                    conexao.Conexao.Open()

                    comando.ExecuteNonQuery()

                    _status = comando.Parameters("@STATUS").Value

                    If _status <> 1 Then
                        Throw New Exception(_status)
                    End If

                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub InserirCargoPretendidoCurriculo(ByVal pCurriculo As Curriculo)
        Try
            Using conexao As New ConexaoSQL
                conexao.Conexao.Open()

                Dim _cargosPretendidos = From c In pCurriculo.CargosPretendidos Where c.Status = "A"


                For Each _cargo In _cargosPretendidos
                    Using comando As New SqlCommand
                        comando.CommandText = "SP_INSERIR_CARGOS_PRETENDIDOS_CURRICULO"
                        comando.CommandType = CommandType.StoredProcedure
                        comando.Connection = conexao.Conexao

                        comando.Parameters.Add("@CURRICULO", SqlDbType.Int).Value = pCurriculo.Codigo
                        comando.Parameters.Add("@CARGO", SqlDbType.Int).Value = _cargo.Cargo.Codigo
                        comando.Parameters.Add("@PRINCIPAL", SqlDbType.Int).Value = _cargo.Principal

                        comando.ExecuteNonQuery()
                    End Using
                Next
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Shared Sub InserirCidade(ByVal pCidade As Cidade)
        Dim _status As String = ""

        Using conexao As New ConexaoSQL
            Using comando As New SqlCommand
                comando.CommandText = "SP_INSERIR_CIDADE"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexao.Conexao

                comando.Parameters.Add("@STATUS", SqlDbType.Int).Direction = ParameterDirection.Output
                comando.Parameters.Add("@NOME", SqlDbType.NVarChar, 50).Value = pCidade.Descricao
                comando.Parameters.Add("@UF", SqlDbType.NVarChar, 2).Value = pCidade.UF
                comando.Parameters.Add("@SITUACAO", SqlDbType.Char).Value = pCidade.Situacao

                Try
                    conexao.Conexao.Open()

                    comando.ExecuteNonQuery()

                    _status = comando.Parameters("@STATUS").Value

                    If _status <> 1 Then
                        Throw New Exception("Ja existe uma cidade com este estado cadastrado")
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Using
        End Using
    End Sub
#End Region

#Region "UPDATES"
    Public Shared Sub AlterarCidade(ByVal pCidade As Cidade)
        Dim _status As String = ""

        Using conexao As New ConexaoSQL
            Using comando As New SqlCommand
                comando.CommandText = "SP_ALTERAR_CIDADE"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexao.Conexao

                comando.Parameters.Add("@STATUS", SqlDbType.Int).Direction = ParameterDirection.Output
                comando.Parameters.Add("@CODIGO", SqlDbType.Int).Value = pCidade.Codigo
                comando.Parameters.Add("@NOME", SqlDbType.NVarChar, 50).Value = pCidade.Descricao
                comando.Parameters.Add("@UF", SqlDbType.NVarChar, 2).Value = pCidade.UF
                comando.Parameters.Add("@SITUACAO", SqlDbType.Char, 1).Value = pCidade.Situacao

                Try
                    conexao.Conexao.Open()

                    comando.ExecuteNonQuery()

                    _status = comando.Parameters("@STATUS").Value

                    If _status <> 1 Then
                        Throw New Exception(_status)
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub AlterarCandidato(ByVal pCandidato As Candidato)
        'Dim _status As String = ""

        Using conexao As New ConexaoSQL
            Using comando As New SqlCommand
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexao.Conexao
                comando.CommandText = "SP_ALTERAR_CANDIDATO"

                'PARAMETROS DA SP
                'comando.Parameters.Add("@STATUS", SqlDbType.Int).Direction = ParameterDirection.Output
                comando.Parameters.Add("@CODIGO", SqlDbType.Int).Value = pCandidato.Codigo
                comando.Parameters.Add("@NOME", SqlDbType.NVarChar, 150).Value = pCandidato.Nome
                comando.Parameters.Add("@DATA_NASCIMENTO", SqlDbType.Date).Value = pCandidato.DataNascimento
                comando.Parameters.Add("@TIPO_DOC", SqlDbType.Int).Value = pCandidato.TipoDoc
                comando.Parameters.Add("@DOCUMENTO", SqlDbType.NVarChar, 15).Value = pCandidato.Documento
                comando.Parameters.Add("@SEXO", SqlDbType.Char).Value = pCandidato.Sexo
                comando.Parameters.Add("@CIDADE", SqlDbType.Int).Value = pCandidato.Cidade.Codigo
                comando.Parameters.Add("@OBS", SqlDbType.NVarChar).Value = pCandidato.Obs
                comando.Parameters.Add("@FACEBOOK", SqlDbType.NVarChar, 70).Value = pCandidato.Facebook
                comando.Parameters.Add("@TELEFONE", SqlDbType.NVarChar, 10).Value = pCandidato.Telefone
                comando.Parameters.Add("@CELULAR", SqlDbType.NVarChar, 11).Value = pCandidato.Celular
                comando.Parameters.Add("@WHATSAPP", SqlDbType.Char).Value = pCandidato.Whatsapp
                comando.Parameters.Add("@ENDERECO", SqlDbType.NVarChar, 100).Value = pCandidato.Endereco
                comando.Parameters.Add("@DATA_ATUALIZACAO", SqlDbType.DateTime).Value = pCandidato.DataAtualizacao
                comando.Parameters.Add("@SITUACAO", SqlDbType.Char).Value = pCandidato.Situacao
                comando.Parameters.Add("@EMAIL", SqlDbType.NVarChar, 100).Value = pCandidato.Email
                comando.Parameters.Add("@RACA", SqlDbType.Int).Value = pCandidato.Raca
                comando.Parameters.Add("@FUMANTE", SqlDbType.Char).Value = pCandidato.Fumante
                comando.Parameters.Add("@TATUAGEM_AMOSTRA", SqlDbType.Char).Value = pCandidato.TatuagemAmostra
                comando.Parameters.Add("@NOME_SOCIAL", SqlDbType.NVarChar, 50).Value = pCandidato.NomeSocial
                comando.Parameters.Add("@FOTO", SqlDbType.NVarChar).Value = pCandidato.Foto
                comando.Parameters.Add("@BOA_APARENCIA", SqlDbType.Int).Value = pCandidato.BoaAparencia
                comando.Parameters.Add("@FILHOS_MENOR", SqlDbType.Int).Value = pCandidato.FilhosMenor
                comando.Parameters.Add("@FILHOS_MAIOR", SqlDbType.Int).Value = pCandidato.FilhosMaior
                comando.Parameters.Add("@ESTADO_CIVIL", SqlDbType.Int).Value = pCandidato.EstadoCivil
                comando.Parameters.Add("@HAB_A", SqlDbType.Int).Value = pCandidato.HabilitacaoA
                comando.Parameters.Add("@HAB_B", SqlDbType.Int).Value = pCandidato.HabilitacaoB
                comando.Parameters.Add("@HAB_C", SqlDbType.Int).Value = pCandidato.HabilitacaoC
                comando.Parameters.Add("@HAB_D", SqlDbType.Int).Value = pCandidato.HabilitacaoD
                comando.Parameters.Add("@NACIONALIDADE", SqlDbType.Int).Value = pCandidato.Nacionalidade.Codigo
                comando.Parameters.Add("@OPERADORA_CELULAR", SqlDbType.Int).Value = pCandidato.Operadora
                comando.Parameters.Add("@HAB_E", SqlDbType.Int).Value = pCandidato.HabilitacaoE
                comando.Parameters.Add("@CONDUCAO_PROPRIA", SqlDbType.Int).Value = pCandidato.ConducaoPropria
                comando.Parameters.Add("@INDICADO", SqlDbType.Int).Value = pCandidato.Indicado
                comando.Parameters.Add("@NOME_INDICADOR", SqlDbType.NVarChar).Value = pCandidato.Indicador
                comando.Parameters.Add("@TEL_RECADO_1", SqlDbType.NVarChar, 11).Value = pCandidato.Tel_Recado_1
                comando.Parameters.Add("@NOME_RECADO_1", SqlDbType.NVarChar, 30).Value = pCandidato.Nome_Recado_1
                comando.Parameters.Add("@TEL_RECADO_2", SqlDbType.NVarChar, 11).Value = pCandidato.Tel_Recado_2
                comando.Parameters.Add("@NOME_RECADO_2", SqlDbType.NVarChar, 30).Value = pCandidato.Nome_Recado_2
                comando.Parameters.Add("@TEL_RECADO_3", SqlDbType.NVarChar, 11).Value = pCandidato.Tel_Recado_3
                comando.Parameters.Add("@NOME_RECADO_3", SqlDbType.NVarChar, 30).Value = pCandidato.Nome_Recado_3

                Try
                    'ABRE CONEXAO
                    conexao.Conexao.Open()

                    'EXECUTA A STORED PROCEDURE
                    comando.ExecuteNonQuery()

                    ''OBTENDO O RETORNO DA STORED
                    '_status = comando.Parameters("@STATUS").Value

                    ''STATUS DA TRANSACAO
                    'If _status <> 1 Then
                    '    Throw New Exception(_status)
                    'End If
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try

            End Using
        End Using
    End Sub

    Public Shared Sub AlterarEntidadeEnsino(ByVal pEntidade As Entidade)
        Dim _status As String = ""

        Using conexao As New ConexaoSQL
            Using comando As New SqlCommand
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = "SP_ALTERAR_ENTIDADE"
                comando.Connection = conexao.Conexao

                comando.Parameters.Add("@STATUS", SqlDbType.Int).Direction = ParameterDirection.Output
                comando.Parameters.Add("@CODIGO", SqlDbType.Int).Value = pEntidade.Codigo
                comando.Parameters.Add("@ENTIDADE", SqlDbType.NVarChar, 100).Value = pEntidade.Descricao
                comando.Parameters.Add("@CIDADE", SqlDbType.Int).Value = pEntidade.Cidade.Codigo
                comando.Parameters.Add("@SITUACAO", SqlDbType.Char).Value = pEntidade.Situacao

                Try
                    conexao.Conexao.Open()

                    comando.ExecuteNonQuery()

                    _status = comando.Parameters("@STATUS").Value

                    If _status <> 1 Then
                        Throw New Exception(_status)
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub AlterarCurso(ByVal pCurso As Curso)
        Dim _status As String = ""

        Using conexao As New ConexaoSQL
            Using comando As New SqlCommand
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = "SP_ALTERAR_CURSO"
                comando.Connection = conexao.Conexao

                comando.Parameters.Add("@STATUS", SqlDbType.Int).Direction = ParameterDirection.Output
                comando.Parameters.Add("@CODIGO", SqlDbType.Int).Value = pCurso.Codigo
                comando.Parameters.Add("@DESCRICAO", SqlDbType.NVarChar, 100).Value = pCurso.Descricao
                comando.Parameters.Add("@ENTIDADE", SqlDbType.Int).Value = pCurso.Entidade.Codigo
                comando.Parameters.Add("@SITUACAO", SqlDbType.NVarChar, 1).Value = pCurso.Situacao
                comando.Parameters.Add("@CATEGORIA", SqlDbType.Int).Value = pCurso.Categoria
                comando.Parameters.Add("@CARGA_HORARIA", SqlDbType.NVarChar, 10).Value = pCurso.CargaHoraria

                Try
                    conexao.Conexao.Open()

                    comando.ExecuteNonQuery()

                    _status = comando.Parameters("@STATUS").Value

                    If _status <> 1 Then
                        Throw New Exception(_status)
                    End If

                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub AlterarEmpresa(ByVal pEmpresa As Empresa)
        Dim _status As String = ""

        Using conexao As New ConexaoSQL
            Using comando As New SqlCommand
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = "SP_ALTERAR_EMPRESA"
                comando.Connection = conexao.Conexao

                comando.Parameters.Add("@STATUS", SqlDbType.Int).Direction = ParameterDirection.Output
                comando.Parameters.Add("@CODIGO", SqlDbType.Int).Value = pEmpresa.Codigo
                comando.Parameters.Add("@NOME_FAN", SqlDbType.NVarChar, 100).Value = pEmpresa.NomeFantasia
                comando.Parameters.Add("@RAZ_SOCIAL", SqlDbType.NVarChar, 100).Value = pEmpresa.RazaoSocial
                comando.Parameters.Add("@SITUACAO", SqlDbType.Char).Value = pEmpresa.Situacao
                comando.Parameters.Add("@CLIENTE", SqlDbType.Int).Value = pEmpresa.Cliente
                comando.Parameters.Add("@CIDADE", SqlDbType.Int).Value = pEmpresa.Cidade.Codigo

                Try
                    conexao.Conexao.Open()

                    comando.ExecuteNonQuery()

                    _status = comando.Parameters("@STATUS").Value

                    If _status <> 1 Then
                        Throw New Exception(_status)
                    End If

                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub AlterarCurriculo(ByVal pCandidato As Candidato)
        Using conexao As New ConexaoSQL
            Using comando As New SqlCommand
                comando.CommandText = "SP_ALTERAR_CURRICULO"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexao.Conexao

                comando.Parameters.Add("@CODIGO", SqlDbType.Int).Value = pCandidato.Curriculo.Codigo
                comando.Parameters.Add("@DATA_INCLUSAO", SqlDbType.DateTime).Value = pCandidato.Curriculo.DataInclusao
                comando.Parameters.Add("@CANDIDATO", SqlDbType.Int).Value = pCandidato.Codigo
                comando.Parameters.Add("@CLASSIFICACAO", SqlDbType.Int).Value = pCandidato.Curriculo.Classificacao
                comando.Parameters.Add("@OBS", SqlDbType.NVarChar).Value = pCandidato.Curriculo.Obs
                comando.Parameters.Add("@ESCOLARIDADE", SqlDbType.Int).Value = pCandidato.Curriculo.Escolaridade
                comando.Parameters.Add("@DATA_ATUALIZACAO", SqlDbType.DateTime).Value = pCandidato.Curriculo.DataAlteracao
                comando.Parameters.Add("@ULTIMO_SALARIO", SqlDbType.Decimal).Value = pCandidato.Curriculo.UltimoSalario
                comando.Parameters.Add("@DIGITALIZACAO_CURRICULO", SqlDbType.NVarChar).Value = pCandidato.Curriculo.Digitalizacao
                comando.Parameters.Add("@PRETENSAO_SALARIAL", SqlDbType.Int).Value = pCandidato.Curriculo.PretensaoSalarial
                comando.Parameters.Add("@DIGITALIZACAO_CURRICULO_2", SqlDbType.NVarChar).Value = pCandidato.Curriculo.Digitalizacao_2
                comando.Parameters.Add("@DIGITALIZACAO_CURRICULO_3", SqlDbType.NVarChar).Value = pCandidato.Curriculo.Digitalizacao_3
                comando.Parameters.Add("@TURNO", SqlDbType.Int).Value = pCandidato.Curriculo.Turno
                comando.Parameters.Add("@ESTUDANDO", SqlDbType.Int).Value = pCandidato.Curriculo.Estudando
                comando.Parameters.Add("@ULTIMA_SERIE", SqlDbType.Int).Value = pCandidato.Curriculo.UltimaSerieIncompleta

                Try
                    conexao.Conexao.Open()

                    comando.ExecuteNonQuery()

                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Using
        End Using
    End Sub

#End Region

#Region "DELETES"
    Public Shared Sub DeletarCargoCurriculo(ByVal pCargosCurriculo As Curriculo)
        Try
            Using conexao As New ConexaoSQL
                conexao.Conexao.Open()

                Dim _cargos = From c In pCargosCurriculo.Cargos Where c.Status = "I"
                For Each _cargo In _cargos
                    Using comando As New SqlCommand
                        comando.CommandType = CommandType.StoredProcedure
                        comando.CommandText = "SP_DELETAR_CARGO_CURRICULO"
                        comando.Connection = conexao.Conexao

                        comando.Parameters.Add("@CARGO", SqlDbType.Int).Value = _cargo.Cargo.Codigo
                        comando.Parameters.Add("@CURRICULO", SqlDbType.Int).Value = pCargosCurriculo.Codigo

                        comando.ExecuteNonQuery()

                    End Using
                Next
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Shared Sub DeletarCursoCurriculo(ByVal pCursoCurriculo As Curriculo)
        Try
            Using conexao As New ConexaoSQL
                conexao.Conexao.Open()
                Dim _cursos = From c In pCursoCurriculo.Cursos Where c.Status = "I"

                For Each c In _cursos
                    Using comando As New SqlCommand
                        comando.CommandType = CommandType.StoredProcedure
                        comando.Connection = conexao.Conexao
                        comando.CommandText = "SP_DELETAR_CURSO_CURRICULO"

                        comando.Parameters.Add("@CURSO", SqlDbType.Int).Value = c.Curso.Codigo
                        comando.Parameters.Add("@CURRICULO", SqlDbType.Int).Value = pCursoCurriculo.Codigo
                        comando.ExecuteNonQuery()

                    End Using
                Next
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    Public Shared Sub DeletarIdiomaCurriculo(ByVal pCursoCurriculo As Curriculo)
        Try
            Using conexao As New ConexaoSQL
                conexao.Conexao.Open()

                Dim _idiomas = From i In pCursoCurriculo.Idiomas Where i.Status = "I"

                For Each i In _idiomas
                    Using comando As New SqlCommand
                        comando.CommandType = CommandType.StoredProcedure
                        comando.Connection = conexao.Conexao
                        comando.CommandText = "SP_DELETAR_IDIOMA_CURRICULO"

                        comando.Parameters.Add("@IDIOMA", SqlDbType.Int).Value = i.Idioma.Codigo
                        comando.Parameters.Add("@CURRICULO", SqlDbType.Int).Value = pCursoCurriculo.Codigo

                        comando.ExecuteNonQuery()
                    End Using
                Next
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Shared Sub DeletarCargoPretendidoCurriculo(ByVal pCurriculo As Curriculo)
        Try
            Using conexao As New ConexaoSQL

                conexao.Conexao.Open()

                Dim _pretendidos = From p In pCurriculo.CargosPretendidos Where p.Status = "I"

                For Each p In _pretendidos
                    Using comando As New SqlCommand
                        comando.CommandType = CommandType.StoredProcedure
                        comando.Connection = conexao.Conexao
                        comando.CommandText = "SP_DELETAR_CARGO_PRETENDIDO_CURRICULO"

                        comando.Parameters.Add("@CURRICULO", SqlDbType.Int).Value = pCurriculo.Codigo
                        comando.Parameters.Add("@CARGO_PRETENDIDO", SqlDbType.Int).Value = p.Cargo.Codigo

                        comando.ExecuteNonQuery()
                    End Using
                Next
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region

#Region "SELECTS"
    Public Shared Function GetCidades(ByVal pQuery As String) As List(Of Cidade)
        Dim _dr As SqlDataReader = Nothing
        Dim cidades = Nothing

        Using conexao As New ConexaoSQL
            Using comando As New SqlCommand(pQuery, conexao.Conexao)

                Try
                    conexao.Conexao.Open()
                    _dr = comando.ExecuteReader

                    If _dr.HasRows Then
                        cidades = New List(Of Cidade)
                        While _dr.Read
                            Dim cidade = New Cidade
                            cidade.Codigo = _dr.GetInt32(0)
                            cidade.Descricao = _dr.GetString(1)
                            cidade.UF = _dr.GetString(2)
                            cidade.Situacao = _dr.GetString(3)

                            cidades.Add(cidade)
                        End While
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                Finally
                    If Not _dr Is Nothing Then
                        _dr.Close()
                    End If
                End Try
            End Using
        End Using

        Return cidades
    End Function

    Public Shared Function GetCandidatos(ByVal strQuery As String) As List(Of Candidato)
        Dim _dr As SqlDataReader = Nothing
        Dim candidatos As List(Of Candidato) = New List(Of Candidato)

        Using conexao As New ConexaoSQL
            Using comando As New SqlCommand(strQuery, conexao.Conexao)
                Try
                    conexao.Conexao.Open()

                    _dr = comando.ExecuteReader

                    If _dr.HasRows Then
                        Dim _candidato As Candidato

                        While _dr.Read

                            'Cidade
                            Dim _cidade As New Cidade
                            _cidade.Codigo = _dr.GetInt32(42)
                            _cidade.Descricao = _dr.GetString(43)
                            _cidade.UF = _dr.GetString(44)
                            _cidade.Situacao = _dr.GetString(45)
                            'Nacionalidade
                            Dim _nacionalidade As New Nacionalidade
                            _nacionalidade.Codigo = _dr.GetInt32(46)
                            _nacionalidade.Descricao = _dr.GetString(47)
                            'curriculo
                            Dim _curriculo As Curriculo = Nothing

                            If Not IsDBNull(_dr.Item(48)) Then
                                _curriculo = New Curriculo

                                _curriculo.Codigo = _dr.GetInt32(48)
                                _curriculo.DataInclusao = _dr.GetDateTime(49)
                                _curriculo.Classificacao = _dr.GetInt32(51)
                                _curriculo.Obs = _dr.GetString(52)
                                _curriculo.Escolaridade = _dr.GetInt32(53)
                                _curriculo.DataAlteracao = _dr.GetDateTime(54)
                                _curriculo.UltimoSalario = _dr.GetDecimal(55)
                                _curriculo.Digitalizacao = _dr.GetString(56)
                                _curriculo.PretensaoSalarial = _dr.GetDecimal(57)
                                _curriculo.Digitalizacao_2 = _dr.GetString(58)
                                _curriculo.Digitalizacao_3 = _dr.GetString(59)
                                _curriculo.Turno = _dr.GetInt32(60)
                                _curriculo.Estudando = _dr.GetInt32(61)
                                _curriculo.UltimaSerieIncompleta = _dr.GetInt32(62)
                                _curriculo.Idiomas = GetIdiomasCurriculo(_curriculo.Codigo)
                                _curriculo.Cursos = GetCursosCurriculo(_curriculo.Codigo)
                                _curriculo.Cargos = GetCargosAnterioresCurriculo(_curriculo.Codigo)
                                _curriculo.CargosPretendidos = GetCargosPretendidos(_curriculo.Codigo)
                            End If

                            'Candidato
                            _candidato = New Candidato
                            _candidato.Codigo = _dr.GetInt32(0)
                            _candidato.Nome = _dr.GetString(1)
                            _candidato.DataNascimento = _dr.GetDateTime(2)
                            _candidato.TipoDoc = _dr.GetInt32(3)
                            _candidato.Documento = _dr.GetString(4)
                            _candidato.Sexo = _dr.GetString(5)
                            _candidato.Cidade = _cidade
                            _candidato.Obs = _dr.GetString(7)
                            _candidato.Facebook = _dr.GetString(8)
                            _candidato.Telefone = _dr.GetString(9)
                            _candidato.Celular = _dr.GetString(10)
                            _candidato.Endereco = _dr.GetString(11)
                            _candidato.DataInclusao = _dr.GetDateTime(12)
                            _candidato.DataAtualizacao = _dr.GetDateTime(13)
                            _candidato.Situacao = _dr.GetString(14)
                            _candidato.Email = _dr.GetString(15)
                            _candidato.Raca = _dr.GetInt32(16)
                            _candidato.Fumante = _dr.GetInt32(17)
                            _candidato.TatuagemAmostra = _dr.GetInt32(18)
                            _candidato.Whatsapp = _dr.GetInt32(19)
                            _candidato.NomeSocial = _dr.GetString(20)
                            _candidato.Foto = _dr.GetString(21)
                            _candidato.BoaAparencia = _dr.GetInt32(22)
                            _candidato.FilhosMenor = _dr.GetInt32(23)
                            _candidato.FilhosMaior = _dr.GetInt32(24)
                            _candidato.EstadoCivil = _dr.GetInt32(25)
                            _candidato.HabilitacaoA = _dr.GetInt32(26)
                            _candidato.HabilitacaoB = _dr.GetInt32(27)
                            _candidato.HabilitacaoC = _dr.GetInt32(28)
                            _candidato.HabilitacaoD = _dr.GetInt32(29)
                            _candidato.Nacionalidade = _nacionalidade
                            _candidato.Operadora = _dr.GetInt32(31)
                            _candidato.Curriculo = _curriculo
                            _candidato.HabilitacaoE = _dr.GetInt32(32)
                            _candidato.ConducaoPropria = _dr.GetInt32(33)
                            _candidato.Indicado = _dr.GetInt32(34)
                            _candidato.Indicador = _dr.GetString(35)

                            _candidato.Tel_Recado_1 = _dr.GetString(36)
                            _candidato.Nome_Recado_1 = _dr.GetString(37)

                            _candidato.Tel_Recado_2 = _dr.GetString(38)
                            _candidato.Nome_Recado_2 = _dr.GetString(39)

                            _candidato.Tel_Recado_3 = _dr.GetString(40)
                            _candidato.Nome_Recado_3 = _dr.GetString(41)


                            candidatos.Add(_candidato)
                        End While
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                Finally
                    If Not _dr Is Nothing Then
                        _dr.Close()
                    End If
                End Try
            End Using
        End Using

        Return candidatos
    End Function

    Public Shared Function NomeExistente(ByVal pNome As String, ByVal pTipoOperacao As Char) As Boolean
        Dim _existe As Boolean = False

        Using conexao As New ConexaoSQL
            Using comando As New SqlCommand("SELECT COUNT(*) FROM TB_CANDIDATO WHERE NOME = @NOME AND SITUACAO = 'A'", conexao.Conexao)
                comando.Parameters.Add("@NOME", SqlDbType.NVarChar).Value = pNome

                Try
                    conexao.Conexao.Open()

                    If pTipoOperacao = "N" Then
                        _existe = IIf(comando.ExecuteScalar > 0, True, False)
                    Else
                        _existe = IIf(comando.ExecuteScalar <= 1, False, True)
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Using
        End Using

        Return _existe
    End Function

    Private Shared Function GetIdiomasCurriculo(ByVal pCodigoCurriculo As String) As List(Of IdiomaCurriculo)
        Dim _dr As SqlDataReader = Nothing
        Dim _idiomas As New List(Of IdiomaCurriculo)

        Using conexao As New ConexaoSQL
            Using comando As New SqlCommand("select a.*,b.NATIVO,b.OBS from TB_IDIOMA a inner join TB_IDIOMA_CURRICULO b on b.IDIOMA = a.CODIGO WHERE b.curriculo = @CODIGO", conexao.Conexao)
                comando.Parameters.Add("@CODIGO", SqlDbType.Int).Value = pCodigoCurriculo

                Try
                    conexao.Conexao.Open()

                    _dr = comando.ExecuteReader

                    If _dr.HasRows Then
                        Dim _idiomaCurriculo As IdiomaCurriculo = Nothing

                        While _dr.Read
                            Dim _idioma As New Idioma
                            'idioma
                            _idioma.Codigo = _dr.GetInt32(0)
                            _idioma.Descricao = _dr.GetString(1)
                            'idioma_curriculo
                            _idiomaCurriculo = New IdiomaCurriculo
                            _idiomaCurriculo.Idioma = _idioma
                            _idiomaCurriculo.Nativo = _dr.GetInt32(2)
                            _idiomaCurriculo.Obs = _dr.GetString(3)
                            _idiomaCurriculo.Status = "A"

                            _idiomas.Add(_idiomaCurriculo)
                        End While
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                Finally
                    If Not _dr Is Nothing Then
                        _dr.Close()
                    End If
                End Try
            End Using
        End Using

        Return _idiomas
    End Function

    Private Shared Function GetCursosCurriculo(ByVal pCurriculo As String) As List(Of CursoCurriculo)
        Dim _dr As SqlDataReader = Nothing
        Dim _cursos As New List(Of CursoCurriculo)
        Dim _query As String = "select _cidade.*,_entidade.CODIGO,_entidade.NOME_ENTIDADE,_curso.CODIGO," & _
                               "_curso.DESCRICAO,_curso.SITUACAO,_curso.CATEGORIA,_curso.CARGA_HORARIA," & _
                               "_curso_curriculo.DATA_INICIAL,_curso_curriculo.DATA_FINAL,_curso_curriculo.CONCLUIDO," & _
                               "_curso_curriculo.OBS,_curso_curriculo.DIG_CERTIFICADO " & _
                               "from TB_CURSO _curso " & _
                               "inner join TB_CURSO_CURRICULO _curso_curriculo " & _
                               "on _curso_curriculo.CURSO = _curso.CODIGO " & _
                               "inner join TB_ENTIDADE_ENSINO _entidade " & _
                               "on _curso.ENTIDADE = _entidade.CODIGO " & _
                               "inner join TB_CIDADE _cidade " & _
                               "on _entidade.CIDADE = _cidade.CODIGO " & _
                               "where _curso_curriculo.CURRICULO = @CODIGO"

        Using conexao As New ConexaoSQL
            Using comando As New SqlCommand(_query, conexao.Conexao)
                comando.Parameters.Add("@CODIGO", SqlDbType.Int).Value = pCurriculo

                Try
                    conexao.Conexao.Open()

                    _dr = comando.ExecuteReader

                    If _dr.HasRows Then
                        Dim _cursoCurriculo As CursoCurriculo = Nothing

                        While _dr.Read
                            'cidade
                            Dim _cidade As New Cidade
                            _cidade.Codigo = _dr.GetInt32(0)
                            _cidade.Descricao = _dr.GetString(1)
                            _cidade.UF = _dr.GetString(2)
                            _cidade.Situacao = _dr.GetString(3)
                            'entidade
                            Dim _entidade As New Entidade
                            _entidade.Codigo = _dr.GetInt32(4)
                            _entidade.Descricao = _dr.GetString(5)
                            _entidade.Cidade = _cidade
                            'curso
                            Dim _curso As New Curso
                            _curso.Codigo = _dr.GetInt32(6)
                            _curso.Descricao = _dr.GetString(7)
                            _curso.Situacao = _dr.GetString(8)
                            _curso.Categoria = _dr.GetInt32(9)
                            _curso.CargaHoraria = _dr.GetString(10)
                            _curso.Entidade = _entidade
                            'cursoCurriculo
                            _cursoCurriculo = New CursoCurriculo
                            _cursoCurriculo.DataInicial = _dr.GetDateTime(11)
                            _cursoCurriculo.DataFinal = _dr.GetDateTime(12)
                            _cursoCurriculo.Concluido = _dr.GetInt32(13)
                            _cursoCurriculo.Obs = _dr.GetString(14)
                            _cursoCurriculo.PathCertificado = _dr.GetString(15)
                            _cursoCurriculo.Curso = _curso
                            _cursoCurriculo.Status = "A"

                            _cursos.Add(_cursoCurriculo)
                        End While
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                Finally
                    If Not _dr Is Nothing Then
                        _dr.Close()
                    End If
                End Try
            End Using
        End Using

        Return _cursos
    End Function

    Private Shared Function GetCargosAnterioresCurriculo(ByVal pCodigoCurriculo As String) As List(Of CurriculoCargo)
        Dim _dr As SqlDataReader = Nothing
        Dim _cargos As New List(Of CurriculoCargo)

        Dim _query As String = "select _cargo.CODIGO,_cargo.DESCRICAO,_cargo.SITUACAO,_area.*,_empresa.CODIGO," & _
                               "_empresa.NOME_FANTASIA,_empresa.RAZ_SOCIAL,_empresa.SITUACAO,_empresa.CLIENTE," & _
                               "_cidade.*,_cargo_curriculo.DATA_INICIO,_cargo_curriculo.DATA_FINAL,_cargo_curriculo.FUNCOES_DESEMP," & _
                               "_cargo_curriculo.CESTA_BASICA,_cargo_curriculo.VALE_TRANSPORTE,_cargo_curriculo.PLR," & _
                               "_cargo_curriculo.CONVENIO_MEDICO,_cargo_curriculo.VALE_REFEICAO,_cargo_curriculo.SEGURO_VIDA," & _
                               "_cargo_curriculo.AJUDA_CUSTO_ENSINO,_cargo_curriculo.AUX_CRECHE,_cargo_curriculo.AUX_DENTISTA," & _
                               "_cargo_curriculo.MOTIVO_SAIDA,_cargo_curriculo.VL_CESTA_BASICA,_cargo_curriculo.VL_VALE_TRANSPORTE," & _
                               "_cargo_curriculo.VL_PLR,_cargo_curriculo.VL_CONVENIO_MEDICO,_cargo_curriculo.VL_VALE_REFEICAO," & _
                               "_cargo_curriculo.VL_SEGURO_VIDA,_cargo_curriculo.VL_AJUDA_CUSTO_ENSINO,_cargo_curriculo.VL_AUX_CRECHE," & _
                               "_cargo_curriculo.VL_AUX_DENTISTA,_cargo_curriculo.VL_RECEBIDO_FORA,_cargo_curriculo.REGISTRADO,_cargo_curriculo.SALARIO,_cargo_curriculo.ATUAL " & _
                               "from TB_CARGO _cargo " & _
                               "inner join TB_CARGO_CURRICULO _cargo_curriculo " & _
                               "on _cargo_curriculo.CARGO = _cargo.CODIGO " & _
                               "inner join TB_EMPRESA _empresa " & _
                               "on _cargo_curriculo.EMPRESA = _empresa.CODIGO " & _
                               "inner join TB_AREA _area " & _
                               "on _cargo.AREA = _area.CODIGO " & _
                               "inner join TB_CIDADE _cidade " & _
                               "on _empresa.CIDADE = _cidade.CODIGO " & _
                               "where _cargo_curriculo.curriculo = @CODIGO"

        Using conexao As New ConexaoSQL
            Using comando As New SqlCommand(_query, conexao.Conexao)
                comando.Parameters.Add("@CODIGO", SqlDbType.Int).Value = pCodigoCurriculo

                Try
                    conexao.Conexao.Open()

                    _dr = comando.ExecuteReader

                    If _dr.HasRows Then
                        Dim _cargoCurriculo As CurriculoCargo = Nothing

                        While _dr.Read
                            'cidade
                            Dim _cidade As New Cidade
                            _cidade.Codigo = _dr.GetInt32(11)
                            _cidade.Descricao = _dr.GetString(12)
                            _cidade.UF = _dr.GetString(13)
                            _cidade.Situacao = _dr.GetString(14)

                            'empresa
                            Dim _empresa As New Empresa
                            _empresa.Codigo = _dr.GetInt32(6)
                            _empresa.NomeFantasia = _dr.GetString(7)
                            _empresa.RazaoSocial = _dr.GetString(8)
                            _empresa.Situacao = _dr.GetString(9)
                            _empresa.Cliente = _dr.GetInt32(10)
                            _empresa.Cidade = _cidade

                            'area
                            Dim _area As New Area
                            _area.Codigo = _dr.GetInt32(3)
                            _area.Descricao = _dr.GetString(4)

                            'cargo
                            Dim _cargo As New Cargo
                            _cargo.Codigo = _dr.GetInt32(0)
                            _cargo.Descricao = _dr.GetString(1)
                            _cargo.Situacao = _dr.GetString(2)
                            _cargo.Area = _area

                            'cargo_curriculo
                            _cargoCurriculo = New CurriculoCargo
                            _cargoCurriculo.DataInicio = _dr.GetDateTime(15)
                            _cargoCurriculo.DataFinal = _dr.GetDateTime(16)
                            _cargoCurriculo.FuncoesDesempenhadas = _dr.GetString(17)
                            _cargoCurriculo.CestaBasica = _dr.GetInt32(18)
                            _cargoCurriculo.ValeTransporte = _dr.GetInt32(19)
                            _cargoCurriculo.PLR = _dr.GetInt32(20)
                            _cargoCurriculo.ConvenioMedico = _dr.GetInt32(21)
                            _cargoCurriculo.ValeRefeicao = _dr.GetInt32(22)
                            _cargoCurriculo.SeguroDeVida = _dr.GetInt32(23)
                            _cargoCurriculo.AjudaCustoEstudo = _dr.GetInt32(24)
                            _cargoCurriculo.AuxilioCreche = _dr.GetInt32(25)
                            _cargoCurriculo.AuxilioDentista = _dr.GetInt32(26)
                            _cargoCurriculo.MotivoSaida = _dr.GetString(27)
                            _cargoCurriculo.ValorCestaBasica = _dr.GetDecimal(28)
                            _cargoCurriculo.ValorTransporte = _dr.GetDecimal(29)
                            _cargoCurriculo.ValorPLR = _dr.GetDecimal(30)
                            _cargoCurriculo.ValorConvenioMedico = _dr.GetDecimal(31)
                            _cargoCurriculo.ValorRefeicao = _dr.GetDecimal(32)
                            _cargoCurriculo.ValorSeguroVida = _dr.GetDecimal(33)
                            _cargoCurriculo.ValorAjudaCustoEnsino = _dr.GetDecimal(34)
                            _cargoCurriculo.ValorAuxilioCreche = _dr.GetDecimal(35)
                            _cargoCurriculo.ValorAuxilioDentista = _dr.GetDecimal(36)
                            _cargoCurriculo.ValorRecebidoFora = _dr.GetDecimal(37)
                            _cargoCurriculo.Registrado = _dr.GetInt32(38)
                            _cargoCurriculo.Salario = _dr.GetDecimal(39)
                            _cargoCurriculo.Atual = _dr.GetInt32(40)
                            _cargoCurriculo.Cargo = _cargo
                            _cargoCurriculo.Empresa = _empresa
                            _cargoCurriculo.Status = "A"

                            _cargos.Add(_cargoCurriculo)

                        End While
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                Finally
                    If Not _dr Is Nothing Then
                        _dr.Close()
                    End If
                End Try
            End Using
        End Using

        Return _cargos
    End Function

    Private Shared Function GetCargosPretendidos(ByVal pCodigoCurriculo As String) As List(Of CargoPretendidoCurriculo)
        Dim _dr As SqlDataReader = Nothing
        Dim _cargos As New List(Of CargoPretendidoCurriculo)

        Dim _query As String = "select _area.CODIGO,_area.DESCRICAO,_cargo.CODIGO,_cargo.DESCRICAO,_cargo.SITUACAO,_cargo_pretendido.PRINCIPAL from TB_CARGO _cargo " & _
                               "inner join TB_CARGO_PRETENDIDO _cargo_pretendido " & _
                               "on _cargo_pretendido.CARGO = _cargo.CODIGO " & _
                               "inner join TB_AREA _area " & _
                               "on _cargo.AREA = _area.CODIGO " & _
                               "where _cargo_pretendido.curriculo = @codigo"

        Using conexao As New ConexaoSQL
            Using comando As New SqlCommand(_query, conexao.Conexao)
                comando.Parameters.Add("@CODIGO", SqlDbType.Int).Value = pCodigoCurriculo

                Try
                    conexao.Conexao.Open()

                    _dr = comando.ExecuteReader

                    If _dr.HasRows Then
                        Dim _cargoPretendido As CargoPretendidoCurriculo = Nothing

                        While _dr.Read
                            'area
                            Dim _area As New Area
                            _area.Codigo = _dr.GetInt32(0)
                            _area.Descricao = _dr.GetString(1)

                            'cargos
                            Dim _cargo As New Cargo
                            _cargo.Codigo = _dr.GetInt32(2)
                            _cargo.Descricao = _dr.GetString(3)
                            _cargo.Situacao = _dr.GetString(4)
                            _cargo.Area = _area

                            _cargoPretendido = New CargoPretendidoCurriculo
                            _cargoPretendido.Cargo = _cargo
                            _cargoPretendido.Status = "A"
                            _cargoPretendido.Principal = _dr.GetInt32(5)

                            _cargos.Add(_cargoPretendido)
                        End While

                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                Finally
                    If Not _dr Is Nothing Then
                        _dr.Close()
                    End If
                End Try
            End Using
        End Using

        Return _cargos
    End Function


    Public Shared Function GetNacionalidades(ByVal strQuery As String) As List(Of Nacionalidade)
        Dim _dr As SqlDataReader = Nothing
        Dim nacionalidades As List(Of Nacionalidade) = New List(Of Nacionalidade)

        Using conexao As New ConexaoSQL
            Using comando As New SqlCommand(strQuery, conexao.Conexao)
                Try
                    conexao.Conexao.Open()

                    _dr = comando.ExecuteReader

                    If _dr.HasRows Then
                        Dim _nacionalidade As Nacionalidade = Nothing

                        While _dr.Read
                            _nacionalidade = New Nacionalidade

                            _nacionalidade.Codigo = _dr.GetInt32(0)
                            _nacionalidade.Descricao = _dr.GetString(1)

                            nacionalidades.Add(_nacionalidade)
                        End While
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                Finally
                    If Not _dr Is Nothing Then
                        _dr.Close()
                    End If
                End Try
            End Using
        End Using

        Return nacionalidades
    End Function

    Public Shared Function GetEntidades(ByVal pQuery As String) As List(Of Entidade)
        Dim _dr As SqlDataReader = Nothing
        Dim _listaEntidade As List(Of Entidade) = New List(Of Entidade)

        Using conexao As New ConexaoSQL
            Using comando As New SqlCommand(pQuery, conexao.Conexao)
                Try
                    conexao.Conexao.Open()

                    _dr = comando.ExecuteReader

                    If _dr.HasRows Then
                        Dim _entidade As Entidade = Nothing

                        While _dr.Read()
                            'cidade
                            Dim _cidade As New Cidade
                            _cidade.Codigo = _dr.GetInt32(4)
                            _cidade.Descricao = _dr.GetString(5)
                            _cidade.UF = _dr.GetString(6)
                            _cidade.Situacao = _dr.GetString(7)
                            'entidade
                            _entidade = New Entidade
                            _entidade.Codigo = _dr.GetInt32(0)
                            _entidade.Descricao = _dr.GetString(1)
                            _entidade.Situacao = _dr.GetString(3)
                            _entidade.Cidade = _cidade

                            _listaEntidade.Add(_entidade)
                        End While
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                Finally
                    If Not _dr Is Nothing Then
                        _dr.Close()
                    End If
                End Try
            End Using
        End Using

        Return _listaEntidade
    End Function

    Public Shared Function GetCursos(ByVal pQuery As String) As List(Of Curso)
        Dim _dr As SqlDataReader = Nothing
        Dim _lstCursos As List(Of Curso) = New List(Of Curso)

        Using conexao As New ConexaoSQL
            Using comando As New SqlCommand(pQuery, conexao.Conexao)
                Try
                    conexao.Conexao.Open()

                    _dr = comando.ExecuteReader

                    If _dr.HasRows Then
                        Dim _curso As Curso = Nothing

                        While _dr.Read
                            'cidade da entidade de ensino
                            Dim _cidadeEntidade As New Cidade
                            _cidadeEntidade.Codigo = _dr.GetInt32(9)
                            _cidadeEntidade.Descricao = _dr.GetString(10)
                            _cidadeEntidade.UF = _dr.GetString(11)
                            _cidadeEntidade.Situacao = _dr.GetString(12)
                            'entidade de ensino
                            Dim _entidade As New Entidade
                            _entidade.Codigo = _dr.GetInt32(6)
                            _entidade.Descricao = _dr.GetString(7)
                            _entidade.Cidade = _cidadeEntidade
                            'curso
                            _curso = New Curso
                            _curso.Codigo = _dr.GetInt32(0)
                            _curso.Descricao = _dr.GetString(1)
                            _curso.Entidade = _entidade
                            _curso.Categoria = _dr.GetInt32(4)
                            _curso.Situacao = _dr.GetString(3)
                            _curso.CargaHoraria = _dr.GetString(5)

                            _lstCursos.Add(_curso)
                        End While
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                Finally
                    If Not _dr Is Nothing Then
                        _dr.Close()
                    End If
                End Try
            End Using
        End Using

        Return _lstCursos
    End Function

    Public Shared Function GetIdiomas(ByVal pQuery As String) As List(Of Idioma)
        Dim _dr As SqlDataReader = Nothing
        Dim _idiomas As List(Of Idioma) = New List(Of Idioma)

        Using conexao As New ConexaoSQL
            Using comando As New SqlCommand(pQuery, conexao.Conexao)
                Try
                    conexao.Conexao.Open()

                    _dr = comando.ExecuteReader

                    If _dr.HasRows Then
                        Dim _idioma As Idioma = Nothing

                        While _dr.Read
                            _idioma = New Idioma

                            _idioma.Codigo = _dr.GetInt32(0)
                            _idioma.Descricao = _dr.GetString(1)

                            _idiomas.Add(_idioma)
                        End While
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                Finally
                    If Not _dr Is Nothing Then
                        _dr.Close()
                    End If
                End Try
            End Using
        End Using

        Return _idiomas
    End Function

    Public Shared Function GetAreas(ByVal pQuery As String) As List(Of Area)
        Dim _dr As SqlDataReader = Nothing
        Dim _areas As List(Of Area) = New List(Of Area)

        Using conexao As New ConexaoSQL
            Using comando As New SqlCommand(pQuery, conexao.Conexao)
                Try
                    conexao.Conexao.Open()

                    _dr = comando.ExecuteReader

                    If _dr.HasRows Then
                        Dim _area As Area = Nothing

                        While _dr.Read
                            _area = New Area

                            _area.Codigo = _dr.GetInt32(0)
                            _area.Descricao = _dr.GetString(1)

                            _areas.Add(_area)
                        End While
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                Finally
                    If Not _dr Is Nothing Then
                        _dr.Close()
                    End If
                End Try
            End Using
        End Using

        Return _areas
    End Function

    Public Shared Function GetCargos(ByVal pQuery As String) As List(Of Cargo)
        Dim _dr As SqlDataReader = Nothing
        Dim _cargos As List(Of Cargo) = New List(Of Cargo)

        Using conexao As New ConexaoSQL
            Using comando As New SqlCommand(pQuery, conexao.Conexao)
                Try
                    conexao.Conexao.Open()

                    _dr = comando.ExecuteReader

                    If _dr.HasRows Then
                        Dim _cargo As Cargo = Nothing

                        While _dr.Read
                            'area
                            Dim _area As New Area
                            _area.Codigo = _dr.GetInt32(4)
                            _area.Descricao = _dr.GetString(5)
                            'cargo
                            _cargo = New Cargo
                            _cargo.Codigo = _dr.GetInt32(0)
                            _cargo.Descricao = _dr.GetString(1)
                            _cargo.Area = _area

                            _cargos.Add(_cargo)
                        End While
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                Finally
                    If Not _dr Is Nothing Then
                        _dr.Close()
                    End If
                End Try
            End Using
        End Using

        Return _cargos
    End Function

    Public Shared Function GetEmpresas(ByVal pQuery As String) As List(Of Empresa)
        Dim _dr As SqlDataReader = Nothing
        Dim _empresas As List(Of Empresa) = New List(Of Empresa)

        Using conexao As New ConexaoSQL
            Using comando As New SqlCommand(pQuery, conexao.Conexao)
                Try
                    conexao.Conexao.Open()
                    _dr = comando.ExecuteReader

                    If _dr.HasRows Then
                        Dim _empresa As Empresa = Nothing

                        While _dr.Read
                            'cidade
                            Dim _cidade As New Cidade
                            _cidade.Codigo = _dr.GetInt32(6)
                            _cidade.Descricao = _dr.GetString(7)
                            _cidade.UF = _dr.GetString(8)
                            _cidade.Situacao = _dr.GetString(9)
                            'empresa
                            _empresa = New Empresa
                            _empresa.Codigo = _dr.GetInt32(0)
                            _empresa.NomeFantasia = _dr.GetString(1)
                            _empresa.RazaoSocial = _dr.GetString(2)
                            _empresa.Situacao = _dr.GetString(3)
                            _empresa.Cliente = _dr.GetInt32(4)
                            _empresa.Cidade = _cidade

                            _empresas.Add(_empresa)
                        End While
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                Finally
                    If Not _dr Is Nothing Then
                        _dr.Close()
                    End If
                End Try
            End Using
        End Using

        Return _empresas
    End Function

    Public Shared Sub Login(ByVal pUsuario As String, ByVal pSenha As String)
        Dim _dr As SqlDataReader = Nothing

        Using conexao As New ConexaoSQL
            Using comando As New SqlCommand("SELECT CODIGO,NOME,NOME_LOGIN,SITUACAO,ELEVACAO FROM TB_USUARIO WHERE NOME_LOGIN = @LOGIN AND SENHA = @SENHA", conexao.Conexao)
                comando.Parameters.Add("@LOGIN", SqlDbType.NVarChar).Value = pUsuario
                comando.Parameters.Add("@SENHA", SqlDbType.NVarChar).Value = pSenha

                Try
                    conexao.Conexao.Open()

                    _dr = comando.ExecuteReader

                    If _dr.HasRows Then
                        _dr.Read()

                        If _dr.GetString(3) <> "A" Then
                            Throw New Exception("Usuario inativo, não será possivel logar. Contate o administrador do sistema.")
                        End If

                        User.CodigoUsuario = _dr.GetInt32(0)
                        User.NomeUsuario = _dr.GetString(1)
                        User.NomeLogin = _dr.GetString(2)
                        User.ElevacaoUsuario = _dr.GetInt32(4)
                    Else
                        Throw New Exception("Usuario e/ou senha incorreto(s)")
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                Finally
                    If Not _dr Is Nothing Then
                        _dr.Close()
                    End If
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub GerarRelatorio(ByVal pQuery As String)
        Dim _dt As DataTable = Nothing
        Dim _da As SqlDataAdapter = Nothing
        Dim _dsRelatorio As dsRelatorio = Nothing

        Using conexao As New ConexaoSQL
            Using comando As New SqlCommand(pQuery, conexao.Conexao)
                Try
                    conexao.Conexao.Open()

                    _dt = New DataTable
                    _da = New SqlDataAdapter(comando)
                    _da.Fill(_dt)

                    _dsRelatorio = New dsRelatorio
                    _dsRelatorio.Tables(0).Merge(_dt)

                    Dim _view As New frmViewer(_dsRelatorio)
                    _view.Show()


                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Public Shared Function GetHistoricoFirebird(ByVal pCodigoCandidato As String) As List(Of HistoricoFB)
        Dim _drFB As FbDataReader = Nothing
        Dim lstHistorico As New List(Of HistoricoFB)

        Using conexao As New ConexaoFB
            Using comando As New FbCommand("SELECT * FROM HISTORICO WHERE CURRICULO = @CODIGO", conexao.Conexao)
                comando.Parameters.Add("@CODIGO", FbDbType.Integer).Value = pCodigoCandidato

                Try
                    conexao.Conexao.Open()

                    _drFB = comando.ExecuteReader

                    If _drFB.HasRows Then
                        While _drFB.Read
                            Dim _historico As New HistoricoFB

                            _historico.Data = _drFB.GetString(1)
                            _historico.Historico = _drFB.GetString(2)

                            lstHistorico.Add(_historico)
                        End While
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                Finally
                    If Not _drFB Is Nothing Then _drFB.Close()
                End Try
            End Using
        End Using

        Return lstHistorico
    End Function
#End Region



End Class


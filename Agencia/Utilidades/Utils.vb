Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Linq
Imports System.Text

Public Class Utils
    Private Declare Auto Function GetPrivateProfileString Lib "Kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Private Shared _nomeArquivo As String = "C:\WVisage\config.ini"

    Private Shared _diretorioCertificados As String = ""
    Private Shared _diretorioFotoCandidato As String = ""
    Private Shared _diretorioCurriculos As String = ""
    Private Shared _conexaoBancoDeDados As String = ""
    Private Shared _diretorioRelatorios As String = ""
    Private Shared _caminhoBDAntigo As String = ""

    Private Shared Function LerINI(ByVal file_name As String, ByVal section_name As String, ByVal key_name As String, ByVal default_value As String) As String
        Const MAX_LENGTH As Integer = 500
        Dim string_builder As New StringBuilder(MAX_LENGTH)

        Try
            If File.Exists(_nomeArquivo) Then
                GetPrivateProfileString(section_name, key_name, default_value, string_builder, MAX_LENGTH, file_name)
            Else
                Throw New Exception("Arquivo de configuração invalido. Entre em contato com o suporte tecnico.")
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

        Return string_builder.ToString()
    End Function

    Public Shared Sub SetarParametros()
        Try
            _diretorioCertificados = LerINI(_nomeArquivo, "Caminhos", "certificados", "")
            _diretorioFotoCandidato = LerINI(_nomeArquivo, "Caminhos", "fotosCandidatos", "")
            _diretorioCurriculos = LerINI(_nomeArquivo, "Caminhos", "curriculos", "")
            _conexaoBancoDeDados = LerINI(_nomeArquivo, "BD", "string", "")
            _diretorioRelatorios = LerINI(_nomeArquivo, "Caminhos", "relatorios", "")
            _caminhoBDAntigo = LerINI(_nomeArquivo, "Firebird", "caminho", "")

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Shared Function FormatarCelular(ByVal strCelular As String)
        Dim _formatado As String = Nothing

        If strCelular.Replace("(", "").Replace(")", "").Replace("-", "").Length < 11 Then
            Throw New Exception("Numero de celular inválido")
        ElseIf Not Regex.IsMatch(strCelular, "^\(\d{2}\)[\s-]?\d{5}-\d{4}$") Then
            _formatado += strCelular.Substring(0, 0) & "("
            _formatado += strCelular.Substring(0, 2) & ")"
            _formatado += strCelular.Substring(2, 5) & "-"
            _formatado += strCelular.Substring(7, 4)
        Else
            _formatado = strCelular
        End If

        Return _formatado
    End Function

    Public Shared Function FormatarTelefoneFixo(ByVal strTelefone As String)
        Dim _formatado As String = Nothing

        If strTelefone.Replace("(", "").Replace(")", "").Replace("-", "").Length < 10 Then
            Throw New Exception("Numero de telefone inválido")
        ElseIf Not Regex.IsMatch(strTelefone, "^\(\d{2}\)[\s-]?\d{4}-\d{4}$") Then
            _formatado += strTelefone.Substring(0, 0) & "("
            _formatado += strTelefone.Substring(0, 2) & ")"
            _formatado += strTelefone.Substring(2, 4) & "-"
            _formatado += strTelefone.Substring(6, 4)
        Else
            _formatado = strTelefone
        End If

        Return _formatado
    End Function

    Public Shared Function FormatarData(ByVal strData As String)
        Dim _formatado As String = Nothing

        If strData.Replace("/", "").Length < 8 Then
            Throw New Exception("Data inválida")
        ElseIf Not Regex.IsMatch(strData, "^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/[12][0-9]{3}$") Then
            _formatado += strData.Substring(0, 2) & "/"
            _formatado += strData.Substring(2, 2) & "/"
            _formatado += strData.Substring(4, 4)
        Else
            _formatado = strData
        End If

        If Not IsDate(_formatado) Then
            Throw New Exception("Data Invalida")
        End If

        Return _formatado
    End Function

    ''' <summary>
    ''' Verifica todos os campos
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function temCampoInvalido(ByVal pGroupBox As GroupBox) As Boolean
        Dim invalido As Boolean = False
        Dim campos = From campo In pGroupBox.Controls Where TypeOf campo Is TextBoxBase

        For Each campo As TextBoxBase In campos
            If (campo.Text = "") And campo.Tag = "O" Then
                invalido = True
                campo.BackColor = Color.Salmon
            Else
                campo.BackColor = Color.White
            End If
        Next

        Return invalido
    End Function

    Public Shared ReadOnly Property DiretorioCertificados As String
        Get
            Return _diretorioCertificados
        End Get
    End Property

    Public Shared ReadOnly Property DiretorioFotoCandidato As String
        Get
            Return _diretorioFotoCandidato
        End Get
    End Property

    Public Shared ReadOnly Property DiretorioCurriculos As String
        Get
            Return _diretorioCurriculos
        End Get
    End Property

    Public Shared ReadOnly Property DiretorioRelatorio As String
        Get
            Return _diretorioRelatorios
        End Get
    End Property

    Public Shared ReadOnly Property ConexaoString As String
        Get
            Return _conexaoBancoDeDados
        End Get
    End Property

    Public Shared ReadOnly Property ConexaoFB As String
        Get
            Return _caminhoBDAntigo
        End Get
    End Property

    Public Shared Function FormataMoeda(ByVal pValor As String) As String
        Try
            Return Double.Parse(pValor).ToString("C2").Replace("R", "").Replace("$", "").Trim
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function





End Class

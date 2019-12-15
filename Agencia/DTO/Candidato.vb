Public Class Candidato
    Implements IDisposable

    Private _codigo As String = ""
    Private _nome As String = ""
    Private _dataNascimento As Date
    Private _tipoDoc As TipoDeDocumento
    Private _documento As String = ""
    Private _sexo As Char = ""
    Private _cidade As Cidade
    Private _obs As String = ""
    Private _facebook As String = ""
    Private _telefone As String = ""
    Private _celular As String = ""
    Private _whatsapp As Integer
    Private _endereco As String = ""
    Private _dataInclusao As DateTime
    Private _dataAtualiza As DateTime
    Private _situacao As Char = ""
    Private _curriculo As Curriculo
    Private _email As String = ""
    Private _raca As TipoRaça
    Private _fumante As Integer
    Private _tatuagemAmostra As Integer
    Private _nomeSocial As String = ""
    Private _foto As String = ""
    Private _boaAparencia As Integer
    Private _filhosMenor As Integer
    Private _filhosMaior As Integer
    Private _habilitadoA As Integer
    Private _habilitadoB As Integer
    Private _habilitadoC As Integer
    Private _habilitadoD As Integer
    Private _estadoCivil As TipoEstadoCivil
    Private _nacionalidade As Nacionalidade
    Private _operadora As OperadoraCelular
    Private _habilitadoE As Integer
    Private _conducaoPropria As Integer
    Private _indicado As Integer
    Private _indicador As String = ""
    Private _tel_recado_1 As String = ""
    Private _nome_recado_1 As String = ""
    Private _tel_recado_2 As String = ""
    Private _nome_recado_2 As String = ""
    Private _tel_recado_3 As String = ""
    Private _nome_recado_3 As String = ""


    Public Property Codigo As String
        Get
            Return _codigo
        End Get
        Set(ByVal value As String)
            _codigo = value
        End Set
    End Property

    Public Property Nome As String
        Get
            Return _nome
        End Get
        Set(ByVal value As String)
            _nome = value
        End Set
    End Property

    Public Property DataNascimento As Date
        Get
            Return _dataNascimento
        End Get
        Set(ByVal value As Date)
            _dataNascimento = value
        End Set
    End Property

    Public Property TipoDoc As TipoDeDocumento
        Get
            Return _tipoDoc
        End Get
        Set(ByVal value As TipoDeDocumento)
            _tipoDoc = value
        End Set
    End Property

    Public Property Documento As String
        Get
            Return _documento
        End Get
        Set(ByVal value As String)
            _documento = value
        End Set
    End Property

    Public Property Sexo As Char
        Get
            Return _sexo
        End Get
        Set(ByVal value As Char)
            _sexo = value
        End Set
    End Property

    Public Property Cidade As Cidade
        Get
            Return _cidade
        End Get
        Set(ByVal value As Cidade)
            _cidade = value
        End Set
    End Property

    Public Property Obs As String
        Get
            Return _obs
        End Get
        Set(ByVal value As String)
            _obs = value
        End Set
    End Property

    Public Property Facebook As String
        Get
            Return _facebook
        End Get
        Set(ByVal value As String)
            _facebook = value
        End Set
    End Property

    Public Property Telefone As String
        Get
            Return _telefone
        End Get
        Set(ByVal value As String)
            _telefone = value
        End Set
    End Property

    Public Property Celular As String
        Get
            Return _celular
        End Get
        Set(ByVal value As String)
            _celular = value
        End Set
    End Property

    Public Property Whatsapp As Integer
        Get
            Return _whatsapp
        End Get
        Set(ByVal value As Integer)
            _whatsapp = value
        End Set
    End Property

    Public Property Endereco As String
        Get
            Return _endereco
        End Get
        Set(ByVal value As String)
            _endereco = value
        End Set
    End Property

    Public Property DataInclusao As DateTime
        Get
            Return _dataInclusao
        End Get
        Set(ByVal value As DateTime)
            _dataInclusao = value
        End Set
    End Property

    Public Property DataAtualizacao As DateTime
        Get
            Return _dataAtualiza
        End Get
        Set(ByVal value As DateTime)
            _dataAtualiza = value
        End Set
    End Property

    Public Property Situacao As Char
        Get
            Return _situacao
        End Get
        Set(ByVal value As Char)
            _situacao = value
        End Set
    End Property

    Public Property Curriculo As Curriculo
        Get
            Return _curriculo
        End Get
        Set(ByVal value As Curriculo)
            _curriculo = value
        End Set
    End Property

    Public Property Email As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property

    Public Property Raca As TipoRaça
        Get
            Return _raca
        End Get
        Set(ByVal value As TipoRaça)
            _raca = value
        End Set
    End Property

    Public Property Fumante As Integer
        Get
            Return _fumante
        End Get
        Set(ByVal value As Integer)
            _fumante = value
        End Set
    End Property

    Public Property TatuagemAmostra As Integer
        Get
            Return _tatuagemAmostra
        End Get
        Set(ByVal value As Integer)
            _tatuagemAmostra = value
        End Set
    End Property

    Public Property NomeSocial As String
        Get
            Return _nomeSocial
        End Get
        Set(ByVal value As String)
            _nomeSocial = value
        End Set
    End Property

    Public Property Foto As String
        Get
            Return _foto
        End Get
        Set(ByVal value As String)
            _foto = value
        End Set
    End Property

    Public Property BoaAparencia As Integer
        Get
            Return _boaAparencia
        End Get
        Set(ByVal value As Integer)
            _boaAparencia = value
        End Set
    End Property

    Public Property FilhosMenor As Integer
        Get
            Return _filhosMenor
        End Get
        Set(ByVal value As Integer)
            _filhosMenor = value
        End Set
    End Property

    Public Property FilhosMaior As Integer
        Get
            Return _filhosMaior
        End Get
        Set(ByVal value As Integer)
            _filhosMaior = value
        End Set
    End Property

    Public Property HabilitacaoA As Integer
        Get
            Return _habilitadoA
        End Get
        Set(ByVal value As Integer)
            _habilitadoA = value
        End Set
    End Property

    Public Property HabilitacaoB As Integer
        Get
            Return _habilitadoB
        End Get
        Set(ByVal value As Integer)
            _habilitadoB = value
        End Set
    End Property

    Public Property HabilitacaoC As Integer
        Get
            Return _habilitadoC
        End Get
        Set(ByVal value As Integer)
            _habilitadoC = value
        End Set
    End Property

    Public Property HabilitacaoD As Integer
        Get
            Return _habilitadoD
        End Get
        Set(ByVal value As Integer)
            _habilitadoD = value
        End Set
    End Property

    Public Property EstadoCivil As TipoEstadoCivil
        Get
            Return _estadoCivil
        End Get
        Set(ByVal value As TipoEstadoCivil)
            _estadoCivil = value
        End Set
    End Property

    Public Property Nacionalidade As Nacionalidade
        Get
            Return _nacionalidade
        End Get
        Set(ByVal value As Nacionalidade)
            _nacionalidade = value
        End Set
    End Property

    Public Property Operadora As OperadoraCelular
        Get
            Return _operadora
        End Get
        Set(ByVal value As OperadoraCelular)
            _operadora = value
        End Set
    End Property

    Public Property HabilitacaoE As Integer
        Get
            Return _habilitadoE
        End Get
        Set(ByVal value As Integer)
            _habilitadoE = value
        End Set
    End Property

    Public Property ConducaoPropria As Integer
        Get
            Return _conducaoPropria
        End Get
        Set(ByVal value As Integer)
            _conducaoPropria = value
        End Set
    End Property

    Public Property Indicado As Integer
        Get
            Return _indicado
        End Get
        Set(ByVal value As Integer)
            _indicado = value
        End Set
    End Property

    Public Property Indicador As String
        Get
            Return _indicador
        End Get
        Set(ByVal value As String)
            _indicador = value
        End Set
    End Property

    Public Property Tel_Recado_1 As String
        Get
            Return _tel_recado_1
        End Get
        Set(ByVal value As String)
            _tel_recado_1 = value
        End Set
    End Property

    Public Property Nome_Recado_1 As String
        Get
            Return _nome_recado_1
        End Get
        Set(ByVal value As String)
            _nome_recado_1 = value
        End Set
    End Property

    Public Property Tel_Recado_2 As String
        Get
            Return _tel_recado_2
        End Get
        Set(ByVal value As String)
            _tel_recado_2 = value
        End Set
    End Property

    Public Property Nome_Recado_2 As String
        Get
            Return _nome_recado_2
        End Get
        Set(ByVal value As String)
            _nome_recado_2 = value
        End Set
    End Property

    Public Property Tel_Recado_3 As String
        Get
            Return _tel_recado_3
        End Get
        Set(ByVal value As String)
            _tel_recado_3 = value
        End Set
    End Property

    Public Property Nome_Recado_3 As String
        Get
            Return _nome_recado_3
        End Get
        Set(ByVal value As String)
            _nome_recado_3 = value
        End Set
    End Property

    Public Enum TipoDeDocumento
        cpf
        rg
        naoAvaliado
    End Enum

    Public Enum TipoRaça
        negro
        branco
        pardo
        indigena
    End Enum

    Public Enum TipoEstadoCivil
        Solteiro
        Casado
        Separado
        Divorciado
        UniaoEstavel
        Viuvo
    End Enum

    Public Enum OperadoraCelular
        VIVO
        CLARO
        NEXTEL
        OI
        TIM
    End Enum

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class

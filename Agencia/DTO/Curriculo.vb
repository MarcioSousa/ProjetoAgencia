Imports System.Collections.Generic

Public Class Curriculo
    Implements IDisposable

    Private _codigo As String = ""
    Private _dataInclusao As Date
    Private _candidato As Candidato
    Private _classificacao As TipoClassificação
    Private _obs As String = ""
    Private _escolaridade As NivelEscolaridade
    Private _dataAlteracao As DateTime
    Private _ultimoSalario As Double
    Private _digitalizacao As String = ""
    Private _pretensaoSalarial As Double
    Private _cargosPretendidos As List(Of CargoPretendidoCurriculo)
    Private _lstCursos As List(Of CursoCurriculo)
    Private _lstCargos As List(Of CurriculoCargo)
    Private _lstHistoricos As List(Of Historico)
    Private _idiomas As List(Of IdiomaCurriculo)
    Private _digitalizacao_2 As String = ""
    Private _digitalizacao_3 As String = ""
    Private _turno As TurnoDisponivel
    Private _estudando As Integer
    Private _ultimaSerieIncompleta As Series


    Public Property Codigo As String
        Get
            Return _codigo
        End Get
        Set(ByVal value As String)
            _codigo = value
        End Set
    End Property

    Public Property DataInclusao As Date
        Get
            Return _dataInclusao
        End Get
        Set(ByVal value As Date)
            _dataInclusao = value
        End Set
    End Property

    Public Property Candidato As Candidato
        Get
            Return _candidato
        End Get
        Set(ByVal value As Candidato)
            _candidato = value
        End Set
    End Property

    Public Property Cursos As List(Of CursoCurriculo)
        Get
            Return _lstCursos
        End Get
        Set(ByVal value As List(Of CursoCurriculo))
            _lstCursos = value
        End Set
    End Property

    Public Property Cargos As List(Of CurriculoCargo)
        Get
            Return _lstCargos
        End Get
        Set(ByVal value As List(Of CurriculoCargo))
            _lstCargos = value
        End Set
    End Property

    Public Property Historico As List(Of Historico)
        Get
            Return _lstHistoricos
        End Get
        Set(ByVal value As List(Of Historico))
            _lstHistoricos = value
        End Set
    End Property

    Public Property Classificacao As TipoClassificação
        Get
            Return _classificacao
        End Get
        Set(ByVal value As TipoClassificação)
            _classificacao = value
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

    Public Property Escolaridade As NivelEscolaridade
        Get
            Return _escolaridade
        End Get
        Set(ByVal value As NivelEscolaridade)
            _escolaridade = value
        End Set
    End Property

    Public Property DataAlteracao As DateTime
        Get
            Return _dataAlteracao
        End Get
        Set(ByVal value As DateTime)
            _dataAlteracao = value
        End Set
    End Property

    Public Property Idiomas As List(Of IdiomaCurriculo)
        Get
            Return _idiomas
        End Get
        Set(ByVal value As List(Of IdiomaCurriculo))
            _idiomas = value
        End Set
    End Property

    Public Property UltimoSalario As Double
        Get
            Return _ultimoSalario
        End Get
        Set(ByVal value As Double)
            _ultimoSalario = value
        End Set
    End Property

    Public Property Digitalizacao As String
        Get
            Return _digitalizacao
        End Get
        Set(ByVal value As String)
            _digitalizacao = value
        End Set
    End Property

    Public Property PretensaoSalarial As Double
        Get
            Return _pretensaoSalarial
        End Get
        Set(ByVal value As Double)
            _pretensaoSalarial = value
        End Set
    End Property

    Public Property CargosPretendidos As List(Of CargoPretendidoCurriculo)
        Get
            Return _cargosPretendidos
        End Get
        Set(ByVal value As List(Of CargoPretendidoCurriculo))
            _cargosPretendidos = value
        End Set
    End Property

    Public Property Digitalizacao_2 As String
        Get
            Return _digitalizacao_2
        End Get
        Set(ByVal value As String)
            _digitalizacao_2 = value
        End Set
    End Property

    Public Property Digitalizacao_3 As String
        Get
            Return _digitalizacao_3
        End Get
        Set(ByVal value As String)
            _digitalizacao_3 = value
        End Set
    End Property

    Public Property Turno As TurnoDisponivel
        Get
            Return _turno
        End Get
        Set(ByVal value As TurnoDisponivel)
            _turno = value
        End Set
    End Property

    Public Property Estudando As Integer
        Get
            Return _estudando
        End Get
        Set(ByVal value As Integer)
            _estudando = value
        End Set
    End Property

    Public Property UltimaSerieIncompleta As Series
        Get
            Return _ultimaSerieIncompleta
        End Get
        Set(ByVal value As Series)
            _ultimaSerieIncompleta = value
        End Set
    End Property

    Public Enum NivelEscolaridade
        Ensino_Fundamental_Incompleto
        Ensino_Fundamental_Completo
        Ensino_Medio_Incompleto
        Ensino_Medio_Completo
        Ensino_Superior_Incompleto
        Ensino_Superior_Completo
        Pos_Graduacao_Incompleta
        Pos_Graduacao_Completa
    End Enum

    Public Enum Series
        Concluido
        Primeira_Serie
        Segunda_serie
        Terceira_serie
        Quarta_serie
        Quinta_serie
        Sexta_serie
        Setima_serie
        Oitava_serie
        Nona_serie
        Primeiro_colegial
        Segundo_colegial
        Terceiro_colegial
    End Enum

    Public Enum TipoClassificação
        Regular
        Bom
        Excelente
        Ruim
    End Enum

    Public Enum TurnoDisponivel
        Primeiro
        Segundo
        Terceiro
        Comercial
        Indiferente
    End Enum

    Public Sub New()
        _lstCursos = New List(Of CursoCurriculo)
        _lstCargos = New List(Of CurriculoCargo)
        _lstHistoricos = New List(Of Historico)
        _idiomas = New List(Of IdiomaCurriculo)
        _cargosPretendidos = New List(Of CargoPretendidoCurriculo)
    End Sub


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

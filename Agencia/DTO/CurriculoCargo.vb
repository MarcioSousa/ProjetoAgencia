Imports System.Collections.Generic
Public Class CurriculoCargo
    Implements IDisposable

    Private _empresa As Empresa
    Private _cargo As Cargo
    Private _dataInicio As Date
    Private _dataFinal As Date
    Private _curriculo As Curriculo
    Private _funcoesDesempenhadas As String = ""
    Private _motivoSaida As String = ""
    Private _status As Char = ""
    Private _registrado As Integer

    Private _cestaBasica As Integer
    Private _valorCestaBasica As Double

    Private _valeTransporte As Integer
    Private _valorTransporte As Double

    Private _plr As Integer
    Private _valorPlr As Double

    Private _convenioMedico As Integer
    Private _valorConvenioMedico As Double

    Private _valeRefeicao As Integer
    Private _valorValeRefeicao As Double

    Private _seguroVida As Integer
    Private _valorSeguroVida As Double

    Private _ajudaCustoEstudo As Integer
    Private _valorAjudaCustoEnsino As Double

    Private _auxCreche As Integer
    Private _valorAuxCreche As Double

    Private _auxDentista As Integer
    Private _valorAuxDentista As Double

    Private _valorRecebidoFora As Double

    Private _salario As Double

    Private _atual As Integer

    Public Property Cargo As Cargo
        Get
            Return _cargo
        End Get
        Set(ByVal value As Cargo)
            _cargo = value
        End Set
    End Property

    Public Property DataInicio As Date
        Get
            Return _dataInicio
        End Get
        Set(ByVal value As Date)
            _dataInicio = value
        End Set
    End Property

    Public Property DataFinal As Date
        Get
            Return _dataFinal
        End Get
        Set(ByVal value As Date)
            _dataFinal = value
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

    Public Property CestaBasica As Integer
        Get
            Return _cestaBasica
        End Get
        Set(ByVal value As Integer)
            _cestaBasica = value
        End Set
    End Property

    Public Property ValorCestaBasica As Double
        Get
            Return _valorCestaBasica
        End Get
        Set(ByVal value As Double)
            _valorCestaBasica = value
        End Set
    End Property

    Public Property ValeTransporte As Integer
        Get
            Return _valeTransporte
        End Get
        Set(ByVal value As Integer)
            _valeTransporte = value
        End Set
    End Property

    Public Property ValorTransporte As Double
        Get
            Return _valorTransporte
        End Get
        Set(ByVal value As Double)
            _valorTransporte = value
        End Set
    End Property

    Public Property PLR As Integer
        Get
            Return _plr
        End Get
        Set(ByVal value As Integer)
            _plr = value
        End Set
    End Property

    Public Property ValorPLR As Double
        Get
            Return _valorPlr
        End Get
        Set(ByVal value As Double)
            _valorPlr = value
        End Set
    End Property

    Public Property ConvenioMedico As Integer
        Get
            Return _convenioMedico
        End Get
        Set(ByVal value As Integer)
            _convenioMedico = value
        End Set
    End Property

    Public Property ValorConvenioMedico As Double
        Get
            Return _valorConvenioMedico
        End Get
        Set(ByVal value As Double)
            _valorConvenioMedico = value
        End Set
    End Property

    Public Property ValeRefeicao As Integer
        Get
            Return _valeRefeicao
        End Get
        Set(ByVal value As Integer)
            _valeRefeicao = value
        End Set
    End Property

    Public Property ValorRefeicao As Double
        Get
            Return _valorValeRefeicao
        End Get
        Set(ByVal value As Double)
            _valorValeRefeicao = value
        End Set
    End Property

    Public Property SeguroDeVida As Integer
        Get
            Return _seguroVida
        End Get
        Set(ByVal value As Integer)
            _seguroVida = value
        End Set
    End Property

    Public Property ValorSeguroVida As Double
        Get
            Return _valorSeguroVida
        End Get
        Set(ByVal value As Double)
            _valorSeguroVida = value
        End Set
    End Property

    Public Property AjudaCustoEstudo As Integer
        Get
            Return _ajudaCustoEstudo
        End Get
        Set(ByVal value As Integer)
            _ajudaCustoEstudo = value
        End Set
    End Property

    Public Property ValorAjudaCustoEnsino As Double
        Get
            Return _valorAjudaCustoEnsino
        End Get
        Set(ByVal value As Double)
            _valorAjudaCustoEnsino = value
        End Set
    End Property

    Public Property AuxilioCreche As Integer
        Get
            Return _auxCreche
        End Get
        Set(ByVal value As Integer)
            _auxCreche = value
        End Set
    End Property

    Public Property ValorAuxilioCreche As Double
        Get
            Return _valorAuxCreche
        End Get
        Set(ByVal value As Double)
            _valorAuxCreche = value
        End Set
    End Property

    Public Property AuxilioDentista As Integer
        Get
            Return _auxDentista
        End Get
        Set(ByVal value As Integer)
            _auxDentista = value
        End Set
    End Property

    Public Property ValorAuxilioDentista As Double
        Get
            Return _valorAuxDentista
        End Get
        Set(ByVal value As Double)
            _valorAuxDentista = value
        End Set
    End Property

    Public Property ValorRecebidoFora As Double
        Get
            Return _valorRecebidoFora
        End Get
        Set(ByVal value As Double)
            _valorRecebidoFora = value
        End Set
    End Property

    Public Property FuncoesDesempenhadas As String
        Get
            Return _funcoesDesempenhadas
        End Get
        Set(ByVal value As String)
            _funcoesDesempenhadas = value
        End Set
    End Property

    Public Property MotivoSaida As String
        Get
            Return _motivoSaida
        End Get
        Set(ByVal value As String)
            _motivoSaida = value
        End Set
    End Property

    Public Property Empresa As Empresa
        Get
            Return _empresa
        End Get
        Set(ByVal value As Empresa)
            _empresa = value
        End Set
    End Property

    Public Property Status As Char
        Get
            Return _status
        End Get
        Set(ByVal value As Char)
            _status = value
        End Set
    End Property

    Public Property Registrado As Integer
        Get
            Return _registrado
        End Get
        Set(ByVal value As Integer)
            _registrado = value
        End Set
    End Property

    Public Property Salario As Double
        Get
            Return _salario
        End Get
        Set(ByVal value As Double)
            _salario = value
        End Set
    End Property

    Public Property Atual As Integer
        Get
            Return _atual
        End Get
        Set(ByVal value As Integer)
            _atual = value
        End Set
    End Property

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

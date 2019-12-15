Imports System.Collections.Generic

Public Class HistoricoFB
    Private _data As String
    Private _codigoCandidato As String
    Private _historico As String


    Public Property Data As String
        Get
            Return _data
        End Get
        Set(ByVal value As String)
            _data = value
        End Set
    End Property

    Public Property CodigoCandidato As String
        Get
            Return _codigoCandidato
        End Get
        Set(ByVal value As String)
            _codigoCandidato = value
        End Set
    End Property

    Public Property Historico As String
        Get
            Return _historico
        End Get
        Set(ByVal value As String)
            _historico = value
        End Set
    End Property

End Class

Imports System.Collections.Generic

Public Class Nacionalidade
    Private _codigo As String = ""
    Private _descricao As String = ""
    Private _candidatos As List(Of Candidato)

    Public Property Codigo As String
        Get
            Return _codigo
        End Get
        Set(ByVal value As String)
            _codigo = value
        End Set
    End Property

    Public Property Descricao As String
        Get
            Return _descricao
        End Get
        Set(ByVal value As String)
            _descricao = value
        End Set
    End Property

    Private Property Candidatos As List(Of Candidato)
        Get
            Return _candidatos
        End Get
        Set(ByVal value As List(Of Candidato))
            _candidatos = value
        End Set
    End Property
End Class

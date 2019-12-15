Imports DTO

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports DAL



'''<summary>
'''This is a test class for PersistenciaTest and is intended
'''to contain all PersistenciaTest Unit Tests
'''</summary>
<TestClass()> _
Public Class PersistenciaTest


    Private testContextInstance As TestContext

    '''<summary>
    '''Gets or sets the test context which provides
    '''information about and functionality for the current test run.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(ByVal value As TestContext)
            testContextInstance = Value
        End Set
    End Property

#Region "Additional test attributes"
    '
    'You can use the following additional attributes as you write your tests:
    '
    'Use ClassInitialize to run code before running the first test in the class
    '<ClassInitialize()>  _
    'Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    'End Sub
    '
    'Use ClassCleanup to run code after all tests in a class have run
    '<ClassCleanup()>  _
    'Public Shared Sub MyClassCleanup()
    'End Sub
    '
    'Use TestInitialize to run code before running each test
    '<TestInitialize()>  _
    'Public Sub MyTestInitialize()
    'End Sub
    '
    'Use TestCleanup to run code after each test has run
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '
#End Region


    '''<summary>
    '''A test for GravarCandidato
    '''</summary>
    <TestMethod()> _
    Public Sub GravarCandidatoTest()
        Dim pCandidato As Candidato = Nothing ' TODO: Initialize to an appropriate value
        pCandidato = New Candidato
        pCandidato.Codigo = "54731"
        pCandidato.Nome = "Eduardo TT"
        pCandidato.DataNascimento = "16/07/1990"
        pCandidato.TipoDoc = Candidato.TipoDeDocumento.cpf
        pCandidato.Documento = "22978449800"
        pCandidato.Sexo = "M"

        Dim cidade As New Cidade
        cidade.Codigo = 19

        pCandidato.Cidade = cidade

        pCandidato.Obs = "Te"
        pCandidato.Facebook = "JJ"
        pCandidato.Telefone = "1140240982"
        pCandidato.Celular = "1102929282"
        pCandidato.Whatsapp = 1
        pCandidato.Endereco = "rua 10"
        pCandidato.DataAtualizacao = Now.ToString
        pCandidato.DataInclusao = Now.ToString
        pCandidato.Situacao = "A"
        pCandidato.Email = "DD"

        'Dim cidade As New Cidade
        'cidade.Codigo = "100"
        'cidade.Descricao = "TATUI"
        'cidade.Situacao = "B"
        'cidade.UF = "SP"
        Persistencia.AlterarCandidato(pCandidato)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub
End Class

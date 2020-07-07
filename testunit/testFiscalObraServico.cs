using System;
using Moq;
using NUnit.Framework;
using unit.entities;
using unit.services;

namespace testunit
{
  public class TestFiscalObraServico
  {
    private FiscalObraServico _fiscalObraServico;

    [SetUp]
    public void Setup()
    {
    }

    [TestFixture]
    public class FiscalObraTests
    {
      Mock<IFiscalObraPeriodoService> mockFiscalObraPeriodoService;
      FiscalObraServico fiscalObraServico;

      [TestCase("12345678910", false)]
      [TestCase("12345678911", true)]
      [TestCase("45698345005", false)]
      [TestCase("12345678992", true)]
      [TestCase("45638542010", false)]
      public void testeCadastroDuplicadoFiscalObra(string CPF, bool expectedResult)
      {
        mockFiscalObraPeriodoService = new Mock<IFiscalObraPeriodoService>(MockBehavior.Strict);
        mockFiscalObraPeriodoService
        .Setup(p => p.verificaCadastroDuplicado(CPF))
        .Returns(expectedResult);

        fiscalObraServico = new FiscalObraServico(mockFiscalObraPeriodoService.Object);

        var result = fiscalObraServico.verificaCadastroDuplicado(CPF);

        Assert.That(result, Is.EqualTo(expectedResult));

        mockFiscalObraPeriodoService.VerifyAll();
      }

    }
  }
}
using System;
using Moq;
using NUnit.Framework;
using unit.services;
using unit.entities;

namespace testunit
{
  public class TestAcompanhamento
  {
    private Acompanhamento _acompanhamento;

    private void criarAcompanhamento(bool atrasado)
    {
      if (atrasado)
      {
        _acompanhamento = new Acompanhamento(
          1,
          new DateTime(2020, 07, 06, 8, 30, 52),
          new DateTime(2020, 06, 19, 8, 30, 52),
          "0001/2020",
          (decimal)300000.00,
          15,
          (decimal)560000.00,
          10
        );
      }
      else
      {
        _acompanhamento = new Acompanhamento(
        1,
        new DateTime(2020, 07, 06, 8, 30, 52),
        new DateTime(2020, 06, 19, 8, 30, 52),
        "0001/2020",
        (decimal)300000.00,
        15,
        (decimal)560000.00,
        new DateTime(2020, 06, 08, 8, 30, 52),
        10
      );
      }

    }

    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void TestIsValidAcompanhamentoCorrect()
    {
      criarAcompanhamento(false);

      var documentoMock = new Mock<IDocumentoService>();
      documentoMock.Setup(p => p.documentoValido(It.IsAny<int>())).Returns(true);

      bool documentoValido = documentoMock.Object.documentoValido(_acompanhamento.idMemoriaCalculo);

      var acompanhamentoEstaAtrasado = _acompanhamento.IsLate();

      Assert.IsTrue(!acompanhamentoEstaAtrasado && documentoValido);
    }

    [Test]
    public void TestIsValidAcompanhamentoIncorrect()
    {
      criarAcompanhamento(true);

      var documentoMock = new Mock<IDocumentoService>();
      documentoMock.Setup(p => p.documentoValido(It.IsAny<int>())).Returns(true);

      bool documentoValido = documentoMock.Object.documentoValido(_acompanhamento.idMemoriaCalculo);

      var acompanhamentoEstaAtrasado = _acompanhamento.IsLate();

      Assert.IsTrue(acompanhamentoEstaAtrasado && documentoValido);
    }

  }
}
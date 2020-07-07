using System;
using System.Collections.Generic;

namespace unit.entities {
  public class Acompanhamento {
    public Acompanhamento (
      int _idAcompanhamento,
      DateTime _periodoMedicaoDataFim,
      DateTime _periodoMedicaoDataInicio,
      string _sequencial,
      decimal _valorPI,
      Byte _percentualConclusao,
      decimal _valorReajuste,
      DateTime _dataEnvio,
      int _idMemoriaCalculo
    ){
      idAcompanhamento = _idAcompanhamento;      
      periodoMedicaoDataFim = _periodoMedicaoDataFim;
      periodoMedicaoDataInicio = _periodoMedicaoDataInicio;
      valorPI = _valorPI;
      sequencial = _sequencial;
      percentualConclusao = _percentualConclusao;
      valorReajuste = _valorReajuste;
      dataEnvio = _dataEnvio;
      idMemoriaCalculo = _idMemoriaCalculo;
    }

    public Acompanhamento (
      int _idAcompanhamento,
      DateTime _periodoMedicaoDataFim,
      DateTime _periodoMedicaoDataInicio,
      string _sequencial,
      decimal _valorPI,
      Byte _percentualConclusao,
      decimal _valorReajuste,      
      int _idMemoriaCalculo
    ){
      idAcompanhamento = _idAcompanhamento;      
      periodoMedicaoDataFim = _periodoMedicaoDataFim;
      periodoMedicaoDataInicio = _periodoMedicaoDataInicio;
      valorPI = _valorPI;
      sequencial = _sequencial;
      percentualConclusao = _percentualConclusao;
      valorReajuste = _valorReajuste;
      idMemoriaCalculo = _idMemoriaCalculo;
    }
    public int idAcompanhamento { get; set; }
    private DateTime periodoMedicaoDataInicio { get; set; }
    private DateTime periodoMedicaoDataFim { get; set; }
    private string sequencial { get; set; }
    private decimal valorPI { get; set; }
    private decimal valorReajuste { get; set; }
    private Byte percentualConclusao { get; set; }
    public int idMemoriaCalculo { get; set; }
    private DateTime? dataEnvio;    

    public bool IsLate () {
      return dataEnvio == null;
    }   
  }
}
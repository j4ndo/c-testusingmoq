using unit.services; 
namespace unit.entities
{
    public class FiscalObraServico
    {
        IFiscalObraPeriodoService  _fiscalObraPeriodo;
        public FiscalObraServico(IFiscalObraPeriodoService fiscalObraServico){
            _fiscalObraPeriodo = fiscalObraServico;
        }
        public int idFiscalObra { get; set; }
        public string nome { get; set; }
        public string CPF { get; set; }   

        public bool verificaCadastroDuplicado(string CPF){
            return _fiscalObraPeriodo.verificaCadastroDuplicado(CPF);
        }
    }
}
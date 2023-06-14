using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace Api.Servico.Models
{
    public class TbSolicitarFerias
    {
        public int Id { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFim { get; set; }
        public int NumeroDias { get; set; }
        public int DiasAbono { get; set; }
        public int IdStatus { get; set; }
        public TbStatus TbStatus { get; set; }
        public int IdContrato { get; set; }
        public TbContrato TbContratos { get; set; }
    }
}

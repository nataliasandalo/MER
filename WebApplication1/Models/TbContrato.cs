using System.ComponentModel.DataAnnotations;

namespace Api.Servico.Models
{
    public class TbContrato
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string CodContrato { get; set; }

        [StringLength(250)]
        public string NmContrato { get; set; }

        [StringLength(250)]
        public string DSContrato { get; set; }
        public List<TbSolicitarFerias> TbSolicitarFerias { get; set; }
    }
}

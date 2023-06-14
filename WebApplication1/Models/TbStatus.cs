using System.ComponentModel.DataAnnotations;

namespace Api.Servico.Models
{
    public class TbStatus
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string NmStatus { get; set; }

        [StringLength(250)]
        public string DsStatus { get; set; }
        public List<TbSolicitarFerias> TbSolicitarFerias { get; set; }

    }
}

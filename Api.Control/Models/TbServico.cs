using System.ComponentModel.DataAnnotations;

namespace Api.Control.Models
{
    public class TbServico
    {
        public int IdServico { get; set; }
        [StringLength(50)]
        public string NmServico { get; set; }
        [StringLength(250)]
        public string DsServico { get; set; }
        [StringLength(250)]
        public string Link { get; set; }
        public char Status { get; set; }
        public List<TbMenuItem> MenuItems { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace Api.Control.Models
{
    public class TbMenu
    {
        public int IdMenu { get; set; }
        [StringLength(50)]
        public string NmMenu { get; set; }
        [StringLength(255)]
        public string DsMenu { get; set; }
        public TbPortal Portal { get; set; }
        public int IdPortal { get; set; }
        public List<TbMenuItem> TbMenuItems { get; internal set; }
    }
}

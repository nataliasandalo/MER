using System.ComponentModel.DataAnnotations;

namespace Api.Control.Models
{
    public class TbPortal
    {
        public int IdPortal { get; set; }
        public char Status { get; set; }
        public byte[] LogoHeader { get; set; }
        public byte[] LogoFooter { get; set; }
        [StringLength(50)]
        public string DsFacebook { get; set; }
        [StringLength(50)]
        public string DsInstagram { get; set; }
        [StringLength(50)]
        public string DsYoutube { get; set; }
        [StringLength(50)]
        public string DsTwitter { get; set; }
        public List<TbMenu> TbMenus { get; internal set; }
    }
}

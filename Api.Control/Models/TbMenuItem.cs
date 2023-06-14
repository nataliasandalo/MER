namespace Api.Control.Models
{
    public class TbMenuItem
    {
        public int IdItem { get; set; }
        public TbMenu Menu { get; set; }
        public int IdMenu { get; set; }
        public TbServico Servico { get; set; }
        public int IdServico { get; set; }
        public short Ordem { get; set; }
    }
}

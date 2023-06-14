using Api.Servico.Models;

namespace Api.Servico.Interface.IService.ISolicitarFeriasService
{
    public interface ISolicitarFeriasService
    {
        IEnumerable<TbSolicitarFerias> GetSolicitarFerias();
        TbSolicitarFerias GetSolicitarFeriasById(int id);
        void AddSolicitarFerias(TbSolicitarFerias portal);
        void UpdateSolicitarFerias(TbSolicitarFerias portal);
        void DeleteSolicitarFerias(TbSolicitarFerias portal);
    }
}

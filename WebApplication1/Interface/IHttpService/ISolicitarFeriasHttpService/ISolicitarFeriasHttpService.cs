using Api.Servico.Models;

namespace Api.Servico.Interface.IHttpService.ISolicitarFeriasHttpService
{
    public interface ISolicitarFeriasHttpService
    {
        Task<IEnumerable<TbSolicitarFerias>> GetSolicitarFerias();
        Task<TbSolicitarFerias> GetSolicitarFeriasById(int id);
        Task<TbSolicitarFerias> CreateSolicitarFerias(TbSolicitarFerias solicitarferias);
        Task<TbSolicitarFerias> UpdateSolicitarFerias(int id, TbSolicitarFerias solicitarferias);
        Task DeleteSolicitarFerias(int id);
    }
}

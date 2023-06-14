using Api.Servico.Models;

namespace Api.Servico.Interface.IHttpService.IStatusHttpService
{
    public interface IStatusHttpService
    {
        Task<IEnumerable<TbStatus>> GetStatus();
        Task<TbStatus> GetStatusById(int id);
        Task<TbStatus> CreateStatus(TbStatus status);
        Task<TbStatus> UpdateStatus(int id, TbStatus status);
        Task DeleteStatus(int id);
    }
}

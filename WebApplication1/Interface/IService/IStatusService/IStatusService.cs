using Api.Servico.Models;

namespace Api.Servico.Interface.IService.IStatusService
{
    public interface IStatusService
    {
        IEnumerable<TbStatus> GetStatus();
        TbStatus GetStatusById(int id);
        void AddStatus(TbStatus portal);
        void UpdateStatus(TbStatus portal);
        void DeleteStatus(TbStatus portal);
    }
}

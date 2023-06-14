using Api.Servico.Models;

namespace Api.Servico.Interface.IService.IContratoService
{
    public interface IContratoHttpService
    {
        IEnumerable<TbContrato> GetContrato();
        TbContrato GetContratoById(int id);
        void AddContrato(TbContrato portal);
        void UpdateContrato(TbContrato portal);
        void DeleteContrato(TbContrato portal);
    }
}

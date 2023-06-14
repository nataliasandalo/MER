using Api.Servico.Models;

namespace Api.Servico.Interface.IHttpService.IContratoHttpService
{
    public interface IContratoHttpService
    {
        Task<IEnumerable<TbContrato>> GetContratos();
        Task<TbContrato> GetContratoById(int id);
        Task<TbContrato> CreateContrato(TbContrato contrato);
        Task<TbContrato> UpdateContrato(int id, TbContrato contrato);
        Task DeleteContrato(int id);
    }
}

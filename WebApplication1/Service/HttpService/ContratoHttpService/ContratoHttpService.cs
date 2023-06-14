using Api.Servico.Data;
using Api.Servico.Interface.IHttpService.IContratoHttpService;
using Api.Servico.Models;

namespace Api.Servico.Service.HttpService.ContratoHttpService
{
    public class ContratoHttpService : IContratoHttpService
    {
        private readonly ApiClient<TbContrato> _apiClient;

        public ContratoHttpService(ApiClient<TbContrato> apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IEnumerable<TbContrato>> GetContratos()
        {
            try
            {
                return (IEnumerable<TbContrato>)await _apiClient.GetAsync("contratos");
            }
            catch (Exception ex)
            {
                // Tratar o erro conforme necessário
                throw new Exception("Ocorreu um erro ao obter os contratos.", ex);
            }
        }

        public async Task<TbContrato> GetContratoById(int id)
        {
            try
            {
                return await _apiClient.GetAsync($"contratos/{id}");
            }
            catch (Exception ex)
            {
                // Tratar o erro conforme necessário
                throw new Exception($"Ocorreu um erro ao obter o contrato com o ID {id}.", ex);
            }
        }

        public async Task<TbContrato> CreateContrato(TbContrato contrato)
        {
            try
            {
                return await _apiClient.PostAsync("contratos", contrato);
            }
            catch (Exception ex)
            {
                // Tratar o erro conforme necessário
                throw new Exception("Ocorreu um erro ao criar o contrato.", ex);
            }
        }

        public async Task<TbContrato> UpdateContrato(int id, TbContrato contrato)
        {
            try
            {
                return await _apiClient.PutAsync($"contratos/{id}", contrato);
            }
            catch (Exception ex)
            {
                // Tratar o erro conforme necessário
                throw new Exception($"Ocorreu um erro ao atualizar o contrato com o ID {id}.", ex);
            }
        }

        public async Task DeleteContrato(int id)
        {
            try
            {
                await _apiClient.DeleteAsync($"contratos/{id}");
            }
            catch (Exception ex)
            {
                // Tratar o erro conforme necessário
                throw new Exception($"Ocorreu um erro ao deletar o contrato com o ID {id}.", ex);
            }
        }
    }
}

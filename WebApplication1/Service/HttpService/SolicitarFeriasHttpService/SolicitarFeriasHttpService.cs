using Api.Servico.Data;
using Api.Servico.Interface.IHttpService.ISolicitarFeriasHttpService;
using Api.Servico.Models;

namespace Api.Servico.Service.HttpService.SolicitarFeriasHttpService
{
    public class SolicitarFeriasHttpService : ISolicitarFeriasHttpService
    {
        private readonly ApiClient<TbSolicitarFerias> _apiClient;

        public SolicitarFeriasHttpService(ApiClient<TbSolicitarFerias> apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IEnumerable<TbSolicitarFerias>> GetSolicitarFerias()
        {
            try
            {
                return (IEnumerable<TbSolicitarFerias>)await _apiClient.GetAsync("SolicitarFerias");
            }
            catch (Exception ex)
            {
                // Tratar o erro conforme necessário
                throw new Exception("Ocorreu um erro ao obter os SolicitarFerias.", ex);
            }
        }

        public async Task<TbSolicitarFerias> GetSolicitarFeriasById(int id)
        {
            try
            {
                return await _apiClient.GetAsync($"SolicitarFerias/{id}");
            }
            catch (Exception ex)
            {
                // Tratar o erro conforme necessário
                throw new Exception($"Ocorreu um erro ao obter o SolicitarFerias com o ID {id}.", ex);
            }
        }

        public async Task<TbSolicitarFerias> CreateSolicitarFerias(TbSolicitarFerias solicitarferias)
        {
            try
            {
                return await _apiClient.PostAsync("SolicitarFerias", solicitarferias);
            }
            catch (Exception ex)
            {
                // Tratar o erro conforme necessário
                throw new Exception("Ocorreu um erro ao criar o SolicitarFerias.", ex);
            }
        }

        public async Task<TbSolicitarFerias> UpdateSolicitarFerias(int id, TbSolicitarFerias solicitarferias)
        {
            try
            {
                return await _apiClient.PutAsync($"solicitarferias/{id}", solicitarferias);
            }
            catch (Exception ex)
            {
                // Tratar o erro conforme necessário
                throw new Exception($"Ocorreu um erro ao atualizar o solicitarferias com o ID {id}.", ex);
            }
        }

        public async Task DeleteSolicitarFerias(int id)
        {
            try
            {
                await _apiClient.DeleteAsync($"solicitarferias/{id}");
            }
            catch (Exception ex)
            {
                // Tratar o erro conforme necessário
                throw new Exception($"Ocorreu um erro ao deletar o solicitarferias com o ID {id}.", ex);
            }
        }
    }
}

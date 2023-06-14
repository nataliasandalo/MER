using Api.Holerite.Data;
using Api.Holerite.Interface;
using Api.Holerite.Models;

namespace Api.Holerite.Service.HoleriteService
{
    public class HoleriteService : IHoleriteService
    {
        private readonly ApiClient<Models.Holerite> _apiClient;

        public HoleriteService(ApiClient<Models.Holerite> apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IEnumerable<Models.Holerite>> GetHolerite()
        {
            try
            {
                return (IEnumerable<Models.Holerite>)await _apiClient.GetAsync("holerite");
            }
            catch (Exception ex)
            {
                // Tratar o erro conforme necessário
                throw new Exception("Ocorreu um erro ao obter os holerite.", ex);
            }
        }

        public async Task<Models.Holerite> GetHoleriteById(int id)
        {
            try
            {
                return await _apiClient.GetAsync($"holerite/{id}");
            }
            catch (Exception ex)
            {
                // Tratar o erro conforme necessário
                throw new Exception($"Ocorreu um erro ao obter o produto com o ID {id}.", ex);
            }
        }

        public async Task<Models.Holerite> CreateHolerite(Models.Holerite holerite)
        {
            try
            {
                return await _apiClient.PostAsync("holerite", holerite);
            }
            catch (Exception ex)
            {
                // Tratar o erro conforme necessário
                throw new Exception("Ocorreu um erro ao criar o produto.", ex);
            }
        }

        public async Task<Models.Holerite> UpdateHolerite(int id, Models.Holerite product)
        {
            try
            {
                return await _apiClient.PutAsync($"holerite/{id}", product);
            }
            catch (Exception ex)
            {
                // Tratar o erro conforme necessário
                throw new Exception($"Ocorreu um erro ao atualizar o holerite com o ID {id}.", ex);
            }
        }

        public async Task DeleteHolerite(int id)
        {
            try
            {
                await _apiClient.DeleteAsync($"holerite/{id}");
            }
            catch (Exception ex)
            {
                // Tratar o erro conforme necessário
                throw new Exception($"Ocorreu um erro ao deletar o produto com o ID {id}.", ex);
            }
        }
    }
}

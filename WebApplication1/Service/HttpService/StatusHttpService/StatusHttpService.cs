using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Servico.Data;
using Api.Servico.Interface.IHttpService.IStatusHttpService;
using Api.Servico.Models;

namespace Api.Servico.Service.HttpService.StatusHttpService
{
    public class StatusHttpService : IStatusHttpService
    {
        private readonly ApiClient<TbStatus> _apiClient;

        public StatusHttpService(ApiClient<TbStatus> apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IEnumerable<TbStatus>> GetStatus()
        {
            try
            {
                return (IEnumerable<TbStatus>)await _apiClient.GetAsync("status");
            }
            catch (Exception ex)
            {
                // Tratar o erro conforme necessário
                throw new Exception("Ocorreu um erro ao obter os status.", ex);
            }
        }

        public async Task<TbStatus> GetStatusById(int id)
        {
            try
            {
                return await _apiClient.GetAsync($"status/{id}");
            }
            catch (Exception ex)
            {
                // Tratar o erro conforme necessário
                throw new Exception($"Ocorreu um erro ao obter o status com o ID {id}.", ex);
            }
        }

        public async Task<TbStatus> CreateStatus(TbStatus status)
        {
            try
            {
                return await _apiClient.PostAsync("status", status);
            }
            catch (Exception ex)
            {
                // Tratar o erro conforme necessário
                throw new Exception("Ocorreu um erro ao criar o status.", ex);
            }
        }

        public async Task<TbStatus> UpdateStatus(int id, TbStatus status)
        {
            try
            {
                return await _apiClient.PutAsync($"status/{id}", status);
            }
            catch (Exception ex)
            {
                // Tratar o erro conforme necessário
                throw new Exception($"Ocorreu um erro ao atualizar o status com o ID {id}.", ex);
            }
        }

        public async Task DeleteStatus(int id)
        {
            try
            {
                await _apiClient.DeleteAsync($"status/{id}");
            }
            catch (Exception ex)
            {
                // Tratar o erro conforme necessário
                throw new Exception($"Ocorreu um erro ao deletar o status com o ID {id}.", ex);
            }
        }
    }
}
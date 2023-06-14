using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Holerite.Data
{
    public class ApiClient<T>
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public ApiClient(string baseUrl)
        {
            _httpClient = new HttpClient();
            _baseUrl = baseUrl;
        }

        public async Task<T> GetAsync(string endpoint)
        {
            var response = await _httpClient.GetFromJsonAsync<T>($"{_baseUrl}/{endpoint}");

            if (response is not null)
            {
                return response;
            }

            throw new Exception($"Falha na chamada da API");
        }

        public async Task<T> PostAsync(string endpoint, T data)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/{endpoint}", data);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }

            throw new Exception($"Falha na chamada da API. Status code: {response.StatusCode}");
        }

        public async Task<T> PutAsync(string endpoint, T data)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/{endpoint}", data);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }

            throw new Exception($"Falha na chamada da API. Status code: {response.StatusCode}");
        }

        public async Task<T> PatchAsync(string endpoint, T data)
        {
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), $"{_baseUrl}/{endpoint}")
            {
                Content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json")
            };

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }

            throw new Exception($"Falha na chamada da API. Status code: {response.StatusCode}");
        }

        public async Task DeleteAsync(string endpoint)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/{endpoint}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Falha na chamada da API. Status code: {response.StatusCode}");
            }
        }
    }
}
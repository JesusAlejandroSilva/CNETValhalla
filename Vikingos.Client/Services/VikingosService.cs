using System.Net.Http.Json;
using Vikingos.Shared;

namespace Vikingos.Client.Services
{
    public class VikingosService : IVikingosService
    {
        private readonly HttpClient _httpClient;

        public VikingosService(HttpClient httpClient)
        {
                _httpClient = httpClient;
        }
        public async Task<VikingosDTO> Buscar(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseAPI<VikingosDTO>>($"api/Vikingos/Buscar/{id}");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensajes);
        }

        public async Task<int> Editar(VikingosDTO vikingo)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Vikingos/Editar/{vikingo.Id}", vikingo);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensajes);
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Vikingos/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.EsCorrecto!;
            else
                throw new Exception(response.Mensajes);
        }

        public async Task<int> Guardar(VikingosDTO vikingo)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/Vikingos/Guardar", vikingo);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensajes);
        }

        public async Task<List<VikingosDTO>> Lista()
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseAPI<List<VikingosDTO>>>("api/Vikingos/Lista");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensajes);
        }
    }
}

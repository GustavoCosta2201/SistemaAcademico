using SistemaAcademico.Request;
using SistemaAcademico.Response;
using System.Net.Http.Json;

namespace SistemaAcademico.Web2.Services
{
    public class FrequenciaAPI
    {
        private readonly HttpClient httpClient;

        public FrequenciaAPI(IHttpClientFactory factory)
        {
            httpClient = factory.CreateClient("API");
        }

        public async Task<ICollection<FrequenciaResponse>?> GetFrequenciasAsync()
        {
            return await httpClient.GetFromJsonAsync<ICollection<FrequenciaResponse>>("Frequencia");
        }

        public async Task<FrequenciaResponse?> GetFrequenciaPorId(int id)
        {
            return await httpClient.GetFromJsonAsync<FrequenciaResponse>($"Frequencia/{id}");
        }

        public async Task AddFrequenciaAsync(FrequenciaRequest frequenciaRequest)
        {
            await httpClient.PostAsJsonAsync("Frequencia", frequenciaRequest);
        }

        public async Task<bool> UpdateFrequenciaAsync(FrequenciaEdit frequenciaEdit)
        {
            await httpClient.PutAsJsonAsync($"Frequencia/{frequenciaEdit.Id_Frequencia}", frequenciaEdit);
            return true;
        }

        public async Task<bool> DeleteFrequenciaAsync(int id)
        {
            await httpClient.DeleteAsync($"Frequencia/{id}");
            return true;
        }
    }
}

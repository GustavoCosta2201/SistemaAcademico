using SistemaAcademico.Request;
using System.Net.Http.Json;

namespace SistemaAcademico.Web2.Services
{
    public class NotaAPI
    {
        private readonly HttpClient httpClient;

        public NotaAPI(IHttpClientFactory factory)
        {
            httpClient = factory.CreateClient("API");

        }

        public async Task<ICollection<NotaResponse>?> GetNotaAsync()
        {
            return await httpClient.GetFromJsonAsync<ICollection<NotaResponse>>("Nota");

        }

        public async Task<NotaResponse?> GetNotaPorIdAsync(int id)
        {
            return await httpClient.GetFromJsonAsync<NotaResponse>($"/Nota/{id}");

        }

        public async Task AddNotaAsync(NotaRequest notaRequest)
        {
            await httpClient.PostAsJsonAsync("Nota", notaRequest);
        }

        public async Task UpdateNotaAsync(NotaEdit notaRequest)
        {
            var url = $"/Nota/{notaRequest.id_nota}";
            await httpClient.PutAsJsonAsync(url, notaRequest);
        }

        public async Task<bool> DeleteNotaAsync(int id)
        {
            await httpClient.DeleteAsync($"/Nota/{id}");
            return true;
        }

    }
}

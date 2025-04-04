using SistemaAcademico.Request;
using System.Net.Http.Json;

namespace SistemaAcademico.Web2.Services
{
    public class TurmaAPI
    {
        private readonly HttpClient httpClient;

        public TurmaAPI(IHttpClientFactory factory)
        {
            httpClient = factory.CreateClient("API");
        }

        public async Task<ICollection<TurmaResponse>?> GetTurmaAsync()
        {
            return await httpClient.GetFromJsonAsync<ICollection<TurmaResponse>>("Turma");
        }

        public async Task<TurmaResponse?> GetTurmaPorIdAsync(int id)
        {
            return await httpClient.GetFromJsonAsync<TurmaResponse>($"/Turma/{id}");

        }

        public async Task AddTurmaAsync(TurmaRequest turmaRequest)
        {
            await httpClient.PostAsJsonAsync("Turma", turmaRequest);
        }

        public async Task UpdateTurmaAsync(TurmaEdit turmaEdit)
        {
            var url = $"/Turma/{turmaEdit.id_turma}";
            await httpClient.PutAsJsonAsync(url, turmaEdit);
        }

        public async Task<bool> DeleteTurmaAsync(int id)
        {
            await httpClient.DeleteAsync($"/Turma/{id}");
            return true;
        }
    }
}


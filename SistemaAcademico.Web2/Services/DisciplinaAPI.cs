using SistemaAcademico.Request;
using System.Net.Http.Json;

namespace SistemaAcademico.Web2.Services
{
    public class DisciplinaAPI
    {

        private readonly HttpClient httpClient;
        public DisciplinaAPI(IHttpClientFactory factory)
        {
            httpClient = factory.CreateClient("API");
        }

        public async Task<ICollection<DisciplinaResponse>?> GetDisciplinasAsync()
        {
            return await httpClient.GetFromJsonAsync<ICollection<DisciplinaResponse>?>("Disciplina");
        }

        public async Task<DisciplinaResponse?> GetDisciplinaPorIdAsync(int id)
        {
            return await httpClient.GetFromJsonAsync<DisciplinaResponse>($"/Disciplina/{id}");
        }

        public async Task AddDisciplinaAsync (DisciplinaRequest DisciplinaRequest)
        {
            await httpClient.PostAsJsonAsync("Disciplina", DisciplinaRequest);
        }

        public async Task UpdateDisciplinaAsync(DisciplinaEdit DisciplinaRequest)
        {
            var url = $"/Disciplina/{DisciplinaRequest.id_disciplina}";
            await httpClient.PutAsJsonAsync(url, DisciplinaRequest);
        }

        public async Task<bool> DeleteDisciplinaAsync(int id)
        {
            await httpClient.DeleteAsync($"/Disciplina/{id}");
            return true;
        }

        

    }
}

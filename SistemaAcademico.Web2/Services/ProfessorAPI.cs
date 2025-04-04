using SistemaAcademico.Request;
using System.Net.Http.Json;

namespace SistemaAcademico.Web2.Services
{
    public class ProfessorAPI
    {
        private readonly HttpClient httpClient;

        public ProfessorAPI(IHttpClientFactory factory)
        {
           httpClient = factory.CreateClient("API");
        }

        public async Task<ICollection<ProfessorResponse>?> GetProfessorAsync()
        {
            return await httpClient.GetFromJsonAsync<ICollection<ProfessorResponse>>("Professor");
        }

        public async Task<ProfessorResponse?> GetProfessorPorIdAsync(int id)
        {
            return await httpClient.GetFromJsonAsync<ProfessorResponse>($"/Professor/{id}");
        }

        public async Task AddProfessorAsync(ProfessorRequest professorRequest)
        {
            await httpClient.PostAsJsonAsync("Professor", professorRequest);
        }

        public async Task UpdateProfessorasync(ProfessorEdit professorEdit)
        {
            var url = $"/Professor/{professorEdit.id_professor}";
            await httpClient.PutAsJsonAsync(url, professorEdit);
        }

        public async Task<bool> DeleteProfessorAsync(int id)
        {
            await httpClient.DeleteAsync($"/Professor/{id}");
            return true;
        }
    }
}

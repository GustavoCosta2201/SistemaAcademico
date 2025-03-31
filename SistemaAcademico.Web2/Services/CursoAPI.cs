using SistemaAcademico.Request;
using System.Net.Http.Json;

namespace SistemaAcademico.Web2.Services
{
    public class CursoAPI
    {

        private readonly HttpClient httpclient;

        public CursoAPI(IHttpClientFactory factory)
        {
            httpclient = factory.CreateClient("API");
        }

        public async Task<ICollection<CursoResponse>?> GetCursoAsync()
        {
            return await httpclient.GetFromJsonAsync<ICollection<CursoResponse>>("Curso");
        }

        public async Task<ICollection<CursoResponse>?> GetCursoPorId(int id)
        {
            return await httpclient.GetFromJsonAsync<ICollection<CursoResponse>>($"/Curso/{id}");
        }

        public async Task AddCursoAsync(CursoRequest cursoRequest)
        {
            await httpclient.PostAsJsonAsync("Curso", cursoRequest);
        }

        public async Task UpdateCursoAsync(CursoEdit edit)
        {
            var url = $"/Curso/{edit.id}";
            await httpclient.PutAsJsonAsync(url, edit);
        }

        public async Task<bool> DeleteCursoAsync(int id)
        {
            await httpclient.DeleteAsync($"/Curso/{id}");
            return true;
        }
    }
}

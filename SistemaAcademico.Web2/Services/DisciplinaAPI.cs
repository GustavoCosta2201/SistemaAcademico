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

        

    }
}

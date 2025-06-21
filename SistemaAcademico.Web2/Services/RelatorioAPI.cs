using SistemaAcademico.Web2.Response;
using System.Net.Http;
using System.Net.Http.Json;

namespace SistemaAcademico.Web2.Services
{
    public class RelatorioAPI
    {
        private readonly HttpClient httpClient;

        public RelatorioAPI(IHttpClientFactory factory)
        {
            httpClient = factory.CreateClient("API");
        }

        public async Task<ICollection<RendimentoDisciplinaResponse>?> GetMediaNotasPorDisciplina()
        {
            return await httpClient.GetFromJsonAsync<ICollection<RendimentoDisciplinaResponse>>("Relatorio/RendimentoPorDisciplina");
        }

    }
}

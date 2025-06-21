using SistemaAcademico.Web2.Response;
using System.Net.Http;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

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

        public async Task<ICollection<RelatorioTurmaDisciplinaResponse>?> GetRelatorioTurmasAsync()
        {
            return await httpClient.GetFromJsonAsync<ICollection<RelatorioTurmaDisciplinaResponse>>("Relatorio/TurmaDisciplina");
        }
        public async Task<List<RelatorioStatusMatriculaResponse>?> GetStatusMatriculasAsync()
        {
            return await httpClient.GetFromJsonAsync<List<RelatorioStatusMatriculaResponse>>("Relatorio/StatusMatricula");
        }

    }
}

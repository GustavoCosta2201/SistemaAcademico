using SistemaAcademico.Response;
using System.Net.Http.Json;

namespace SistemaAcademico.Web2.Services
{
    public class HorarioAPI
    {
        private readonly HttpClient httpClient;

        public HorarioAPI(IHttpClientFactory factory)
        {
            httpClient = factory.CreateClient("API");
        }

        public async Task<ICollection<HorarioResponse>?> GetHorariosAsync(
            int? idCurso = null,
            int? ano = null,
            string? semestre = null,
            string? turno = null)
        {
            var queryParams = new List<string>();

            if (idCurso.HasValue) queryParams.Add($"idCurso={idCurso}");
            if (ano.HasValue) queryParams.Add($"ano={ano}");
            if (!string.IsNullOrWhiteSpace(semestre)) queryParams.Add($"semestre={semestre}");
            if (!string.IsNullOrWhiteSpace(turno)) queryParams.Add($"turno={turno}");

            var url = "Horario";
            if (queryParams.Count > 0)
                url += "?" + string.Join("&", queryParams);

            return await httpClient.GetFromJsonAsync<ICollection<HorarioResponse>>(url);
        }
    }
}

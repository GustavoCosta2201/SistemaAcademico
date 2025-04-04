using SistemaAcademico.Request;
using System.Net.Http.Json;


namespace SistemaAcademico.Web2.Services
{
    public class MatriculaAPI
    {
        private readonly HttpClient httpClient;

        public MatriculaAPI(IHttpClientFactory factory)
        {
            httpClient = factory.CreateClient("API");
        }

        public async Task<ICollection<MatriculaResponse>?> GetEnderecoAsync()
        {
            return await httpClient.GetFromJsonAsync<ICollection<MatriculaResponse>>("Matricula");
        }

        public async Task<MatriculaResponse?> GetMatriculaPorIdAsync(int id)
        {
            return await httpClient.GetFromJsonAsync<MatriculaResponse>($"/Matricula/{id}");
        }

        public async Task AddMatriculaAsync(MatriculaRequest matriculaRequest)
        {
            await httpClient.PostAsJsonAsync("Matricula", matriculaRequest);
        }

        public async Task UpdateMatriculaAsync(MatriculaEdit matriculaRequest)
        {
            var url = $"/Matricula/{matriculaRequest.id_matricula}";
            await httpClient.PutAsJsonAsync(url, matriculaRequest);
        }

        public async Task<bool> DeleteMatriculaAsync(int id)
        {
            await httpClient.DeleteAsync($"/Matricula/{id}");
            return true;
        }

    }
}

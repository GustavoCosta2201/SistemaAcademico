using SistemaAcademico.Request;
using SistemaAcademico.Response;
using System.Net.Http.Json;

namespace SistemaAcademico.Web2.Services
{
    public class FinanceiroAPI
    {
        private readonly HttpClient httpClient;

        public FinanceiroAPI(IHttpClientFactory factory)
        {
            httpClient = factory.CreateClient("API");
        }

        public async Task<ICollection<FinanceiroResponse>?> GetFinanceirosAsync()
        {
            return await httpClient.GetFromJsonAsync<ICollection<FinanceiroResponse>>("Financeiro");
        }

        public async Task<FinanceiroResponse?> GetFinanceiroPorIdAsync(int id)
        {
            return await httpClient.GetFromJsonAsync<FinanceiroResponse>($"Financeiro/{id}");
        }

        public async Task<bool> AddFinanceiroAsync(FinanceiroRequest request)
        {
            var response = await httpClient.PostAsJsonAsync("Financeiro", request);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateFinanceiroAsync(int id, FinanceiroRequest request)
        {
            var response = await httpClient.PutAsJsonAsync($"Financeiro/{id}", request);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteFinanceiroAsync(int id)
        {
            var response = await httpClient.DeleteAsync($"Financeiro/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

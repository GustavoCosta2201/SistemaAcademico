
using SistemaAcademico.Request;
using SistemaAcademico.Response;
using System.Net.Http.Json;

namespace SistemaAcademico.Web2.Services
{

    public class AlunoAPI
    {
        private readonly HttpClient httpclient;
        public AlunoAPI(IHttpClientFactory factory)
        {
            httpclient = factory.CreateClient("API");
        }

        public async Task<ICollection<AlunoResponse>?> GetAlunosAsync()
        {
            return await httpclient.GetFromJsonAsync<ICollection<AlunoResponse>>("Aluno");
        }

        public async Task<AlunoResponse?> GetAlunoPorId(int Id)
        {
            return await httpclient.GetFromJsonAsync<AlunoResponse>($"/Aluno/{Id}");
        }

        public async Task AddAlunoAsync(AlunoRequest alunoRequest)
        {
            await httpclient.PostAsJsonAsync("Aluno", alunoRequest);
        }

        public async Task<bool> UpdateAlunoAsync(AlunoEdit edit)
        {
            var url = $"/Aluno/{edit.Id_Aluno}";
            await httpclient.PutAsJsonAsync(url, edit);
            return true;
        }

         public async Task<bool> DeleteAlunoAsync(int id)
         {
            await httpclient.DeleteAsync($"/Aluno/{id}");
            return true;
         }


        }
    }

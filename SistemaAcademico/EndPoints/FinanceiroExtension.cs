using Microsoft.AspNetCore.Mvc;
using SistemaAcademico.Data;
using SistemaAcademico.Models;
using SistemaAcademico.Request;

namespace SistemaAcademico.EndPoints
{
    public static class FinanceiroExtension
    {
        public static void AddEndPointsFinanceiro(this WebApplication app)
        {
            var group = app.MapGroup("Financeiro").WithTags("Financeiro");

            // GET: todos os registros financeiros
            group.MapGet("", ([FromServices] DAL<Financeiro> financeiroDAL) =>
            {
                var lista = financeiroDAL.GetAll();
                return Results.Ok(lista);
            });

            // GET: um financeiro por ID
            group.MapGet("{id:int}", ([FromServices] DAL<Financeiro> financeiroDAL, int id) =>
            {
                var item = financeiroDAL.GetItem(f => f.Id_Financeiro == id);
                return item is not null ? Results.Ok(item) : Results.NotFound();
            });

            // POST: criar novo financeiro
            group.MapPost("", ([FromServices] DAL<Financeiro> financeiroDAL, [FromBody] FinanceiroRequest request) =>
            {
                var novo = new Financeiro
                {
                    Id_Matricula = request.Id_Matricula,
                    Valor = request.Valor,
                    Data_Vencimento = request.Data_Vencimento,
                    Data_Pagamento = request.Data_Pagamento,
                    Status = request.Status
                };

                financeiroDAL.AddItem(novo);
                return Results.Created($"/Financeiro/{novo.Id_Financeiro}", novo);
            });

            // PUT: atualizar financeiro
            group.MapPut("{id:int}", ([FromServices] DAL<Financeiro> financeiroDAL, int id, [FromBody] FinanceiroRequest request) =>
            {
                var existente = financeiroDAL.GetItem(f => f.Id_Financeiro == id);
                if (existente == null)
                    return Results.NotFound();

                existente.Id_Matricula = request.Id_Matricula;
                existente.Valor = request.Valor;
                existente.Data_Vencimento = request.Data_Vencimento;
                existente.Data_Pagamento = request.Data_Pagamento;
                existente.Status = request.Status;

                financeiroDAL.UpdateItem(existente);
                return Results.Ok(existente);
            });

            // DELETE: remover financeiro
            group.MapDelete("{id:int}", ([FromServices] DAL<Financeiro> financeiroDAL, int id) =>
            {
                var existente = financeiroDAL.GetItem(f => f.Id_Financeiro == id);
                if (existente == null)
                    return Results.NotFound();

                financeiroDAL.RemoveItem(existente);
                return Results.NoContent();
            });
        }
    }
}

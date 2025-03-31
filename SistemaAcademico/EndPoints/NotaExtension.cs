using Microsoft.AspNetCore.Mvc;
using SistemaAcademico.Data;
using SistemaAcademico.Models;
using SistemaAcademico.Request;

namespace SistemaAcademico.EndPoints
{
    public static class NotaExtension
    {

        public static void AddEndPointsNota(this WebApplication app)
        {
            var GroupBuilder = app.MapGroup("Nota").WithTags("Nota");

            GroupBuilder.MapGet("", ([FromServices] DAL<Nota> nota) =>
            {
                var notalist = nota.GetAll();
                return Results.Ok(notalist);
            });

            GroupBuilder.MapGet("{id:int}", ([FromServices] DAL<Nota> nota, int id) =>
            {
                var notarecover = nota.GetItem(a => a.Id_Nota == id);
                return Results.Ok(notarecover);
            });


            GroupBuilder.MapPost("", ([FromServices] DAL<Nota> Nota, [FromBody] NotaRequest notaReque) =>
            {
                var newNota = new Nota(notaReque.id_aluno, notaReque.id_turma, notaReque.nota_final, notaReque.Data_avaliacao);
                Nota.AddItem(newNota);
                return Results.Ok(newNota);
            });


            GroupBuilder.MapPut("/{id:int}", ([FromServices] DAL<Nota> Nota, int id, [FromBody] NotaEdit edit) =>
            {
                var recover = Nota.GetItem(n => n.Id_Nota == id);

                if(recover != null)
                {
                    recover.Id_Aluno = edit.id_aluno;
                    recover.Id_Turma = edit.id_turma;
                    recover.Nota_Final = edit.nota_final;
                    recover.Data_Avaliacao = edit.Data_avaliacao;
                    Nota.UpdateItem(recover);

                    return Results.Ok(recover);
                }
                else
                {
                    return Results.NotFound();
                }
            });


            GroupBuilder.MapDelete("{id:int}", ([FromServices] DAL<Nota> nota, int id) =>
            {
                var delete = nota.GetItem(a => a.Id_Nota == id);
                nota.RemoveItem(delete);

                return Results.NoContent();
            });


        }
    }
}

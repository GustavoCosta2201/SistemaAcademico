using Microsoft.AspNetCore.Mvc;
using SistemaAcademico.Data;
using SistemaAcademico.Models;
using SistemaAcademico.Request;

namespace SistemaAcademico.EndPoints
{
    public static class TurmaExtension
    {

        public static void AddEndPointsTurma(this WebApplication app)
        {
            var GroupBuilder = app.MapGroup("Turma").WithTags("Turma");

            GroupBuilder.MapGet("", ([FromServices] DAL<Turma> turma) =>
            {
                var turmalist = turma.GetAll();
                return Results.Ok(turmalist);
            });

            GroupBuilder.MapGet("/{id:int}", ([FromServices] DAL<Turma> turma, int id) =>
            {
                var turmarecover = turma.GetItem(a => a.Id_Turma == id);
                return Results.Ok(turmarecover);
            });

            GroupBuilder.MapPost("", ([FromServices] DAL<Turma> Turma, [FromBody] TurmaRequest TurmaRe) =>
            {
                var newTurma = new Turma(TurmaRe.Id_Disciplina, TurmaRe.Id_Professor, TurmaRe.ano, TurmaRe.semestre, TurmaRe.turno);
                Turma.AddItem(newTurma);
                return Results.Ok(newTurma);
            });

            GroupBuilder.MapPut("/{id:int}", ([FromServices] DAL<Turma> Turma, int id, [FromBody] TurmaEdit edit) =>
            {
                var recover = Turma.GetItem(t => t.Id_Turma == id);

                if (recover != null)
                {
                    recover.Id_Disciplina = edit.Id_Disciplina;
                    recover.Id_Professor = edit.Id_Professor;
                    recover.Ano = edit.ano;
                    recover.Semestre = edit.semestre;
                    recover.Turno = edit.turno;
                    Turma.UpdateItem(recover);

                    return Results.Ok(recover);
                }
                else{
                    return Results.NotFound();
                }
            });


            GroupBuilder.MapDelete("/{id:int}", ([FromServices] DAL<Turma> turma, int id) =>
            {
                var delete = turma.GetItem(a => a.Id_Turma == id);
                turma.RemoveItem(delete);

                return Results.NoContent();
            });
        }
    }
}

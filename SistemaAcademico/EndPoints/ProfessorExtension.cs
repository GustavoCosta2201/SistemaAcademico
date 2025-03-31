using Microsoft.AspNetCore.Mvc;
using SistemaAcademico.Data;
using SistemaAcademico.Models;
using SistemaAcademico.Request;

namespace SistemaAcademico.EndPoints
{
    public static class ProfessorExtension
    {

        public static void AddEndPointsProfessor(this WebApplication app)
        {
            var GroupBuilder = app.MapGroup("Professor").WithTags("Professor");

            GroupBuilder.MapGet("", ([FromServices] DAL<Professor> professor) =>
            {
                var professorlist = professor.GetAll();
                return Results.Ok(professorlist);
            });

            GroupBuilder.MapGet("{id:int}", ([FromServices] DAL<Professor> professor, int id) =>
            {
                var professorrecover = professor.GetItem(a => a.Id_Professor == id);
                return Results.Ok(professorrecover);
            });


            GroupBuilder.MapPost("", ([FromServices] DAL<Professor> Prof, [FromBody] ProfessorRequest Profrequest) =>
            {
                var newProf = new Professor(Profrequest.nome, Profrequest.email,Profrequest.telefone, Profrequest.departamento);
                Prof.AddItem(newProf);
                return Results.Ok(newProf);
            });

            GroupBuilder.MapPut("/{id:int}", ([FromServices] DAL<Professor> Prof, int id, [FromBody] ProfessorEdit edit) =>
            {
                var recover = Prof.GetItem(p => p.Id_Professor == id);

                if(recover != null)
                {
                    recover.Nome = edit.nome;
                    recover.Email = edit.email;
                    recover.Telefone = edit.telefone;
                    recover.Departamento = edit.departamento;

                    Prof.UpdateItem(recover);
                    return Results.Ok(recover);
                }
                else
                {
                    return Results.NotFound();
                }
            });


            GroupBuilder.MapDelete("{id:int}", ([FromServices] DAL<Professor> professor, int id) =>
            {
                var delete = professor.GetItem(a => a.Id_Professor == id);
                professor.RemoveItem(delete);

                return Results.NoContent();
            });
        }
    }
}

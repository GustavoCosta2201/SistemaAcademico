using Microsoft.AspNetCore.Mvc;
using SistemaAcademico.Data;
using SistemaAcademico.Models;
using SistemaAcademico.Request;
using System.Reflection.Metadata.Ecma335;

namespace SistemaAcademico.EndPoints
{
    public static class MatriculaExtension
    {

        public static void AddEndPointsMatricula(this WebApplication app)
        {
            var GroupBuilder = app.MapGroup("Matricula").WithTags("Matricula");

            GroupBuilder.MapGet("", ([FromServices] DAL<Matricula> matricula) =>
            {
                var matriculalist = matricula.GetAll();
                return Results.Ok(matriculalist);
            });

            GroupBuilder.MapGet("{id:int}", ([FromServices] DAL<Matricula> matricula, int id) =>
            {
                var matricularecover = matricula.GetItem(a => a.Id_Matricula == id);
                return Results.Ok(matricularecover);
            });


            GroupBuilder.MapPost("", ([FromServices] DAL<Matricula> Matricula, [FromBody] MatriculaRequest matriRequest ) =>
            {
                var newmatricula = new Matricula(matriRequest.Id_aluno, matriRequest.IdCurso, matriRequest.Data_Matricula, matriRequest.Status_Matricula);
                Matricula.AddItem(newmatricula);
                return Results.Ok(newmatricula);
            });


            GroupBuilder.MapPut("/{id:int}", ([FromServices] DAL<Matricula> Matricula, int id, [FromBody] MatriculaEdit edit) =>
            {
                var recover = Matricula.GetItem(m => m.Id_Matricula == id);

                if(recover != null)
                {
                    recover.Id_Aluno = edit.Id_aluno;
                    recover.Id_Curso = edit.IdCurso;
                    recover.Data_Matricula = edit.Data_Matricula;
                    recover.Status_Matricula = edit.Status_Matricula;

                    Matricula.UpdateItem(recover);

                    return Results.Ok(recover);
                }
                else
                {
                    return Results.NotFound();
                }
            });


            GroupBuilder.MapDelete("{id:int}", ([FromServices] DAL<Matricula> matricula, int id) =>
            {
                var delete = matricula.GetItem(a => a.Id_Matricula == id);
                matricula.RemoveItem(delete);

                return Results.NoContent();
            });

        }
    }
}

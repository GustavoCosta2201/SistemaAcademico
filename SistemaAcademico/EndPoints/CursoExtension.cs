using Microsoft.AspNetCore.Mvc;
using SistemaAcademico.Data;
using SistemaAcademico.Models;
using SistemaAcademico.Request;
using System.Net.NetworkInformation;

namespace SistemaAcademico.EndPoints
{
    public static class CursoExtension
    {
        
        public static void AddEndPointsCurso(this WebApplication app)
        {
            var GroupBuilder = app.MapGroup("Curso").WithTags("Curso");

            GroupBuilder.MapGet("", ([FromServices] DAL<Curso> Cursos) =>
            {
               var listCurso = Cursos.GetAll();
                return Results.Ok(listCurso);
            });
            
            GroupBuilder.MapGet("{id:int}", ([FromServices] DAL<Curso> Cursos, int id) =>
            {
                var cursorecover = Cursos.GetItem(c => c.Id_Curso == id);
                return Results.Ok(cursorecover);
            });


            GroupBuilder.MapPost("", ([FromServices] DAL<Curso> Cursos, [FromBody] CursoRequest cursorequest) =>
            {
                var newCurso = new Curso(cursorequest.nome, cursorequest.descricao, cursorequest.duracao);
                Cursos.AddItem(newCurso);
                return Results.Ok(newCurso);
            });

            GroupBuilder.MapPut("/{id:int}", ([FromServices] DAL<Curso> Curso, int id, [FromBody] CursoEdit edit) =>
            {
                var recover = Curso.GetItem(c => c.Id_Curso == id);

                if(recover != null)
                {
                    recover.Nome = edit.nome;
                    recover.Descricao = edit.descricao;
                    recover.Duracao = edit.duracao;

                    Curso.UpdateItem(recover);

                    return Results.Ok(recover);
                }
                else
                {
                    return Results.NotFound();
                }
            });


            GroupBuilder.MapDelete("{id:int}", ([FromServices] DAL<Curso> Cursos, int id) =>
            {
                var CursoDelete = Cursos.GetItem(c => c.Id_Curso == id);
                Cursos.RemoveItem(CursoDelete);
                return Results.NoContent();
            });


        }
    }
}

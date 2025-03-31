using Microsoft.AspNetCore.Mvc;
using SistemaAcademico.Data;
using SistemaAcademico.Models;
using SistemaAcademico.Request;

namespace SistemaAcademico.EndPoints
{
    public static class DisciplinaExtension
    {
        public static void AddEndPointsDisciplina(this WebApplication app)
        {
            var Groupbuilder = app.MapGroup("Disciplina").WithTags("Disciplina");

            Groupbuilder.MapGet("", ([FromServices] DAL<Disciplina> Disciplina) =>
            {
                var ListDis = Disciplina.GetAll();
                return Results.Ok(ListDis);
            });

            Groupbuilder.MapGet("{id:int}", ([FromServices] DAL<Disciplina> Disc, int id) =>
            {
                var cursoRecover = Disc.GetItem(d => d.Id_Disciplina == id);
                return Results.Ok(cursoRecover);
            });


            Groupbuilder.MapPost("", ([FromServices] DAL<Disciplina> Disc, DisciplinaRequest DiscRequest) => {

                var Discnew = new Disciplina(DiscRequest.nome, DiscRequest.descricao, DiscRequest.id_curso);
                Disc.AddItem(Discnew);  
                return Results.Ok(Discnew);
               
            });

            Groupbuilder.MapPut("/{id:int}", ([FromServices] DAL<Disciplina> Disc, int id, DisciplinaEdit edit) =>
            {
                var recover = Disc.GetItem(d => d.Id_Disciplina == id);

                if(recover != null)
                {
                    recover.Nome = edit.nome;
                    recover.Descricao = edit.descricao;
                    recover.Id_Curso = edit.id_curso;

                    Disc.UpdateItem(recover);
                    return Results.Ok(recover);
                }
                else
                {
                    return Results.NotFound();
                }
            });



            Groupbuilder.MapDelete("{id:int}", ([FromServices] DAL<Disciplina> Disc, int id) =>
            {
                var DiscDelete = Disc.GetItem(D => D.Id_Disciplina == id);
                Disc.RemoveItem(DiscDelete);
                return Results.NoContent(); 
            });
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using SistemaAcademico.Data;
using SistemaAcademico.Models;
using SistemaAcademico.Request;

namespace SistemaAcademico.EndPoints
{
    public static class AlunoExtension
    {
        public static void AddEndPointsAluno(this WebApplication app)
        {
            var GroupBuilder = app.MapGroup("Aluno").WithTags("Aluno");

            GroupBuilder.MapGet("", ([FromServices] DAL<Aluno> aluno) =>
            {
                var alunos = aluno.GetAll();
                return Results.Ok(alunos);
            });

            GroupBuilder.MapGet("{id:int}", ([FromServices] DAL<Aluno> alunos, int id) =>
            {
                var alunorecover = alunos.GetItem(a => a.Id_Aluno == id);
                return Results.Ok(alunorecover);    
            });


            GroupBuilder.MapPost("", ([FromServices] DAL<Aluno> alunos, [FromBody] AlunoRequest alunoRequest) =>
            {
                var alunonew = new Aluno(alunoRequest.nome, alunoRequest.email, alunoRequest.senha, alunoRequest.telefone, alunoRequest.endereco, alunoRequest.Data_nasc);
                alunos.AddItem(alunonew);
                return Results.Ok(alunonew);
            });


            GroupBuilder.MapPut("/{id:int}", ([FromServices] DAL<Aluno> Aluno, int id, AlunoEdit edit) =>
            {
                var AlunoRecover = Aluno.GetItem(a => a.Id_Aluno == id);

                if(AlunoRecover != null)
                {
                    AlunoRecover.Nome = edit.nome;
                    AlunoRecover.Email = edit.email;
                    AlunoRecover.Senha = edit.senha;
                    AlunoRecover.Telefone = edit.telefone;
                    AlunoRecover.Endereco = edit.endereco;
                    AlunoRecover.Data_Nasc = edit.Datanasc;

                    Aluno.UpdateItem(AlunoRecover);
                    return Results.Ok(AlunoRecover);
                }
                else
                { 
                    return Results.NotFound();
                }
            });


            GroupBuilder.MapDelete("{id:int}", ([FromServices] DAL<Aluno> alunos, int id ) =>
            {
                var delete = alunos.GetItem(a => a.Id_Aluno == id);
                alunos.RemoveItem(delete);

                return Results.NoContent();
            });






           
        }
    }
}

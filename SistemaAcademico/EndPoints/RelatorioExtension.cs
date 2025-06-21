using Microsoft.AspNetCore.Mvc;
using SistemaAcademico.Data;
using SistemaAcademico.Models;

namespace SistemaAcademico.EndPoints
{
    public static class RelatorioExtension
    {
        public static void AddEndPointsRelatorio(this WebApplication app)
        {
            var group = app.MapGroup("Relatorio").WithTags("Relatório");

            group.MapGet("/RendimentoPorDisciplina", (
                [FromServices] DAL<Nota> notaDAL,
                [FromServices] DAL<Turma> turmaDAL,
                [FromServices] DAL<Disciplina> disciplinaDAL
            ) =>
            {
                var notas = notaDAL.GetAll().ToList();
                var turmas = turmaDAL.GetAll().ToList();
                var disciplinas = disciplinaDAL.GetAll().ToList();

                var resultado = notas
                    .Join(turmas, nota => nota.Id_Turma, turma => turma.Id_Turma,
                        (nota, turma) => new { nota.Nota_Final, turma.Id_Disciplina })
                    .Join(disciplinas, nt => nt.Id_Disciplina, disc => disc.Id_Disciplina,
                        (nt, disc) => new { disc.Nome, nt.Nota_Final })
                    .GroupBy(x => x.Nome)
                    .Select(g => new
                    {
                        NomeDisciplina = g.Key,
                        Media = g.Average(x => x.Nota_Final)
                    })
                    .ToList();

                return Results.Ok(resultado);
            });
        }
    }
}

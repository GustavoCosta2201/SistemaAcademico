using Microsoft.AspNetCore.Mvc;
using SistemaAcademico.Data;
using SistemaAcademico.Models;
using SistemaAcademico.Web2.Response;

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

        public static void AddEndPointsRelatorioTurmaDisciplina(this WebApplication app)
        {
            var group = app.MapGroup("Relatorio").WithTags("Relatórios");

            group.MapGet("/TurmaDisciplina", (
                [FromServices] DAL<Turma> dalTurma,
                [FromServices] DAL<Matricula> dalMatricula,
                [FromServices] DAL<Disciplina> dalDisciplina,
                [FromServices] DAL<Professor> dalProfessor
                ) =>
            {
                var turmas = dalTurma.GetAll();

                var resultado = turmas.Select(t =>
                {
                    var disciplina = dalDisciplina.GetItem(d => d.Id_Disciplina == t.Id_Disciplina);
                    var professor = dalProfessor.GetItem(p => p.Id_Professor == t.Id_Professor);

                    var totalAlunos = dalMatricula.GetAll().Count(m => m.Id_Curso == disciplina.Id_Disciplina);

                    return new RelatorioTurmaDisciplinaResponse
                    {
                        Disciplina = disciplina?.Nome ?? "Não encontrado",
                        Professor = professor?.Nome ?? "Não encontrado",
                        Ano = t.Ano,
                        Semestre = t.Semestre,
                        Turno = t.Turno,
                        TotalAlunos = totalAlunos
                    };
                }).ToList();

                return Results.Ok(resultado);
            });
        }

        public static void AddEndPointsRelatorioStatusMatricula(this WebApplication app)
        {
            var group = app.MapGroup("Relatorio").WithTags("Relatórios");

            group.MapGet("/StatusMatricula", ([FromServices] DAL<Matricula> dal) =>
            {
                var resultado = dal.GetAll()
                    .GroupBy(m => m.Status_Matricula)
                    .Select(g => new RelatorioStatusMatriculaResponse
                    {
                        Status = g.Key.ToString(),
                        Quantidade = g.Count()
                    })
                    .ToList();

                return Results.Ok(resultado);
            });
        }

    }

}


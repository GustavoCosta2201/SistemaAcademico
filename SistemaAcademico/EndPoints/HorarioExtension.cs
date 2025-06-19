using Microsoft.AspNetCore.Mvc;
using SistemaAcademico.Data;
using SistemaAcademico.Models;
using SistemaAcademico.Response; // seu DTO HorarioResponse
using Microsoft.EntityFrameworkCore;

namespace SistemaAcademico.EndPoints
{
    public static class HorarioExtension
    {
        public static void AddEndPointsHorario(this WebApplication app)
        {
            var group = app.MapGroup("Horario").WithTags("Horario");

            group.MapGet("", async ([FromServices] AcademicoContext context,
                        int? idCurso,
                        int? ano,
                        string? semestre,
                        string? turno) =>
            {
                var query = from curso in context.Curso
                            join cursoDisciplina in context.CursoDisciplina on curso.Id_Curso equals cursoDisciplina.Id_Curso
                            join disciplina in context.Disciplina on cursoDisciplina.Id_Disciplina equals disciplina.Id_Disciplina
                            join turma in context.Turma on disciplina.Id_Disciplina equals turma.Id_Disciplina
                            join professor in context.Professor on turma.Id_Professor equals professor.Id_Professor
                            where (!idCurso.HasValue || curso.Id_Curso == idCurso.Value)
                              && (!ano.HasValue || turma.Ano == ano.Value)
                              && (string.IsNullOrEmpty(semestre) || turma.Semestre == semestre)
                              && (string.IsNullOrEmpty(turno) || turma.Turno == turno)
                            select new HorarioResponse
                            {
                                IdCurso = curso.Id_Curso,
                                NomeCurso = curso.Nome,
                                IdDisciplina = disciplina.Id_Disciplina,
                                NomeDisciplina = disciplina.Nome,
                                IdTurma = turma.Id_Turma,
                                IdProfessor = professor.Id_Professor,
                                NomeProfessor = professor.Nome,
                                Ano = turma.Ano,
                                Semestre = turma.Semestre,
                                Turno = turma.Turno
                            };

                var result = await query.ToListAsync();

                return Results.Ok(result);
            });

        }
    }
}

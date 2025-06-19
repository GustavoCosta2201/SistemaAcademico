namespace SistemaAcademico.Request
{
    public record class TurmaResponse(int Id_Turma, int Id_Disciplina, int Id_Professor, int ano, string semestre, string turno);
    
}

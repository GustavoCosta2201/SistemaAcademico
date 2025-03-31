namespace SistemaAcademico.Request
{
    public record class TurmaEdit(int Id_Disciplina, int Id_Professor, int ano, string semestre, string turno)
        : TurmaRequest(Id_Disciplina, Id_Professor, ano, semestre, turno);
}

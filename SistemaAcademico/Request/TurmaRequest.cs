namespace SistemaAcademico.Request
{
    public record class TurmaRequest( int Id_Disciplina, int Id_Professor, int ano, string semestre, string turno);
    
}

namespace SistemaAcademico.Request
{
    public record class MatriculaRequest(int Id_aluno, int IdCurso, DateTime Data_Matricula, string Status_Matricula);
    
    
}

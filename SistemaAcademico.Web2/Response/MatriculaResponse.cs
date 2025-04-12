namespace SistemaAcademico.Response
{
    public record class MatriculaResponse(int Id_Matricula,int Id_aluno, int IdCurso, DateTime Data_Matricula, string Status_Matricula);
    
    
}

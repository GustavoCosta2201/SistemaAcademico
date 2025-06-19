namespace SistemaAcademico.Response
{
    public record class MatriculaResponse(int Id_Matricula,int Id_aluno, int Id_Curso, DateTime Data_Matricula, string Status_Matricula);
    
    
}

namespace SistemaAcademico.Request
{
    public record class MatriculaEdit(int id_matricula,int Id_aluno , int IdCurso, DateTime Data_Matricula, string Status_Matricula)
        : MatriculaRequest(Id_aluno, IdCurso, Data_Matricula, Status_Matricula);

}

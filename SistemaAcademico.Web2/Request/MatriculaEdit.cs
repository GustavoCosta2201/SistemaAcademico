namespace SistemaAcademico.Request
{
    public class MatriculaEdit
    {
        public int Id_Matricula { get; set; }
        public int Id_Aluno { get; set; }
        public int Id_Curso { get; set; }
        public DateTime Data_Matricula { get; set; }
        public string Status_Matricula { get; set; } = string.Empty;

        public MatriculaEdit() { }

        public MatriculaEdit(int id_Matricula, int id_Aluno, int id_Curso, DateTime data_Matricula, string status_Matricula)
        {
            Id_Matricula = id_Matricula;
            Id_Aluno = id_Aluno;
            Id_Curso = id_Curso;
            Data_Matricula = data_Matricula;
            Status_Matricula = status_Matricula;
        }
    }
}

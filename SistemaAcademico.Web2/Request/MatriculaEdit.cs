namespace SistemaAcademico.Request
{
    public class MatriculaEdit
    {
        public int id_matricula { get; set; }
        public int Id_aluno { get; set; }
        public int IdCurso { get; set; }
        public DateTime Data_Matricula { get; set; }
        public string Status_Matricula { get; set; }

        public MatriculaEdit() { }

        public MatriculaEdit(int id_matricula, int Id_aluno, int IdCurso, DateTime Data_Matricula, string Status_Matricula)
        {
            this.id_matricula = id_matricula;
            this.Id_aluno = Id_aluno;
            this.IdCurso = IdCurso;
            this.Data_Matricula = Data_Matricula;
            this.Status_Matricula = Status_Matricula;
        }
    }
}

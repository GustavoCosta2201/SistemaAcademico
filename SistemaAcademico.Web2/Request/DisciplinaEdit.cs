namespace SistemaAcademico.Request
{
    public record class DisciplinaEdit(int id_disciplina,string nome, string descricao, int id_curso)
        : DisciplinaRequest(nome, descricao, id_curso);
}

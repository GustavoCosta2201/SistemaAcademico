namespace SistemaAcademico.Request
{
    public record class DisciplinaEdit(string nome, string descricao, int id_curso)
        : DisciplinaRequest(nome, descricao, id_curso);
}

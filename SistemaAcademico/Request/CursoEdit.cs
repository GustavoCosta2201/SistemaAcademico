namespace SistemaAcademico.Request
{
    public record class CursoEdit (int id, string nome, string descricao, int duracao)
        : CursoRequest(nome, descricao, duracao);

}

namespace SistemaAcademico.Request
{
    public record class NotaRequest(int id_aluno, int id_turma, float nota_final, DateTime Data_avaliacao);

}

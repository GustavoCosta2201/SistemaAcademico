namespace SistemaAcademico.Request
{
    public record class NotaResponse(int Id_Nota,int id_aluno, int id_turma, float nota_final, DateTime Data_avaliacao);

}

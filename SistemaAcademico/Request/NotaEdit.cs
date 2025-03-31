namespace SistemaAcademico.Request
{
    public record class NotaEdit(int id,int id_aluno, int id_turma, float nota_final, DateTime Data_avaliacao)
        : NotaRequest(id_aluno, id_turma, nota_final, Data_avaliacao);
    
}

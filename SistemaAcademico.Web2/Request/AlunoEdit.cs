namespace SistemaAcademico.Request
{
    public record class AlunoEdit(int id, string nome, string email, string senha, DateTime Datanasc, string telefone, string endereco ) 
        : AlunoRequest(nome, email, senha, Datanasc, telefone, endereco);
    
}

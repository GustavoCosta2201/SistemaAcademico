namespace SistemaAcademico.Request
{
    public record class AlunoRequest(string nome,string email, string senha, DateTime Data_nasc, string telefone,string endereco);
    
}

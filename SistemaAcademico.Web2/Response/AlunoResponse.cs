namespace SistemaAcademico.Response
{
    public record class AlunoResponse(int Id_Aluno ,string nome,string email, string senha, DateTime Data_nasc, string telefone,string endereco);
    
}

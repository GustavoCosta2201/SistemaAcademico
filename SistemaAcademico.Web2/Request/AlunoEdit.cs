public class AlunoEdit
{
    public int Id_Aluno { get; set; }
    public string nome { get; set; }
    public string email { get; set; }
    public string senha { get; set; }
    public DateTime Datanasc { get; set; }
    public string telefone { get; set; }
    public string endereco { get; set; }

    public AlunoEdit() { }

    public AlunoEdit(int Id_Aluno, string nome, string email, string senha, DateTime datanasc, string telefone, string endereco)
    {
        this.Id_Aluno = Id_Aluno;
        this.nome = nome;
        this.email = email;
        this.senha = senha;
        this.Datanasc = datanasc;
        this.telefone = telefone;
        this.endereco = endereco;
    }
}

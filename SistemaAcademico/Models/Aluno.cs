using System.ComponentModel.DataAnnotations;

namespace SistemaAcademico.Models
{
    public class Aluno
    {
        [Key]
        public int Id_Aluno { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public DateTime Data_Nasc { get; set; }

        public Aluno()
        {
            
        }
        public Aluno( string nome, string email, string senha, string telefone, string endereco, DateTime data_Nasc)
        {

            Nome = nome;
            Email = email;
            Senha = senha;
            Telefone = telefone;
            Endereco = endereco;
            Data_Nasc = data_Nasc;
        }
    }
}

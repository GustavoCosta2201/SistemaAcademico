using System.ComponentModel.DataAnnotations;

namespace SistemaAcademico.Models
{
    public class Professor
    {
        [Key]
        public int Id_Professor { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Departamento { get; set; }

        public Professor()
        {
            
        }

        public Professor(string nome, string email, string telefone, string departamento)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Departamento = departamento;
        }
    }
}

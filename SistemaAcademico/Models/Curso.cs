using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace SistemaAcademico.Models
{
    public class Curso
    {
        [Key]
        public int Id_Curso { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Duracao { get; set; }
        public virtual ICollection<CursoDisciplina> CursosDisciplinas { get; set; } = new List<CursoDisciplina>();




        public Curso()
        {
            
        }

        public Curso(string nome, string descricao, int duracao)
        {
            Nome = nome;
            Descricao = descricao;
            Duracao = duracao;
        }
    }

    
    
}

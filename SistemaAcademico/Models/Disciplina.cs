using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAcademico.Models
{
    public class Disciplina
    {
        [Key]
        public int Id_Disciplina { get; set; }

        public string Nome { get; set; }
        public string Descricao { get; set; }

        public int Id_Curso { get; set; } 

        [ForeignKey("Id_Curso")]
        public virtual Curso Curso { get; set; }

        public Disciplina()
        {
            
        }

        public Disciplina(string nome, string descricao, int id_curso)
        {
            Nome = nome;
            Descricao = descricao;
            Id_Curso = id_curso;
        }
    }
}

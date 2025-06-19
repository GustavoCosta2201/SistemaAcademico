using System.ComponentModel.DataAnnotations;

namespace SistemaAcademico.Models
{
    public class Disciplina
    {
        [Key]
        public int Id_Disciplina { get; set; }

        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<CursoDisciplina> CursosDisciplinas { get; set; } = new List<CursoDisciplina>();

        public Disciplina()
        {
        }

        public Disciplina(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }
    }
}

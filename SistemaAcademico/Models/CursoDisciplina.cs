using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAcademico.Models
{
    public class CursoDisciplina
    {
        [Key]
        public int Id { get; set; }

        public int Id_Curso { get; set; }
        public int Id_Disciplina { get; set; }

        [ForeignKey(nameof(Id_Curso))]
        public Curso Curso { get; set; }

        [ForeignKey(nameof(Id_Disciplina))]
        public Disciplina Disciplina { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAcademico.Models
{
    public class Turma
    {
        [Key]
        public int Id_Turma { get; set; }

        public int Id_Disciplina { get; set; } 
        public int Id_Professor { get; set; } 

        [ForeignKey("Id_Disciplina")]
        public virtual Disciplina Disciplina { get; set; } 

        [ForeignKey("Id_Professor")]
        public virtual Professor Professor { get; set; } 

        public int Ano { get; set; } 
        public string Semestre { get; set; }
        public string Turno { get; set; }

        public Turma()
        {
            
        }

        public Turma(int iddisciplina, int idprofessor, int ano, string semestre, string turno)
        {
            Id_Disciplina = iddisciplina;
            Id_Professor = idprofessor;
            Ano = ano;
            Semestre = semestre;
            Turno = turno;
        }
    }
}

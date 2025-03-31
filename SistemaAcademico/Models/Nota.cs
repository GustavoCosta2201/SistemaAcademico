using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAcademico.Models
{
    public class Nota
    {
        [Key]
        public int Id_Nota { get; set; }

        public int Id_Aluno { get; set; } 
        public int Id_Turma { get; set; } 

        [ForeignKey("Id_Aluno")]
        public virtual Aluno Aluno { get; set; } 

        [ForeignKey("Id_Turma")]
        public virtual Turma Turma { get; set; } 

        public float Nota_Final { get; set; }
        public DateTime Data_Avaliacao { get; set; }

        public Nota()
        {
            
        }

        public Nota(int idaluno, int idturma, float nota_final, DateTime DataAvali)
        {
            Id_Aluno = idaluno;
            Id_Turma = idturma;
            Nota_Final = nota_final;
            Data_Avaliacao = DataAvali;
        }
    }
}

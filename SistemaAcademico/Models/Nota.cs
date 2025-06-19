using System;
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

        public double Nota_Final { get; set; }
        public DateTime Data_Avaliacao { get; set; }

        public Nota() { }

        public Nota(int idAluno, int idTurma, double notaFinal, DateTime dataAvaliacao)
        {
            Id_Aluno = idAluno;
            Id_Turma = idTurma;
            Nota_Final = notaFinal;
            Data_Avaliacao = dataAvaliacao;
        }
    }
}

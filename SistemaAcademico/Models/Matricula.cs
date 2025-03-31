using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace SistemaAcademico.Models
{
    public class Matricula
    {
        [Key]
        public int Id_Matricula { get; set; }

        public int Id_Aluno { get; set; } 
        public int Id_Curso { get; set; } 

        [ForeignKey("Id_Aluno")]
        public virtual Aluno Aluno { get; set; } 

        [ForeignKey("Id_Curso")]
        public virtual Curso Curso { get; set; } 

        public DateTime Data_Matricula { get; set; }
        public string Status_Matricula { get; set; }

        public Matricula()
        {
            
        }

        public Matricula(int idaluno, int idcurso, DateTime Data_Matricula, string status)
        {
            Id_Aluno = idaluno;
            Id_Curso = idcurso;
            this.Data_Matricula = Data_Matricula;
            this.Status_Matricula = status;
        }
    }
}

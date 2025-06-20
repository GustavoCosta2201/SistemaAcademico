using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAcademico.Models
{
    public class Frequencia
    {
        [Key]
        public int Id_Frequencia { get; set; }
        public int Id_Matricula { get; set; }
        public DateTime Data_Frequencia { get; set; }
        public bool Presenca { get; set; }

       

        public Frequencia() { }
        public Frequencia(int idMatricula, DateTime data, bool presenca)
        {
            Id_Matricula = idMatricula;
            Data_Frequencia = data;
            Presenca = presenca;
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAcademico.Models
{
    [Table("Financeiro")]
    public class Financeiro
    {
        [Key]
        public int Id_Financeiro { get; set; }

        [Required]
        public int Id_Matricula { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }

        [Required]
        public DateTime Data_Vencimento { get; set; }

        public DateTime? Data_Pagamento { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = string.Empty;
    }
}

namespace SistemaAcademico.Request
{
    public class FinanceiroRequest
    {
        public int Id_Financeiro { get; set; }
        public int Id_Matricula { get; set; }
        public int Id_Aluno { get; set; }
        public int Id_Curso { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data_Vencimento { get; set; }
        public DateTime Data_Pagamento { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}

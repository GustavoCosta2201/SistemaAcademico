namespace SistemaAcademico.Request
{
    public class FinanceiroRequest
    {
        public int Id_Matricula { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data_Vencimento { get; set; }
        public DateTime Data_Pagamento { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}

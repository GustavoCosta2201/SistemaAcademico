public class FinanceiroResponse
{
    public int Id_Financeiro { get; set; }
    public int Id_Matricula { get; set; }
    public decimal Valor { get; set; }
    public DateTime Data_Vencimento { get; set; }
    public DateTime? Data_Pagamento { get; set; }  // <- nullable para aceitar null
    public string Status { get; set; }
}

namespace SistemaAcademico.Request
{
    public class FrequenciaRequest
    {
        public int Id_Matricula { get; set; }
        public DateTime Data_Frequencia { get; set; }
        public bool Presenca { get; set; }
    }
}

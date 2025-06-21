namespace SistemaAcademico.Web2.Response
{
    public class RelatorioTurmaDisciplinaResponse
    {
        public string Disciplina { get; set; } = string.Empty;
        public string Professor { get; set; } = string.Empty;
        public int Ano { get; set; }
        public string Semestre { get; set; } = string.Empty;
        public string Turno { get; set; } = string.Empty;
        public int TotalAlunos { get; set; }
    }
}

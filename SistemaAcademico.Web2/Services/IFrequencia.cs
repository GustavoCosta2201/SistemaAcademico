namespace SistemaAcademico.Web2.Services
{
    public interface IFrequenciaAPI
    {
        Task<List<FrequenciaResponse>> GetFrequenciasAsync();
        Task<List<FrequenciaResponse>> GetFrequenciasPorMatriculaAsync(int idMatricula);
    }
}

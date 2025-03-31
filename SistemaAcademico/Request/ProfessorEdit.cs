namespace SistemaAcademico.Request
{
    public record class ProfessorEdit(string nome, string email, string telefone, string departamento)
        : ProfessorRequest(nome, email, telefone, departamento);
}

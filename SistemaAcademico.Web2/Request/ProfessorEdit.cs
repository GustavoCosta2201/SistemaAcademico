namespace SistemaAcademico.Request
{
    public record class ProfessorEdit(int id_professor,string nome, string email, string telefone, string departamento)
        : ProfessorRequest(nome, email, telefone, departamento);
}

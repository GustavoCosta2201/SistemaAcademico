using Microsoft.EntityFrameworkCore;
using SistemaAcademico.Models;

namespace SistemaAcademico.Data
{
    public class AcademicoContext: DbContext
    {

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Disciplina> Disciplina { get; set; }
        public DbSet<Matricula> Matricula { get; set; }
        public DbSet<Nota> Nota { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Turma> Turma{ get; set; }


        

        private string ConnectionString = "Data Source=GUSTAVOPC;Initial Catalog=ACADEMICO;User ID=sa;Password=masterkey;" +
            "Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString).UseLazyLoadingProxies(true);
        }
    }
}

using api_crud_entity_framework.Estudantes;
using Microsoft.EntityFrameworkCore;

namespace Dados
{
    public class AppDbContext : DbContext
    {
        public DbSet<Estudante> Estudantes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: "Data Source=Banco.sqlite");
            optionsBuilder.LogTo(System.Console.WriteLine, LogLevel.Information);
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }

}
using BlazorAppJsonColumns.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BlazorAppJsonColumns.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("Server=.\\SQLExpress;DataBase=Alunos1;Trusted_Connection=True;TrustServerCertificate=true");
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=Aluno1;Trusted_Connection=True;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().OwnsOne(x => x.Details, navigationsBuilder =>
            {
                navigationsBuilder.ToJson();
            });
        }
        public DbSet<Aluno> TblTeste2 { get; set; } = null!;
    }
}

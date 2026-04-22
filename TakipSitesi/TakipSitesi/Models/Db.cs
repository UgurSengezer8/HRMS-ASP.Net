using Microsoft.EntityFrameworkCore;

namespace TakipSitesi.Models
{
    public class Db:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(LocalDb)\\MSSQLLocalDB;database=Takip;integrated security = true;MultipleActiveResultSets=True;");

            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-CRQ95L2\SQLEXPRESS;Database=Emlak;Trusted_Connection=True;TrustServerCertificate=True");
        }
        public DbSet<Calisan> Calisanlar { get; set; }
        public DbSet<Gorev> Gorevler { get; set; }
        public DbSet<Izin> Izinler { get; set; }
        public DbSet<Departman> Departmanlar { get; set; }



    }
}

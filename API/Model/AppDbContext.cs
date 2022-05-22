using Microsoft.EntityFrameworkCore;

namespace API.Model
{
    public class AppDbContext : DbContext
    {

        public DbSet<Productos> tblProductos { get; set; }
        public DbSet<Categorias> tblCategorias { get; set; }
   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration
                .GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}

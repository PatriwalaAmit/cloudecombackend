using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIUsers
{
    public class ApplicationDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-JRR96T5;
                                          Database=eComm;
                                          Trusted_Connection=True;
                                          TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Users> Users { get; set; }
    }
}

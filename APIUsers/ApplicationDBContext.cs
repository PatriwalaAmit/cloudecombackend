using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIUsers
{
    public class ApplicationDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-JRR96T5;
            //                              Database=eComm;
            //                              Trusted_Connection=True;
            //                              TrustServerCertificate=True;");

            optionsBuilder.UseSqlServer(@"Server=192.168.1.47, 1433;
                                          Database=eComm;
                                          User Id=sa;
                                          Password=Password1!;
                                          TrustServerCertificate=true;                                         
                                          MultipleActiveResultSets=true");

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Users> Users { get; set; }
    }
}

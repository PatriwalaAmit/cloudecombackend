using Microsoft.EntityFrameworkCore;
using VirtualMeetingAdmin.Entities;

namespace VirtualMeetingAdmin.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
               : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().ToTable("VM_Users");
            base.OnModelCreating(modelBuilder);
        }
    }
}

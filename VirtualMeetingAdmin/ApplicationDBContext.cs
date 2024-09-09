using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace VirtualMeetingAdmin
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
                   : base(options)
        {
        }
    }
}

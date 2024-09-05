
using Domain.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base()
        {
            Database.EnsureCreated();
        }

        public DbSet<Log> Logs { get; set; }    

    }
}

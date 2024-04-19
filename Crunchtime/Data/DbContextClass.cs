using Microsoft.EntityFrameworkCore;
using Crunchtime.Entities;

namespace Crunchtime.Data
{
    public class DbContextClass: DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options)
        { }
        public DbSet<User> User { get; set; }
    }
}

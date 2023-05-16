using BCSC.Entities;
using Microsoft.EntityFrameworkCore;

namespace BCSC.Data
{
    public class DataBaseBContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"");
            base.OnConfiguring(optionsBuilder);
        }
    }
}

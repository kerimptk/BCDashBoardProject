using BCSC.Entities;
using Microsoft.EntityFrameworkCore;

namespace BCDashBoardProject.Models
{
    public class BCSCDBContext : DbContext
    {
        public BCSCDBContext(DbContextOptions<BCSCDBContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
            modelBuilder.Entity<User>().ToTable("user");
        }
    }
}

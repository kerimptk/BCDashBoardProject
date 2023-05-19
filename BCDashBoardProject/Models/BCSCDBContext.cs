 using Microsoft.EntityFrameworkCore;
 
namespace BCDashBoardProject.Models
{
    public class BCSCDBContext : DbContext
    {
        public BCSCDBContext(DbContextOptions<BCSCDBContext> options)
        {
        }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-5HCE79K;Database=BCSCDB;Trusted_Connection=True;Encrypt=False;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
            modelBuilder.Entity<User>().ToTable("user");
        }
    }
}

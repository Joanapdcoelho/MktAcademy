using Microsoft.EntityFrameworkCore;
using MktAcademy.Models;

namespace MktAcademy.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1, Name="Marketing", DisplayOrder = 1},
                new Category { Id = 2, Name = "Digital Marketing", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Legislation", DisplayOrder = 3 }
                
                );
        }

    }
}

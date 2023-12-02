using Microsoft.EntityFrameworkCore;
using MktAcademy.Models;
using MktAcademy.DataAccess.Data;


namespace MktAcademy.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1, Name="Marketing", DisplayOrder = 1},
                new Category { Id = 2, Name = "Digital Marketing", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Legislation", DisplayOrder = 3 }
                
                );

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "Marketing", Description = "Marketing course 25h", ListPrice = 540, Price20 = 432, Remarks = "" },
                new Course { Id = 2, Name = "Digital Marketing", Description = "Marketing course 25h", ListPrice = 540, Price20 = 432, Remarks = ""},
                new Course { Id = 3, Name = "E-mail Marketing", Description = "Marketing course 25h", ListPrice = 540, Price20 = 432, Remarks = ""},
                new Course { Id = 4, Name = "Social Media Marketing", Description = "Marketing course 25h", ListPrice = 540, Price20 = 432, Remarks = ""},
                new Course { Id = 5, Name = "Legislation 2.0", Description = "Marketing course 25h", ListPrice = 540, Price20 = 432, Remarks = ""}
                );
        }

    }
}

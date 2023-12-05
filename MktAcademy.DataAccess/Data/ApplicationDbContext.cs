using Microsoft.EntityFrameworkCore;
using MktAcademy.Models;
using MktAcademy.DataAccess.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace MktAcademy.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>()
            .HasOne(c => c.Category)
            .WithMany()
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.Restrict); // Define o comportamento de exclusão para "Restrict"

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Marketing"},
                new Category { Id = 2, Name = "Digital Marketing"},
                new Category { Id = 3, Name = "Legislation"}

                );

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "Marketing", Description = "Marketing course 25h", ListPrice = 540, Price20 = 432, Remarks = "", CategoryId = 1, ImageUrl = "" },
                new Course { Id = 2, Name = "Digital Marketing", Description = "Marketing course 25h", ListPrice = 540, Price20 = 432, Remarks = "", CategoryId = 2, ImageUrl = "" },
                new Course { Id = 3, Name = "E-mail Marketing", Description = "Marketing course 25h", ListPrice = 540, Price20 = 432, Remarks = "", CategoryId = 3, ImageUrl = "" },
                new Course { Id = 4, Name = "Social Media Marketing", Description = "Marketing course 25h", ListPrice = 540, Price20 = 432, Remarks = "", CategoryId = 1, ImageUrl = "" },
                new Course { Id = 5, Name = "Legislation 2.0", Description = "Marketing course 25h", ListPrice = 540, Price20 = 432, Remarks = "", CategoryId = 2, ImageUrl = "" }
                );

            
        }

    }
}

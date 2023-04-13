using Microsoft.EntityFrameworkCore;
using SchoolApp.Models;

namespace SchoolApp.Data
{
    public class AppDbContext : DbContext 
    {
        //Define a public constructor for the AppDbContext and parse to the base class using the Base keyword.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        //Table definition using EFcore for each model
        public DbSet<Student> Students { get; set; }
        public DbSet<ClassRoom> Classrooms { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}

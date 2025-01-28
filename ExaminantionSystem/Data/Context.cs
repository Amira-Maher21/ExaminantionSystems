 using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace ExaminantionSystem.Data
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {
 
        }


        public Context() 
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<AuthorizeRole> AuthorizeRoles { get; set; }
        public DbSet<RoleFeature> RoleFeatures { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Student> students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-2I0OH7I\\SQLEXPRESS;Initial Catalog=ExaminantionSystem; User Id=sa;Password=123;TrustServerCertificate=true")
                .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
                .EnableSensitiveDataLogging();
         }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<Instructor>().ToTable("Instructor", schema: "HR");
        }

        public override int SaveChanges()
        {


            return base.SaveChanges();
        }

        public override DbSet<T> Set<T>()
        {
            return base.Set<T>();
        }

    }
}

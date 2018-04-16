using DataBase.Models;
using System.Data.Entity;

namespace DataBase
{
    public class UniversityContext : DbContext
    {
        public UniversityContext() : base("UniversityContext")
        {
        }

        public UniversityContext(string connectionString) : base (connectionString)
        {
            Database.SetInitializer<UniversityContext>(new UniversityInitializer<UniversityContext>());
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

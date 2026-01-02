using Microsoft.EntityFrameworkCore;
using WebApplication1.DbEntities;

namespace WebApplication1.Data
{
    public class SchoolDbContext : DbContext
    {
        // Define the tables in your database
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer($"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SodiqSchoolDb;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
    }
}

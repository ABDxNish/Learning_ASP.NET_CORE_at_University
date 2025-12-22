using CrudOpCF.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudOpCF.EF
{
    public class UMSContext:DbContext
    {
        public UMSContext() { }
        public UMSContext(DbContextOptions<UMSContext> options):base(options) 
        {
        }
        public DbSet<Student>Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}

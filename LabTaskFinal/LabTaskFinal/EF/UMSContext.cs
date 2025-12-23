using LabTaskFinal.EF.Table;
using Microsoft.EntityFrameworkCore;

namespace LabTaskFinal.EF
{
    public class UMSContext:DbContext
    {
        public UMSContext() { }
        public UMSContext(DbContextOptions<UMSContext> options) : base(options)
        {
        }
        public DbSet <Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}

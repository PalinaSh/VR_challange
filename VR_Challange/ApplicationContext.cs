using Microsoft.EntityFrameworkCore;
using VR_Challange.Models;

namespace VR_Challange
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Box> Boxes => Set<Box>();


        public ApplicationContext() => Database.EnsureCreated();


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=VR_Challange.db");
        }
    }
}

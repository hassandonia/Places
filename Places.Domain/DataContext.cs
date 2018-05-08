using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Places.Domain
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
                
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        //}

        public DbSet<Category> Categories { get; set; }

        public DbSet<Place> Places { get; set; }
    }
}

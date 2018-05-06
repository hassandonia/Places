using System.Data.Entity;

namespace Places.Domain
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
                
        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Place> Places { get; set; }
    }
}

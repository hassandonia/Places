namespace Places.Backend.Models
{
    using Domain;
    public class DataContextLocal : DataContext
    {
        public System.Data.Entity.DbSet<Places.Domain.Customer> Customers { get; set; }
    }
}
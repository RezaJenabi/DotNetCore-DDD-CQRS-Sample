using Domain.Configuration;
using Domain.Models.CustomerAggregate.Customers;
using Microsoft.EntityFrameworkCore;

namespace Domain.DbContext
{
    public class StoreDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public StoreDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        }
        public DbSet<Customer> Customers { get; set; }
    }
}

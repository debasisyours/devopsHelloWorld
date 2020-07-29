using AzureDevOps.Domain.Configurations;
using AzureDevOps.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AzureDevOps.Domain
{
    public class ApiContext:DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration<Customer>(new CustomerMap());
        }

        public DbSet<Customer> Customers { get; set; }
    }
}

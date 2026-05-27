using Microsoft.EntityFrameworkCore;
using PaymentGateway.API.Models;

namespace PaymentGateway.API.Data
{
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
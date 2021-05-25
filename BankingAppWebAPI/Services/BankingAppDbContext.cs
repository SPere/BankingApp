using BankingAppWebAPI.DBModels;
using Microsoft.EntityFrameworkCore;

namespace BankingAppWebAPI.Services
{
    public class BankingAppDbContext : DbContext
    {
        public BankingAppDbContext()
        {
        }

        public BankingAppDbContext(DbContextOptions options): base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Currency> Currencies { get; set; }

        public virtual DbSet<Balance> Balances { get; set; }
    }

}

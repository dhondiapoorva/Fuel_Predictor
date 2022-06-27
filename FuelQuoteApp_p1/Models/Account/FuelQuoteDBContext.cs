using FuelQuoteApp_p1.Models.Client_Profile;
using FuelQuoteApp_p1.Models.Quote;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FuelQuoteApp_p1.Models.Account
{
    public class FuelQuoteDBContext : IdentityDbContext
    {
        public FuelQuoteDBContext(DbContextOptions<FuelQuoteDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Profile> Client { get; set; }

        public DbSet<Login> UsersInfo { get; set; }

        public DbSet<FQuote> FuelQuote { get; set; }

    }
}
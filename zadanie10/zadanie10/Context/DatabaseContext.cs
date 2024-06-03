using Microsoft.EntityFrameworkCore;
using zadanie10.Models;

namespace zadanie10.Context;

public class DatabaseContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Product> Products { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        /*modelBuilder.Entity<Account>().HasData(new List<Account>
        {
            new Account
            {
                
            }
        });
        
        modelBuilder.Entity<Product>().HasData(new List<Product>
        {
            new Product
            {
                
            }
        });*/
    }
}
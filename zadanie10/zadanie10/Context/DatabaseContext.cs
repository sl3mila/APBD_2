using Microsoft.EntityFrameworkCore;
using zadanie10.Models;

namespace zadanie10.Context;

public class DatabaseContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
}
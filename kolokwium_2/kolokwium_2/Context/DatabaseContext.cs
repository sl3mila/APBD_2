using Microsoft.EntityFrameworkCore;

namespace kolokwium_2.Context;

public class DatabaseContext : DbContext
{
    //public DbSet<Klasa tabeli> klasa { get; set; }

    protected DatabaseContext()
    {
        
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
        
    }
    
}
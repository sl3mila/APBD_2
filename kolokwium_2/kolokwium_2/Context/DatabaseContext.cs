using kolokwium_2.Models;
using Microsoft.EntityFrameworkCore;

namespace kolokwium_2.Context;

public class DatabaseContext : DbContext
{
    //public DbSet<Klasa tabeli> klasa { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<BackpackSlot> BackpackSlots { get; set; }
    public DbSet<Title> Titles { get; set; }

    public DbSet<Item> Items { get; set; }
    protected DatabaseContext()
    {
        
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Character>().HasData(new List<Character>
        {
            new Character()
            {
                
            }
        });
        
        modelBuilder.Entity<BackpackSlot>().HasData(new List<BackpackSlot>
        {
            new BackpackSlot()
            {
                
            }
        });
        
        modelBuilder.Entity<Item>().HasData(new List<Item>
        {
            new Item()
            {
                
            }
        });
        
        /*modelBuilder.Entity<Product>().HasData(new List<Product>
        {
            new Product
            {
                
            }
        });*/
    }
}
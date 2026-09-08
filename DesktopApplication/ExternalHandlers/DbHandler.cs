using DesktopApplication.Dto;
using Microsoft.EntityFrameworkCore;

namespace DesktopApplication.ExternalHandlers;

public sealed class DbHandler : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Item> Inventory { get; set; }
    public DbSet<Sale> Sales { get; set; }

    public DbHandler()
    {
        this.Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=store.db");
    }
}

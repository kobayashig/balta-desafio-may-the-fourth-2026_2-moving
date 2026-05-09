using Microsoft.EntityFrameworkCore;
using Moving.Core.Models;

namespace Moving.Infra.Context;

public class SqliteContext(DbContextOptions<SqliteContext> options) : DbContext(options)
{
    public DbSet<Item> Items { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>()
                    .HasIndex(u => u.Name)
                    .IsUnique();
    }
}
using BreakfastGyG.Models;
using Microsoft.EntityFrameworkCore;

namespace BreakfastGyG.Persistence;

public class BreakfastGyGDbContext : DbContext
{
    public BreakfastGyGDbContext(DbContextOptions<BreakfastGyGDbContext> options)
        : base(options)
    {
    }

    public DbSet<Breakfast> Breakfasts { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BreakfastGyGDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
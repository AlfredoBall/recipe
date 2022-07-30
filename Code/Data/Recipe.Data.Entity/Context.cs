using Microsoft.EntityFrameworkCore;
using Recipe.Data.Entity.Configuration;

namespace Recipe.Data.Entity;

public class Context : DbContext
{
    public Context() : base() {}
    public Context(DbContextOptions<Context> options) : base(options) {}

    public DbSet<Test> Test { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TestConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer();
    }
}
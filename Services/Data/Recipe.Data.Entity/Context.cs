using Microsoft.EntityFrameworkCore;
using Recipe.Data.Entity;
using Recipe.Data.Entity.Configuration;
using Finbuckle.MultiTenant;
using Finbuckle.MultiTenant.Core;

namespace Recipe.Data;

public class Context : DbContext
{
    public Context() : base() {}
    public Context(DbContextOptions<Context> options, TenantInfo tenantInfo) : base(options) {}

    public DbSet<Recipe.Data.Entity.Recipe> Recipes { get; set; }
    public DbSet<Instruction> Instructions { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<PlanItem> Planning { get; set; }

    private Finbuckle.MultiTenant.ITenantInfo TenantInfo { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RecipeConfiguration());
        modelBuilder.ApplyConfiguration(new PlanItemConfiguration());
        modelBuilder.ApplyConfiguration(new InstructionConfiguration());
        modelBuilder.ApplyConfiguration(new IngredientConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(TenantInfo.ConnectionString);
    }
}
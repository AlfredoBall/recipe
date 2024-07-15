using Microsoft.EntityFrameworkCore;
using Recipe.Data.Entity;
using Recipe.Data.Entity.Configuration;
using Finbuckle.MultiTenant;

namespace Recipe.Data.Entity;

public class Context : DbContext
{
    public Context() : base() {}

    // public Context(DbContextOptions<Context> options) : base(options) {}
    //public Context(DbContextOptions<Context> options) : base(options)
    //{
    //    Console.WriteLine("test");
    //}

    public Context(ITenantInfo tenantInfo) : base()
    {
        TenantInfo = tenantInfo;
    }

    public ITenantInfo? TenantInfo { get; }

    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Instruction> Instructions { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<PlanItem> Planning { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RecipeConfiguration());
        modelBuilder.ApplyConfiguration(new PlanItemConfiguration());
        modelBuilder.ApplyConfiguration(new InstructionConfiguration());
        modelBuilder.ApplyConfiguration(new IngredientConfiguration());
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseSqlServer();
    // }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(TenantInfo?.ConnectionString);
    }
}
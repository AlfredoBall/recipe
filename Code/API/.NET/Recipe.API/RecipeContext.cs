using Microsoft.EntityFrameworkCore;
using Recipe.Data;


namespace Recipe.API.Data
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options) : base(options)
        {
        }

        public DbSet<Test> Tests { get; set; }
        // public DbSet<Instruction> Instructions { get; set; }
        // public DbSet<Ingredient> Ingredients { get; set; }
        // public DbSet<PlanItem> Planning { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>().
                ToTable("Test");

            // modelBuilder.Entity<Instruction>().
            //     ToTable("Instruction");

            // modelBuilder.Entity<Ingredient>().
            //     ToTable("Ingredient");

            // modelBuilder.Entity<PlanItem>().
            //     ToTable("Planning").
            //     HasIndex(pi => pi.Text).
            //     IsUnique(true);
            
            // modelBuilder.Entity<Recipe>().HasMany<Instruction>(recipe => recipe.Instructions);
            // modelBuilder.Entity<Recipe>().HasMany<Ingredient>(recipe => recipe.Ingredients);
        }
    }
}
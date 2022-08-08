using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Recipe.Data.Entity;

namespace Recipe.Data.Entity.Configuration;

internal class RecipeConfiguration  : IEntityTypeConfiguration<Recipe>
{
    private const string TableName = "Recipe";
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.ToTable(TableName);

        builder.HasMany<Instruction>(recipe => recipe.Instructions);
        builder.HasMany<Ingredient>(recipe => recipe.Ingredients);
    }
}
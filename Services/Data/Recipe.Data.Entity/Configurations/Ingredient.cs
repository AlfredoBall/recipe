using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Recipe.Data.Entity;

namespace Recipe.Data.Entity.Configuration;

internal class IngredientConfiguration  : IEntityTypeConfiguration<Ingredient>
{
    private const string TableName = "Ingredient";
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.ToTable(TableName);
    }
}
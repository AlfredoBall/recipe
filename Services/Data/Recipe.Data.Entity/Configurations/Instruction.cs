using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Recipe.Data.Entity;

namespace Recipe.Data.Entity.Configuration;

internal class InstructionConfiguration  : IEntityTypeConfiguration<Instruction>
{
    private const string TableName = "Instruction";
    public void Configure(EntityTypeBuilder<Instruction> builder)
    {
        builder
            .ToTable(TableName);
        
        builder.Property<int>("RecipeID").HasColumnName("Recipe_ID");

        builder.HasIndex(c => c.Order);
    }
}
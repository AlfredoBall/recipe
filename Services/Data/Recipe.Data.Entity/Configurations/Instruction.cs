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
            .ToTable(TableName)
            .HasIndex(c => c.Order);
    }
}
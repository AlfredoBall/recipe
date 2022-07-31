using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Recipe.Data.Entity;

namespace Recipe.Data.Entity.Configuration;

internal class PlanItemConfiguration  : IEntityTypeConfiguration<PlanItem>
{
    private const string TableName = "PlanItem";
    public void Configure(EntityTypeBuilder<PlanItem> builder)
    {
        builder.ToTable(TableName);
        builder.HasIndex(pi => pi.Text).
                IsUnique(true);
    }
}
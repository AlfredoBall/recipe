using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Recipe.Data.Entity;

namespace Recipe.Data.Entity.Configuration;

internal class TestConfiguration  : IEntityTypeConfiguration<Test>
{
    private const string TableName = "Test";
    public void Configure(EntityTypeBuilder<Test> builder)
    {
        builder.ToTable(TableName);
        builder.HasKey(x => x.ID);
        builder.Property(x => x.ID)
            .HasColumnName("Test_ID")
            .HasColumnType("int")
            .IsRequired();
        builder.HasIndex(x => x.ID)
            .HasName("Test_ID")
            .IsUnique();
        builder.Property(x => x.Name)
            .HasColumnName("Name");

        // Seed Data
        // builder.HasData(new {});
    }
}
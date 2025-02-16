using ASUniversity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASUniversity.Persistence.Configuration
{
    internal class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
    {
        public void Configure(EntityTypeBuilder<Faculty> builder)
        {
            builder
                .Property(f => f.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");
            builder
                .HasIndex(f => f.Name)
                .IsUnique();
        }
    }
}

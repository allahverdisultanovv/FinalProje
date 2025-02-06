using ASUniversity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASUniversity.Persistence.Configuration
{
    internal class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder
                .Property(s => s.Credits)
                .IsRequired()
                .HasColumnType("integer");
            builder
                .Property(s => s.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");
        }
    }
}

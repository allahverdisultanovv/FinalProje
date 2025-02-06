using ASUniversity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASUniversity.Persistence.Configuration
{
    internal class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder
                .Property(t => t.Position)
                .IsRequired();

        }
    }
}

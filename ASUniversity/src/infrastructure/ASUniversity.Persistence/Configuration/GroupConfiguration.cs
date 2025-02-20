using ASUniversity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASUniversity.Persistence.Configuration
{
    internal class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder
                .Property(g => g.Name)
                .IsRequired()
                .HasColumnType("varchar(10)");
            builder
                 .HasOne(g => g.Specialization)
            .WithMany(f => f.Groups)
            .HasForeignKey(g => g.SpecializationId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

using ASUniversity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASUniversity.Persistence.Configuration
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .Property(u => u.Degree)
                .IsRequired();
            builder
                .Property(s => s.AdmissionYear)
                .IsRequired();
            builder
                .HasOne(s => s.Group)
                .WithMany(X => X.Students)
                .HasForeignKey(s => s.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
              .HasOne(s => s.Specialization)
              .WithMany(s => s.Students)
              .HasForeignKey(s => s.SpecializationId)
              .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

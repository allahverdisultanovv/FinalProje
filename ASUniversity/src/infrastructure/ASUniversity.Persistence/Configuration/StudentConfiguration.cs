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
                .IsRequired()
                .HasColumnType("date");
        }
    }
}

using ASUniversity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASUniversity.Persistence.Configuration
{
    internal class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder
                .Property(e => e.Classroom)
                .IsRequired()
                .HasColumnType("char(4)");

            builder
                .Property(e => e.StartTime)
                .HasColumnType("time");
            builder
                .Property(e => e.EndTime)
                .HasColumnType("time");
            builder
                .Property(e => e.Date)
                .HasColumnType("date");
            builder
                .Property(e => e.ExamType)
                .IsRequired();

            builder
               .HasOne(e => e.Subject)
               .WithMany()
               .HasForeignKey(e => e.SubjectId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(e => e.Group)
               .WithMany()
               .HasForeignKey(e => e.GroupId)
               .OnDelete(DeleteBehavior.Restrict);

            //builder
            //   .HasOne(e => e.Teacher)
            //   .WithMany()
            //   .HasForeignKey(e => e.TeacherId)
            //   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

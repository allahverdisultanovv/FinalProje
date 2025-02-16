using ASUniversity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASUniversity.Persistence.Configuration
{
    internal class ExamResultConfiguration : IEntityTypeConfiguration<ExamResult>
    {
        public void Configure(EntityTypeBuilder<ExamResult> builder)
        {
            builder
                .Property(e => e.Grade)
                .IsRequired()
                .HasColumnType("integer");
            builder
                .HasOne(er => er.Exam)
                .WithMany()
                .HasForeignKey(er => er.ExamId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

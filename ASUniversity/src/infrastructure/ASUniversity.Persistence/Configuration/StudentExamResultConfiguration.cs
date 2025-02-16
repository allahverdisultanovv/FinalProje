using ASUniversity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASUniversity.Persistence.Configuration
{
    public class StudentExamResultConfiguration : IEntityTypeConfiguration<StudentExamResults>
    {
        public void Configure(EntityTypeBuilder<StudentExamResults> builder)
        {
            builder
                .HasKey(x => new { x.StudentId, x.ExamResultId });

            //builder.HasKey(x => new { x.ProductId, x.ColorId });
        }
    }
}

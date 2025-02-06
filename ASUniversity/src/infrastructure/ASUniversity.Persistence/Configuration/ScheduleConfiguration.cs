using ASUniversity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASUniversity.Persistence.Configuration
{
    internal class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder
                .Property(s => s.StartTime)
                .IsRequired()
                .HasColumnType("time");
            builder
                .Property(s => s.EndTime)
                .IsRequired()
                .HasColumnType("time");
            builder
                .Property(s => s.DayOfWeek)
                .IsRequired()
                .HasMaxLength(10);
            builder
                .Property(s => s.Classroom)
                .IsRequired()
                .HasColumnType("varchar(4)");
        }
    }
}

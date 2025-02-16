using ASUniversity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASUniversity.Persistence.Configuration
{
    internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {

            builder
                .Property(u => u.Surname)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(u => u.Birthday)
                .IsRequired();
            builder
               .HasOne(u => u.Faculty)
               .WithMany()
               .HasForeignKey(t => t.FacultyId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

using ASUniversity.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace ASUniversity.Domain.Entities
{
    public abstract class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
    }
}

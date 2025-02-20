using Microsoft.AspNetCore.Identity;

namespace ASUniversity.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string FIN { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }

    }
}

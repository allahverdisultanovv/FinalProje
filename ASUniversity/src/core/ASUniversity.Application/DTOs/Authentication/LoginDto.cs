namespace ASUniversity.Application.DTOs.Authentication
{
    public class LoginDto
    {
        public string EmailOrUsernameOrFIN { get; set; }
        public string Password { get; set; }
        public bool IsPersistence { get; set; }


    }
}

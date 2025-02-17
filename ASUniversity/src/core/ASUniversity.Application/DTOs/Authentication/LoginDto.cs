namespace ASUniversity.Application.DTOs.Authentication
{
    public class LoginDto
    {
        public string EmailOrUsername { get; set; }
        public string Password { get; set; }
        public bool IsPersistence { get; set; }
    }
}

using ASUniversity.Application.DTOs.Authentication;

namespace ASUniversity.Application.Abstractions.Services
{
    public interface IAuthenticationService
    {
        Task<bool> Login(LoginDto loginDto);
        Task Register(RegisterDto registerDto, string role);
        Task CreateRole();
    }
}

using ASUniversity.Application.DTOs.Authentication;
using ASUniversity.Domain.Enums;

namespace ASUniversity.Application.Abstractions.Services
{
    public interface IAuthenticationService
    {
        Task Login(LoginDto loginDto);
        Task Register(RegisterDto registerDto, UserRole role);
    }
}

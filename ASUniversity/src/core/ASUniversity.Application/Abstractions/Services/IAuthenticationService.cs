using ASUniversity.Application.DTOs.Authentication;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ASUniversity.Application.Abstractions.Services
{
    public interface IAuthenticationService
    {
        Task<bool> Login(LoginDto loginDto, ModelStateDictionary ModelState);
        Task Register(RegisterDto registerDto, string role);
        Task CreateRole();
    }
}

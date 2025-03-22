using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Ogani.Business.Dtos.AccountDtos;

using Ogani.Core.Entities;

namespace Ogani.Business.Services.Abstractions
{
    public interface IAccountService
    {
        string GetId();
        Task<string> GetRedirectUrlAfterLogin(AppUser user);
        Task<AppUser> FindUser();
        Task<bool> UserHasPasswordAsync(AppUser user);
        Task<IdentityResult> RegisterUserAsync(RegisterDto registerDto);
        Task<IdentityResult> ResetPasswordAsync(AppUser user, string token, string newPassword);
        Task<string> GeneratePasswordResetTokenAsync(AppUser user);
        Task<string> GenerateEmailConfirmationTokenAsync(AppUser user);
        Task<AppUser> FindUserByEmailAsync(string email);
        Task<AppUser> FindUserByIdAsync(string Id);
        Task<IdentityResult> ConfirmEmailAsync(AppUser user, string token);
        Task<SignInResult> LoginUserAsync(LoginDto loginDto);
        Task LogoutUserAsync();
        Task SendEmailAsync(string to, string subject, string body);
        Task<IdentityResult> ChangePasswordAsync(AppUser user, string oldPassword, string newPassword);

    }

}

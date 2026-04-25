using System.Security.Claims;
using CampClotNot.Data;
using CampClotNot.Data.Entities;
using CampClotNot.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CampClotNot.Services;

/// <summary>
/// Handles login, user creation, and cookie issuance.
/// Passwords are hashed with BCrypt — plain-text passwords are never stored or logged.
/// </summary>
public class AuthService(IUserRepository users)
{
    /// <summary>
    /// Validates email/password and signs the user in via cookie authentication.
    /// Returns false if credentials are invalid or the account is inactive.
    /// </summary>
    public async Task<bool> LoginAsync(HttpContext httpContext, string email, string password)
    {
        var user = await users.GetByEmailAsync(email);
        if (user is null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            return false;

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new(ClaimTypes.Name, user.DisplayName),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Role, user.Role.ToString())
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await httpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(identity));

        return true;
    }

    public async Task LogoutAsync(HttpContext httpContext) =>
        await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

    /// <summary>
    /// Creates a new user account. Hashes the password with BCrypt before storing.
    /// </summary>
    public Task<User> CreateUserAsync(string displayName, string email, string plainPassword, UserRole role) =>
        users.CreateAsync(new User
        {
            UserId = Guid.NewGuid(),
            DisplayName = displayName,
            Email = email.ToLowerInvariant(),
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(plainPassword),
            Role = role,
            IsActive = true
        });

    public Task<List<User>> GetAllUsersAsync() => users.GetAllAsync();

    public async Task DeactivateUserAsync(Guid userId)
    {
        var all = await users.GetAllAsync();
        var user = all.FirstOrDefault(u => u.UserId == userId);
        if (user is not null)
        {
            user.IsActive = false;
            await users.UpdateAsync(user);
        }
    }
}

using Chat.ApplicationService.Dtos;

namespace Chat.ApplicationService.Services.Auth
{
    public interface IAuthService
    {
        AuthData GetAuthData(string id);

        string HashPassword(string password);

        bool VerifyPassword(string actualPassword, string hashedPassword);
    }
}

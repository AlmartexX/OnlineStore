using OnlineStore.BLL.DTO.User;

namespace OnlineStore.BLL.Services.Interfaces
{
    public interface IAuthorizationService
    {
        Task<string> LoginAsync(string Email, string Password, CancellationToken cancellationToken);
        Task<UserDto> RegisterUserAsync(RegisterUserDto dto, CancellationToken cancellationToken);

    }
}

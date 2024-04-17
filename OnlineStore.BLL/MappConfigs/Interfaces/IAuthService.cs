using OnlineStore.BLL.DTO.User;

namespace OnlineStore.BLL.MappConfigs.Interfaces
{
    public interface IAuthService
    {
        Task<TokenDto> LoginUserAsync(LoginUserDto dto, CancellationToken cancellationToken);
        Task<UserDto> RegisterUserAsync(RegisterUserDto dto, CancellationToken cancellationToken);
    }
}

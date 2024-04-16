namespace OnlineStore.BLL.Services.Interfaces
{
    public interface IAuthorizationService
    {
        Task<string> LoginAsync(string Email, string Password, CancellationToken cancellationToken);

    }
}

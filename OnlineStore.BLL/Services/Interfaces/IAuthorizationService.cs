namespace OnlineStore.BLL.Services.Interfaces
{
    public interface IAuthorizationService
    {
        Task<string> Login(string Email, string Password, CancellationToken cancellationToken);

    }
}

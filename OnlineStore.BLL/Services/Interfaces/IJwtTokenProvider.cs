namespace OnlineStore.BLL.Services.Interfaces
{
    public interface IJwtTokenProvider
    {
        string GenerateToken(User user);
    }
}

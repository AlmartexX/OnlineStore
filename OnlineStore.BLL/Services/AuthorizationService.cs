using OnlineStore.BLL.Exceptions;
using OnlineStore.BLL.JwtInfrastructure;
using OnlineStore.BLL.Services.Interfaces;
using OnlineStore.DAL.Repositories.UnitOfWork;

namespace OnlineStore.BLL.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtTokenProvider _jwtProvider;

        public AuthorizationService(IUnitOfWork unitOfWork, IJwtTokenProvider jwtProvider)
        {
            _unitOfWork = unitOfWork;
            _jwtProvider = jwtProvider;
        }

        public async Task<string> LoginAsync(string Email, string Password, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.FindByEmailAsync(Email, cancellationToken);
            if (user != null)
            {
                if (PasswordHasher.Verify(user.PasswordHash, PasswordHasher.GetHash((Password))))
                {
                    return _jwtProvider.GenerateToken(user);
                }
                else { throw new UserNotFoundException("Uncorrected password"); }

            }
            else { throw new UserNotFoundException("Uncorrected email or user is not exist"); }
        }
    }
}

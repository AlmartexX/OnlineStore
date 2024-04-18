using AutoMapper;
using OnlineStore.BLL.DTO.User;
using OnlineStore.BLL.Exceptions;
using OnlineStore.BLL.JwtInfrastructure;
using OnlineStore.BLL.Services.Interfaces;
using OnlineStore.DAL.Entities;
using OnlineStore.DAL.Repositories.UnitOfWork;

namespace OnlineStore.BLL.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtTokenProvider _jwtProvider;
        private readonly IMapper _mapper;

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

        public async Task<UserDto> RegisterUserAsync(RegisterUserDto dto, CancellationToken cancellationToken)
        {
            if (dto.Password != dto.ConfirmPassword)
            {
                throw new Exception("Password not confirm");
            }

            try
            {
                var response = await _unitOfWork.Users.FindByEmailAsync(dto.Login, cancellationToken);

                if (response is not null)
                {
                    throw new Exception("User is already exists");
                }

                response = new User()
                {
                    Email = dto.Login,
                    PasswordHash = PasswordHasher.GetHash(dto.Password)
                };

                await _unitOfWork.Users.AddAsync(response, cancellationToken);

                return _mapper.Map<UserDto>(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

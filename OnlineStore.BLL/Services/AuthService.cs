using System.Security.Cryptography;
using AutoMapper;
using OnlineStore.BLL.DTO.User;
using OnlineStore.BLL.MappConfigs.Interfaces;
using OnlineStore.DAL.Entities;
using OnlineStore.DAL.Repositories.UnitOfWork;
using System.Text;

namespace OnlineStore.BLL.Services
{
    public class AuthService: IAuthService
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public AuthService(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<TokenDto> LoginUserAsync(LoginUserDto dto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> RegisterUserAsync(RegisterUserDto dto, CancellationToken cancellationToken)
        {
            if (dto.Password != dto.ConfirmPassword)
            {
                throw new Exception("Password not confirm");
            }

            try
            {
                var response = await _repository.Users.FindByEmailAsync(dto.Login, cancellationToken);

                if (response is not null)
                {
                    throw new Exception("User is already exists");
                }

                response = new User()
                {
                    Email = dto.Login,
                    Password = HashPassword(dto.Password)
                };

                await _repository.Users.AddAsync(response, cancellationToken);

                return _mapper.Map<UserDto>(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        private string HashPassword(string password)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        private bool IsVerifyPassword(string hashPassword, string userPassword)
        {
            var hash = HashPassword(hashPassword);

            return hash == userPassword;
        }
    }
}

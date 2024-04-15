using FluentValidation;
using OnlineStore.BLL.DTO;

namespace OnlineStore.BLL.Vallidation
{
    public class AuthValidator : AbstractValidator<AuthDTO>
    {
        public AuthValidator()
        {
            RuleFor(authDTO => authDTO.Username)
                .NotEmpty()
                .Length(2, 15)
                .WithMessage("Username must be between 2 and 15 characters.");

            RuleFor(authDTO => authDTO.Password)
                .NotEmpty()
                .MinimumLength(8);
        }
    }
}

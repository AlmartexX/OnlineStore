using FluentValidation;
using OnlineStore.BLL.DTO;

namespace OnlineStore.BLL.Vallidation
{
    public class RegisterValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterValidator() 
        {
            RuleFor(registerDTO => registerDTO.Username)
                .NotEmpty()
                .Length(2, 15)
                .WithMessage("Name must be between 2 and 15 characters.");

            RuleFor(registerDTO => registerDTO.Surname)
                .NotEmpty()
                .Length(2, 20)
                .WithMessage("Surname must be between 2 and 20 characters.");

            RuleFor(registerDTO => registerDTO.Birthdate)
                .NotEmpty()
                .Must(date => date != default(DateOnly))
                .Must(date => date <= DateOnly.FromDateTime(DateTime.Now))
                .WithMessage("Birth date can't be in the future.");

            RuleFor(registerDTO => registerDTO.Password)
                .NotEmpty()
                .MinimumLength(8);

            RuleFor(registerDTO => registerDTO.PasswordConfirm)
                .Equal(dto => dto.Password)
                .WithMessage("Passwords don't match!");
        }
    }
}

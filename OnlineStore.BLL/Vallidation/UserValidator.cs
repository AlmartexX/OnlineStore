using FluentValidation;

namespace OnlineStore.BLL.Vallidation
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(user => user.Id)
                .NotEmpty()
                .Must((user, id) => id == user.Id)
                .WithMessage("Id must not be changed!");

            RuleFor(user => user.Username)
                .NotEmpty()
                .Length(2, 15)
                .WithMessage("Name must be between 2 and 15 characters.");

            RuleFor(user => user.Surname)
                .NotEmpty()
                .Length(2, 20)
                .WithMessage("Surname must be between 2 and 20 characters.");

            RuleFor(request => request.Birthdate)
                .NotEmpty()
                .Must(date => date != default(DateOnly))
                .Must(date => date <= DateOnly.FromDateTime(DateTime.Now))
                .WithMessage("Birth date can't be in the future.");
        }
    }
}

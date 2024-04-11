using FluentValidation;

namespace OnlineStore.BLL.Vallidation
{
    public class OrderValidator : AbstractValidator<OrderDTO>
    {
        public OrderValidator()
        {
            RuleFor(user => user.Id)
                .NotEmpty()
                .Must((user, id) => id == user.Id)
                .WithMessage("Id must not be changed!");

            RuleFor(request => request.CreationDate)
                .NotEmpty()
                .Must(date => date != default(DateTime))
                .Must(date => date <= DateTime.Now)
                .WithMessage("Creation date can't be in the future.");

            RuleFor(item => item.UserId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("User id must not be changed!");
        }
    }
}

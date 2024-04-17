using FluentValidation;
using OnlineStore.BLL.DTO;

namespace OnlineStore.BLL.Vallidation
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderDTO>
    {
        public CreateOrderValidator()
        {
            RuleFor(order => order.CreationDate)
                .NotEmpty()
                .Must(date => date != default(DateTime))
                .Must(date => date <= DateTime.Now)
                .WithMessage("Creation date can't be in the future.");

            RuleFor(order => order.UserId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("User id must not be changed!");

            RuleFor(order => order.OrderItems)
                .Must(orderItems => orderItems != null && orderItems.Any())
                .WithMessage("Order must contain at least one item!");
        }
    }
}

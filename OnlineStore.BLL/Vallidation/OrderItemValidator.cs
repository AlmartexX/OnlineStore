using FluentValidation;
using OnlineStore.BLL.DTO;

namespace OnlineStore.BLL.Vallidation
{
    public class OrderItemValidator : AbstractValidator<OrderItemDTO>
    {
        public OrderItemValidator()
        {
            RuleFor(item => item.OrderId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Order id must not be changed!");

            RuleFor(item => item.ProductId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Product id must not be changed!");

            RuleFor(item => item.Count)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Count of product must be greater than zero!");
        }
    }
}

using FluentValidation;
using OnlineStore.BLL.DTO;

namespace OnlineStore.BLL.Vallidation
{
    public class CreateProductValidator : AbstractValidator<CreateProductDTO>
    {
        public CreateProductValidator()
        {
            RuleFor(product => product.Title)
                .NotEmpty()
                .Length(2, 12)
                .WithMessage("Title must be between 2 and 12 characters.");

            RuleFor(product => product.Price)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Product can't be free. Price must be greater than zero.");

            RuleFor(product => product.CategoryId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Category id must not be changed!");
        }
    }
}

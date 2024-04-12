using FluentValidation;
using OnlineStore.BLL.DTO;

namespace OnlineStore.BLL.Vallidation
{
    public class ProductValidator : AbstractValidator<ProductDTO>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Id)
                .NotEmpty()
                .Must((product, id) => id == product.Id)
                .WithMessage("Id must not be changed!");

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

using FluentValidation;
using OnlineStore.BLL.DTO;

namespace OnlineStore.BLL.Vallidation
{
    public class CategoryValidator : AbstractValidator<CategoryDTO>
    {
        public CategoryValidator()
        {
            RuleFor(category => category.Id)
                .NotEmpty()
                .Must((category, id) => id == category.Id)
                .WithMessage("Id must not be changed!");

            RuleFor(category => category.Title)
                .NotEmpty()
                .Length(2, 12)
                .WithMessage("Title must be between 2 and 12 characters.");
        }
    }
}

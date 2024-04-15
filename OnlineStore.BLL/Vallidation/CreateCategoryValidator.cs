using FluentValidation;
using OnlineStore.BLL.DTO;

namespace OnlineStore.BLL.Vallidation
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDTO>
    {
        public CreateCategoryValidator() 
        {
            RuleFor(category => category.Title)
                .NotEmpty()
                .Length(2, 12)
                .WithMessage("Title must be between 2 and 12 characters.");
        }
    }
}

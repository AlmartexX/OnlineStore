using FluentValidation;

namespace OnlineStore.BLL.Vallidation
{
    public class CategoryValidator : AbstractValidator<CategoryDTO>
    {
        public CategoryValidator()
        {
            RuleFor(user => user.Id)
                .NotEmpty()
                .Must((user, id) => id == user.Id)
                .WithMessage("Id must not be changed!");

            RuleFor(user => user.Title)
                .NotEmpty()
                .Length(2, 12)
                .WithMessage("Title must be between 2 and 12 characters.");
        }
    }
}

using FluentValidation;

namespace OnlineStore.BLL.Vallidation
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDTO>
    {
        public CreateCategoryValidator() 
        {
            RuleFor(user => user.Title)
                .NotEmpty()
                .Length(2, 12)
                .WithMessage("Title must be between 2 and 12 characters.");
        }
    }
}

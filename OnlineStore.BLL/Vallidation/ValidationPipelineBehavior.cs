using OnlineStore.BLL.DTO;
using OnlineStore.BLL.Vallidation.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.BLL.Vallidation
{
    public class ValidationPipelineBehavior<TRequest, TResult> : IValidationPipelineBehavior<TRequest, TResult>
    {
        public async Task<TResult> Process(TRequest request, Func<Task<TResult>> next)
        {
            var validator = GetValidator<TRequest>();
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                throw new ValidationException("The entry is incorrect");
            }

            return await next();
        }

        private IValidator<TRequest> GetValidator<TRequest>()
        {
            if (typeof(TRequest) == typeof(CreateCategoryDTO))
            {
                return new CreateCategoryValidator() as IValidator<TRequest>;
            }
            else if (typeof(TRequest) == typeof(CreateProductDTO))
            {
                return new CreateProductValidator() as IValidator<TRequest>;
            }

            throw new InvalidOperationException("No validator found for the given request type.");
        }
    }
}

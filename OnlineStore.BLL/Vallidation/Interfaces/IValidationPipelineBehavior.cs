
using Azure.Core;

namespace OnlineStore.BLL.Vallidation.Interfaces
{
    public interface IValidationPipelineBehavior<TRequest, TResult>
    {
        Task<TResult> Process(TRequest request, Func<Task<TResult>> next);
    }
}

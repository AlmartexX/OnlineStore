using OnlineStore.UI.Middleware;

namespace OnlineStore.UI.Extensions
{
	public static class MiddlewareExtension
	{
		public static IApplicationBuilder UseCustomExceptionHandlerMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<GlobalExceptionHandler>();
		}
	}
}

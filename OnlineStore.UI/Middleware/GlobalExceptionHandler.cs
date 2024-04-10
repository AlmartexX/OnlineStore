using OnlineStore.DAL.Entities.ErrorModel;
using OnlineStore.DAL.Exceptions;
using OnlineStore.BLL.Exceptions;
using System.Net;

namespace OnlineStore.UI.Middleware
{
	public class GlobalExceptionHandler
	{
		private readonly RequestDelegate _next;

		public GlobalExceptionHandler(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception exception)
			{
				await HandleExceptionAsync(context, exception);
			}
		}

		private async Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			context.Response.ContentType = "application/json";

			string message;
			switch (exception)
			{
				case EntityAlreadyExistsException:
					context.Response.StatusCode = (int)HttpStatusCode.Conflict;
					message = "Entity is already exists";
					break;
				case DatabaseNotFoundException:
					context.Response.StatusCode = (int)HttpStatusCode.NotFound;
					message = "Object not found";
					break;
				case UserUnauthorizedException:
					context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
					message = "Unauthorized";
					break;
				case UserNotFoundException:
					context.Response.StatusCode = (int)HttpStatusCode.NotFound;
					message = "User not found";
					break;
				default:
					context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
					message = "Internal server error";
					break;
			}

			await context.Response.WriteAsync(new ErrorDetails()
			{
				StatusCode = context.Response.StatusCode,
				Message = message
			}.ToString()); ;
		}
	}
}


using Microsoft.AspNetCore.Mvc;
using OnlineStore.BLL.Services.Interfaces;

namespace OnlineStore.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }
        [HttpPost]
        public async Task<IResult> Login(string login, string password, CancellationToken cancellationToken)
        {
            var token = await _authorizationService.LoginAsync(login, password, cancellationToken);
            return Results.Ok(token);
        }
    }
}

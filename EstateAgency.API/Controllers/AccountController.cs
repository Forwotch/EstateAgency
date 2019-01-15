using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstateAgency.API.Models.Authentication;
using Microsoft.AspNetCore.Mvc;
using EstateAgency.Authentification.Services;

namespace EstateAgency.API.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAuthentificationService _authentificationService;

        public AccountController(IAuthentificationService authentificationService)
        {
            _authentificationService = authentificationService;
        }

        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn([FromBody] UserLoginModel model)
        {
            var logInSuccess = await _authentificationService.LogIn(model.Email, model.Password);
            if (!logInSuccess)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost("LogOff")]
        public async Task<IActionResult> LogOff()
        {
            await _authentificationService.LogOut();
            return Ok();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterModel model)
        {
            var identityErrors =
                await _authentificationService.Register(model.Email, model.Password, model.PasswordConfirm, model.Role);
            if (identityErrors.Count() != 0)
            {
                return BadRequest(identityErrors);
            }
            return Ok();
        }
    }
}
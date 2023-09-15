using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_INTEGRADOR.DTOs;
using TP_INTEGRADOR.Helpers;
using TP_INTEGRADOR.Services;

namespace TP_INTEGRADOR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private JWT_TokenHelper _token;
        private readonly IUnitOfWork _unitOfWork;

        public LoginController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _token = new JWT_TokenHelper(configuration);
        }


        [HttpPost]
        public async Task<IActionResult> Login(AuthenticateDTO userToAuthenticate)
        {
            var userCredentials = await _unitOfWork.UserRepository.AuthenticateCredentials(userToAuthenticate);

            if (userCredentials is null) return Unauthorized("Incorrect combination of credentials.");

            var token = _token.GenerateToken(userCredentials);

            var userAuthenticated = new LoginDTO
            {
                UserName = userCredentials.Name,
                UserDNI = userCredentials.DNI,
                UserToken = token
            };

            return Ok(userAuthenticated);
        }
    }
}

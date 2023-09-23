using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_INTEGRADOR.DTOs;
using TP_INTEGRADOR.Entities;
using TP_INTEGRADOR.Helpers;
using TP_INTEGRADOR.Infrastructure;
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


        /// <summary>
        /// Brings access to the rest of the routes depending on the written credentials.
        /// </summary>
        /// <param name="userToAuthenticate">ID and Password to validate.</param>
        /// <returns>The valid token for the user to use and access the rest of the routes.</returns>
        [HttpPost]
        public async Task<ActionResult> Login(AuthenticateDTO userToAuthenticate)
        {
            try
            {
                var userCredentials = await _unitOfWork.UserRepository.AuthenticateCredentials(userToAuthenticate);

                if (userCredentials is ObjectResult error) return error;

                var userCredentials2 = (User)userCredentials;
                var token = _token.GenerateToken(userCredentials2);

                var userAuthenticated = new LoginDTO
                {
                    UserName = userCredentials2.Name,
                    UserDNI = userCredentials2.DNI,
                    UserRole = userCredentials2.UserRole,
                    UserToken = token
                };

                return ResponseFactory.CreateSuccessResponse(200, userAuthenticated);
            }

            catch (Exception)
            {
                return ResponseFactory.CreateErrorResponse(500, "An unknown error has occured.");
            }
        }
    }
}

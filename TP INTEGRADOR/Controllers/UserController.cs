using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using TP_INTEGRADOR.Entities;
using TP_INTEGRADOR.Services;

namespace TP_INTEGRADOR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        [Route("/getAllUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            return await _unitOfWork.UserRepository.GetAll();
        }

        [HttpGet]
        [Route("/getUser")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            return await _unitOfWork.UserRepository.GetById(id);
        }

        [HttpPost]
        [Route("/addUser")]
        public IActionResult AddUser()
        {
            try
            {
                return Ok("Usuario creado.");
            }
            catch
            {
                return BadRequest("No se pudo realizar la peticion.");
            }
        }

        [HttpDelete]
        [Route("/deleteUser")]
        public IActionResult DeleteUser()
        {
            try
            {
                return Ok("Usuario eliminado.");
            }
            catch
            {
                return BadRequest("No se pudo realizar la peticion.");
            }
        }

        [HttpPut]
        [Route("/updateUser")]
        public IActionResult UpdateUser()
        {
            try
            {
                return Ok("Usuario modificado.");
            }
            catch
            {
                return BadRequest("No se pudo realizar la peticion.");
            }
        }
    }
}

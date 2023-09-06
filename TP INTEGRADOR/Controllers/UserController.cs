using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TP_INTEGRADOR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("/getAllUsers")]
        public IActionResult GetAllUsers()
        {
            try
            {
                return Ok("Usuarios obtenidos");
            }
            catch
            {
                return BadRequest("No se pudo realizar la peticion.");
            }
        }

        [HttpGet]
        [Route("/getUser")]
        public IActionResult GetUserById()
        {
            try
            {
                return Ok("Usuario obtenido");
            }
            catch
            {
                return BadRequest("No se pudo realizar la peticion.");
            }
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

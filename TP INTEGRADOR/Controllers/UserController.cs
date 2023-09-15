using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using TP_INTEGRADOR.DTOs;
using TP_INTEGRADOR.Entities;
using TP_INTEGRADOR.Services;

namespace TP_INTEGRADOR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        public async Task<ActionResult> AddUser(UserDTO userToAdd)
        {
            User user = new User
            {
                Name = userToAdd.Name,
                DNI = userToAdd.DNI,
                UserRole = userToAdd.UserRole,
                Password = userToAdd.Password
            };

            bool status = await _unitOfWork.UserRepository.Insert(user);

            if (status)
            {
                await _unitOfWork.Save();
                return Ok("User successfully created");
            }

            return BadRequest("Ooops!. Something went wrong. User not created.");
        }

        [HttpPut]
        [Route("/deleteUser")] //Al ser borrado logico deja de ser 'httpDelete' para ser un 'httpPut'.
        public async Task<ActionResult> DeleteUser(int id)
        {
            bool status = await _unitOfWork.UserRepository.Delete(id);

            if (status)
            {
                await _unitOfWork.Save();
                return Ok("User successfully deleted.");
            }

            return BadRequest("Ooops! Something went wrong. User not deleted");
        }

        [HttpPut]
        [Route("/updateUser")] 
        public async Task<ActionResult> UpdateUser(UserDTO userToUpdate, int id)
        {
            User user = new User
            {
                Name = userToUpdate.Name,
                DNI = userToUpdate.DNI,
                Password = userToUpdate.Password,
                UserRole = userToUpdate.UserRole,
            };

            bool status = await _unitOfWork.UserRepository.Update(user, id);

            if (status)
            {
                await _unitOfWork.Save();
                return Ok("User successfully updated.");
            }

            return BadRequest("Ooops! Something went wrong. User not updated");
        }
    }
}

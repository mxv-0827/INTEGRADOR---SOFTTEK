using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using TP_INTEGRADOR.DTOs.UserDTOs;
using TP_INTEGRADOR.Entities;
using TP_INTEGRADOR.Helpers;
using TP_INTEGRADOR.Infrastructure;
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


        /// <summary>
        /// Obtains all users from DB paginated based on the given number of 'itemsPerPage'.
        /// </summary>
        /// <param name="itemsPerPage"></param>
        /// <returns>Every user whether is activated or not.</returns>
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers(int? itemsPerPage)
        {
            try
            {
                var usersList = await _unitOfWork.UserRepository.GetAll();
                int pageToShow = 1;

                if (usersList.Any()) 
                {
                    var usersDTOList = new List<UserGetDTO>();

                    foreach (var us in usersList)
                    {
                        usersDTOList.Add(new UserGetDTO 
                        {
                            ID = us.CodUser,
                            Name = us.Name,
                            DNI = us.DNI,
                            UserRole = us.UserRole,
                            LeavingDate = us.LeavingDate
                        });
                    }

                    if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);
                    if (Request.Query.ContainsKey("itemsPerPage") && int.TryParse(Request.Query["itemsPerPage"], out var parsedItemsPerPage)) itemsPerPage = parsedItemsPerPage;
                    
                    var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
                    var paginatedUsers = Pagination_Helper.Paginate(usersDTOList, itemsPerPage, pageToShow, url);

                    return ResponseFactory.CreateSuccessResponse(200, paginatedUsers);
                } 

                return ResponseFactory.CreateErrorResponse(404, "Users table is empty.");
            }

            catch (Exception)
            {
                return ResponseFactory.CreateErrorResponse(500, "Server error.");
            }
        }


        /// <summary>
        /// Obtains the user based on the given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The user that matched with the ID.</returns>
        [HttpGet("GetUser/{id}")]
        public async Task<ActionResult<User>> GetUserById([FromRoute] int id)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.GetById(id);
                
                if (user != null) return ResponseFactory.CreateSuccessResponse(200, new UserGetDTO { ID = user.CodUser, Name = user.Name, DNI = user.DNI, UserRole = user.UserRole, LeavingDate = user.LeavingDate});
                
                return ResponseFactory.CreateErrorResponse(404, "ID not found.");
            }

            catch (Exception)
            {
                return ResponseFactory.CreateErrorResponse(500, "Server error.");
            }
        }


        /// <summary>
        /// Adds a new user to DB.
        /// </summary>
        /// <param name="userToAdd">The user to add.</param>
        /// <returns>A message notifying if the process was successful or not.</returns>
        [HttpPost("AddUser")]
        [Authorize(Policy = "Administrator")]
        public async Task<ActionResult> AddUser(UserAddDTO userToAdd)
        {
            User user = new User
            {
                Name = userToAdd.Name,
                DNI = userToAdd.DNI,
                UserRole = userToAdd.UserRole,
                Password = PasswordEncrypter_Helper.EncryptPassword(userToAdd.Password, userToAdd.DNI)
            };

            try
            {
                bool status = await _unitOfWork.UserRepository.Insert(user);

                if (status)
                {
                    await _unitOfWork.Save();
                    return ResponseFactory.CreateSuccessResponse(201, "User successfully added to DB.");
                }

                return ResponseFactory.CreateErrorResponse(404, "User not added to DB");
            }

            catch (Exception)
            {
                return ResponseFactory.CreateSuccessResponse(500, "Server error.");
            }
        }


        /// <summary>
        /// Modifies a user based on the given ID.
        /// </summary>
        /// <param name="userToUpdate">The user's new features.</param>
        /// <param name="id"></param>
        /// <returns>A message notifying if the process was successful or not.</returns>
        [HttpPut("UpdateUser/{id}")]
        [Authorize(Policy = "Administrator")]
        public async Task<ActionResult> UpdateUser(UserUpdateDTO userToUpdate, [FromRoute] int id)
        {
            User user = new User
            {
                Name = userToUpdate.Name,
                Password = userToUpdate.Password,
                UserRole = userToUpdate.UserRole,
                LeavingDate = userToUpdate.LeavingDate
            };

            try
            {
                bool status = await _unitOfWork.UserRepository.Update(user, id);

                if (status)
                {
                    await _unitOfWork.Save();
                    return ResponseFactory.CreateSuccessResponse(200, "User successfully updated.");
                }

                return ResponseFactory.CreateErrorResponse(404, "User not updated.");
            }

            catch (Exception)
            {
                return ResponseFactory.CreateSuccessResponse(500, "Server error.");
            }
        }


        /// <summary>
        /// Deactivates a user based on the given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A message notifying if the process was successful or not.</returns>
        [HttpPut("DeleteUser/{id}")] //Al ser borrado logico deja de ser 'httpDelete' para ser un 'httpPut'.
        [Authorize(Policy = "Administrator")]
        public async Task<ActionResult> DeleteUser([FromRoute] int id)
        {
            try
            {
                bool status = await _unitOfWork.UserRepository.Delete(id);

                if (status)
                {
                    await _unitOfWork.Save();
                    return ResponseFactory.CreateSuccessResponse(200, "User successfully deleted from DB.");
                }

                return ResponseFactory.CreateErrorResponse(404, "Id not found.");
            }

            catch (Exception)
            {
                return ResponseFactory.CreateErrorResponse(500, "Server error.");
            }
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_INTEGRADOR.DTOs.ProjectDTOs;
using TP_INTEGRADOR.DTOs.ServiceDTOs;
using TP_INTEGRADOR.Entities;
using TP_INTEGRADOR.Infrastructure;
using TP_INTEGRADOR.Services;

namespace TP_INTEGRADOR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ServiceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public ServiceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// Obtains all services from DB.
        /// </summary>
        /// <returns>All services whether they have been deactivated or not.</returns>
        [HttpGet("GetAllServices")]
        public async Task<ActionResult<IEnumerable<Service>>> GetAllServices()
        {
            try
            {
                var serviceList = await _unitOfWork.ServiceRepository.GetAll();

                if (serviceList.Any())
                {
                    var serviceDTOList = new List<ServiceGetDTO>();

                    foreach (var serv in serviceList)
                    {
                        serviceDTOList.Add(new ServiceGetDTO
                        {
                            ID = serv.CodService,
                            Description = serv.Description,
                            State = serv.State,
                            HourValue = serv.HourValue,
                            LeavingDate = serv.LeavingDate
                        });
                    }

                    return ResponseFactory.CreateSuccessResponse(200, serviceDTOList);
                }

                return ResponseFactory.CreateErrorResponse(404, "Services table empty");
            }

            catch (Exception)
            {
                return ResponseFactory.CreateErrorResponse(500, "Server error.");
            }
        }


        /// <summary>
        /// Obtains all services whose 'State' prop is 'True'.
        /// </summary>
        /// <returns>All projects which are active at the moment.</returns>
        [HttpGet("GetActiveServices")]
        public async Task<ActionResult<IEnumerable<Service>>> GetActiveServices()
        {
            try
            {
                var activeServicesList = await _unitOfWork.ServiceRepository.GetAllActiveServices();

                if (activeServicesList.Any())
                {
                    var serviceDTOList = new List<ServiceGetDTO>();

                    foreach (var serv in activeServicesList)
                    {
                        serviceDTOList.Add(new ServiceGetDTO
                        {
                            ID = serv.CodService,
                            Description = serv.Description,
                            State = serv.State,
                            HourValue = serv.HourValue,
                            LeavingDate = serv.LeavingDate
                        });
                    }

                    return ResponseFactory.CreateSuccessResponse(200, serviceDTOList);
                }

                return ResponseFactory.CreateErrorResponse(404, "There are no active services.");
            }

            catch
            {
                return ResponseFactory.CreateErrorResponse(500, "Server error.");
            }
        }


        /// <summary>
        /// Obtains a service based on the given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The service that matches the ID.</returns>
        [HttpGet("GetServiceById/{id}")]
        public async Task<ActionResult<Service>> GetServiceById([FromRoute] int id)
        {
            try
            {
                var service = await _unitOfWork.ServiceRepository.GetById(id);

                if (service != null) return ResponseFactory.CreateSuccessResponse(200, new ServiceGetDTO { ID = service.CodService, Description = service.Description, State = service.State, HourValue = service.HourValue, LeavingDate = service.LeavingDate });

                return ResponseFactory.CreateErrorResponse(404, "ID not found.");
            }

            catch (Exception)
            {
                return ResponseFactory.CreateErrorResponse(500, "Server error.");
            }
        }


        /// <summary>
        /// Adds a new service to DB.
        /// </summary>
        /// <param name="serviceToAdd">The service to add.</param>
        /// <returns>A message notifying if the process was successful or not.</returns>
        [HttpPost("AddService")]
        [Authorize(Policy = "Administrator")]
        public async Task<ActionResult> AddService(ServiceAddDTO serviceToAdd)
        {
            Service service = new Service
            {
                Description = serviceToAdd.Description,
                State = serviceToAdd.State,
                HourValue = serviceToAdd.HourValue
            };

            try
            {
                bool status = await _unitOfWork.ServiceRepository.Insert(service);

                if (status)
                {
                    await _unitOfWork.Save();
                    return ResponseFactory.CreateSuccessResponse(200, "Service added to DB.");
                }

                return ResponseFactory.CreateErrorResponse(404, "Service not added to DB.");
            }

            catch
            {
                return ResponseFactory.CreateErrorResponse(500, "Server error.");
            }
        }


        /// <summary>
        /// Modifies a service based on the given ID.
        /// </summary>
        /// <param name="serviceToUpdate">The new service's features.</param>
        /// <param name="id"></param>
        /// <returns>A message notifying if the process was successful or not.</returns>
        [HttpPut("UpdateService/{id}")]
        [Authorize(Policy = "Administrator")]
        public async Task<ActionResult> UpdateService(ServiceUpdateDTO serviceToUpdate, [FromRoute] int id)
        {
            Service service = new Service
            {
                Description = serviceToUpdate.Description,
                State = serviceToUpdate.State,
                HourValue = serviceToUpdate.HourValue,
                LeavingDate = serviceToUpdate.LeavingDate
            };

            try
            {
                bool status = await _unitOfWork.ServiceRepository.Update(service, id);

                if (status)
                {
                    await _unitOfWork.Save();
                    return ResponseFactory.CreateSuccessResponse(200, "Service successfully updated");
                }

                return ResponseFactory.CreateErrorResponse(404, "Service not updated.");
            }

            catch (Exception)
            {
                return ResponseFactory.CreateErrorResponse(500, "Server error.");
            }
        }


        /// <summary>
        /// Deactivates a service based on the given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A message notifying if the process was successful or not.</returns>
        [HttpPut("DeleteService/{id}")] //Al ser borrado logico deja de ser 'httpDelete' para ser un 'httpPut'.
        [Authorize(Policy = "Administrator")]
        public async Task<ActionResult> DeleteService([FromRoute] int id)
        {
            try
            {
                bool status = await _unitOfWork.ServiceRepository.Delete(id);

                if (status)
                {
                    await _unitOfWork.Save();
                    return ResponseFactory.CreateSuccessResponse(200, "Service deleted from DB.");
                }

                return ResponseFactory.CreateErrorResponse(404, "Service not deleted.");
            }

            catch (Exception)
            {
                return ResponseFactory.CreateErrorResponse(500, "Server error.");
            }
        }
    }
}

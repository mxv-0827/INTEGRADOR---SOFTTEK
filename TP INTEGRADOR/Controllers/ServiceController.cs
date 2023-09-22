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


        [HttpGet]
        [Route("/getAllServices")]
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


        [HttpGet]
        [Route("/getActiveServices")]
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


        [HttpGet]
        [Route("/getService/{id}")]
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


        [HttpPost]
        [Authorize(Policy = "Administrator")]
        [Route("/addService")]
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


        [HttpPut]
        [Authorize(Policy = "Administrator")]
        [Route("/updateService/{id}")]
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


        [HttpPut] //Al ser borrado logico deja de ser 'httpDelete' para ser un 'httpPut'.
        [Authorize(Policy = "Administrator")]
        [Route("/deleteService/{id}")]
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

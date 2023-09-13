using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_INTEGRADOR.DTOs;
using TP_INTEGRADOR.Entities;
using TP_INTEGRADOR.Services;

namespace TP_INTEGRADOR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            return await _unitOfWork.ServiceRepository.GetAll();    
        }

        [HttpGet]
        [Route("/getActiveServices")]
        public IActionResult GetActiveServices()
        {
            try
            {
                return Ok("Servicios obtenidos");
            }
            catch
            {
                return BadRequest("No se pudo realizar la peticion.");
            }
        }

        [HttpGet]
        [Route("/getService")]
        public async Task<ActionResult<Service>> GetServiceById(int id)
        {
            return await _unitOfWork.ServiceRepository.GetById(id);
        }

        [HttpPost]
        [Route("/addService")]
        public async Task<ActionResult> AddService(ServiceDTO serviceToAdd)
        {
            Service service = new Service
            {
                Description = serviceToAdd.Description,
                State = serviceToAdd.State,
                HourValue = serviceToAdd.HourValue
            };

            bool status = await _unitOfWork.ServiceRepository.Insert(service);

            if (status)
            {
                await _unitOfWork.Save();
                return Ok("Service successfully created");
            }

            return BadRequest("Ooops! Something went wrong. Service not created");
        }

        [HttpDelete]
        [Route("/deleteService")]
        public IActionResult DeleteService()
        {
            try
            {
                return Ok("Servicio eliminado.");
            }
            catch
            {
                return BadRequest("No se pudo realizar la peticion.");
            }
        }

        [HttpPut]
        [Route("/updateService")]
        public IActionResult UpdateService()
        {
            try
            {
                return Ok("Proyecto modificado.");
            }
            catch
            {
                return BadRequest("No se pudo realizar la peticion.");
            }
        }
    }
}

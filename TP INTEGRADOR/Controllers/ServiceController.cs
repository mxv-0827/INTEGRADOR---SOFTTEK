using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TP_INTEGRADOR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        [HttpGet]
        [Route("/getAllServices")]
        public IActionResult GetAllServices()
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
        public IActionResult GetServiceById()
        {
            try
            {
                return Ok("Servicio obtenido");
            }
            catch
            {
                return BadRequest("No se pudo realizar la peticion.");
            }
        }

        [HttpPost]
        [Route("/addService")]
        public IActionResult AddService()
        {
            try
            {
                return Ok("Servicio creado.");
            }
            catch
            {
                return BadRequest("No se pudo realizar la peticion.");
            }
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

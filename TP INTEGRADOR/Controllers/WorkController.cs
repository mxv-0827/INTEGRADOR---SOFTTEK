using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TP_INTEGRADOR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        [HttpGet]
        [Route("/getAllWorks")]
        public IActionResult GetAllWorks()
        {
            try
            {
                return Ok("Trabajos obtenidos");
            }
            catch
            {
                return BadRequest("No se pudo realizar la peticion.");
            }
        }

        [HttpGet]
        [Route("/getWork")]
        public IActionResult GetWorkById()
        {
            try
            {
                return Ok("Trabajo obtenido");
            }
            catch
            {
                return BadRequest("No se pudo realizar la peticion.");
            }
        }

        [HttpPost]
        [Route("/addWork")]
        public IActionResult AddWork()
        {
            try
            {
                return Ok("Trabajo creado.");
            }
            catch
            {
                return BadRequest("No se pudo realizar la peticion.");
            }
        }

        [HttpDelete]
        [Route("/deleteWork")]
        public IActionResult DeleteWork()
        {
            try
            {
                return Ok("Trabajo eliminado.");
            }
            catch
            {
                return BadRequest("No se pudo realizar la peticion.");
            }
        }

        [HttpPut]
        [Route("/updateWork")]
        public IActionResult UpdateWork()
        {
            try
            {
                return Ok("Trabajo modificado.");
            }
            catch
            {
                return BadRequest("No se pudo realizar la peticion.");
            }
        }
    }
}

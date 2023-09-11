using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using TP_INTEGRADOR.Entities;
using TP_INTEGRADOR.Services;

namespace TP_INTEGRADOR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public WorkController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        [Route("/getAllWorks")]
        public async Task<ActionResult<IEnumerable<Work>>> GetAllWorks()
        {
            return await _unitOfWork.WorkRepository.GetAll();
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

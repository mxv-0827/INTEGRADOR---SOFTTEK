using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_INTEGRADOR.DataAccess.Repositories;
using TP_INTEGRADOR.Entities;
using TP_INTEGRADOR.Services;

namespace TP_INTEGRADOR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public ProjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        [Route("/getAllProjects")]
        public async Task<ActionResult<IEnumerable<Project>>> GetAllProjects()
        {
            return await _unitOfWork.ProjectRepository.GetAll();
        }

        [HttpGet]
        [Route("/getProjectFilter")]
        public IActionResult GetProjectsByState()
        {
            try
            {
                return Ok("Proyectos obtenidos");
            }
            catch
            {
                return BadRequest("No se pudo realizar la peticion.");
            }
        }

        [HttpGet]
        [Route("/getProject")]
        public IActionResult GetProjectById()
        {
            try
            {
                return Ok("Proyecto obtenido");
            }
            catch
            {
                return BadRequest("No se pudo realizar la peticion.");
            }
        }

        [HttpPost]
        [Route("/addProject")]
        public IActionResult AddProject() 
        {
            try
            {
                return Ok("Proyecto creado.");
            }
            catch
            {
                return BadRequest("No se pudo realizar la peticion.");
            }
        }

        [HttpDelete]
        [Route("/deleteProject")]
        public IActionResult DeleteProject()
        {
            try
            {
                return Ok("Proyecto eliminado.");
            }
            catch
            {
                return BadRequest("No se pudo realizar la peticion.");
            }
        }

        [HttpPut]
        [Route("/updateProject")]
        public IActionResult UpdateProject()
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

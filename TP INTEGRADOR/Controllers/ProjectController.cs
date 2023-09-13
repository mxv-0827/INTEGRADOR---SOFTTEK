using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_INTEGRADOR.DataAccess.Repositories;
using TP_INTEGRADOR.DTOs;
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
        public async Task<ActionResult<Project>> GetProjectById(int id)
        {
            return await _unitOfWork.ProjectRepository.GetById(id);
        }

        [HttpPost]
        [Route("/addProject")]
        public async Task<ActionResult> AddProject(ProjectDTO projectToAdd) 
        {
            Project project = new Project
            {
                Name = projectToAdd.Name,
                Direction = projectToAdd.Direction,
                State = projectToAdd.State
            };

            bool status = await _unitOfWork.ProjectRepository.Insert(project);

            if (status)
            {
                await _unitOfWork.Save();
                return Ok("Project successfully created.");
            }

            return BadRequest("Ooops! Something went wrong. Project not created");
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
        public async Task<ActionResult> UpdateProject(ProjectDTO projectToUpdate, int id)
        {
            Project project = new Project
            {
                Name = projectToUpdate.Name,
                Direction = projectToUpdate.Direction,
                State = projectToUpdate.State,
                LeavingDate = projectToUpdate.LeavingDate
            };

            bool status = await _unitOfWork.ProjectRepository.Update(project, id);

            if (status)
            {
                await _unitOfWork.Save();
                return Ok("Project successfully updated.");
            }

            return BadRequest("Ooops! Something went wrong. Project not updated");
        }
    }
}

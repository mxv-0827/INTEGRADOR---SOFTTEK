using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_INTEGRADOR.DataAccess.Repositories;
using TP_INTEGRADOR.DTOs.ProjectDTOs;
using TP_INTEGRADOR.DTOs.UserDTOs;
using TP_INTEGRADOR.Entities;
using TP_INTEGRADOR.Infrastructure;
using TP_INTEGRADOR.Services;

namespace TP_INTEGRADOR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
            try
            {
                var projectList = await _unitOfWork.ProjectRepository.GetAll();

                if (projectList.Any())
                {
                    var projectDTOList = new List<ProjectGetDTO>();

                    foreach (var proj in projectList)
                    {
                        projectDTOList.Add(new ProjectGetDTO
                        {
                            ID = proj.CodProject,
                            Name = proj.Name,
                            Direction = proj.Direction,
                            State = proj.State,
                            LeavingDate = proj.LeavingDate
                        });
                    }

                    return ResponseFactory.CreateSuccessResponse(200, projectDTOList);
                }

                return ResponseFactory.CreateErrorResponse(404, "Projects table empty");
            }

            catch (Exception)
            {
                return ResponseFactory.CreateErrorResponse(500, "Server error.");
            }
        }


        [HttpGet]
        [Route("/getProjectFilter")]
        public async Task<ActionResult> GetProjectsByState(int state)
        {
            try
            {
                var projectsStateList = await _unitOfWork.ProjectRepository.GetAllStateProjects(state);

                if (projectsStateList.Any())
                {
                    var projectDTOList = new List<ProjectGetDTO>();

                    foreach (var proj in projectsStateList)
                    {
                        projectDTOList.Add(new ProjectGetDTO
                        {
                            ID = proj.CodProject,
                            Name = proj.Name,
                            Direction = proj.Direction,
                            State = proj.State,
                            LeavingDate = proj.LeavingDate
                        });
                    }

                    return ResponseFactory.CreateSuccessResponse(200, projectDTOList);
                }

                return ResponseFactory.CreateErrorResponse(404, "Not projects found with the established state.");
            }

            catch
            {
                return ResponseFactory.CreateErrorResponse(500, "Server error.");
            }
        }


        [HttpGet]
        [Route("/getProject/{id}")]
        public async Task<ActionResult<Project>> GetProjectById([FromRoute] int id)
        {
            try
            {
                var project = await _unitOfWork.ProjectRepository.GetById(id);

                if (project != null) return ResponseFactory.CreateSuccessResponse(200, new ProjectGetDTO { ID = project.CodProject, Name = project.Name, Direction = project.Direction, State = project.State, LeavingDate = project.LeavingDate});

                return ResponseFactory.CreateErrorResponse(404, "ID not found.");
            }

            catch (Exception)
            {
                return ResponseFactory.CreateErrorResponse(500, "Server error.");
            }
        }


        [HttpPost]
        [Authorize(Policy = "Administrator")]
        [Route("/addProject")]
        public async Task<ActionResult> AddProject(ProjectAddDTO projectToAdd) 
        {
            Project project = new Project
            {
                Name = projectToAdd.Name,
                Direction = projectToAdd.Direction,
                State = projectToAdd.State
            };

            try
            {
                bool status = await _unitOfWork.ProjectRepository.Insert(project);

                if (status)
                {
                    await _unitOfWork.Save();
                    return ResponseFactory.CreateSuccessResponse(200, "Project added to DB.");
                }

                return ResponseFactory.CreateErrorResponse(404, "Project not added to DB.");
            }

            catch
            {
                return ResponseFactory.CreateErrorResponse(500, "Server error.");
            }
        }


        [HttpPut]
        [Authorize(Policy = "Administrator")]
        [Route("/updateProject/{id}")]
        public async Task<ActionResult> UpdateProject(ProjectUpdateDTO projectToUpdate, [FromRoute] int id)
        {
            Project project = new Project
            {
                Name = projectToUpdate.Name,
                Direction = projectToUpdate.Direction,
                State = projectToUpdate.State,
                LeavingDate = projectToUpdate.LeavingDate
            };

            try
            {
                bool status = await _unitOfWork.ProjectRepository.Update(project, id);

                if (status)
                {
                    await _unitOfWork.Save();
                    return ResponseFactory.CreateSuccessResponse(200, "Project successfully updated");
                }

                return ResponseFactory.CreateErrorResponse(404, "Project not updated.");
            }

            catch (Exception)
            {
                return ResponseFactory.CreateErrorResponse(500, "Server error.");
            }
        }


        [HttpPut]
        [Authorize(Policy = "Administrator")]
        [Route("/deleteProject/{id}")] //Al ser borrado logico deja de ser 'httpDelete' para ser un 'httpPut'.
        public async Task<ActionResult> DeleteProject([FromRoute] int id)
        {
            try
            {
                bool status = await _unitOfWork.ProjectRepository.Delete(id);

                if (status)
                {
                    await _unitOfWork.Save();
                    return ResponseFactory.CreateSuccessResponse(200, "Project deleted from DB.");
                }

                return ResponseFactory.CreateErrorResponse(404, "Project not deleted.");
            }

            catch (Exception)
            {
                return ResponseFactory.CreateErrorResponse(500, "Server error.");
            }
        }
    }
}

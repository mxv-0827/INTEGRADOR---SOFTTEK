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

        /// <summary>
        /// Obtains all projects from DB.
        /// </summary>
        /// <returns>All projects whether they have been deactivated or not.</returns>
        [HttpGet("GetAllProjects")]
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


        /// <summary>
        /// Obtains all projects with the state that matches the one written.
        /// </summary>
        /// <param name="state"></param>
        /// <returns>Projects with the same state as the parameter.</returns>
        [HttpGet("GetProjectsByState")]
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


        /// <summary>
        /// Obtains the project that matches with the given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the project with the same ID as the written one.</returns>
        [HttpGet("GetProjectById/{id}")]
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


        /// <summary>
        /// Adds a new project to DB.
        /// </summary>
        /// <param name="projectToAdd">The project to add.</param>
        /// <returns>A message notifying if the process was successful or not.</returns>
        [HttpPost("AddProject")]
        [Authorize(Policy = "Administrator")]
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


        /// <summary>
        /// Modifies a project based on the given ID.
        /// </summary>
        /// <param name="projectToUpdate">The new project's features.</param>
        /// <param name="id"></param>
        /// <returns>A message notifying if the process was successful or not.</returns>
        [HttpPut("Updateproject/{id}")]
        [Authorize(Policy = "Administrator")]
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


        /// <summary>
        /// Deactivates a project based on the given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A message notifying if the process was successful or not.</returns>
        [HttpPut("DeleteProject/{id}")] //Al ser borrado logico deja de ser 'httpDelete' para ser un 'httpPut'.
        [Authorize(Policy = "Administrator")]
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

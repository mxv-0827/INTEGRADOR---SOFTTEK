using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using TP_INTEGRADOR.DTOs;
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
        public async Task<ActionResult<Work>> GetWorkById(int id)
        {
            return await _unitOfWork.WorkRepository.GetById(id);
        }

        [HttpPost]
        [Route("/addWork")]
        public async Task<ActionResult> AddWork(WorkDTO workToAdd)
        {
            Work work = new Work
            {
                Date = workToAdd.Date,
                CodProject = workToAdd.CodProject,
                CodService = workToAdd.CodService,
                AmountHours = workToAdd.AmountHours,
                ValuePerHour = workToAdd.ValuePerHour
            };
            work.Cost = work.AmountHours * work.ValuePerHour;

            bool status = await _unitOfWork.WorkRepository.Insert(work);

            if (status)
            {
                await _unitOfWork.Save();
                return Ok("Work successfully created.");
            }

            return BadRequest("Ooops! Something went wrong. Work not created");
        }

        [HttpPut]
        [Route("/deleteWork")] //Al ser borrado logico deja de ser 'httpDelete' para ser un 'httpPut'.
        public async Task<ActionResult> DeleteWork(int id)
        {
            bool status = await _unitOfWork.UserRepository.Delete(id);

            if (status)
            {
                await _unitOfWork.Save();
                return Ok("Work successfully deleted.");
            }

            return BadRequest("Ooops! Something went wrong. Work not deleted");
        }

        [HttpPut]
        [Route("/updateWork")]
        public async Task<ActionResult> UpdateWork(Work workToUpdate, int id)
        {
            Work work = new Work
            {
                Date = workToUpdate.Date,
                CodProject = workToUpdate.CodProject,
                CodService = workToUpdate.CodService,
                AmountHours = workToUpdate.AmountHours,
                ValuePerHour = workToUpdate.ValuePerHour,
        };

            bool status = await _unitOfWork.WorkRepository.Update(work, id);

            if (status)
            {
                await _unitOfWork.Save();
                return Ok("Work successfully updated.");
            }

            return BadRequest("Ooops! Something went wrong. Work not updated");
        }
    }
}

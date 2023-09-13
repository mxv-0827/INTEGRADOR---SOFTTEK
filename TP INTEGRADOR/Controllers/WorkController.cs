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

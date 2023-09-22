﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using TP_INTEGRADOR.DTOs.ProjectDTOs;
using TP_INTEGRADOR.DTOs.WorkDTOs;
using TP_INTEGRADOR.Entities;
using TP_INTEGRADOR.Infrastructure;
using TP_INTEGRADOR.Services;

namespace TP_INTEGRADOR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
            try
            {
                var workList = await _unitOfWork.WorkRepository.GetAll();

                if (workList.Any())
                {
                    var workDTOList = new List<WorkGetDTO>();

                    foreach (var work in workList)
                    {
                        workDTOList.Add(new WorkGetDTO
                        {
                            ID = work.CodWork,
                            CodProject = work.CodProject,
                            CodService = work.CodService,
                            AmountHours = work.AmountHours,
                            ValuePerHour = work.ValuePerHour,
                            Cost = work.Cost,
                            LeavingDate = work.LeavingDate
                        });
                    }

                    return ResponseFactory.CreateSuccessResponse(200, workDTOList);
                }

                return ResponseFactory.CreateErrorResponse(404, "Works table empty");
            }

            catch (Exception)
            {
                return ResponseFactory.CreateErrorResponse(500, "Server error.");
            }
        }


        [HttpGet]
        [Route("/getWork/{id}")]
        public async Task<ActionResult<Work>> GetWorkById([FromRoute] int id)
        {
            try
            {
                var work = await _unitOfWork.WorkRepository.GetById(id);

                if (work != null) return ResponseFactory.CreateSuccessResponse(200, new WorkGetDTO 
                { ID = work.CodWork, CodProject = work.CodProject, CodService = work.CodService, AmountHours = work.AmountHours, ValuePerHour = work.ValuePerHour, Cost = work.Cost, LeavingDate = work.LeavingDate });

                return ResponseFactory.CreateErrorResponse(404, "ID not found.");
            }

            catch (Exception)
            {
                return ResponseFactory.CreateErrorResponse(500, "Server error.");
            }
        }


        [HttpPost]
        [Authorize(Policy = "Administrator")]
        [Route("/addWork")]
        public async Task<ActionResult> AddWork(WorkAddDTO workToAdd)
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

            try
            {
                bool status = await _unitOfWork.WorkRepository.Insert(work);

                if (status)
                {
                    await _unitOfWork.Save();
                    return ResponseFactory.CreateSuccessResponse(200, "Work added to DB.");
                }

                return ResponseFactory.CreateErrorResponse(404, "Work not added to DB.");
            }

            catch
            {
                return ResponseFactory.CreateErrorResponse(500, "Server error.");
            }
        }


        [HttpPut]
        [Authorize(Policy = "Administrator")]
        [Route("/updateWork/{id}")]
        public async Task<ActionResult> UpdateWork(WorkUpdateDTO workToUpdate, [FromRoute] int id)
        {
            Work work = new Work
            {
                Date = workToUpdate.Date,
                CodProject = workToUpdate.CodProject,
                CodService = workToUpdate.CodService,
                AmountHours = workToUpdate.AmountHours,
                ValuePerHour = workToUpdate.ValuePerHour,
                LeavingDate = workToUpdate.LeavingDate
            };

            try
            {
                bool status = await _unitOfWork.WorkRepository.Update(work, id);

                if (status)
                {
                    await _unitOfWork.Save();
                    return ResponseFactory.CreateSuccessResponse(200, "Work successfully updated");
                }

                return ResponseFactory.CreateErrorResponse(404, "Work not updated.");
            }

            catch (Exception)
            {
                return ResponseFactory.CreateErrorResponse(500, "Server error.");
            }
        }


        [HttpPut]
        [Authorize(Policy = "Administrator")]
        [Route("/deleteWork/{id}")] //Al ser borrado logico deja de ser 'httpDelete' para ser un 'httpPut'.
        public async Task<ActionResult> DeleteWork([FromRoute] int id)
        {
            bool status = await _unitOfWork.WorkRepository.Delete(id);

            if (status)
            {
                await _unitOfWork.Save();
                return Ok("Work successfully deleted.");
            }

            return BadRequest("Ooops! Something went wrong. Work not deleted");
        }

        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Izmainas.API.Domain.Constants;
using Izmainas.API.Domain.Contracts.Admin;
using Izmainas.API.Domain.Dtos;
using Izmainas.API.Domain.Entities;
using Izmainas.API.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Izmainas.API.Controllers
{
    /// <summary>
    /// API controller for Imported schedules manipulation
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleImportController : ControllerBase
    {
        private readonly IScheduleImportRepository _scheduleImportRepository;
        private readonly IMapper _mapper;

        public ScheduleImportController(IScheduleImportRepository scheduleImportRepository, IMapper mapper)
        {
            _scheduleImportRepository = scheduleImportRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Method used to fetch student schedules displayed on the webpage
        /// </summary>
        /// <param name="day">The day to return the schedule for</param>      
        /// <returns>Success response containing student schedule list for specified day or failure status</returns>
        [HttpGet(APIRoutes.ScheduleImportRoutes.StudentSchedule, Name = nameof(GetStudentSchedulesAsync))]
        public async Task<ActionResult<List<StudentScheduleDto>>> GetStudentSchedulesAsync(int day)
        {
            if (day >= 1 && day <= 5)
            {
                var result = await _scheduleImportRepository.GetStudentSchedule(day);
                return Ok(_mapper.Map<List<StudentScheduleDto>>(result));
            }
            return BadRequest();
        }

        /// <summary>
        /// Method used to fetch teacher schedules displayed on the webpage
        /// </summary>
        /// <param name="day">The day to return the schedule for</param>
        /// <returns>Success response containing teacher schedule list for specified day or failure status</returns>
        [HttpGet(APIRoutes.ScheduleImportRoutes.TeacherSchedule, Name = nameof(GetTeacherSchedulesAsync))]        
        public async Task<ActionResult<List<TeacherScheduleDto>>> GetTeacherSchedulesAsync(int day)
        {
            if (day >= 1 && day <= 5)
            {
                var result = await _scheduleImportRepository.GetTeacherSchedule(day);
                return Ok(_mapper.Map<List<TeacherScheduleDto>>(result));
            }
            return BadRequest();
        }

        /// <summary>
        /// Method used to populate database with imported student schedule
        /// </summary>
        /// <param name="request">Payload containing student schedule</param>
        /// <returns>Success response of student schedule import or failure status</returns>
        [HttpPost(APIRoutes.ScheduleImportRoutes.StudentScheduleImport)]
        public async Task<IActionResult> PopulateStudentSchedulesAsync(StudentScheduleRequest request)
        {
            if (request.StudentScheduleItems == null)
            {
                return BadRequest();
            }
            
            var items = _mapper.Map<List<StudentScheduleItem>>(request.StudentScheduleItems);

            await _scheduleImportRepository.PopulateStudentSchedule(items);                
            await _scheduleImportRepository.SaveChangesAsync();

            // TODO: return correct data
            //return CreatedAtRoute("GetStudentSchedulesAsync", items.Count);

            // TODO: review created result
            return Ok();            
        }

        /// <summary>
        /// Method used to populate database with imported teacher schedule
        /// </summary>
        /// <param name="request">Payload containing teacher schedule</param>
        /// <returns>Success response of teacher schedule import or failure status</returns>
        [HttpPost(APIRoutes.ScheduleImportRoutes.TeacherScheduleImport)]
        public async Task<IActionResult> PopulateTeacherSchedulesAsync(TeacherScheduleRequest request)
        {
            if (request.TeacherScheduleItems == null)
            {
                return BadRequest();
            }

            var items = _mapper.Map<List<TeacherScheduleItem>>(request.TeacherScheduleItems);

            await _scheduleImportRepository.PopulateTeacherSchedule(items);
            await _scheduleImportRepository.SaveChangesAsync();

            // TODO: return correct data
            //return CreatedAtRoute("GetTeacherSchedulesAsync", items.Count);
            
            // TODO: review created result
            return Ok();            
        }

        /// <summary>
        /// Method used to clear database from old student schedule version
        /// </summary>
        /// <returns>No content message or failure status</returns>
        [HttpDelete(APIRoutes.ScheduleImportRoutes.StudentScheduleImport)]
        public async Task<ActionResult> ClearStudentSchedulesAsync()
        {
            var items = await _scheduleImportRepository.GetStudentSchedule();
            if (items == null)
            {
                return BadRequest();
            }
            await _scheduleImportRepository.ClearStudentSchedules();
            await _scheduleImportRepository.SaveChangesAsync();
            return NoContent();
            
            // TODO: review return type
        }

        /// <summary>
        /// Method used to clear database from old teacher schedule version
        /// </summary>
        /// <returns>No content message or failure status</returns>
        [HttpDelete(APIRoutes.ScheduleImportRoutes.TeacherScheduleImport)]
        public async Task<ActionResult> ClearTeacherSchedulesAsync()
        {
            var items = await _scheduleImportRepository.GetTeacherSchedule();
            if (items == null)
            {
                return BadRequest();
            }

            await _scheduleImportRepository.ClearTeacherSchedules();
            await _scheduleImportRepository.SaveChangesAsync();
            return NoContent();
            
            // TODO: review return type
        }
    }
}
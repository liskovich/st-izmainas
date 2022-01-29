using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Izmainas.API.Domain.Constants;
using Izmainas.API.Domain.Contracts;
using Izmainas.API.Domain.Entities;
using Izmainas.API.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Izmainas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleImportController : ControllerBase
    {
        private readonly IScheduleImportRepository _scheduleImportRepository;

        public ScheduleImportController(IScheduleImportRepository scheduleImportRepository)
        {
            _scheduleImportRepository = scheduleImportRepository;
        }

        // TODO: replace with dto
        [HttpGet(
            APIRoutes.ScheduleImportRoutes.StudentSchedule, 
            Name = nameof(GetStudentSchedulesAsync))]
        public async Task<ActionResult<List<StudentScheduleItem>>> GetStudentSchedulesAsync(int day)
        {
            if (day >= 1 && day <= 5)
            {
                return Ok(await _scheduleImportRepository.GetStudentSchedule(day));
            }
            return BadRequest();
        }

        // TODO: replace with dto
        [HttpGet(
            APIRoutes.ScheduleImportRoutes.TeacherSchedule,
            Name = nameof(GetTeacherSchedulesAsync))]
        public async Task<ActionResult<List<TeacherScheduleItem>>> GetTeacherSchedulesAsync(int day)
        {
            if (day >= 1 && day <= 5)
            {
                return Ok(await _scheduleImportRepository.GetTeacherSchedule(day));
            }
            return BadRequest();
        }

        // TODO: replace with dto
        [HttpPost(APIRoutes.ScheduleImportRoutes.StudentScheduleImport)]
        public async Task<IActionResult> PopulateStudentSchedulesAsync(StudentScheduleRequest request)
        {
            if (request.StudentScheduleItems is not null)
            {
                // TODO: configure automapper
                var items = new List<StudentScheduleItem>();                
                foreach (var dto in request.StudentScheduleItems)
                {
                    var item = new StudentScheduleItem()
                    {
                        Class = dto.Class,
                        Lesson = dto.Lesson,
                        Subject = dto.Subject,
                        Day = dto.Day
                    };
                    items.Add(item);
                }
                await _scheduleImportRepository.PopulateStudentSchedule(items);
                var test = await _scheduleImportRepository.SaveChangesAsync();
                if (test)
                {
                    System.Console.WriteLine("successfully save");
                }
                // TODO: return correct data
                //return CreatedAtRoute("GetStudentSchedulesAsync", items.Count);

                // TODO: review created result
                return Ok();
            }
            return BadRequest();
        }

        // TODO: replace with dto
        [HttpPost(APIRoutes.ScheduleImportRoutes.TeacherScheduleImport)]
        public async Task<IActionResult> PopulateTeacherSchedulesAsync(TeacherScheduleRequest request)
        {
            if (request.TeacherScheduleItems is not null)
            {
                // TODO: configure automapper
                var items = new List<TeacherScheduleItem>();                
                foreach (var dto in request.TeacherScheduleItems)
                {
                    var item = new TeacherScheduleItem()
                    {
                        Class = dto.Class,
                        Lesson = dto.Lesson,
                        TeacherName = dto.TeacherName,
                        Day = dto.Day
                    };
                    items.Add(item);
                }
                await _scheduleImportRepository.PopulateTeacherSchedule(items);
                await _scheduleImportRepository.SaveChangesAsync();
                // TODO: return correct data
                //return CreatedAtRoute("GetTeacherSchedulesAsync", items.Count);
                
                // TODO: review created result
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete(APIRoutes.ScheduleImportRoutes.StudentScheduleImport)]
        public async Task<ActionResult> ClearStudentSchedulesAsync()
        {
            var items = await _scheduleImportRepository.GetStudentSchedule();
            if (items is not null)
            {
                await _scheduleImportRepository.ClearStudentSchedules();
                await _scheduleImportRepository.SaveChangesAsync();
                return NoContent();
            }
            // TODO: review return type
            return BadRequest();
        }

        [HttpDelete(APIRoutes.ScheduleImportRoutes.TeacherScheduleImport)]
        public async Task<ActionResult> ClearTeacherSchedulesAsync()
        {
            var items = await _scheduleImportRepository.GetTeacherSchedule();
            if (items is not null)
            {
                await _scheduleImportRepository.ClearTeacherSchedules();
                await _scheduleImportRepository.SaveChangesAsync();
                return NoContent();
            }
            // TODO: review return type
            return BadRequest();
        }
    }
}
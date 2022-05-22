using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Izmainas.API.Domain.Contracts.Client;
using Izmainas.API.Domain.Contracts.Client.Teacher;
using Izmainas.API.Domain.Services;
using Izmainas.API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Izmainas.API.Controllers
{
    /// <summary>
    /// API controller for Student schedule manipulation
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IStudentScheduleService _studentScheduleService;
        private readonly ITeacherScheduleService _teacherScheduleService;

        public ScheduleController(IStudentScheduleService studentScheduleService, ITeacherScheduleService teacherScheduleService)
        {
            _studentScheduleService = studentScheduleService;
            _teacherScheduleService = teacherScheduleService;
        }

        /// <summary>
        /// Method used for retrieving current student schedule - ONLY FOR CLASSES THAT HAVE ANY CHANGES
        /// </summary>
        /// <returns>Success response containing student schedule from service or failure status</returns>
        [HttpGet]
        public async Task<ActionResult<StudentScheduleResponse>> GetStudentScheduleToday()
        {
            var timestamp = DateTime.Today.ToTimestamp();
            var result = await _studentScheduleService.GetAsync(timestamp);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Method used for retrieving current student schedule - FULL
        /// </summary>
        /// <returns>Success response containing student schedule from service or failure status</returns>
        [HttpGet("/full")]
        public async Task<ActionResult<StudentScheduleResponse>> GetStudentScheduleFullToday()
        {
            var timestamp = DateTime.Today.ToTimestamp();
            var result = await _studentScheduleService.GetFullAsync(timestamp);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
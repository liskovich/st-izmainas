using Izmainas.API.Domain.Contracts.Client.Teacher;
using Izmainas.API.Domain.Services;
using Izmainas.API.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Izmainas.API.Controllers
{
    /// <summary>
    /// API controller for Teacher schedule manipulation
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherScheduleController : ControllerBase
    {
        private readonly ITeacherScheduleService _teacherScheduleService;

        public TeacherScheduleController(ITeacherScheduleService teacherScheduleService)
        {
            _teacherScheduleService = teacherScheduleService;
        }

        /// <summary>
        /// Method used for retrieving current teacher schedule - ONLY FOR TEACHERS WHO HAVE ANY CHANGES
        /// </summary>
        /// <returns>Success response containing teacher schedule from service or failure status</returns>
        [HttpGet]        
        public async Task<ActionResult<TeacherScheduleResponse>> GetTeacherScheduleToday()
        {
            var timestamp = DateTime.Today.ToTimestamp();
            var result = await _teacherScheduleService.GetAsync(timestamp);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}

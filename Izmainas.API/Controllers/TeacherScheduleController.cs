using Izmainas.API.Domain.Contracts.Client.Teacher;
using Izmainas.API.Domain.Services;
using Izmainas.API.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Izmainas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherScheduleController : ControllerBase
    {
        private readonly ITeacherScheduleService _teacherScheduleService;

        public TeacherScheduleController(ITeacherScheduleService teacherScheduleService)
        {
            _teacherScheduleService = teacherScheduleService;
        }

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

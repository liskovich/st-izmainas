using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Izmainas.API.Domain.Contracts.Client;
using Izmainas.API.Domain.Services;
using Izmainas.API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Izmainas.API.Controllers
{
    // TODO: completely refactor schedule controller

    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IStudentScheduleService _studentScheduleService;

        public ScheduleController(IStudentScheduleService studentScheduleService)
        {
            _studentScheduleService = studentScheduleService;
        }

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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Izmainas.API.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Izmainas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IMapper _mapper;

        public ScheduleController(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Izmainas.API.Domain.Dtos.Data>> GetTodayScheduleAsync()
        {
            var schedule = await _scheduleRepository.GetByDate(DateTime.Today);
            return _mapper.Map<Izmainas.API.Domain.Dtos.Data>(schedule);
        }
    }
}
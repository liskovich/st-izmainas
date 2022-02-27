using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Izmainas.API.Controllers
{
    // TODO: completely refactor schedule controller

    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IMapper _mapper;

        public ScheduleController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
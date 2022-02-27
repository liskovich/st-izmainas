using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Izmainas.API.Domain.Dtos;

namespace Izmainas.API.Domain.Contracts.Admin
{
    public class TeacherScheduleRequest
    {
        public IEnumerable<TeacherScheduleCreateDto> TeacherScheduleItems { get; set; }
    }
}
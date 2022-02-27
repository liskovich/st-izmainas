
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.API.Domain.Contracts.Admin
{
    public record StudentScheduleCreateDto(int Lesson, int Day, string Class, string Subject);    
}
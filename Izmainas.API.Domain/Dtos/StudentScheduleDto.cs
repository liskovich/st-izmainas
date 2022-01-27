
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.API.Domain.Dtos
{
    public record StudentScheduleDto(int Lesson, int Day, string Class, string Subject);    
}
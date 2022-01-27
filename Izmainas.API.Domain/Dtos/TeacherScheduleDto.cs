using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.API.Domain.Dtos
{
    public record TeacherScheduleDto(int Lesson, int Day, string TeacherName, string Class);
}
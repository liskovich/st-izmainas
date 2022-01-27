using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.FileUploadService.Domain.Dtos
{
    public record StudentScheduleDto(string Lesson, int Day, string Class, string Subject);
}
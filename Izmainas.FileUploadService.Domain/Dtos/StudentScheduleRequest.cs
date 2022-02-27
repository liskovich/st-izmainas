using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izmainas.FileUploadService.Domain.Dtos
{
    public class StudentScheduleRequest
    {
        public IEnumerable<StudentScheduleDto> StudentScheduleItems { get; set; }

        public StudentScheduleRequest(IEnumerable<StudentScheduleDto> studentScheduleItems)
        {
            StudentScheduleItems = studentScheduleItems;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izmainas.FileUploadService.Domain.Dtos
{
    public class TeacherScheduleRequest
    {
        public IEnumerable<TeacherScheduleDto> TeacherScheduleItems { get; set; }

        public TeacherScheduleRequest(IEnumerable<TeacherScheduleDto> teacherScheduleItems)
        {
            TeacherScheduleItems = teacherScheduleItems;
        }
    }
}

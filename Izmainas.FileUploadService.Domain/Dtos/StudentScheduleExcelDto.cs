using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Izmainas.FileUploadService.Domain.Constants;
using Npoi.Mapper.Attributes;

namespace Izmainas.FileUploadService.Domain.Dtos
{
    public class StudentScheduleExcelDto
    {
        [Column(ExcelTableNames.Student.Lesson)]
        public string Lesson { get; set; }

        [Column(ExcelTableNames.Student.Day)]
        public int Day { get; set; }

        [Column(ExcelTableNames.Student.Class)]
        public string Class { get; set; }

        [Column(ExcelTableNames.Student.Subject)]
        public string Subject { get; set; }
    }
}
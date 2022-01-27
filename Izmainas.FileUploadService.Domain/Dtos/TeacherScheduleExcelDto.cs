using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Izmainas.FileUploadService.Domain.Constants;
using Npoi.Mapper.Attributes;

namespace Izmainas.FileUploadService.Domain.Dtos
{
    public class TeacherScheduleExcelDto
    {
        [Column(ExcelTableNames.Teacher.Lesson)]
        public string Lesson { get; set; }
        
        [Column(ExcelTableNames.Teacher.Day)]
        public int Day { get; set; }
        
        [Column(ExcelTableNames.Teacher.TeacherName)]
        public string TeacherName { get; set; }
        
        [Column(ExcelTableNames.Teacher.Class)]
        public string Class { get; set; }
    }
}
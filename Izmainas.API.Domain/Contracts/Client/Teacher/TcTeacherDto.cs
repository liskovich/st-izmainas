using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izmainas.API.Domain.Contracts.Client.Teacher
{
    public class TcTeacherDto
    {
        public string TeacherName { get; set; }
        public List<TcLessonDto> Lessons { get; set; }
    }
}

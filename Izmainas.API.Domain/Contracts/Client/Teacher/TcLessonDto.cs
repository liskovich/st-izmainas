using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izmainas.API.Domain.Contracts.Client.Teacher
{
    public class TcLessonDto
    {
        public long LessonNumber { get; set; }
        public string Class { get; set; }
        public long Room { get; set; }
        public TcNoteDto Note { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.API.Domain.Contracts.Client.Student
{
    public class StLessonDto
    {
        public long LessonNumber { get; set; }
        public List<StRoomDto> Rooms { get; set; }
    }
}
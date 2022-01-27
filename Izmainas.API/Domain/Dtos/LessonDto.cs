using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.API.Domain.Dtos
{
    public class LessonDto
    {
        public long LessonNumber { get; set; }
        public List<RoomDto> Rooms { get; set; }
    }
}
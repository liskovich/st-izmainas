using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Izmainas.API.Domain.Dtos
{
    public class RoomDto
    {
        [JsonPropertyName("room")]
        public string RoomNumber { get; set; }
        public string Subject { get; set; }
        public string TeacherName { get; set; }
        public NoteDto Note { get; set; }
    }
}
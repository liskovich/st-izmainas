using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Izmainas.API.Domain.Contracts.Client.Student
{
    public class StClassDto
    {
        [JsonPropertyName("class")]
        public string ClassNumber { get; set; }
        public List<StLessonDto> Lessons { get; set; }
    }
}
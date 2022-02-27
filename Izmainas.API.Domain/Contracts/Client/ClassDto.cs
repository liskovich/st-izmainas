using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Izmainas.API.Domain.Contracts.Client
{
    public class ClassDto
    {
        [JsonPropertyName("class")]
        public string ClassNumber { get; set; }
        public List<LessonDto> Lessons { get; set; }
    }
}
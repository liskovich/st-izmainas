using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Izmainas.API.Domain.Models
{
    public class Class
    {
        //[JsonPropertyName("class")]
        [Key]
        public Guid Id { get; set; }
        public string ClassNumber { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}
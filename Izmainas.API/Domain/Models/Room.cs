using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Izmainas.API.Domain.Models
{
    public class Room
    {
        //[JsonPropertyName("room")]
        [Key]
        public Guid Id { get; set; }
        public string RoomNumber { get; set; }
        public string Subject { get; set; }
        public string TeacherName { get; set; }
        public Note Note { get; set; }
    }
}
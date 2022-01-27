using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.API.Domain.Models
{
    public class Lesson
    {
        [Key]
        public Guid Id { get; set; }
        public long LessonNumber { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
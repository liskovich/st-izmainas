using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.API.Domain.Entities
{
    public class TeacherScheduleItem
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        // string
        public int Lesson { get; set; }
        
        [Required]
        public int Day { get; set; }
        
        [Required]
        public string TeacherName { get; set; }
        
        [Required]
        public string Class { get; set; }
    }
}
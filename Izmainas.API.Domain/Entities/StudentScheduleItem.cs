using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Izmainas.API.Domain.Entities
{
    public class StudentScheduleItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]        
        // string
        public string Lesson { get; set; }
        
        [Required]
        public int Day { get; set; }
        
        [Required]
        public string Class { get; set; }
        
        [Required]
        public string Subject { get; set; }
    }
}
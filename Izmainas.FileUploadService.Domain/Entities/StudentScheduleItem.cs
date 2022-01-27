using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.FileUploadService.Domain.Entities
{
    public class StudentScheduleItem
    {
        [Key]
        public int Id { get; set; }

        [Required]        
        public string Lesson { get; set; }
        
        [Required]
        public int Day { get; set; }
        
        [Required]
        public string Class { get; set; }
        
        [Required]
        public string Subject { get; set; }
    }
}
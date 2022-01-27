using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Izmainas.API.Domain.Entities
{
    public class Note
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public string NoteText { get; set; }
        
        [Required]
        public long CreatedDate { get; set; }
        
        [Required]
        public int Lesson { get; set; }

        [Required]
        public string Class { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.API.Domain.Models
{
    public class Note
    {
        [Key]
        public Guid NoteId { get; set; }
        public string NoteText { get; set; }
        public long CreatedDate { get; set; }
    }
}
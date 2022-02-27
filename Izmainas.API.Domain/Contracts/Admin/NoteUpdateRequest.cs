using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izmainas.API.Domain.Contracts.Admin
{
    public class NoteUpdateRequest
    {
        [Required]
        public string NoteText { get; set; }

        [Required]
        public int Lesson { get; set; }

        [Required]
        public string Class { get; set; }

        [Required]
        public long CreatedDate { get; set; }
    }
}

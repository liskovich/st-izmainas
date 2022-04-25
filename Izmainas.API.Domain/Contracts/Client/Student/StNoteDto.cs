using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.API.Domain.Contracts.Client.Student
{
    public class StNoteDto
    {
        public Guid NoteId { get; set; }
        public string NoteText { get; set; }
        public long CreatedDate { get; set; }
    }
}
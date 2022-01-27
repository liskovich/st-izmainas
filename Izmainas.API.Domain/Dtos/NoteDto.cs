using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.API.Domain.Dtos
{
    // TODO: add CreatedDate and ID
    public record NoteDto(string NoteText, int Lesson, string Class);
}
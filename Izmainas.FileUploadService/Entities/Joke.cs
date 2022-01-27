using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.FileUploadService.Entities
{
    public record Joke(int Id, string Type, string Setup, string Punchline);
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.API.Domain.Dtos
{
    public class Data
    {
        public Guid Id { get; set; }
        public string DayOfWeek { get; set; }
        public long Date { get; set; }
        public List<ClassDto> Classes { get; set; }
    }
}
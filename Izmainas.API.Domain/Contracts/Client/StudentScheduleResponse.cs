using Izmainas.API.Domain.Contracts.Client.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.API.Domain.Contracts.Client
{
    public class StudentScheduleResponse
    {
        public Guid Id { get; set; }
        public string DayOfWeek { get; set; }
        public long Date { get; set; }
        public List<StClassDto> Classes { get; set; }
    }
}
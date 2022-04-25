using Izmainas.API.Domain.Contracts.Client.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izmainas.API.Domain.Contracts.Client
{
    public class TeacherScheduleResponse
    {
        public Guid Id { get; set; }
        public long Date { get; set; }
        public string DayOfWeek { get; set; }
        public List<TcTeacherDto> Teachers { get; set; }
    }
}

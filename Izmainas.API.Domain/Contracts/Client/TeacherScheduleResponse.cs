using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izmainas.API.Domain.Contracts.Client.Teacher
{
    public class TeacherScheduleResponse
    {
        public Datas Datas { get; set; }
    }

    public class Datas
    {
        public Guid Id { get; set; }
        public long Date { get; set; }
        public string DayOfWeek { get; set; }
        public List<TcTeacherDto> Teachers { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Izmainas.API.Domain.Entities;

namespace Izmainas.API.Domain.Services
{
    public interface IScheduleImportRepository
    {
        Task<IEnumerable<StudentScheduleItem>> GetStudentSchedule([Optional] int day);
        Task<IEnumerable<TeacherScheduleItem>> GetTeacherSchedule([Optional] int day);
        Task PopulateStudentSchedule(IEnumerable<StudentScheduleItem> items);
        Task PopulateTeacherSchedule(IEnumerable<TeacherScheduleItem> items);
        Task ClearStudentSchedules();
        Task ClearTeacherSchedules();
    }
}
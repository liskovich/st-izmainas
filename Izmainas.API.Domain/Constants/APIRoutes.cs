using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.API.Domain.Constants
{
    public class APIRoutes
    {
        public static class ScheduleImportRoutes
        {
            public const string StudentSchedule = "/student-schedule/{day:int}";
            public const string TeacherSchedule = "/teacher-schedule/{day:int}";
            public const string StudentScheduleImport = "/student-schedule";
            public const string TeacherScheduleImport = "/teacher-schedule";
        }
    }
}
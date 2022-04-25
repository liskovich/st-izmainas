using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izmainas.FileUploadService.Domain.Constants
{
    public static class ServerOptions
    {
        public const string BaseAddress = "https://localhost:5001/api/";
        public const string StudentsEndpoint = "ScheduleImport/studentSchedule";
        public const string TeachersEndpoint = "ScheduleImport/teacherSchedule";
    }
}

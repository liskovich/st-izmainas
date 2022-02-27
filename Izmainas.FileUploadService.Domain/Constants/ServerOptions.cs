using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izmainas.FileUploadService.Domain.Constants
{
    public static class ServerOptions
    {
        public const string BaseAddress = "https://localhost:5001/";
        public const string StudentsEndpoint = "studentSchedule";
        public const string TeachersEndpoint = "teacherSchedule";
    }
}

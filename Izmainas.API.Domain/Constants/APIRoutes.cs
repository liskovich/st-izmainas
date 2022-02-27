namespace Izmainas.API.Domain.Constants
{
    /// <summary>
    /// Endpoints for API access
    /// </summary>
    public class APIRoutes
    {
        /// <summary>
        /// API endpoints for schedule import
        /// </summary>
        public static class ScheduleImportRoutes
        {
            public const string StudentSchedule = "studentSchedule/{day:int}";
            public const string TeacherSchedule = "teacherSchedule/{day:int}";
            public const string StudentScheduleImport = "studentSchedule";
            public const string TeacherScheduleImport = "teacherSchedule";
        }
    }
}
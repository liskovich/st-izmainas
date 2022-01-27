using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.FileUploadService.Domain.Constants
{
    public class LogMessages
    {
        // TODO: review log file location
        public static string BuildLogFileLocation()
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = $@"{appData}\IzmainasLocal";
            return $@"{path}\LogFile.txt";
        }

        public static class ErrorMessages
        {
            public const string GeneralError = "An error occured";
            public const string FailedToStartService = "Failed To Start Service";
        }

        public static class InfoMessages
        {
            public const string GeneralInfo = "Service is up and running";
            public const string StartingService = "Starting The Service";
        }
    }
}
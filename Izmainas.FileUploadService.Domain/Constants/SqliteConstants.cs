using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.FileUploadService.Domain.Constants
{
    public class SqliteConstants
    {
        // TODO: review DB location
        public static string BuildConnectionString()
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = $@"{appData}\IzmainasLocal";
            return $@"Data Source={path}\IzmainasLocal.db;";
        }
    }
}
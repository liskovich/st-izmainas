using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Izmainas.FileUploadService.Domain.Exceptions
{
    public class NetworkException : Exception
    {
        public NetworkException()
        {
        }

        public NetworkException(string message = "Failed to post data") : base(message)
        {
        }
    }
}

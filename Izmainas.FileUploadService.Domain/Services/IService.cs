using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.FileUploadService.Domain.Services
{
    public interface IService<T, S> 
        where T : class
        where S : class
    {
        Task SendAllTAsync(List<T> items);
        Task SendAllSAsync(List<S> items);
    }
}
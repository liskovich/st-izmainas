using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Izmainas.FileUploadService.Domain.Services
{
    public interface IRepository<T, S> 
        where T : class
        where S : class
    {
        Task<List<T>> GetAllTAsync();
        Task<List<S>> GetAllSAsync();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Izmainas.API.Domain.Services
{
    public interface IService<T> where T : class
    {
        Task<T> GetAsync(long date);
    }
}

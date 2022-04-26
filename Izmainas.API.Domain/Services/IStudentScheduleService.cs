using Izmainas.API.Domain.Contracts.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izmainas.API.Domain.Services
{
    public interface IStudentScheduleService : IService<StudentScheduleResponse>
    {
        Task<StudentScheduleResponse> GetFullAsync(long date);
    }
}

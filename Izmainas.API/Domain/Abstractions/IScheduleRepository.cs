using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Izmainas.API.Domain.Abstractions;
using Izmainas.API.Domain.Models;

namespace Izmainas.API.Domain.Abstractions
{
    public interface IScheduleRepository : IRepository<Schedule>
    {
        Task<Schedule> GetByDate(DateTime date);
    }
}
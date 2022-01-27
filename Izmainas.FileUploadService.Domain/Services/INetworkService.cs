using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Izmainas.FileUploadService.Domain.Dtos;

namespace Izmainas.FileUploadService.Domain.Services
{
    public interface INetworkService : IService<TeacherScheduleDto, StudentScheduleDto>
    {
    }
}
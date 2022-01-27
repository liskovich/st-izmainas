using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Izmainas.FileUploadService.Data;
using Izmainas.FileUploadService.Domain.Dtos;
using Izmainas.FileUploadService.Domain.Services;

namespace Izmainas.FileUploadService.Services
{
    public class NetworkService : INetworkService
    {
        private readonly AppDbContext _context;

        public NetworkService(AppDbContext context)
        {
            _context = context;
        }

        public async Task SendAllSAsync(List<StudentScheduleDto> items)
        {
            throw new NotImplementedException();
        }

        public async Task SendAllTAsync(List<TeacherScheduleDto> items)
        {
            throw new NotImplementedException();
        }
    }
}
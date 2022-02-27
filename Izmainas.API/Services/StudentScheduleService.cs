using Izmainas.API.Domain.Contracts.Client;
using Izmainas.API.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Izmainas.API.Services
{
    public class StudentScheduleService : IStudentScheduleService
    {
        private readonly IScheduleImportRepository _scheduleImportRepository;
        private readonly INotesRepository _notesRepository;

        public StudentScheduleService(
            IScheduleImportRepository scheduleImportRepository, 
            INotesRepository notesRepository)
        {
            _scheduleImportRepository = scheduleImportRepository;
            _notesRepository = notesRepository;
        }

        public Task<StudentScheduleResponse> GetAsync(long date)
        {
            // TODO: implement this service
            throw new NotImplementedException();
        }
    }
}

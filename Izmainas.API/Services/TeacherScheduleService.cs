using Izmainas.API.Domain.Contracts.Client;
using Izmainas.API.Domain.Services;
using System;
using System.Threading.Tasks;

namespace Izmainas.API.Services
{
    public class TeacherScheduleService : ITeacherScheduleService
    {
        private readonly IScheduleImportRepository _scheduleImportRepository;
        private readonly INotesRepository _notesRepository;

        public TeacherScheduleService(
            IScheduleImportRepository scheduleImportRepository, 
            INotesRepository notesRepository)
        {
            _scheduleImportRepository = scheduleImportRepository;
            _notesRepository = notesRepository;
        }

        public Task<TeacherScheduleResponse> GetAsync(long date)
        {
            // TODO: implement this service
            throw new NotImplementedException();
        }
    }
}

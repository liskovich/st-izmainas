using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Izmainas.API.Domain.Entities;

namespace Izmainas.API.Domain.Services
{
    public interface INotesRepository : IRepository<Note>
    {
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<Note>> GetAllNotesByDateAsync(long date);
    }
}
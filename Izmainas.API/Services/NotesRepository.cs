using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Izmainas.API.Data;
using Izmainas.API.Domain.Entities;
using Izmainas.API.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Izmainas.API.Services
{
    public class NotesRepository : INotesRepository
    {
        private readonly AppDbContext _context;

        public NotesRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Delete(Note item)
        {
            _context.Notes.Remove(item);
        }

        public async Task<IEnumerable<Note>> GetAllAsync()
        {
            return await _context.Notes.ToListAsync();
        }

        public async Task<Note> GetAsync(Guid id)
        {
            return await _context.Notes.FindAsync(id);
        }

        public async Task InsertAsync(Note item)
        {
            await _context.Notes.AddAsync(item);
        }

        // TODO: call save on db calls
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public void Update(Note item)
        {
            _context.Update(item);
        }
    }
}
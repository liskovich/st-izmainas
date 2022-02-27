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
    /// <summary>
    /// Internal service used to operate with Notes in persistance level
    /// </summary>
    public class NotesRepository : INotesRepository
    {
        private readonly AppDbContext _context;

        public NotesRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method used for deleting specified note
        /// </summary>
        /// <param name="item">Identifier for note lookup</param>
        public void Delete(Note item)
        {
            _context.Notes.Remove(item);
        }

        /// <summary>
        /// Method used for getting all notes from database
        /// </summary>
        /// <returns>List of notes</returns>
        public async Task<IEnumerable<Note>> GetAllAsync()
        {
            return await _context.Notes.ToListAsync();
        }

        /// <summary>
        /// Method used for getting notes based on date from database
        /// </summary>
        /// <param name="date">Identifier for note lookup by date</param>
        /// <returns>List of notes</returns>
        public async Task<IEnumerable<Note>> GetAllNotesByDateAsync(long date)
        {
            return await _context.Notes.Where(n => n.CreatedDate == date).ToListAsync();
        }

        /// <summary>
        /// Method used for getting a specific note based from database
        /// </summary>
        /// <param name="id">Identifier for note lookup</param>
        /// <returns>A single note</returns>
        public async Task<Note> GetAsync(Guid id)
        {
            return await _context.Notes.FindAsync(id);
        }

        /// <summary>
        /// Method used for inserting a note into database
        /// </summary>
        /// <param name="item">Note data to insert</param>
        public async Task InsertAsync(Note item)
        {
            await _context.Notes.AddAsync(item);
        }

        /// <summary>
        /// Save changes made to database
        /// </summary>
        /// <returns>Operation result (bool)</returns>
        /// <remarks>It is necessary to call this method on all operations that mutate data</remarks>
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        /// <summary>
        /// Method used for updating specified note
        /// </summary>
        /// <param name="item">Identifier for note lookup</param>
        public void Update(Note item)
        {
            _context.Update(item);
        }
    }
}
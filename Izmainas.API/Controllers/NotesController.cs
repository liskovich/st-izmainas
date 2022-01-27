using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Izmainas.API.Domain.Dtos;
using Izmainas.API.Domain.Entities;
using Izmainas.API.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Izmainas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        // TODO: refactor notes repostiory and note dto
        private readonly INotesRepository _notesRepository;

        public NotesController(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<NoteDto>>> GetAllNotesAsync()
        {
            var items = await _notesRepository.GetAllAsync();
            // TODO: automapper mapping
            var result = new List<NoteDto>();
            foreach (var item in items)
            {
                var note = new NoteDto(item.NoteText, item.Lesson, item.Class);
                result.Add(note);
            }
            return Ok(result);
        }

        [HttpGet("{id}", Name = nameof(GetNoteByIdAync))]
        public async Task<ActionResult<NoteDto>> GetNoteByIdAync(Guid id)
        {
            var item = await _notesRepository.GetAsync(id);
            if (item is not null)
            {
                var result = new NoteDto(item.NoteText, item.Lesson, item.Class);
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<NoteDto>> InsertNoteAsync(NoteDto newNote)
        {
            var item = new Note()
            {
                Id = Guid.NewGuid(),
                NoteText = newNote.NoteText,
                Lesson = newNote.Lesson,
                Class = newNote.Class,
                CreatedDate = DateTimeOffset.Now.ToUnixTimeSeconds()
            };
            await _notesRepository.InsertAsync(item);
            await _notesRepository.SaveChangesAsync();

            // TODO: replace with correct dto
            return CreatedAtAction(nameof(GetNoteByIdAync), new { Id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNoteAsync(NoteDto note, Guid id)
        {
            var item = await _notesRepository.GetAsync(id);
            if (item is not null)
            {
                item.NoteText = note.NoteText;
                item.Lesson = item.Lesson;
                item.Class = item.Class;
                // TODO: replace with correct dto
                item.CreatedDate = DateTimeOffset.Now.ToUnixTimeSeconds();
                _notesRepository.Update(item);
                await _notesRepository.SaveChangesAsync();                
                
                return Ok("Successfuly updated");
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNoteAsync(Guid id)
        {
            var item = await _notesRepository.GetAsync(id);
            if (item is not null)
            {
                _notesRepository.Delete(item);
                await _notesRepository.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }
    }
}
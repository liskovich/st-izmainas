using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Izmainas.API.Domain.Constants;
using Izmainas.API.Domain.Contracts.Admin;
using Izmainas.API.Domain.Dtos;
using Izmainas.API.Domain.Entities;
using Izmainas.API.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Izmainas.API.Controllers
{
    /// <summary>
    /// API controller for Notes manipulation
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INotesRepository _notesRepository;
        private readonly IMapper _mapper;

        public NotesController(INotesRepository notesRepository, IMapper mapper)
        {
            _notesRepository = notesRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Method used for retrieving all notes from database
        /// </summary>
        /// <returns>Success response containing list of notes from database or failure status</returns>
        [HttpGet]
        public async Task<ActionResult<List<NoteDto>>> GetAllNotesAsync()
        {
            var items = await _notesRepository.GetAllAsync();

            var result = _mapper.Map<List<NoteDto>>(items);
            return Ok(result);
        }

        /// <summary>
        /// Method used for retrieving specific note from database 
        /// </summary>
        /// <param name="id">Identifier used for retreiving specific note</param>
        /// <returns>Success response containing specific note or not found error</returns>
        [HttpGet("{id}", Name = nameof(GetNoteByIdAync))]
        public async Task<ActionResult<NoteDto>> GetNoteByIdAync(Guid id)
        {
            var item = await _notesRepository.GetAsync(id);
            if (item is not null)
            {
                var result = _mapper.Map<NoteDto>(item);
                return Ok(result);
            }
            
            return NotFound(APIResponses.NotFoundResponse);
        }

        /// <summary>
        /// Method used for inserting new note into database
        /// </summary>
        /// <param name="newNote">Payload containing note information</param>
        /// <returns>Success response containing newly created note or failure status</returns>
        [HttpPost]
        public async Task<ActionResult<NoteDto>> InsertNoteAsync(NoteCreateRequest newNote)
        {
            var item = _mapper.Map<Note>(newNote);

            await _notesRepository.InsertAsync(item);
            await _notesRepository.SaveChangesAsync();

            var result = _mapper.Map<NoteDto>(item);
            return CreatedAtAction(nameof(GetNoteByIdAync), new { Id = result.Id }, result);
        }

        // TODO: fix update note method
        /// <summary>
        /// Method used for updating specific note information
        /// </summary>
        /// <param name="note">Payload containing new note information</param>
        /// <param name="id">Identifier used for retreiving specific note to update</param>
        /// <returns>Success message of update or not found error</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNoteAsync(NoteUpdateRequest note, Guid id)
        {
            var item = await _notesRepository.GetAsync(id);
            if (item is not null)
            {
                item = _mapper.Map<Note>(note);
                item.Id = id; //?

                _notesRepository.Update(item);
                await _notesRepository.SaveChangesAsync();                
                
                return Ok(APIResponses.UpdatedResponse);
            }
            return NotFound(APIResponses.NotFoundResponse);
        }

        /// <summary>
        /// Method used for deleting specific note from database
        /// </summary>
        /// <param name="id">Identifier used for deleting specific note from database</param>
        /// <returns>Success message of delete or not found error</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNoteAsync(Guid id)
        {
            var item = await _notesRepository.GetAsync(id);
            if (item is not null)
            {
                _notesRepository.Delete(item);
                await _notesRepository.SaveChangesAsync();
                return Ok(APIResponses.DeletedResponse);
            }
            return NotFound(APIResponses.NotFoundResponse);
        }
    }
}
using AutoMapper;
using Izmainas.API.Domain.Contracts.Admin;
using Izmainas.API.Domain.Dtos;
using Izmainas.API.Domain.Entities;
using Izmainas.API.Profiles.Resolvers;

namespace Izmainas.API.Profiles
{
    /// <summary>
    /// Structure used for mapping Note entities
    /// </summary>
    public class NotesProfile : Profile
    {        
        public NotesProfile()
        {
            // Map from NoteCreateRequest to Note
            CreateMap<NoteCreateRequest, Note>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom<DateTimeResolver>())
                .ForMember(dest => dest.Id, opt => opt.MapFrom<GuidResolver>());

            // Map from NoteUpdateRequest to Note
            CreateMap<NoteUpdateRequest, Note>();

            // Map from Note to NoteDto
            CreateMap<Note, NoteDto>();
        }
    }
}

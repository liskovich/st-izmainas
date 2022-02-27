using AutoMapper;
using Izmainas.API.Domain.Contracts.Admin;
using Izmainas.API.Domain.Dtos;
using Izmainas.API.Domain.Entities;
using Izmainas.API.Profiles.Resolvers;

namespace Izmainas.API.Profiles
{
    /// <summary>
    /// Structure used for mapping schedule import entities
    /// </summary>
    public class ScheduleImportProfile : Profile
    {
        public ScheduleImportProfile()
        {
            // Map from StudentScheduleCreateDto to StudentScheduleItem
            CreateMap<StudentScheduleCreateDto, StudentScheduleItem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom<GuidResolver>());

            // Map from TeacherScheduleCreateDto to TeacherScheduleItem
            CreateMap<TeacherScheduleCreateDto, TeacherScheduleItem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom<GuidResolver>());

            // Map from StudentScheduleItem to StudentScheduleDto
            CreateMap<StudentScheduleItem, StudentScheduleDto>();

            // Map from TeacherScheduleItem to TeacherScheduleDto
            CreateMap<TeacherScheduleItem, TeacherScheduleDto>();
        }
    }
}

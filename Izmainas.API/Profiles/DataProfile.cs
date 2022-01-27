using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Izmainas.API.Domain.Models;

namespace Izmainas.API.Profiles
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<Schedule, Izmainas.API.Domain.Dtos.Data>();
        }
    }
}
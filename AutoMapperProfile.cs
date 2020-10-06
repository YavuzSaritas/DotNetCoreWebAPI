using AutoMapper;
using DotNetCoreWebAPI.Dtos;
using DotNetCoreWebAPI.Models;

namespace DotNetCoreWebAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character,CharacterDto>();
        }
        
    }
}
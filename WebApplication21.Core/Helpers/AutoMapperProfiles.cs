using AutoMapper;
using WebApplication21.Api.DTOs;
using WebApplication21.Core.Entities;

namespace WebApplication21.Core.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterDto, User>();
            CreateMap<BookUpdateDto, Book>();
        }
    }
}

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
            CreateMap<BookReservationDto, BookReservation>();
            CreateMap<BookDto, Book>();

            CreateMap<BookReservation, BookReservationDto>();
            CreateMap<Book, BookDto>();
        }
    }
}

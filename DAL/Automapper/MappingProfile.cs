using AutoMapper;
using Core.DTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Books, BooksDTO>();
            CreateMap<BooksHistory, BooksHistoryDTO>();
            CreateMap<Genres, GenresDTO>();
            CreateMap<Roles, RolesDTO>();
            CreateMap<Users, UsersDTO>();
            CreateMap<RegisterDTO, Users>();
        }
    }
}

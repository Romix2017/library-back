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
            CreateMap<BooksDTO, Books>();
            CreateMap<BooksHistory, BooksHistoryDTO>();
            CreateMap<BooksHistoryDTO, BooksHistory>();
            CreateMap<Genres, GenresDTO>();
            CreateMap<GenresDTO, Genres>();
            CreateMap<Roles, RolesDTO>();
            CreateMap<RolesDTO, Roles>();
            CreateMap<Users, UsersDTO>();
            CreateMap<UsersDTO, Users>();
            CreateMap<RegisterDTO, Users>();
        }
    }
}

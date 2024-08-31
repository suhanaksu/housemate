using AutoMapper;
using Core.DTOs.User;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<UpdateUserDto, User>();
        }
    }
}

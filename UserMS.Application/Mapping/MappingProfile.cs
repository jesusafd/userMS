using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMS.Application.Dtos.User;
using UserMS.Domain.Entities.User;

namespace UserMS.Application.Mapping
{
    public class MappingProfile : Profile 
    {
        public MappingProfile() 
        {
            UserProfile();
        }

        private void UserProfile()
        {
            CreateMap<UserEntity, UserDto>().ReverseMap();
        }
    }
}

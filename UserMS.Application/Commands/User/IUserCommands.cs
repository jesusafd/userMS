using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMS.Application.Dtos.User;
using UserMS.Domain.Entities.User;

namespace UserMS.Application.Commands.User
{
    public interface IUserCommands
    {
        Task<UserDto> PostUser(UserDto user);
    }
}

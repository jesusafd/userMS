using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMS.Application.Dtos.User;

namespace UserMS.Application.Queries.User
{
    public interface IUserQueries
    {
        Task<UserDto> GetUserByEmail(string email); 
    }
}

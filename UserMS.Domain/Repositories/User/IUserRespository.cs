using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMS.Domain.Entities.User;

namespace UserMS.Domain.Repositories.User
{
    public interface IUserRespository
    {
        Task<UserEntity> GetUserByEmail(string mail);
        Task<UserEntity> PostUser(UserEntity user);
    }
}

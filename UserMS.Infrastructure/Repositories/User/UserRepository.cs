
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMS.Domain.Entities.User;
using UserMS.Domain.Repositories.User;
using UserMS.Infrastructure.Context;

namespace UserMS.Infrastructure.Repositories.User
{
    public class UserRepository : IUserRespository
    {
        private readonly ILogger<UserRepository> _logger;
        private readonly UserContext _userContext;
        
        public UserRepository(ILogger<UserRepository> logger, UserContext userContext)
        {
            _logger = logger;
            _userContext = userContext;
        }
        public Task<UserEntity> GetUserByEmail(string mail)
        {
            try
            {
                return _userContext.Users.FirstOrDefaultAsync(x => x.Mail == mail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                return null;
            }
        }

        public async Task<UserEntity> PostUser(UserEntity user)
        {
            try
            {
                _userContext.Users.Add(user);
                var rowInserted = _userContext.SaveChanges();
                return rowInserted > 0 ? user : null;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "");
                return null;
            }
        }
    }
}

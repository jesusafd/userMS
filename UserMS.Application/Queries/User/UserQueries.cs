using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMS.Application.Dtos.User;
using UserMS.Application.Mapping;
using UserMS.Domain.Repositories.User;

namespace UserMS.Application.Queries.User
{
    public class UserQueries : IUserQueries
    {
        private readonly IUserRespository _userRespository;
        private readonly ILogger<UserQueries> _logger;
        private readonly IMapper _mappingProfile;
        public UserQueries(
            ILogger<UserQueries> logger,
            IUserRespository userRespository,
            IMapper mappingProfile
            ) 
        {
            _logger = logger;
            _userRespository = userRespository;
            _mappingProfile = mappingProfile;
        }
        public async Task<UserDto> GetUserByEmail(string email)
        {
            try
            {
                var savedUser = _userRespository.GetUserByEmail(email);
                return savedUser != null ?
                    _mappingProfile.Map<UserDto>(savedUser) :
                    null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                return null;
            }
        }
    }
}

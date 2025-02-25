using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMS.Application.Dtos.User;
using UserMS.Application.Queries.User;
using UserMS.Domain.Entities.User;
using UserMS.Domain.Repositories.User;

namespace UserMS.Application.Commands.User
{
    public class UserCommands : IUserCommands
    {
        private readonly IUserRespository _userRespository;
        private readonly ILogger<UserCommands> _logger;
        private readonly IMapper _mappingProfile;
        public UserCommands(
            ILogger<UserCommands> logger,
            IUserRespository userRespository,
            IMapper mappingProfile
            )
        {
            _logger = logger;
            _userRespository = userRespository;
            _mappingProfile = mappingProfile;
        }
        public async Task<UserDto> PostUser(UserDto user)
        {
            try
            {
                var userEntity = _mappingProfile.Map<UserEntity>( user );
                var insertedUser = _userRespository.PostUser(userEntity).Result;
                return insertedUser != null ?
                    _mappingProfile.Map<UserDto>(insertedUser) :
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

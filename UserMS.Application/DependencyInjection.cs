using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMS.Application.Commands.User;
using UserMS.Application.Mapping;
using UserMS.Application.Queries.User;

namespace UserMS.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationService (this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IUserCommands,UserCommands> ();
            services.AddScoped<IUserQueries,UserQueries> ();
            return services;
        } 
    }
}

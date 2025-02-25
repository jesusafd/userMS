using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMS.Domain.Repositories.User;
using UserMS.Infrastructure.Context;
using UserMS.Infrastructure.Repositories.User;

namespace UserMS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["CONNECTIONSTRING"];
            services.AddDbContext<UserContext>(
                options =>
                options.UseSqlServer(connectionString)
            );
            services.AddScoped<IUserRespository, UserRepository>();
            return services;
        }
    }
}

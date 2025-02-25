using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMS.Domain.Entities.User;

namespace UserMS.Infrastructure.Context
{
    public class UserContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
    }
}

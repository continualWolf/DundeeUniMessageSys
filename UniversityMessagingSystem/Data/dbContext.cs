
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using UniversityMessagingSystem.Entities;

namespace UniversityMessagingSystem.Data
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> opt) : base(opt)
        {

        }

        public DbSet<User> user { get; set; }
    }
}

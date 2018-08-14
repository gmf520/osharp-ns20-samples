using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OSharp.Entity;

namespace OSharp.Samples.MultipleDbContexts.Entity
{
    public class MySqlDbContext : DbContextBase
    {
        public MySqlDbContext(DbContextOptions options, IEntityConfigurationTypeFinder typeFinder) : base(options, typeFinder)
        {
        }
    }
}

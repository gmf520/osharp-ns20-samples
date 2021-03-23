using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OSharp.Entity;

namespace OSharp.Samples.MultipleDbContexts.Entity
{
    public class SqlServerDbContext : DbContextBase
    {
        public SqlServerDbContext(DbContextOptions options, IServiceProvider serviceProvider) : base(options, serviceProvider)
        {
        }
    }
}
